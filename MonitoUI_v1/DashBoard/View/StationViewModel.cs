using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
using Protocol.Database;
using Protocol.Database.DashBoard;
using Protocol.Enum;
using Protocol.Model.Common;
using Protocol.Model.Dashboard;
using Protocol.Model.Dashboard;
using Protocol.Popup;
using Protocol.ShareLib.Cache;
using Protocol.ShareLib.DashBoard;
using Protocol.ViewModel;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows;
using Unity;

namespace DashBoard.View
{
    public class StationViewModel : BaseViewModel
    {
        #region property

        private GroupList stationGroupList;

        public GroupList StationGroupList
        {
            get { return stationGroupList; }
            set { SetProperty(ref stationGroupList, value); }
        }

        private GroupTree stationGroupTree;

        public GroupTree StationGroupTree
        {
            get { return stationGroupTree; }
            set { SetProperty(ref stationGroupTree, value); }
        }

        private MnStationList stationList;

        public MnStationList StationList
        {
            get { return stationList; }
            set { SetProperty(ref stationList, value); }
        }

        private ObservableCollection<string> stationListToString;

        public ObservableCollection<string> StationListToString
        {
            get { return stationListToString; }
            set { SetProperty(ref stationListToString, value); }
        }

        private string selectStationOnComboBox;

        public string SelectStationOnComboBox
        {
            get { return selectStationOnComboBox; }
            set { SetProperty(ref selectStationOnComboBox, value); }
        }

        private GroupTreeItem selectedItem;

        public GroupTreeItem SelectedItem
        {
            get { return selectedItem; }
            set { SetProperty(ref selectedItem, value); }
        }

        private GroupTreeItem selectedGroup;

        public GroupTreeItem SelectedGroup
        {
            get { return selectedGroup; }
            set { SetProperty(ref selectedGroup, value); }
        }

        private bool stationSearchYN;

        public bool StationSearchYN
        {
            get { return stationSearchYN; }
            set { SetProperty(ref stationSearchYN, value); }
        }

        #endregion property

        public StationViewModel(IEventAggregator ea, IRegionManager regionManager, IUnityContainer container) : base(ea, regionManager, container)
        {
            StationSearchYN = false;

            StationListSetting();
        }
        #region method

        public void StationListSetting()
        {
            StationGroupList = new GroupList();
            StationGroupTree = new GroupTree();
            StationList = new MnStationList();
            StationListToString = new ObservableCollection<string>();

            string dbMessage = string.Empty;

            dbMessage = DashBoardDBMessage.SelectStationGroup();
            StationGroupList.Dt = DatabaseConnect.Instance.Select(dbMessage);
            DashBoardDataConverter.GetGroupList(StationGroupList);

            dbMessage = DashBoardDBMessage.SelectStation();
            StationList.Dt = DatabaseConnect.Instance.Select(dbMessage);
            DashBoardDataConverter.GetStationList(StationList);

            foreach (var item in StationGroupList)
            {
                if (item.Sort == (int)DashBoardEnum.GroupSort.Station)
                {
                    StationGroupTree.Add(new GroupTreeItem(item.GroupName, item.GroupNo, CommonEnum.GroupItemType.Group, true));
                }
            }

            SettingStationGroupTree(StationGroupTree);
            SelectStation();
        }

        public void SelectStation()
        {
            foreach (var item in StationList)
            {
                if (item.DefaultYN)
                {
                    Cache.Instance.DefaultDashBoardNo = item.No;
                    _eventAggregator.GetEvent<DashBoardDefaultStationNoSelectPublisher>().Publish(item.GroupNo);
                    _eventAggregator.GetEvent<DashBoardStationNoSelectPublisher>().Publish(item.No);
                }

                StationListToString.Add(item.Name);
            }
        }

        public void SettingStationGroupTree(ObservableCollection<GroupTreeItem> list)
        {
            foreach (var treeItem in list)
            {
                foreach (var item in StationGroupList)
                {
                    if (treeItem.GroupSort == CommonEnum.GroupItemType.Group && item.HigherGroupNo == treeItem.No)
                    {
                        treeItem.AddItem(item.GroupName, item.GroupNo, CommonEnum.GroupItemType.Group);
                    }
                }

                foreach (var station in StationList)
                {
                    if (treeItem.GroupSort == CommonEnum.GroupItemType.Group && station.GroupNo == treeItem.No)
                    {
                        treeItem.AddItem(station.Name, station.No, CommonEnum.GroupItemType.Item);
                    }
                }
            }
        }

        #endregion method

        #region EA

        protected override void SubscribeEA()
        {
            _eventAggregator.GetEvent<DashBoardStationNoSelectPublisher>().Subscribe(SelectStation);
        }

