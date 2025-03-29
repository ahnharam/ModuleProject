using PoleServerWithUI.Model;
using PoleServerWithUI.Utils;
using PoleServerWithUI.View;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading;
using System.Threading.Tasks;
using static System.Windows.Forms.AxHost;

namespace PoleServerWithUI.ViewModel
{
    internal class DeviceStateViewModel : BindableBase
    {
        private GateWayConnect _gateWayConnect;
        private int PolingTime;
        private int DeviceId;

        private List<Task> TaskList;

        #region Property

        private bool dbState = false;

        public bool DBState
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

        private DeviceGroupList deviceGroupList;

        public DeviceGroupList DeviceGroupList
        {
            get { return deviceGroupList; }
            set { SetProperty(ref deviceGroupList, value); }
        }

        private BatVInfoList batVInfoList;

        public BatVInfoList BatVInfoList
        {
            get { return batVInfoList; }
            set { SetProperty(ref batVInfoList, value); }
        }

        private PoleUIList poleUIList;

        public PoleUIList PoleUIList
        {
            get { return poleUIList; }
            set { SetProperty(ref poleUIList, value); }
        }

        private PoleLogList poleLogList;

        public PoleLogList PoleLogList
        {
            get { return poleLogList; }
            set { SetProperty(ref poleLogList, value); }
        }

        private ObservableCollection<string> unknownDevice;

        public ObservableCollection<string> UnknownDevice
        {
            get { return unknownDevice; }
            set { SetProperty(ref unknownDevice, value); }
        }

        private CancellationTokenSource gatewayCancellationTokenSource;

        public CancellationTokenSource GateWayCancellationTokenSource
        {
            get { return gatewayCancellationTokenSource; }
            set { SetProperty(ref gatewayCancellationTokenSource, value); }
        }

        private DeviceModel selectDeviceModel;
        public DeviceModel SelectDeviceModel
        {
            get { return selectDeviceModel; }
            set { SetProperty(ref selectDeviceModel, value); }
        }

        #endregion Property

        public DeviceStateViewModel()
        {
            DatabaseModel = new DatabaseModel
            {
                ServerIp = CacheManager.Instance.DBIP,
                ServerPort = CacheManager.Instance.DBPort,
                Database = CacheManager.Instance.DBName,

                Uid = CacheManager.Instance.DBID,
                Pwd = CacheManager.Instance.DBPW
            };

            PolingTime = Convert.ToInt32(CacheManager.Instance.PolingCycle);
            DeviceId = Convert.ToInt32(CacheManager.Instance.ServerID);

            DeviceGroupList = new DeviceGroupList();
            BatVInfoList = new BatVInfoList();
            PoleUIList = new PoleUIList();
            PoleLogList = new PoleLogList();

            UnknownDevice = new ObservableCollection<string>();

            TaskList = new List<Task>();
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
            // DB 데이터 입력 확인
            DatabaseConnect.Instance.Setup(DatabaseModel);
            bool databaseSettingCheck = DatabaseConnect.Instance.DatabaseSettingCheck();
            if (databaseSettingCheck == false) return;

            if (DatabaseConnect.Instance.Conn != null && DatabaseConnect.Instance.Conn.State != System.Data.ConnectionState.Closed)
            {
                // DB Connection이 열려있는 경우 Disconnect 실행
                DatabaseDisconnection();
                return;
            }
            else
            {
                // DB Connection이 열려있지 않은 경우 연결 세팅
                DatabaseConnection();
            }

            bool deviceCheck = DeviceSetting();
            if (deviceCheck == false) return;

            _gateWayConnect = new GateWayConnect(DBState, DeviceGroupList);
            _gateWayConnect.GatewayConnect(UnknownDevice);
        }

        public void DatabaseConnection()
        {

            DatabaseModel = new DatabaseModel
            {
                ServerIp = CacheManager.Instance.DBIP,
                ServerPort = CacheManager.Instance.DBPort,
                Database = CacheManager.Instance.DBName,

                Uid = CacheManager.Instance.DBID,
                Pwd = CacheManager.Instance.DBPW
            };

            PolingTime = Convert.ToInt32(CacheManager.Instance.PolingCycle);
            DeviceId = Convert.ToInt32(CacheManager.Instance.ServerID);

            // 연결 시도
            DBState = DatabaseConnect.Instance.Connect();
        }

