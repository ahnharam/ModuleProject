using Prism.Commands;
using Prism.Events;
using Prism.Regions;
using Protocol.Database;
using Protocol.Database.DashBoard;
using Protocol.Model.Common;
using Protocol.ShareLib.DashBoard;
using Protocol.ViewModel;
using Unity;
using static Protocol.Enum.CommonEnum;
using static Protocol.Enum.DashBoardEnum;

namespace DashBoard.View
{
    public class ScreenViewModel : BaseViewModel
    {
        #region property

        private GroupList screenList;

        public GroupList ScreenList
        {
            get { return screenList; }
            set { SetProperty(ref screenList, value); }
        }

        private GroupTree screenTree;

        public GroupTree ScreenTree
        {
            get { return screenTree; }
            set { SetProperty(ref screenTree, value); }
        }

        private GroupTreeItem oldSelectedItem;

        public GroupTreeItem OldSelectedItem
        {
            get { return oldSelectedItem; }
            set { SetProperty(ref oldSelectedItem, value); }
        }

        #endregion property

        public ScreenViewModel(IEventAggregator ea, IRegionManager regionManager, IUnityContainer container) : base(ea, regionManager, container)
        {
            ScreenListSetting();
        }

        public void ScreenListSetting()
        {
            ScreenList = new GroupList();
            ScreenTree = new GroupTree();

            //string dbMessage = string.Empty;
            //dbMessage = DashBoardDBMessage.SelectGroup(GroupSort.Screen);
            //ScreenList.Dt = DatabaseConnect.Instance.Select(dbMessage);
            //DashBoardDataConverter.GetGroupList(ScreenList);

            ScreenList = new GroupList();
            ScreenTree = new GroupTree();

            string dbMessage = string.Empty;
            dbMessage = DashBoardDBMessage.SelectAllGroup();
            ScreenList.Dt = DatabaseConnect.Instance.Select(dbMessage);
            DashBoardDataConverter.GetGroupList(ScreenList);

            foreach (var item in ScreenList)
            {
                if (item.HigherGroupNo == 0 && item.Sort == (int)GroupSort.Screen)
                {
                    ScreenTree.Add(new GroupTreeItem(item.GroupName, item.GroupNo, GroupItemType.Group, true));
                }
            }

            foreach (var item in ScreenList)
            {
                foreach (var treeItem in ScreenTree)
                {
                    if (item.HigherGroupNo == treeItem.No && item.Sort == (int)GroupSort.Screen)
                    {
                        treeItem.AddItem(item.GroupName, item.GroupNo, GroupItemType.Group);
                    }
                }
            }
        }

        #region event

        private DelegateCommand<object> screenTreeViewItemSelectedButtonCommand;

        public DelegateCommand<object> ScreenTreeViewItemSelectedButtonCommand
        {
            get
            {
                return screenTreeViewItemSelectedButtonCommand ??
                    (screenTreeViewItemSelectedButtonCommand = new DelegateCommand<object>(ScreenTreeViewItemSelectedButton));
            }
        }

        private void ScreenTreeViewItemSelectedButton(object obj)
        {
            if (obj is GroupTreeItem)
            {
                var selectTreeItem = obj as GroupTreeItem;

                if (selectTreeItem.LoadItems) return;

                foreach (var item in ScreenList)
                {
                    foreach (var treeItem in selectTreeItem.Items)
                    {
                        if (item.HigherGroupNo == treeItem.No && item.Sort == (int)GroupSort.Screen)
                        {
                            treeItem.AddItem(item.GroupName, item.GroupNo, GroupItemType.Group);
                        }
                    }

                    if (selectTreeItem.LoadItems == false)
                    {
                        if (OldSelectedItem != null)
                        {
                            OldSelectedItem.LoadItems = false;
                        }
                        selectTreeItem.LoadItems = true;
                        OldSelectedItem = selectTreeItem;
                        _eventAggregator.GetEvent<DashBoardScreenSelectPublisher>().Publish(selectTreeItem.No);
                    }
                }
            }
        }

        #endregion event
    }
}