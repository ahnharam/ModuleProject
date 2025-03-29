using DashBoard.Popup;
using Prism.Commands;
using Prism.Events;
using Prism.Regions;
using Protocol.Database;
using Protocol.Database.DashBoard;
using Protocol.Message;
using Protocol.Model.Dashboard;
using Protocol.ShareLib.Cache;
using Protocol.ShareLib.DashBoard;
using Protocol.ViewModel;
using System.Diagnostics;
using System.Windows;
using Unity;

namespace DashBoard.View
{
    public class BroadcastViewModel : BaseViewModel
    {
        #region Property

        private MnStationList stationList;

        public MnStationList StationList
        {
            get { return stationList; }
            set { SetProperty(ref stationList, value); }
        }

        private MnStationM selectStation;

        public MnStationM SelectStation
        {
            get { return selectStation; }
            set { SetProperty(ref selectStation, value); }
        }

        #endregion Property

        public BroadcastViewModel(IEventAggregator ea, IRegionManager regionManager, IUnityContainer container) : base(ea, regionManager, container)
        {
            if (Cache.Instance.DefaultDashBoardNo != 0)
            {
                SettingList(Cache.Instance.DefaultDashBoardNo);
            }
        }

        #region EA

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
            GetSelectStationGroupNo();
            GetSelectStationNo(stationNo);
        }

        #endregion EA

        private void GetSelectStationGroupNo()
        {
            string dbMessage = string.Empty;
            StationList = new MnStationList();

            dbMessage = DashBoardDBMessage.SelectStation();
            StationList.Dt = DatabaseConnect.Instance.Select(dbMessage);
            DashBoardDataConverter.GetStationList(StationList);
        }

        private void GetSelectStationNo(int stationNo)
        {
            if (SelectStation != null && stationNo == SelectStation.No) return;

            foreach (var station in StationList)
            {
                if (station.No == stationNo)
                    SelectStation = station;
            }
        }

        private DelegateCommand<object> micButtonCommand;

        public DelegateCommand<object> MicButtonCommand
        {
            get
            {
                return micButtonCommand ??
                    (micButtonCommand = new DelegateCommand<object>(MicButton));
            }
        }

        private void MicButton(object obj)
        {
            if (SelectStation == null)
            {
                Window error = new ErrorMessageBox("Error", "Station을 선택해주세요.");
                error.ShowDialog();
                return;
            }

            // Mic On command
            BroadcastPopupView broadcastWindow = new BroadcastPopupView(SelectStation.Name);
            broadcastWindow.Show();
        }
    }
}