        public void DatabaseDisconnection()
        {
            DBState = false;
            _gateWayConnect.ConnectedGateway = DBState;
            _gateWayConnect.GatewayDisconnect();
            DatabaseConnect.Instance.Disconnect();
            if (TaskList.Count != 0)
                TaskList.Clear();
            if (DeviceGroupList.Count != 0)
                DeviceGroupList.Clear();
        }

        public bool DeviceSetting()
        {
            // 데이터베이스의 device_info 테이블에 Master의 아이피를 통해 그룹핑을 하고 해당 그룹을 저장
            DeviceGroupList.SelectData(DeviceId);
            DeviceGroupList.dt = DatabaseConnect.Instance.Select(DeviceGroupList.dbMessage);
            DeviceGroupList.GetList(DeviceGroupList);

            if (DeviceGroupList.dt == null || DeviceGroupList.dt.Rows.Count == 0)
            {
                LogMessage.Instance.LogWriteView("등록된 디바이스를 찾을 수 없습니다.");
                LogMessage.Instance.LogWrite("DeviceGroupList is Empty");
                return false;
            }

            // 수정필요
            // 저장된 DeviceGroupList를 하나씩 추출
            foreach (var deviceGroup in DeviceGroupList)
            {
                DeviceList deviceList = new DeviceList();
                // DeviceGroup의 아이피와 같은 Device 검색
                deviceList.SelectData(DeviceId, deviceGroup.Ip);
                deviceList.dt = DatabaseConnect.Instance.Select(deviceList.dbMessage);
                DeviceList.GetList(deviceList);

                // 검색한 DeviceList를 DeviceGroup.Devices에 저장
                foreach (var device in deviceList)
                {
                    deviceGroup.Devices.Add(device);
                }
                LogMessage.Instance.LogWrite("DeviceGroupListName : " + deviceGroup.MasterName + ",  DeviceList Count : " + deviceList.dt.Rows.Count);
            }

            return true;
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
            _gateWayConnect.ConnectedGateway = GateWaySendData;
            if (!GateWaySendData)
            {
                GateWayCancellationTokenSource.Cancel();
                TaskList.Clear();
                return;
            }

            GateWayCancellationTokenSource = new CancellationTokenSource();

            Task gateway = _gateWayConnect.DataPolling(GateWayCancellationTokenSource.Token);
            Task queue = DataDequeueAndPush(GateWayCancellationTokenSource.Token);

            TaskList.Add(gateway);
            TaskList.Add(queue);
        }

