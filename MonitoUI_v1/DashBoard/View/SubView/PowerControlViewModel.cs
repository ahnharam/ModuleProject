using Prism.Commands;
using Prism.Events;
using Prism.Regions;
using Protocol.Database;
using Protocol.Database.DashBoard;
using Protocol.Enum;
using Protocol.Model.Dashboard;
using Protocol.ShareLib.Cache;
using Protocol.ShareLib.DashBoard;
using Protocol.ViewModel;
using Unity;

namespace DashBoard.View.SubView
{
    public class PowerControlViewModel : BaseViewModel
    {
        #region property

        private MnControlList mnControlList;

        public MnControlList MnControlList
        {
            get { return mnControlList; }
            set { SetProperty(ref mnControlList, value); }
        }

        private DeviceFunctionList deviceFunctionList;

        public DeviceFunctionList DeviceFunctionList
        {
            get { return deviceFunctionList; }
            set { SetProperty(ref deviceFunctionList, value); }
        }

        #endregion property

        public PowerControlViewModel(IEventAggregator ea, IRegionManager regionManager, IUnityContainer container) : base(ea, regionManager, container)
        {
            if (Cache.Instance.DefaultDashBoardNo != 0)
            {
                SettingDevice(Cache.Instance.DefaultDashBoardNo);

            }
        }

        #region event

        protected override void SubscribeEA()
        {
            _eventAggregator.GetEvent<DashBoardStationNoSelectPublisher>().Subscribe(SettingDevice);
        }

        protected override void UnsubscribeEA()
        {
            _eventAggregator.GetEvent<DashBoardStationNoSelectPublisher>().Unsubscribe(SettingDevice);
        }

        public void SettingDevice(int stationNo)
        {
            GetDeviceList(stationNo);
            GetDeviceFunctionList(stationNo);
            DeviceJoinFunction();
        }

        public void GetDeviceList(int stationNo)
        {
            string dbMessage = string.Empty;
            this.MnControlList = new MnControlList();

            dbMessage = DashBoardDBMessage.SelectDeviceListFromStationNo(stationNo, DashBoardEnum.DeviceType.Power);
            MnControlList.Dt = DatabaseConnect.Instance.Select(dbMessage);
            DashBoardDataConverter.DeviceList(MnControlList);
        }

        public void GetDeviceFunctionList(int stationNo)
        {
            string dbMessage = string.Empty;
            this.DeviceFunctionList = new DeviceFunctionList();

            dbMessage = DashBoardDBMessage.SelectDeviceFunctionList();
            DeviceFunctionList.Dt = DatabaseConnect.Instance.Select(dbMessage);
            DashBoardDataConverter.DeviceFunctionList(DeviceFunctionList);
        }

        public void DeviceJoinFunction()
        {
            if (MnControlList == null) return;

            foreach (var control in MnControlList)
            {
                control.DeviceFunctionList = new DeviceFunctionList();

                foreach (var function in DeviceFunctionList)
                {
                    if (control.Function == function.GroupNo)
                        control.DeviceFunctionList.Add(function);
                }

                control.GetDeviceFunction(control.DefaultValue);
            }
        }

        #endregion event

        DelegateCommand<object> mouseLeftButtonUpCommand;
        public DelegateCommand<object> MouseLeftButtonUpCommand
        {
            get
            {
                return mouseLeftButtonUpCommand ??
                    (mouseLeftButtonUpCommand = new DelegateCommand<object>(MouseLeftButtonUp));
            }
        }

        private void MouseLeftButtonUp(object obj)
        {
            // Message Send command
            if(obj is MnControlM)
            {
                var MnControlM = (MnControlM)obj;
                switch(MnControlM.DeviceFunction.FunctionValue)
                {
                    case 1:
                        MnControlM.Function = 2;
                        break;
                    case 2:
                        MnControlM.Function = 1;
                        break;
                }

                MnControlM.GetDeviceFunction(MnControlM.Function);
            }
        }
        
    }
}