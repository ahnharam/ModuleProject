using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PoleServerWithUI.Model;
using System.Collections.ObjectModel;
using Prism.Mvvm;
using PoleServerWithUI.Utils;
using Prism.Commands;
using System.Configuration;

namespace PoleServerWithUI.ViewModel
{
    class DeviceStateViewModel : BindableBase
    {
        private GateWayConnect _gateWayConnect;
        private int PolingTime;

        private bool dbState = false;
        public bool DbState
        {
            get { return dbState; }
            set { SetProperty(ref dbState, value); }
        }

        private bool gateWaySendData = false;
        public bool GateWaySendData
        {
            get { return gateWaySendData; }
            set { SetProperty(ref gateWaySendData, value); }
        }

        private bool autoPolingStop = true;
        public bool AutoPolingStop
        {
            get { return autoPolingStop; }
            set { SetProperty(ref autoPolingStop, value); }
        }

        private string selectDevice = "";
        public string SelectDevice
        {
            get { return selectDevice; }
            set { SetProperty(ref selectDevice, value); }
        }

        private string selectDeviceSendData = "";
        public string SelectDeviceSendData
        {
            get { return selectDeviceSendData; }
            set { SetProperty(ref selectDeviceSendData, value); }
        }

        private DatabaseModel databaseModel;
        public DatabaseModel DatabaseModel
        {
            get { return databaseModel; }
            set { SetProperty(ref databaseModel, value); }
        }

        private ObservableCollection<DeviceModel> devices;
        public ObservableCollection<DeviceModel> Devices
        {
            get { return devices; }
            set { SetProperty(ref devices, value); }
        }

        private ObservableCollection<DeviceGroupModel> deviceGroupModels;
        public ObservableCollection<DeviceGroupModel> DeviceGroupModels
        {
            get { return deviceGroupModels; }
            set { SetProperty(ref deviceGroupModels, value); }
        }


        private int deviceId;
        public int DeviceId
        {
            get { return deviceId; }
            set { SetProperty(ref deviceId, value); }
        }

        private ObservableCollection<string> unknownDevice;
        public ObservableCollection<string> UnknownDevice
        {
            get { return unknownDevice; }
            set { SetProperty(ref unknownDevice, value); }
        }


        public DeviceStateViewModel()
        {
            DatabaseModel = new DatabaseModel();

            //DatabaseModel.ServerIp = "192.168.50.2";
            //DatabaseModel.Database = "smart_pole";
            DatabaseModel.ServerIp = ConfigurationManager.AppSettings["DBIP"];
            DatabaseModel.ServerPort = ConfigurationManager.AppSettings["DBPORT"];
            DatabaseModel.Database = ConfigurationManager.AppSettings["DBNAME"];

            DatabaseModel.Uid = ConfigurationManager.AppSettings["DBID"];
            DatabaseModel.Pwd = ConfigurationManager.AppSettings["DBPW"];

            PolingTime = Convert.ToInt32(ConfigurationManager.AppSettings["POLINGTIME"]);
            DeviceId = Convert.ToInt32(ConfigurationManager.AppSettings["DEVICEID"]);

            _gateWayConnect = new GateWayConnect();
            
            DeviceGroupModels = new ObservableCollection<DeviceGroupModel>();
            UnknownDevice = new ObservableCollection<string>();
        }

        private DelegateCommand<object> databaseConnectButton;
        public DelegateCommand<object> DatabaseConnectButton
        {
            get
            {
                if (databaseConnectButton == null)
                    databaseConnectButton = new DelegateCommand<object>(DatabaseConnectAction);
                return databaseConnectButton;
            }
        }

        private void DatabaseConnectAction(object obj)
        {
            if(DatabaseModel.ServerIp == null
                || DatabaseModel.Database == null
                || DatabaseModel.Uid == null
                || DatabaseModel.Pwd == null)
            {

                LogMessage.Instance.LogWrite("DB 데이터 입력 필요");
                return;
            }

            if (DatabaseConnect.Instance.ConnectCheck())
            {
                DatabaseConnect.Instance.Disconnect();
                DbState = false;
                _gateWayConnect._ConnectedGateway = DbState;
                _gateWayConnect.GatewayDisconnect();
                DeviceGroupModels = new ObservableCollection<DeviceGroupModel>();
                return;
            }

            DbState = DatabaseConnect.Instance.ConnectDB(DatabaseModel);


            LogMessage.Instance.LogWrite("DB connect : " + DbState);
            Devices = DatabaseConnect.Instance.SelectDB(DeviceId);

            if (Devices == null)
            {

                LogMessage.Instance.LogWrite("Device is Empty");
                return;
            }
            else
            {
                foreach(var device in Devices)
                {
                    bool check = false;
                    if(DeviceGroupModels != null)
                    {
                        foreach(var deviceGroupModel in DeviceGroupModels)
                        {
                            if (deviceGroupModel.Ip == device.Ip)
                            {
                                check = true;
                                break;
                            }
                        }
                    }

                    if(check == false)
                    {
                        DeviceGroupModel deviceGroupModel = new DeviceGroupModel();
                        deviceGroupModel.Ip = device.Ip;
                        deviceGroupModel.Devices = new ObservableCollection<DeviceModel>();
                        DeviceGroupModels.Add(deviceGroupModel);
                    }
                }

                foreach (var device in Devices)
                {
                    foreach (var deviceGroupModel in DeviceGroupModels)
                    {
                        if (deviceGroupModel.Ip == device.Ip)
                            deviceGroupModel.Devices.Add(device);
                    }
                }
            }
            
            LogMessage.Instance.LogWrite("Device Count : " + Devices.Count);

            _gateWayConnect._ConnectedGateway = DbState;
            _gateWayConnect.GatewayConnect(Devices, DeviceGroupModels, UnknownDevice);
        }

