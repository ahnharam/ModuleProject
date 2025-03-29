using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
using Protocol.Database.DashBoard;
using Protocol.Database;
using Protocol.Enum;
using Protocol.Message;
using Protocol.Model.Dashboard;
using Protocol.ShareLib;
using Protocol.ShareLib.DashBoard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Unity;
using Protocol.ShareLib.Cache;
using Protocol.ViewModel;
using System.Diagnostics;

namespace DashBoard.View.SubView
{
    public class ControlViewModel : BaseViewModel
    {
        #region property
        private string airType;
        public string AirType
        {
            get { return airType; }
            set { SetProperty(ref airType, value); }
        }

        private string airTemp;
        public string AirTemp
        {
            get { return airTemp; }
            set { SetProperty(ref airTemp, value); }
        }

        private string airWindType;
        public string AirWindType
        {
            get { return airWindType; }
            set { SetProperty(ref airWindType, value); }
        }

        private string message;
        public string Message
        {
            get { return message; }
            set { SetProperty(ref message, value); }
        }

        private string[] door;
        public string[] Door
        {
            get { return door; }
            set { SetProperty(ref door, value); }
        }

        private MnControlList mnControlList;
        public MnControlList MnControlList
        {
            get { return mnControlList; }
            set { SetProperty(ref mnControlList, value); }
        }

        #endregion

        public ControlViewModel(IEventAggregator ea, IRegionManager regionManager, IUnityContainer container) : base(ea, regionManager, container)
        {

            if (Cache.Instance.DefaultDashBoardNo != 0)
            {
                SettingList(Cache.Instance.DefaultDashBoardNo);
            }
        }
        #region event
        protected override void SubscribeEA()
        {
            _eventAggregator.GetEvent<DashBoardStationNoSelectPublisher>().Subscribe(SettingList);
        }
        protected override void UnsubscribeEA()
        {
            _eventAggregator.GetEvent<DashBoardStationNoSelectPublisher>().Unsubscribe(SettingList);
        }

        public void SettingList(int stationNo)
        {
            GetDeviceList(stationNo);
            GetDeviceFunctionList();
        }

        public void GetDeviceList(int stationNo)
        {
            string dbMessage = string.Empty;
            MnControlList = new MnControlList();

            dbMessage = DashBoardDBMessage.SelectDeviceListFromStationNo(stationNo, DashBoardEnum.DeviceType.Control);
            MnControlList.Dt = DatabaseConnect.Instance.Select(dbMessage);
            DashBoardDataConverter.DeviceList(MnControlList);
        }

        public void GetDeviceFunctionList()
        {
            foreach(var mnControlM in MnControlList)
            {
                string dbMessage = string.Empty;
                DeviceFunctionList DeviceFunctionList = new DeviceFunctionList();

                dbMessage = DashBoardDBMessage.SelectDeviceFunctionListFromGroupNo(mnControlM.Function);
                DeviceFunctionList.Dt = DatabaseConnect.Instance.Select(dbMessage);
                DashBoardDataConverter.DeviceFunctionList(DeviceFunctionList);

                mnControlM.DeviceFunctionList = DeviceFunctionList;

                try
                {
                    mnControlM.DeviceFunction = DeviceFunctionList.Single(function => function.FunctionValue == mnControlM.DefaultValue);
                }
                catch(Exception e)
                {
                    if(DeviceFunctionList != null && DeviceFunctionList.Count != 0)
                    {
                        mnControlM.DeviceFunction = DeviceFunctionList.First();
                    }
                    Debug.WriteLine("mnControlM DefaultValue Can't Find : " + e.Message);
                }
            }
        }
        #endregion

        DelegateCommand<object> messageSendCommand;
        public DelegateCommand<object> MessageSendCommand
        {
            get
            {
                return messageSendCommand ??
                    (messageSendCommand = new DelegateCommand<object>(MessageSend));
            }
        }

        private void MessageSend(object obj)
        {
            // Message Send command
        }
    }
}
