using PoleServerWithUI.Model;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PoleServerWithUI.Utils
{
    internal class GateWayConnect : BindableBase
    {
        private TcpListener _server;
        private IPHostEntry IPHost;

        private bool _connectedGateway = false;

        public bool _ConnectedGateway
        {
            get { return _connectedGateway; }
            set { SetProperty(ref _connectedGateway, value); }
        }

        private int _polingTime;

        public int _PolingTime
        {
            get { return _polingTime; }
            set { SetProperty(ref _polingTime, value); }
        }

        private int _deviceDataReadTime;

        public int _DeviceDataReadTime
        {
            get { return _deviceDataReadTime; }
            set { SetProperty(ref _deviceDataReadTime, value); }
        }

        private int _deviceErrorCount;

        public int _DeviceErrorCount
        {
            get { return _deviceErrorCount; }
            set { SetProperty(ref _deviceErrorCount, value); }
        }

        private Queue<PoleLogModel> _poleLogData = new Queue<PoleLogModel>();

        public Queue<PoleLogModel> _PoleLogData
        {
            get { return _poleLogData; }
            set { SetProperty(ref _poleLogData, value); }
        }

        private ObservableCollection<DeviceGroupModel> deviceGroupModels;

        public ObservableCollection<DeviceGroupModel> DeviceGroupModels
        {
            get { return deviceGroupModels; }
            set { SetProperty(ref deviceGroupModels, value); }
        }

        private int _errorClientClose;

        public int _ErrorClientClose
        {
            get { return _errorClientClose; }
            set { SetProperty(ref _errorClientClose, value); }
        }

        private List<TcpClient> _tcpClients;

        public List<TcpClient> _TcpClients
        {
            get { return _tcpClients; }
            set { SetProperty(ref _tcpClients, value); }
        }

        public GateWayConnect()
        {
            _PolingTime = Convert.ToInt32(ConfigurationManager.AppSettings["POLINGTIME"]);
            _DeviceDataReadTime = Convert.ToInt32(ConfigurationManager.AppSettings["READTIMEOUT"]);
            _DeviceErrorCount = Convert.ToInt32(ConfigurationManager.AppSettings["ERRORCOUNT"]);
            _ErrorClientClose = Convert.ToInt32(ConfigurationManager.AppSettings["ErrorClientClose"]);
            //_DeviceDataReadTime = 100;
        }

        // Gateway 연결
        public async void GatewayConnect(ObservableCollection<DeviceModel> deviceModels, ObservableCollection<DeviceGroupModel> deviceGroupModels, ObservableCollection<string> unknownDevice)
        {
            DeviceGroupModels = deviceGroupModels;

            _TcpClients = new List<TcpClient>();
            const int bindPort = 502;       //device_info / port로 변경 할수 있도록 변경
            _server = null;
            try
            {
                _server = new TcpListener(IPAddress.Any, bindPort);

                _server.Start();

                LogMessage.Instance.LogWrite("서버 시작...");

                await Task.Run(() =>
                {
                    while (_ConnectedGateway)
                    {
                        TcpClient client = _server.AcceptTcpClient();

                        LogMessage.Instance.LogWrite(String.Format("클라이언트 접속: {0} ", ((IPEndPoint)client.Client.RemoteEndPoint).Address.ToString()));
                        if (unknownDevice.Contains(((IPEndPoint)client.Client.RemoteEndPoint).Address.ToString()) != true)
                        {
                            DispatcherService.Invoke((System.Action)(() =>
                            {
                                unknownDevice.Add(((IPEndPoint)client.Client.RemoteEndPoint).Address.ToString());
                            }));
                        }

                        _TcpClients.Add(client);

                        DeviceModel data = null;

                        foreach (var deviceGroupModel in DeviceGroupModels)
                        {
                            if (deviceGroupModel.Ip.Equals(((IPEndPoint)client.Client.RemoteEndPoint).Address.ToString()))
                            {
                                deviceGroupModel.Connected = true;
                            }
                        }

                        foreach (var device in deviceModels)
                        {
                            if (device.Ip.Equals(((IPEndPoint)client.Client.RemoteEndPoint).Address.ToString()))
                            {
                                device.Connected = true;
                                data = device;

                                LogMessage.Instance.DataLogWrite(String.Format("클라이언트 IP : {0}, Connection : {1}", data.Ip, data.Connected));

                                DispatcherService.Invoke((System.Action)(() =>
                                {
                                    unknownDevice.Remove(((IPEndPoint)client.Client.RemoteEndPoint).Address.ToString());
                                }));
                            }
                        }

                        Task.Delay(100);
                    }
                });
            }
            catch (Exception e)
            {
                LogMessage.Instance.LogWrite(String.Format("Connection Error : {0}", e));
            }
        }

        public void GatewayDisconnect()
        {
            try
            {
                foreach (var tcp in _TcpClients)
                {
                    tcp.Close();
                }
                _server.Stop();
            }
            catch (Exception e)
            {
                LogMessage.Instance.LogWrite(String.Format("Disconnect Error : {0}", e));
            }
        }

        public async void DataPolling()
        {
            await Task.Run(async () =>
            {
                while (_ConnectedGateway)

                //while (true)
                {
                    try
                    {
                        for (int i = 0; i < _TcpClients.Count; i++)
                        {
                            foreach (var deviceGroupModel in DeviceGroupModels)
                            {
                                if (_ConnectedGateway == false) return;

                                if (((IPEndPoint)_TcpClients[i].Client.RemoteEndPoint).Address.ToString() == deviceGroupModel.Ip)
                                {
                                    DeviceGroupLoad(deviceGroupModel.Devices, _TcpClients[i]);
                                }
                            }
                        }

                        //foreach (var client in _TcpClients)
                        //{
                        //    foreach(var deviceGroupModel in DeviceGroupModels)
                        //    {
                        //        if(((IPEndPoint)client.Client.RemoteEndPoint).Address.ToString() == deviceGroupModel.Ip)
                        //        {
                        //            DeviceGroupLoad(deviceGroupModel.Devices, client);
                        //        }
                        //    }
                        //}
                    }
                    catch (Exception e)
                    {
                        LogMessage.Instance.LogWrite("Data Read Error : " + e);
                    }

                    await Task.Delay(_PolingTime);
                }
            });
        }

        public void DeviceGroupLoad(ObservableCollection<DeviceModel> deviceModels, TcpClient client)
        {
            if (client == null) return;

            bool connected = client.Connected;

            if (connected == false)
            {
                foreach (var deviceGroupModel in DeviceGroupModels)
                {
                    if (deviceGroupModel.Ip == ((IPEndPoint)client.Client.RemoteEndPoint).Address.ToString())
                    {
                        deviceGroupModel.Connected = false;
                        foreach (var groupDevice in deviceGroupModel.Devices)
                        {
                            groupDevice.Connected = false;
                        }
                    }
                }
                client.Dispose();
                client.Close();
                _TcpClients.Remove(client);
            }

            if (deviceModels == null)
            {
                return;
            }

            foreach (var device in deviceModels)
            {
                if (_ConnectedGateway == false) return;

                if (connected == false)
                {
                    device.Connected = false;
                    continue;
                }

                if (device.Ip.Equals(((IPEndPoint)client.Client.RemoteEndPoint).Address.ToString()))
                {
                    DataLoad(device.TxData, device, client);

                    Thread.Sleep(2000);
                }
                else
                {
                    continue;
                }
            }
        }

        //public void DeviceGroupLoad(ObservableCollection<DeviceModel> deviceModels, string sendData, string selectIp)
        //{
        //    TcpClient client = null;
        //    foreach (var tcpClient in _TcpClients)
        //    {
        //        foreach (var deviceGroupModel in DeviceGroupModels)
        //        {
        //            if (tcpClient == null || tcpClient.Client == null) return;

        //            if (((IPEndPoint)tcpClient.Client.RemoteEndPoint).Address.ToString() == selectIp)
        //            {
        //                client = tcpClient;
        //            }
        //        }
        //    }

        //    if (client == null)
        //    {
        //        LogMessage.Instance.LogWrite(String.Format("연결된 Master가 없습니다."));
        //        return;
        //    }

        //    bool connected = client.Connected;

        //    if (connected == false)
        //    {
        //        foreach (var deviceGroupModel in DeviceGroupModels)
        //        {
        //            if (deviceGroupModel.Ip == ((IPEndPoint)client.Client.RemoteEndPoint).Address.ToString())
        //            {
        //                deviceGroupModel.Connected = false;
        //                foreach (var groupDevice in deviceGroupModel.Devices)
        //                {
        //                    groupDevice.Connected = false;
        //                }
        //            }
        //        }
        //        client.Close();
        //        _TcpClients.Remove(client);
        //    }

        //    if (deviceModels == null)
        //    {
        //        LogMessage.Instance.LogWrite(String.Format("연결된 Slave가 없습니다."));
        //        return;
        //    }

        //    foreach (var device in deviceModels)
        //    {
        //        if (connected == false)
        //        {
        //            device.Connected = false;
        //            continue;
        //        }

        //        if (device.Ip.Equals(((IPEndPoint)client.Client.RemoteEndPoint).Address.ToString()))
        //        {
        //            DataLoad(sendData, device, client);
        //        }
        //        else
        //        {
        //            continue;
        //        }
        //    }
        //}

        public void DeviceLoadDataOne(ObservableCollection<DeviceModel> deviceModels, string sendData, string selectIp)
        {
            try
            {
                TcpClient client = null;
                DeviceModel device = null;
                foreach (var tcpClient in _TcpClients)
                {
                    foreach (var deviceGroupModel in DeviceGroupModels)
                    {
                        if (tcpClient == null || tcpClient.Client == null) return;

                        if (((IPEndPoint)tcpClient.Client.RemoteEndPoint).Address.ToString() == selectIp)
                        {
                            client = tcpClient;
                            break;
                        }
                    }

                    if (client != null) break;
                }

                if (client == null || client.Connected == false)
                {
                    LogMessage.Instance.DataLogWrite(String.Format("수동 송신 불가 : Master Connection is false"));
                    return;
                }

                foreach (var deviceModel in deviceModels)
                {
                    if (deviceModel.Ip.Equals(((IPEndPoint)client.Client.RemoteEndPoint).Address.ToString()))
                    {
                        device = deviceModel;
                        break;
                    }
                }

                if (device == null)
                {
                    LogMessage.Instance.DataLogWrite(String.Format("수동 송신 불가 : Slave Connection is false"));
                    return;
                }

                DataLoad(sendData, device, client);
            }
            catch (Exception e)
            {
                LogMessage.Instance.LogWrite(String.Format("수동 송신 불가 : " + e));
            }
        }

        // Gateway 를 통한 데이터 로드
        public void DataLoad(string sendData, DeviceModel device, TcpClient client)
        {
            NetworkStream stream = null;

            try
            {
                if (client == null) return;

                if (client.Connected == false)
                {
                    LogMessage.Instance.LogWrite(String.Format("Connection Close Device : {0}", device.Sid));
                    return;
                }

                if (!device.Ip.Equals(((IPEndPoint)client.Client.RemoteEndPoint).Address.ToString()))
                {
                    Console.WriteLine("back");
                    return;
                }

                if (string.IsNullOrEmpty(sendData))
                    return;

                LogMessage.Instance.LogWrite(String.Format("connect device : {0}", device.Sid));
                LogMessage.Instance.LogWrite(String.Format("connect client : {0}", ((IPEndPoint)client.Client.RemoteEndPoint).Address.ToString()));

                stream = client.GetStream();

                byte[] msg = ConvertHexStringToByte(sendData.Trim().Replace(" ", ""));

                LogMessage.Instance.LogWrite(String.Format("Make message"));

                byte[] crcByte = ComputeCrc(msg);

                string crc = ByteToHex(crcByte);

                string complete = sendData + " " + crc;

                byte[] completeMsg = ConvertHexStringToByte(complete.Trim().Replace(" ", ""));

                LogMessage.Instance.LogWrite(String.Format("Make completeMsg"));

                //completeMsg = { 0x1B,};

                stream.Write(completeMsg, 0, completeMsg.Length);
                LogMessage.Instance.LogWrite(String.Format("송신 : {0}", complete));

                LogMessage.Instance.DataLogWrite(String.Format("송신 : {0}", complete));

                byte[] datas = new byte[1024];

                stream.ReadTimeout = _DeviceDataReadTime + _TcpClients.IndexOf(client) * 10;
                string responseData = "";
                string responseDatas = "";

                var Result = stream.Read(datas, 0, datas.Length);

                responseData = Encoding.Unicode.GetString(datas, 0, Result);
                byte[] arr = Encoding.Unicode.GetBytes(responseData);

                foreach (byte bytestr in arr)
                {
                    responseDatas += string.Format("{0:X2} ", bytestr);
                }

                // test
                //responseData = (string)Result;
                LogMessage.Instance.LogWrite(String.Format("수신 : {0}", responseDatas));

                LogMessage.Instance.DataLogWrite(String.Format("수신 : {0}", responseDatas));

                //if (responseData == "")
                //{
                //    device.Connected = false;
                //    client.Close();
                //    _TcpClients.Remove(client);
                //}

                device.ErrorCount = 0;
                device.Connected = true;
                DataSave(responseDatas, device);
            }
            catch (SocketException se)
            {
                if (se.SocketErrorCode == SocketError.TimedOut)
                {
                    LogMessage.Instance.LogWrite(String.Format("Error Device : {0}", device.Sid));
                    LogMessage.Instance.LogWrite(String.Format("Socket Read Time out : {0}", se.SocketErrorCode));
                }
                else
                {
                    LogMessage.Instance.LogWrite(String.Format("Error Device : {0}", device.Sid));
                    LogMessage.Instance.LogWrite(String.Format("Socket Error : {0}", se.SocketErrorCode));
                }
            }
            catch (InvalidOperationException)
            {
                if (client.Connected == false)
                {
                    foreach (var deviceGroupModel in DeviceGroupModels)
                    {
                        if (deviceGroupModel.Ip == ((IPEndPoint)client.Client.RemoteEndPoint).Address.ToString())
                        {
                            deviceGroupModel.Connected = false;
                            foreach (var groupDevice in deviceGroupModel.Devices)
                            {
                                groupDevice.Connected = false;
                            }
                        }
                    }

                    device.Connected = false;
                    client.Close();

                    if (_TcpClients.IndexOf(client) != -1)
                        _TcpClients.Remove(client);

                    LogMessage.Instance.LogWrite(String.Format("Error Device : {0}", device.Sid));
                    LogMessage.Instance.LogWrite(String.Format("Socket Close"));
                }
            }
            catch (Exception e)
            {
                LogMessage.Instance.LogWrite(String.Format("Error Device : {0}", device.Sid));
                LogMessage.Instance.LogWrite(String.Format("Data Error : {0}", e));

                bool check = DatabaseConnect.Instance.SelectPole(Convert.ToInt32(device.Sid));

                if (check)
                {
                    DatabaseConnect.Instance.InsertWirelessPlusPoleUI(device.Id, Convert.ToInt32(device.Sid), false);
                }

                device.ErrorCount++;

                if (device.ErrorCount >= _DeviceErrorCount)
                {
                    device.Connected = false;
                    device.ErrorCount = 0;

                    //if (_ErrorClientClose == 1)
                    //{
                    //    client.Dispose();
                    //    client.Close();

                    //    if (_TcpClients.IndexOf(client) != -1)
                    //        _TcpClients.Remove(client);
                    //}
                }
            }
        }

        public PoleLogModel DataSave(string responseData, DeviceModel deviceModel)
        {
            PoleLogModel poleLogModel = new PoleLogModel();
            bool crcCheck = false;
            int packetLength = 0;

            string[] datas = responseData.Split(' ');
            packetLength = Convert.ToInt32(datas[2], 16);

            LogMessage.Instance.LogWrite(String.Format("수신 Data Length : {0}", datas.Length));
            LogMessage.Instance.LogWrite(String.Format("패킷 Data Length : {0}", packetLength));

            // ex)
            if (datas.Length == 33)
            {
                //string crcCode = Convert.ToInt32(datas[29] + datas[30], 16).ToString();
                string crcCode = Convert.ToInt32(datas[30] + datas[29], 16).ToString(); //CRC LSB MSB 변경

                string data = string.Empty;

                for (int i = 0; i < datas.Length - 1; i++)
                {
                    data += datas[i];
                }

                byte[] msg = ConvertHexStringToByte(data);

                byte[] crcByte = ComputeCrc(msg);

                string crc = ByteToHex(crcByte);

                if (crc.Equals(crcCode))
                    crcCheck = true;
            }

            // 임시코드
            crcCheck = true;

            if (packetLength != 26)
                crcCheck = false;

            if (crcCheck)
            {
                try
                {
                    poleLogModel.No = deviceModel.No;
                    poleLogModel.MId = deviceModel.Id;
                    poleLogModel.Id = deviceModel.Sid;
                    poleLogModel.Screen = deviceModel.Screen;
                    poleLogModel.Poc = Convert.ToInt32(datas[4] + datas[3], 16).ToString();
                    poleLogModel.Potml = Convert.ToInt32(datas[6] + datas[5], 16).ToString();
                    poleLogModel.Potmh = Convert.ToInt32(datas[8] + datas[7], 16).ToString();
                    poleLogModel.Battery = Convert.ToInt32(datas[10] + datas[9], 16).ToString();
                    poleLogModel.Solar = Convert.ToInt32(datas[12] + datas[11], 16).ToString();
                    poleLogModel.Wind = Convert.ToInt32(datas[14] + datas[13], 16).ToString();
                    poleLogModel.Outbat = Convert.ToInt32(datas[16] + datas[15], 16).ToString();
                    poleLogModel.Outpowerfirst = Convert.ToInt32(datas[18] + datas[17], 16).ToString();
                    poleLogModel.Outpowersecond = Convert.ToInt32(datas[20] + datas[19], 16).ToString();
                    poleLogModel.Temp = (Convert.ToInt32(datas[22] + datas[21], 16) * 10).ToString();
                    poleLogModel.Outtemp = (Convert.ToInt32(datas[24] + datas[23], 16) * 10).ToString();
                    poleLogModel.Humi = Convert.ToInt32(datas[26] + datas[25], 16).ToString();
                    poleLogModel.Windspeed = Convert.ToInt32(datas[28] + datas[27], 16).ToString();
                    poleLogModel.Wireless = "36";
                    poleLogModel.Broken = "1";

                    _PoleLogData.Enqueue(poleLogModel);
                }
                catch (Exception e)
                {
                    LogMessage.Instance.LogWrite(String.Format("Converting Error : {0}", e));
                }
            }

            //
            //{
            //    foreach(var data in datas)
            //    {
            //        LogMessage.Instance.LogWrite(String.Format("Split Data : {0}", data));
            //    }
            //}

            return poleLogModel;
        }

        //public bool GatewayDisConnect()
        //{
        //    foreach(var tcp in _TcpClients)
        //    {
        //        tcp.Close();
        //    }
        //    return true;
        //}

        private byte[] StringToByte(string str)
        {
            byte[] StrByte = Encoding.UTF8.GetBytes(str);
            return StrByte;
        }

        private static ushort[] CrcTable = {
            0X0000, 0XC0C1, 0XC181, 0X0140, 0XC301, 0X03C0, 0X0280, 0XC241,
            0XC601, 0X06C0, 0X0780, 0XC741, 0X0500, 0XC5C1, 0XC481, 0X0440,
            0XCC01, 0X0CC0, 0X0D80, 0XCD41, 0X0F00, 0XCFC1, 0XCE81, 0X0E40,
            0X0A00, 0XCAC1, 0XCB81, 0X0B40, 0XC901, 0X09C0, 0X0880, 0XC841,
            0XD801, 0X18C0, 0X1980, 0XD941, 0X1B00, 0XDBC1, 0XDA81, 0X1A40,
            0X1E00, 0XDEC1, 0XDF81, 0X1F40, 0XDD01, 0X1DC0, 0X1C80, 0XDC41,
            0X1400, 0XD4C1, 0XD581, 0X1540, 0XD701, 0X17C0, 0X1680, 0XD641,
            0XD201, 0X12C0, 0X1380, 0XD341, 0X1100, 0XD1C1, 0XD081, 0X1040,
            0XF001, 0X30C0, 0X3180, 0XF141, 0X3300, 0XF3C1, 0XF281, 0X3240,
            0X3600, 0XF6C1, 0XF781, 0X3740, 0XF501, 0X35C0, 0X3480, 0XF441,
            0X3C00, 0XFCC1, 0XFD81, 0X3D40, 0XFF01, 0X3FC0, 0X3E80, 0XFE41,
            0XFA01, 0X3AC0, 0X3B80, 0XFB41, 0X3900, 0XF9C1, 0XF881, 0X3840,
            0X2800, 0XE8C1, 0XE981, 0X2940, 0XEB01, 0X2BC0, 0X2A80, 0XEA41,
            0XEE01, 0X2EC0, 0X2F80, 0XEF41, 0X2D00, 0XEDC1, 0XEC81, 0X2C40,
            0XE401, 0X24C0, 0X2580, 0XE541, 0X2700, 0XE7C1, 0XE681, 0X2640,
            0X2200, 0XE2C1, 0XE381, 0X2340, 0XE101, 0X21C0, 0X2080, 0XE041,
            0XA001, 0X60C0, 0X6180, 0XA141, 0X6300, 0XA3C1, 0XA281, 0X6240,
            0X6600, 0XA6C1, 0XA781, 0X6740, 0XA501, 0X65C0, 0X6480, 0XA441,
            0X6C00, 0XACC1, 0XAD81, 0X6D40, 0XAF01, 0X6FC0, 0X6E80, 0XAE41,
            0XAA01, 0X6AC0, 0X6B80, 0XAB41, 0X6900, 0XA9C1, 0XA881, 0X6840,
            0X7800, 0XB8C1, 0XB981, 0X7940, 0XBB01, 0X7BC0, 0X7A80, 0XBA41,
            0XBE01, 0X7EC0, 0X7F80, 0XBF41, 0X7D00, 0XBDC1, 0XBC81, 0X7C40,
            0XB401, 0X74C0, 0X7580, 0XB541, 0X7700, 0XB7C1, 0XB681, 0X7640,
            0X7200, 0XB2C1, 0XB381, 0X7340, 0XB101, 0X71C0, 0X7080, 0XB041,
            0X5000, 0X90C1, 0X9181, 0X5140, 0X9301, 0X53C0, 0X5280, 0X9241,
            0X9601, 0X56C0, 0X5780, 0X9741, 0X5500, 0X95C1, 0X9481, 0X5440,
            0X9C01, 0X5CC0, 0X5D80, 0X9D41, 0X5F00, 0X9FC1, 0X9E81, 0X5E40,
            0X5A00, 0X9AC1, 0X9B81, 0X5B40, 0X9901, 0X59C0, 0X5880, 0X9841,
            0X8801, 0X48C0, 0X4980, 0X8941, 0X4B00, 0X8BC1, 0X8A81, 0X4A40,
            0X4E00, 0X8EC1, 0X8F81, 0X4F40, 0X8D01, 0X4DC0, 0X4C80, 0X8C41,
            0X4400, 0X84C1, 0X8581, 0X4540, 0X8701, 0X47C0, 0X4680, 0X8641,
            0X8201, 0X42C0, 0X4380, 0X8341, 0X4100, 0X81C1, 0X8081, 0X4040 };

        public static byte[] ComputeCrc(byte[] data)    //UInt16
        {
            ushort crc = 0xFFFF;

            foreach (byte datum in data)
            {
                crc = (ushort)((crc >> 8) ^ CrcTable[(crc ^ datum) & 0xFF]);
            }

            return BitConverter.GetBytes(crc);
        }

        public static string ByteToHex(byte[] bytes)
        {
            string hex = BitConverter.ToString(bytes);
            return hex.Replace("-", " ");
        }

        public static byte[] ConvertHexStringToByte(string convertString)
        {
            byte[] convertArr = new byte[convertString.Length / 2];

            for (int i = 0; i < convertArr.Length; i++)
            {
                convertArr[i] = Convert.ToByte(convertString.Substring(i * 2, 2), 16);
            }
            return convertArr;
        }
    }
}