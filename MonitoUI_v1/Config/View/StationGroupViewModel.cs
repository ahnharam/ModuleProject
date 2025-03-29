using Prism.Commands;
using Prism.Events;
using Prism.Regions;
using Protocol.Database;
using Protocol.Database.DashBoard;
using Protocol.Enum;
using Protocol.Model.Common;
using Protocol.ShareLib.Config;
using Protocol.ShareLib.DashBoard;
using Protocol.ViewModel;
using Unity;

namespace Config.View
{
    public class StationGroupViewModel : BaseViewModel
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

        public GroupTreeItem OldSelecteditem
        {
            get { return oldSelectedItem; }
            set { SetProperty(ref oldSelectedItem, value); }
        }

        #endregion property

        public StationGroupViewModel(IEventAggregator ea, IRegionManager regionManager, IUnityContainer container) : base(ea, regionManager, container)
        {
            ScreenListSetting();
        }

        public void ScreenListSetting()
        {
            ScreenList = new GroupList();
            ScreenTree = new GroupTree();

            string dbMessage = string.Empty;
            dbMessage = DashBoardDBMessage.SelectAllGroup();
            ScreenList.Dt = DatabaseConnect.Instance.Select(dbMessage);
            DashBoardDataConverter.GetGroupList(ScreenList);

            foreach (var item in ScreenList)
            {
                if (item.HigherGroupNo == 0 && item.ScreenType == (int)CommonEnum.ViewPanel.CONFIG)
                {
                    ScreenTree.Add(new GroupTreeItem(item.GroupName, item.GroupNo, CommonEnum.GroupItemType.Group, true));
                }
            }

            foreach (var item in ScreenList)
            {
                foreach (var treeItem in ScreenTree)
                {
                    if (item.HigherGroupNo == treeItem.No && item.ScreenType == (int)CommonEnum.ViewPanel.CONFIG)
                    {
                        treeItem.AddItem(item.GroupName, item.GroupNo, CommonEnum.GroupItemType.Group);
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
                        if (item.HigherGroupNo == treeItem.No && item.ScreenType == (int)CommonEnum.ViewPanel.CONFIG)
                        {
                            treeItem.AddItem(item.GroupName, item.GroupNo, CommonEnum.GroupItemType.Group);
                        }
                    }

                    if (selectTreeItem.LoadItems == false)
                    {
                        if (OldSelecteditem != null)
                        {
                            OldSelecteditem.LoadItems = false;
                        }
                        selectTreeItem.LoadItems = true;
                        OldSelecteditem = selectTreeItem;
                        _eventAggregator.GetEvent<SelectScreenNoPublisher>().Publish(selectTreeItem.No);
                    }
                }
            }
        }

        #endregion event
    }
}