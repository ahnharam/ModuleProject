using Org.BouncyCastle.Asn1.Ocsp;
using PoleServerWithUI.Model;
using Prism.Mvvm;
using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static PoleServerWithUI.Model.DeviceModel;

namespace PoleServerWithUI.Utils
{
    public class GateWayConnect : BindableBase
    {
        private const int BindPort = 502;

        private TcpListener _server;
        private readonly int PolingTime;
        private readonly int DeviceDataReadTime;
        private readonly int DeviceErrorCount;
        private readonly int ErrorClientClose;

        private ObservableCollection<TcpClient> tcpClients;

        public ObservableCollection<TcpClient> TcpClients
        {
            get { return tcpClients; }
            set { SetProperty(ref tcpClients, value); }
        }

        private DeviceGroupList DeviceGroupModels;

        private bool connectedGateway = false;

        public bool ConnectedGateway
        {
            get { return connectedGateway; }
            set { SetProperty(ref connectedGateway, value); }
        }

        public GateWayConnect(bool DBState, DeviceGroupList deviceGroupModels)
        {
            ConnectedGateway = DBState;
            DeviceGroupModels = deviceGroupModels;
            PolingTime = Convert.ToInt32(CacheManager.Instance.PolingCycle);
            DeviceDataReadTime = Convert.ToInt32(CacheManager.Instance.ReadTimeOut);
            DeviceErrorCount = Convert.ToInt32(CacheManager.Instance.ErrorCount);
            ErrorClientClose = Convert.ToInt32(CacheManager.Instance.SocketClose);
            //_DeviceDataReadTime = 100;
        }

        // Gateway 연결
        public async void GatewayConnect(ObservableCollection<string> unknownDevice)
        {
            TcpClients = new ObservableCollection<TcpClient>();

            try
            {
                _server = new TcpListener(IPAddress.Any, BindPort);
                _server.Start();
                LogMessage.Instance.LogWrite("서버 구동");

                await Task.Run(async () =>
                {
                    while (ConnectedGateway)
                    {
                        TcpClient client = _server.AcceptTcpClient();
                        string clientIp = ((IPEndPoint)client.Client.RemoteEndPoint).Address.ToString();

                        LogMessage.Instance.LogWriteView(string.Format("클라이언트 접속: {0} ", clientIp));
                        LogMessage.Instance.LogWrite(string.Format("클라이언트 접속: {0} ", clientIp));

                        bool unknown = UnknownCheck(unknownDevice, clientIp, client);
                        if (unknown == false) continue; 

                        ClientAdd(clientIp, client);

                        await Task.Delay(100);
                    }
                });
            }
            catch (Exception e)
            {
                LogMessage.Instance.LogWrite(string.Format("Connection Error : {0}", e));
            }
        }

        public bool UnknownCheck(ObservableCollection<string> unknownDevice, string clientIp, TcpClient client)
        {
            if (DeviceGroupModels.ToList().Select(device => device.Ip == clientIp).Count() == 0)
            {
                if (unknownDevice.Contains(clientIp) != true)
                    unknownDevice.Add(clientIp);


                LogMessage.Instance.LogWrite(string.Format("클라이언트 접속 해제: {0} ", clientIp));
                client.Close();
                return false;
            }

            return true;
        }

        public void ClientAdd(string clientIp, TcpClient client)
        {
            foreach (var deviceGroupModel in DeviceGroupModels)
            {
                if (deviceGroupModel.Ip.Equals(clientIp) == false) continue;

                deviceGroupModel.Connected = ConnectionState.Open;
                TcpClients.Add(client);
                LogMessage.Instance.LogWrite(string.Format("클라이언트 IP : {0}, Connected", clientIp));

                //foreach (var device in deviceGroupModel.Devices)
                //{
                //    device.Connected = true;
                //}
            }
        }

        public void GatewayDisconnect()
        {
            try
            {
                foreach (var tcp in TcpClients)
                {
                    tcp.Close();
                }
                _server.Stop();
            }
            catch (Exception e)
            {
                LogMessage.Instance.LogWrite(string.Format("Disconnect Error : {0}", e));
            }
        }

