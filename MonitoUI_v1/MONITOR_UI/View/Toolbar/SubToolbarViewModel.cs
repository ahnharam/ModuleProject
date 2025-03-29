using Prism.Commands;
using Prism.Events;
using Prism.Regions;
using Protocol.Database;
using Protocol.Database.DashBoard;
using Protocol.Model.Dashboard;
using Protocol.ShareLib;
using Protocol.ShareLib.DashBoard;
using Protocol.ViewModel;
using System.Linq;
using System.Security;
using Unity;
using static Protocol.Enum.CommonEnum;

namespace MONITOR_UI.View
{
    internal class SubToolbarViewModel : BaseViewModel
    {
        #region property

        private string id = "test";

        public string Id
        {
            get { return id; }
            set { SetProperty(ref id, value); }
        }

        private SecureString pw;

        public SecureString Pw
        {
            get { return pw; }
            set { SetProperty(ref pw, value); }
        }

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

        private bool backEnabled;

        public bool BackEnabled
        {
            get { return backEnabled; }
            set { SetProperty(ref backEnabled, value); }
        }

        private int no;
        public int No
        {
            get { return no; }
            set { SetProperty(ref no, value); }
        }


        private bool nextEnabled;

        public bool NextEnabled
        {
            get { return nextEnabled; }
            set { SetProperty(ref nextEnabled, value); }
        }

        #endregion property

        public SubToolbarViewModel(IEventAggregator ea, IRegionManager regionManager, IUnityContainer container) : base(ea, regionManager, container)
        {
            BackEnabled = false;
            NextEnabled = false;
        }

        #region EA

        protected override void SubscribeEA()
        {
            _eventAggregator.GetEvent<DashBoardStationGroupSelectPublisher>().Subscribe(GetSelectStationGroupNo);
            _eventAggregator.GetEvent<DashBoardStationNoSelectPublisher>().Subscribe(GetSelectStationNo);
            _eventAggregator.GetEvent<DashBoardDefaultStationNoSelectPublisher>().Subscribe(GetSelectStationGroupNo);
        }

        protected override void UnsubscribeEA()
        {
            _eventAggregator.GetEvent<DashBoardStationGroupSelectPublisher>().Unsubscribe(GetSelectStationGroupNo);
            _eventAggregator.GetEvent<DashBoardStationNoSelectPublisher>().Unsubscribe(GetSelectStationNo);
            _eventAggregator.GetEvent<DashBoardDefaultStationNoSelectPublisher>().Unsubscribe(GetSelectStationGroupNo);
        }

        private void GetSelectStationGroupNo(int stationGroupNo)
        {
            StationList = new MnStationList();
            string dbMessage = string.Empty;

            dbMessage = DashBoardDBMessage.SelectStationWithGroupNo(stationGroupNo);
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

            if (StationList.First() == SelectStation) BackEnabled = false;
            else BackEnabled = true;

            if (StationList.Last() == SelectStation) NextEnabled = false;
            else NextEnabled = true;
        }

        #endregion EA

        private DelegateCommand<object> stationSelectedButtonCommand;

        public DelegateCommand<object> StationSelectedButtonCommand
        {
            get
            {
                return stationSelectedButtonCommand ??
                    (stationSelectedButtonCommand = new DelegateCommand<object>(StationSelectedButton));
            }
        }

        private void StationSelectedButton(object obj)
        {
            if (SelectStation != null)
            {
                _eventAggregator.GetEvent<DashBoardStationNoSelectPublisher>().Publish(SelectStation.No);
            }
        }

        private DelegateCommand<object> nextStationButtonCommand;

        public DelegateCommand<object> NextStationButtonCommand
        {
            get
            {
                return nextStationButtonCommand ??
                    (nextStationButtonCommand = new DelegateCommand<object>(NextStationButton));
            }
        }

        private void NextStationButton(object obj)
        {
            if (SelectStation == null) return;

            int stationNum = StationList.IndexOf(SelectStation);
            stationNum++;

            if (stationNum >= StationList.Count) return;

            SelectStation = StationList[stationNum];
            _eventAggregator.GetEvent<DashBoardStationNoSelectPublisher>().Publish(SelectStation.No);
        }

        private DelegateCommand<object> backStationButtonCommand;

        public DelegateCommand<object> BackStationButtonCommand
        {
            get
            {
                return backStationButtonCommand ??
                    (backStationButtonCommand = new DelegateCommand<object>(BackStationButton));
            }
        }

        private void BackStationButton(object obj)
        {
            if (SelectStation == null) return;

            int stationNum = StationList.IndexOf(SelectStation);
            stationNum--;

            if (stationNum < 0) return;

            SelectStation = StationList[stationNum];
            _eventAggregator.GetEvent<DashBoardStationNoSelectPublisher>().Publish(SelectStation.No);
        }

        private DelegateCommand<string> viewPanelChangeButtonCommand;

        public DelegateCommand<string> ViewPanelChangeButtonCommand
        {
            get
            {
                return viewPanelChangeButtonCommand ??
                    (viewPanelChangeButtonCommand = new DelegateCommand<string>(ViewPanelChangeButton));
            }
        }

        private void ViewPanelChangeButton(string panelName)
        {
            if (panelName == null) return;

            ViewPanel viewPanel;

            switch (panelName)
            {
                case "DASHBOARD":
                    viewPanel = ViewPanel.DASHBOARD;
                    break;

                case "GISMAP":
                    viewPanel = ViewPanel.GISMAP;
                    break;

                case "VIEWER":
                    viewPanel = ViewPanel.VIEWER;
                    break;

                case "FIND":
                    viewPanel = ViewPanel.FIND;
                    break;

                default:
                    return;
            }

            _eventAggregator.GetEvent<ViewPanelChangePublisher>().Publish(viewPanel);
        }
    }
}