        private async Task DataDequeueAndPush(CancellationToken cancellationToken)
        {
            await Task.Run(async () =>
            {
                while (!cancellationToken.IsCancellationRequested)
                {
                    await Task.Delay(PolingTime);

                    LogMessage.Instance.LogWrite("Queue Count : " + QueueManager.Instance.Count);

                    while (QueueManager.Instance.Count != 0)
                    {
                        LogMessage.Instance.LogWrite("DB Insert");

                        PoleLogModel poleLogModel = QueueManager.Instance.Dequeue();
                        PoleUIList.SelectData(poleLogModel.SNo);
                        PoleUIList.dt = DatabaseConnect.Instance.Select(PoleUIList.dbMessage);
                        PoleUIList.GetList(PoleUIList);

                        if (PoleUIList.Count == 0)
                        {
                            LogMessage.Instance.LogWrite("Can't find Slave No In PoleUI");
                            continue;
                        }

                        BatVInfoList.SelectData(poleLogModel.Battery);
                        BatVInfoList.dt = DatabaseConnect.Instance.Select(BatVInfoList.dbMessage);
                        BatVInfoList.GetOne(BatVInfoList, out BatVInfoModel batVInfoModel);

                        if (batVInfoModel != null)
                        {
                            PoleLogList.UpdateData(poleLogModel);
                            DatabaseConnect.Instance.InsertOrUpdate(PoleLogList.dbMessage);

                            PoleUIList.UpdateData(poleLogModel);
                            DatabaseConnect.Instance.InsertOrUpdate(PoleUIList.dbMessage);
                            PoleUIList.UpdateBattery(poleLogModel.SNo, batVInfoModel.Wattage, batVInfoModel.Percent);
                            DatabaseConnect.Instance.InsertOrUpdate(PoleUIList.dbMessage);

                            switch(poleLogModel.Screen)
                            {
                                case 1:
                                    PoleUIList.UpdatePhonePoleLog(poleLogModel.Genneration, "video_pole");
                                    DatabaseConnect.Instance.InsertOrUpdate(PoleUIList.dbMessage);
                                    break;
                                case 2:
                                    PoleUIList.UpdatePhonePoleLog(poleLogModel.Genneration, "cabon_pole");
                                    DatabaseConnect.Instance.InsertOrUpdate(PoleUIList.dbMessage);
                                    break;
                                case 3:
                                    PoleUIList.UpdatePhonePoleLog(poleLogModel.Genneration, "phone_pole");
                                    DatabaseConnect.Instance.InsertOrUpdate(PoleUIList.dbMessage);
                                    break;
                            }
                        }
                        else
                        {
                            // 장애처리
                            PoleUIList.UpdateBattery(poleLogModel.SNo, batVInfoModel.Wattage, batVInfoModel.Percent, 0);
                            DatabaseConnect.Instance.InsertOrUpdate(PoleUIList.dbMessage);
                            PoleUIList.UpdateReception(poleLogModel.SNo);
                            DatabaseConnect.Instance.InsertOrUpdate(PoleUIList.dbMessage);
                        }
                    }
                }
            }, cancellationToken);
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
            await Task.Run(() =>
            {
                AutoPolingStop = false;
                DeviceGroupModel deviceGroupModel = null;

                if (DeviceGroupList == null)
                {
                    LogMessage.Instance.LogWrite("등록된 Master가 존재하지 않습니다.");
                    return;
                }

                foreach (var deviceGroup in DeviceGroupList)
                {
                    if (SelectDevice.Equals(deviceGroup.Ip))
                        deviceGroupModel = deviceGroup;
                }

                if (deviceGroupModel == null)
                {
                    LogMessage.Instance.LogWrite("입력한 IP와 같은 Master가 존재하지 않습니다.");
                    return;
                }

                _gateWayConnect.DeviceGroupLoad(deviceGroupModel.Ip, SelectDeviceSendData);

                LogMessage.Instance.LogWrite("Queue Count : " + QueueManager.Instance.Count);

                while (QueueManager.Instance.Count != 0)
                {
                    LogMessage.Instance.LogWrite("DB Insert");
                    PoleLogModel poleLogModel = QueueManager.Instance.Dequeue();
                    PoleLogList.UpdateData(poleLogModel.SNo);
                    DatabaseConnect.Instance.InsertOrUpdate(PoleLogList.dbMessage);
                }

                AutoPolingStop = true;
            });
        }

        private DelegateCommand<object> _gridClickCommand;

        public DelegateCommand<object> GridClickCommand =>
            _gridClickCommand ?? (_gridClickCommand = new DelegateCommand<object>(ExecuteGridClickCommand));

        private void ExecuteGridClickCommand(object deviceModel)
        {
            // 여기에 클릭 처리 코드를 추가합니다.
            if (deviceModel == null) return;
            if (deviceModel is DeviceModel model)
            {
                SelectDeviceModel = model;
            }
        }

        private DelegateCommand<object> settingButton;

        public DelegateCommand<object> SettingButton
        {
            get
            {
                if (settingButton == null)
                    settingButton = new DelegateCommand<object>(Setting);
                return settingButton;
            }
        }

        private void Setting(object obj)
        {
            SettingView settingView = new SettingView();
            settingView.Width = 550;
            settingView.Height = 320;
            settingView.Show();
        }
    }
}