using DashBoard.View.SubView;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
using Protocol.Database.DashBoard;
using Protocol.Database;
using Protocol.Model.Dashboard;
using Protocol.ShareLib.DashBoard;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;
using DashBoard.Model;
using Protocol.Enum;
using System.Runtime.Remoting.Messaging;
using System.Diagnostics;
using Protocol.ShareLib.Cache;
using Protocol.ViewModel;

namespace DashBoard.View
{
    public class OperationViewModel : BaseViewModel
    {

        #region Property

        private StoperateList stoperateList;
        public StoperateList StoperateList
        {
            get { return stoperateList; }
            set { SetProperty(ref stoperateList, value); }
        }

        private StoperateM stoperateM;
        public StoperateM StoperateM
        {
            get { return stoperateM; }
            set { SetProperty(ref stoperateM, value); }
        }

        private MnOperationList realTimeDeviceList;
        public MnOperationList RealTimeDeviceList
        {
            get { return realTimeDeviceList; }
            set { SetProperty(ref realTimeDeviceList, value); }
        }

        private ObservableCollection<ModuleStateView> realTimeSenserList;
        public ObservableCollection<ModuleStateView> RealTimeSenserList
        {
            get { return realTimeSenserList; }
            set { SetProperty(ref realTimeSenserList, value); }
        }
        #endregion

        public OperationViewModel(IEventAggregator ea, IRegionManager regionManager, IUnityContainer container) : base(ea, regionManager, container)
        {

            if(Cache.Instance.DefaultDashBoardNo != 0)
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

        private void SettingList(int stationNo)
        {
            Debug.WriteLine("DashBoardStationSelectPublisher / stationNo : " + stationNo);
            SettingTimeList(stationNo);
            SettingRealTimeDeviceList(stationNo);
        }
        #endregion

        #region method

        public void SettingTimeList(int stationNo)
        {
            string dbMessage = string.Empty;
            this.StoperateList = new StoperateList();

            dbMessage = DashBoardDBMessage.SelectTimeListFromStationNo(stationNo);
            StoperateList.Dt = DatabaseConnect.Instance.Select(dbMessage);
            DashBoardDataConverter.TimeList(StoperateList);

            try
            {
                StoperateM = StoperateList.Single(item => item.StationNo == stationNo);

            }catch(Exception e)
            {
                if(StoperateList != null && StoperateList.Count != 0)
                {
                    StoperateM = StoperateList.First();
                }
                Debug.WriteLine("Stoperate DefaultValue Can't Find : " + e.Message);
            }
        }

        public void SettingRealTimeDeviceList(int stationNo)
        {
            string dbMessage = string.Empty;
            this.RealTimeDeviceList = new MnOperationList();

            dbMessage = DashBoardDBMessage.SelectDeviceFunctionListFromDGroup(stationNo, DashBoardEnum.DeviceType.Control);
            RealTimeDeviceList.Dt = DatabaseConnect.Instance.Select(dbMessage);
            DashBoardDataConverter.RealTimeDeviceList(RealTimeDeviceList);
        }

        #endregion
    }
}