        protected override void UnsubscribeEA()
        {
            _eventAggregator.GetEvent<DashBoardStationNoSelectPublisher>().Unsubscribe(SelectStation);
        }

        private void SelectStation(int stationNo)
        {
            if (SelectedGroup == null || SelectedItem.No == stationNo)
            {
                return;
            }

            foreach (var item in SelectedGroup.Items)
            {
                if (item.No == stationNo)
                {
                    SelectedItem = item;
                    break;
                }
            }
        }

        #endregion EA

        #region event

        private DelegateCommand<object> stationTreeViewItemSelectedButtonCommand;

        public DelegateCommand<object> StationTreeViewItemSelectedButtonCommand
        {
            get
            {
                return stationTreeViewItemSelectedButtonCommand ??
                    (stationTreeViewItemSelectedButtonCommand = new DelegateCommand<object>(StationTreeViewItemSelectedButton));
            }
        }

        private void StationTreeViewItemSelectedButton(object obj)
        {
            if (obj is GroupTreeItem)
            {
                var selectTreeItem = obj as GroupTreeItem;
                if (SelectedItem != selectTreeItem && selectTreeItem.GroupSort == CommonEnum.GroupItemType.Item)
                {
                    SelectedItem = selectTreeItem;
                }
                else if (SelectedItem != selectTreeItem && selectTreeItem.GroupSort == CommonEnum.GroupItemType.Group)
                {
                    SelectedGroup = selectTreeItem;
                }
                else
                {
                    return;
                }

                if (selectTreeItem.LoadItems == false)
                {
                    SettingStationGroupTree(selectTreeItem.Items);
                    selectTreeItem.LoadItems = true;
                }

                if (selectTreeItem.GroupSort == CommonEnum.GroupItemType.Group)
                {
                    _eventAggregator.GetEvent<DashBoardStationGroupSelectPublisher>().Publish(selectTreeItem.No);
                    foreach (var item in selectTreeItem.Items)
                    {
                        if (item.GroupSort == CommonEnum.GroupItemType.Item)
                        {
                            SelectedItem = item;
                            _eventAggregator.GetEvent<DashBoardStationNoSelectPublisher>().Publish(SelectedItem.No);
                            break;
                        }
                    }
                }
                else
                {
                    _eventAggregator.GetEvent<DashBoardStationNoSelectPublisher>().Publish(SelectedItem.No);
                }
            }
        }

        private DelegateCommand<object> stationSelectedComboBoxCommand;

        public DelegateCommand<object> StationSelectedComboBoxCommand
        {
            get
            {
                return stationSelectedComboBoxCommand ??
                    (stationSelectedComboBoxCommand = new DelegateCommand<object>(StationSelectedComboBox));
            }
        }

        private void StationSelectedComboBox(object obj)
        {
            Debug.WriteLine("selectionChanged");
            foreach (var item in StationList)
            {
                if (item.Name == obj.ToString())
                {
                    _eventAggregator.GetEvent<DashBoardStationNoSelectPublisher>().Publish(item.No);
                }
            }
        }

        private DelegateCommand<string> stationSelectedComboBoxCommand2;

        public DelegateCommand<string> StationSelectedComboBoxCommand2
        {
            get
            {
                return stationSelectedComboBoxCommand2 ??
                    (stationSelectedComboBoxCommand2 = new DelegateCommand<string>(StationSelectedComboBox2));
            }
        }

        private void StationSelectedComboBox2(string obj)
        {
            Debug.WriteLine("selectionChanged");
            foreach (var item in StationList)
            {
                if (item.Name == obj)
                {
                    _eventAggregator.GetEvent<DashBoardStationNoSelectPublisher>().Publish(item.No);
                }
            }
        }

        private DelegateCommand<object> stationDoubleClickButtonCommand;

        public DelegateCommand<object> StationDoubleClickButtonCommand
        {
            get
            {
                return stationDoubleClickButtonCommand ??
                    (stationDoubleClickButtonCommand = new DelegateCommand<object>(StationDoubleClickButton));
            }
        }

        private void StationDoubleClickButton(object obj)
        {
            System.Console.WriteLine("Test double click");

            // 이벤트 확인
            // 카메라 팝업 표출

            Window cameraPopup = new CameraPopup();
            cameraPopup.Show();
                
        }



        private DelegateCommand<object> searchStationButtonCommand;

        public DelegateCommand<object> SearchStationButtonCommand
        {
            get
            {
                return searchStationButtonCommand ??
                    (searchStationButtonCommand = new DelegateCommand<object>(SearchStationButton));
            }
        }

        private void SearchStationButton(object obj)
        {
            StationSearchYN = !StationSearchYN;
        }

        #endregion event
    }
}