        public async Task DataPolling(CancellationToken cancellationToken)
        {
            // 토큰이 캔슬 되기 전까지 무한 루프
            await Task.Run(async () =>
            {
                while (!cancellationToken.IsCancellationRequested)
                {
                    try
                    {
                        // ToList()를 사용하여 컬렉션을 복사하고, 동기 처리 중에 컬렉션이 변경되는 것을 방지
                        LogMessage.Instance.LogWriteView(string.Format("접속중인 클라이언트 수 : {0} ", TcpClients.Count));
                        foreach (var client in TcpClients.ToList())
                        {
                            // 만약 클라이언트의 연결이 close 상태라면 continue를 통해 다음 클라이언트로 건너뜀
                            if (ClientConnectionCheck(client) == false) continue;

                            // client IP 와 일치하는 DeviceGroupModel 찾기
                            LogMessage.Instance.LogWriteView("Client IP: " + ((IPEndPoint)client.Client.RemoteEndPoint).Address.ToString());
                            var deviceGroupModel = DeviceGroupModels.ToList().FirstOrDefault(dgm => ((IPEndPoint)client.Client.RemoteEndPoint).Address.ToString() == dgm.Ip);

                            if (deviceGroupModel == null) continue;
                            if (deviceGroupModel.Devices == null) continue;

                            if (deviceGroupModel != null)
                            {
                                // 찾은 DeviceGroupModel을 통해 DeviceGroupLoad 메소드 실행
                                DeviceGroupLoad(deviceGroupModel, client);
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        LogMessage.Instance.LogWrite("Data Read Error: " + e);
                    }

                    // 동기 로드가 종료 될 시 기다리는 대기시간
                    await Task.Delay(PolingTime);
                }
            }, cancellationToken);
        }

        public bool ClientConnectionCheck(TcpClient client)
        {
            bool connected = client.Connected;

            // client의 연결이 종료 된 경우
            if (!connected)
            {
                string clientIP = ((IPEndPoint)client.Client.RemoteEndPoint).Address.ToString();

                // DeviceGroupModels 에서 클라이언트와 같은 IP 주소 검색
                var deviceGroupModel = DeviceGroupModels.FirstOrDefault(dgm => dgm.Ip == clientIP);
                if (deviceGroupModel != null)
                {
                    deviceGroupModel.Connected = ConnectionState.Closed;
                    foreach (var groupDevice in deviceGroupModel.Devices)
                    {
                        groupDevice.Connected = ConnectionState.Closed;
                    }
                }

                LogMessage.Instance.LogWrite(string.Format("Connection Closed Device : {0}", deviceGroupModel.MasterName));
                client.Dispose();
                client.Close();
                TcpClients.Remove(client);
            }

            return connected;
        }

        public void DeviceGroupLoad(DeviceGroupModel deviceGroupModel, TcpClient tcpClient)
        {
            bool clientConnect = false;

            foreach (var device in deviceGroupModel.Devices)
            {
                DataLoad(device, tcpClient, out string responseDatas);

                DataSave(responseDatas, device);

                if(device.Connected == ConnectionState.Connecting) clientConnect = true;

                if (deviceGroupModel.Connected == ConnectionState.Open && clientConnect == true)
                {
                    DeviceGroupConnectionState(deviceGroupModel, clientConnect);
                }
            }

            if (clientConnect == false)
            {
                DeviceGroupConnectionState(deviceGroupModel, clientConnect);
            }
        }

        public void DeviceGroupLoad(string selectIp, string sendData)
        {
            TcpClient client = null;
            foreach (var tcpClient in TcpClients)
            {
                if (tcpClient == null || tcpClient.Client == null) return;

                if (((IPEndPoint)tcpClient.Client.RemoteEndPoint).Address.ToString() == selectIp)
                {
                    client = tcpClient;
                }
            }

            if (client == null)
            {
                LogMessage.Instance.LogWrite(string.Format("연결된 Master가 없습니다."));
                return;
            }

            if (ClientConnectionCheck(client) == false) return;

            NetworkStream stream = client.GetStream();
            stream.ReadTimeout = DeviceDataReadTime;

            NetworkStreamWrite(sendData, stream);
            NetworkStreamWRead(stream);
        }

        public void DeviceGroupConnectionState(DeviceGroupModel deviceGroupModel, bool clientConnect)
        {
            if (deviceGroupModel.Connected == ConnectionState.Closed) return;

            if (clientConnect)
            {
                deviceGroupModel.Connected = ConnectionState.Connecting;
            }
            else
            {
                deviceGroupModel.Connected = ConnectionState.Open;
            }
        }

        // Gateway 를 통한 데이터 로드
        public void DataLoad(DeviceModel device, TcpClient client, out string completeResponseDatas)
        {
            completeResponseDatas = string.Empty;
            try
            {
                string sendData = device.TxData;

                LogMessage.Instance.LogWrite(string.Format("connect device : {0}", device.Sid));
                LogMessage.Instance.LogWrite(string.Format("connect client : {0}", ((IPEndPoint)client.Client.RemoteEndPoint).Address.ToString()));

                NetworkStream stream = client.GetStream();
                stream.ReadTimeout = DeviceDataReadTime;

                NetworkStreamWrite(sendData.Replace(" ", ""), stream);
                completeResponseDatas = NetworkStreamWRead(stream);

                device.ErrorCount = 0;
                device.Connected = ConnectionState.Connecting;
            }
            catch (Exception e)
            {
                LogMessage.Instance.LogWrite(string.Format("Error Device : {0}", device.Sid));
                LogMessage.Instance.LogWrite(string.Format("Error Message : {0}", e));

                PoleUIList poleUIList = new PoleUIList();
                poleUIList.SelectData(device.No);
                poleUIList.dt = DatabaseConnect.Instance.Select(poleUIList.dbMessage);

                if (poleUIList.dt.Rows.Count == 0)
                {
                    LogMessage.Instance.LogWrite(string.Format("{0} : poleUIList.dt.Rows.Count == 0", device.No));
                }
                else
                {
                    PoleUIList.GetList(poleUIList);

                    poleUIList.UpdateReception(device.No);
                    DatabaseConnect.Instance.InsertOrUpdate(poleUIList.dbMessage);
                }

                device.ErrorCount++;

                if (device.ErrorCount >= DeviceErrorCount)
                {
                    device.Connected = ConnectionState.Closed;
                    device.ErrorCount = 0;
                }

                completeResponseDatas = string.Empty;
            }
        }

        public void NetworkStreamWrite(string sendData, NetworkStream stream)
        {
            byte[] msg = Converter.ConvertHexStringToByte(sendData);
            string crc = Converter.ComputeCrc(msg);
            string complete = (sendData + crc).Replace(" ", "");
            byte[] completeMsg = Converter.ConvertHexStringToByte(complete);

            stream.Write(completeMsg, 0, completeMsg.Length);

            LogMessage.Instance.LogWrite(string.Format("송신 : {0}", complete));
            LogMessage.Instance.DataLogWrite(string.Format("송신 : {0}", complete));
        }

        public string NetworkStreamWRead(NetworkStream stream)
        {
            StringBuilder responseDatas = new StringBuilder();
            byte[] datas = new byte[1024];

            int result = stream.Read(datas, 0, datas.Length);
            Encoding.Unicode.GetString(datas, 0, result);

            foreach (byte bytestr in datas.Take(result))
            {
                responseDatas.AppendFormat("{0:X2} ", bytestr);
            }

            string completeResponseDatas = responseDatas.ToString();

            LogMessage.Instance.LogWrite(string.Format("수신 : {0}", completeResponseDatas.Replace(" ", "")));
            LogMessage.Instance.DataLogWrite(string.Format("수신 : {0}", completeResponseDatas.Replace(" ", "")));

            return completeResponseDatas;
        }

        public PoleLogModel DataSave(string responseData, DeviceModel deviceModel)
        {
            PoleLogModel poleLogModel = new PoleLogModel();
            bool crcCheck = false;
            if (responseData == null)
            {
                //poleLogModel.No = deviceModel.No;
                poleLogModel.SNo = deviceModel.No;
                poleLogModel.Mid = deviceModel.Id;
                poleLogModel.Id = deviceModel.Sid;
                poleLogModel.Screen = deviceModel.Screen;
                poleLogModel.TxData = deviceModel.TxData;
                poleLogModel.Poc = "0";
                poleLogModel.Potml = "0";
                poleLogModel.Potmh = "0";
                poleLogModel.Battery = "0";
                poleLogModel.Solar = "0";
                poleLogModel.Wind = "0";
                poleLogModel.Outbat = "0";
                poleLogModel.OutPowerFirst = "0";
                poleLogModel.OutPowerSecond = "0";
                poleLogModel.Temp = "0";
                poleLogModel.OutTemp = "0";
                poleLogModel.Humi = "0";
                poleLogModel.WindSpeed = "0";
                poleLogModel.WireLess = "0";
                poleLogModel.Broken = "0";
                poleLogModel.Genneration = 0;
                DeviceModelDataList.ConvertPolLog(deviceModel.DeviceDataList, poleLogModel);
            }
            else
            {
                string[] datas = responseData.Split(' ');
                CrcCheck(datas, ref crcCheck);
                //poleLogModel.No = deviceModel.No;
                poleLogModel.SNo = deviceModel.No;
                poleLogModel.Mid = deviceModel.Id;
                poleLogModel.Id = deviceModel.Sid;
                poleLogModel.Screen = deviceModel.Screen;
                poleLogModel.TxData = deviceModel.TxData;
                poleLogModel.Poc = Convert.ToInt32(datas[4] + datas[3], 16).ToString();
                poleLogModel.Potml = Convert.ToInt32(datas[6] + datas[5], 16).ToString();
                poleLogModel.Potmh = Convert.ToInt32(datas[8] + datas[7], 16).ToString();
                poleLogModel.Battery = Convert.ToInt32(datas[10] + datas[9], 16).ToString();
                poleLogModel.Solar = Convert.ToInt32(datas[12] + datas[11], 16).ToString();
                poleLogModel.Wind = Convert.ToInt32(datas[14] + datas[13], 16).ToString();
                poleLogModel.Outbat = Convert.ToInt32(datas[16] + datas[15], 16).ToString();
                poleLogModel.OutPowerFirst = Convert.ToInt32(datas[18] + datas[17], 16).ToString();
                poleLogModel.OutPowerSecond = Convert.ToInt32(datas[20] + datas[19], 16).ToString();
                poleLogModel.Temp = (Convert.ToInt32(datas[22] + datas[21], 16) * 10).ToString();
                poleLogModel.OutTemp = (Convert.ToInt32(datas[24] + datas[23], 16) * 10).ToString();
                poleLogModel.Humi = Convert.ToInt32(datas[26] + datas[25], 16).ToString();
                poleLogModel.WindSpeed = Convert.ToInt32(datas[28] + datas[27], 16).ToString();
                poleLogModel.WireLess = "36";
                poleLogModel.Broken = "1";
                poleLogModel.Genneration =
                    Convert.ToInt32(poleLogModel.Battery)
                    + Convert.ToInt32(poleLogModel.Solar)
                    + Convert.ToInt32(poleLogModel.Wind);

                QueueManager.Instance.Enqueue(poleLogModel);
                DeviceModelDataList.ConvertPolLog(deviceModel.DeviceDataList, poleLogModel);
            }

            return poleLogModel;
        }

        public bool CrcCheck(string[] datas, ref bool crcCheck)
        {
            int packetLength = Convert.ToInt32(datas[2], 16);
            LogMessage.Instance.LogWrite(string.Format("수신 Data Length : {0}", datas.Length));
            LogMessage.Instance.LogWrite(string.Format("패킷 Data Length : {0}", packetLength));

            // ex)
            if (datas.Length == 32)
            {
                string crcCode = "" + datas[30] + "" + datas[29];
                LogMessage.Instance.LogWrite(string.Format("CRC Data : {0}", crcCode));

                string data = string.Empty;

                for (int i = 0; i < datas.Length - 1; i++)
                {
                    data += datas[i];
                }

                byte[] msg = Converter.ConvertHexStringToByte(data.Replace(" ", ""));
                string crc = Converter.ComputeCrc(msg);
                LogMessage.Instance.LogWrite(string.Format("Get Data Make CRC : {0}", crc));

                if (crc.Equals(crcCode))
                    return crcCheck = true;
            }

            return crcCheck = true;
        } 
    }
}