        private DelegateCommand<object> gatewayConnectButton;
        public DelegateCommand<object> GatewayConnectButton
        {
            get
            {
                if (gatewayConnectButton == null)
                    gatewayConnectButton = new DelegateCommand<object>(GatewayConnect);
                return gatewayConnectButton;
            }
        }

        private void GatewayConnect(object obj)
        {
            AutoPolingStop = !GateWaySendData;
            if (GateWaySendData == false)
            {
                _gateWayConnect._ConnectedGateway = GateWaySendData;
                return;
            }
            _gateWayConnect._ConnectedGateway = GateWaySendData;

            _gateWayConnect.DataPolling();

            Task.Run(async () =>
            {
                while (GateWaySendData)
                {
                    await Task.Delay(PolingTime);

                    DispatcherService.Invoke((System.Action)(() =>
                    {
                        LogMessage.Instance.LogWrite("Queue Count : " + _gateWayConnect._PoleLogData.Count);
                    }));

                    while (_gateWayConnect._PoleLogData.Count != 0)
                    {
                        DispatcherService.Invoke((System.Action)(() =>
                        {
                            LogMessage.Instance.LogWrite("DB Insert");
                        }));

                        PoleLogModel poleLogModel = _gateWayConnect._PoleLogData.Dequeue();
                        
                        DatabaseConnect.Instance.InsertPoleLog(poleLogModel);
                        int[] data = DatabaseConnect.Instance.SelectBatVInfo(poleLogModel);

                        if(data != null)
                        {
                            DatabaseConnect.Instance.InsertPoleUI(Convert.ToInt32(poleLogModel.Id), data);
                        }
                        else
                        {
                            // 장애처리
                            DatabaseConnect.Instance.InsertPoleUI(Convert.ToInt32(poleLogModel.Id), data, 0);
                            DatabaseConnect.Instance.InsertWirelessPlusPoleUI(Convert.ToInt32(poleLogModel.Id), false);

                        }
                    }
                }
            });

            //Task.Run(async () =>
            //{
            //while (GateWaySendData)
            //{
            //    await Task.Delay(10000);

            //    DispatcherService.Invoke((System.Action)(() =>
            //    {
            //        LogMessage.Instance.LogWrite("Master Diconnection Queue Count : " + _gateWayConnect._PoleLogData.Count);
            //    }));

            //        while (_gateWayConnect._GatewayConnectionLogdata.Count != 0)
            //        {
            //            string masterIp = _gateWayConnect._GatewayConnectionLogdata.Dequeue();
            //            foreach(var deviceGroupModel in DeviceGroupModels)
            //            {
            //                if(masterIp == deviceGroupModel.Ip)
            //                {
            //                    deviceGroupModel.Connected = false;
            //                }
            //            }

            //        }
            //    }
            //});
        }

        private DelegateCommand<object> gatewaySendDataButton;
        public DelegateCommand<object> GatewaySendDataButton
        {
            get
            {
                if (gatewaySendDataButton == null)
                    gatewaySendDataButton = new DelegateCommand<object>(GatewaySendData);
                return gatewaySendDataButton;
            }
        }

        private async void GatewaySendData(object obj)
        {
            await Task.Run(async () =>
            {
                AutoPolingStop = false;
                DeviceGroupModel deviceGroupModel = null;

                if (DeviceGroupModels == null)
                {
                    LogMessage.Instance.LogWrite("등록된 Master가 존재하지 않습니다.");
                    return;
                }

                foreach (var deviceGroup in DeviceGroupModels)
                {
                    if (SelectDevice.Equals(deviceGroup.Ip))
                        deviceGroupModel = deviceGroup;
                }

                if (deviceGroupModel == null)
                {
                    DispatcherService.Invoke((System.Action)(() =>
                    {
                        LogMessage.Instance.LogWrite("입력한 IP와 같은 Master가 존재하지 않습니다.");
                    }));
                    return;
                }

                _gateWayConnect.DeviceGroupLoad(deviceGroupModel.Devices, SelectDeviceSendData, SelectDevice);


                DispatcherService.Invoke((System.Action)(() =>
                {
                    LogMessage.Instance.LogWrite("Queue Count : " + _gateWayConnect._PoleLogData.Count);
                }));

                while (_gateWayConnect._PoleLogData.Count != 0)
                {
                    DispatcherService.Invoke((System.Action)(() =>
                    {
                        LogMessage.Instance.LogWrite("DB Insert");
                    }));
                    DatabaseConnect.Instance.InsertPoleLog(_gateWayConnect._PoleLogData.Dequeue());
                }

                AutoPolingStop = true;
            });
        }

        public void UnLoaded()
        {
            //_gateWayConnect.GatewayDisConnect();
        }
    }
}
