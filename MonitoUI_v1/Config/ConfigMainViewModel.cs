
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
using Protocol.ViewModel;
using Protocol.Database;
using Protocol.Database.DashBoard;
using Protocol.Main;
using Protocol.Model.Dashboard;
using Protocol.ShareLib.DashBoard;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Unity;
using Config.View;
using Protocol.ShareLib.Config;
using Protocol.Message;
using System.Windows;
using System.Runtime.Remoting.Messaging;
using Protocol.Model.Common;

namespace Config
{
    public class ConfigMainViewModel : BaseViewModel
    {

        #region Property

        private int screenNo;
        public int ScreenNo
        {
            get { return screenNo; }
            set { SetProperty(ref screenNo, value); }
        }

        private UserControl settingView;
        public UserControl SettingView
        {
            get { return settingView; }
            set { SetProperty(ref settingView, value); }
        }

        private GroupList groupList;
        public GroupList GroupList
        {
            get { return groupList; }
            set { SetProperty(ref groupList, value); }
        }

        #endregion

        public ConfigMainViewModel(IEventAggregator ea, IRegionManager regionManager, IUnityContainer container) : base(ea, regionManager, container)
        {
        }

        protected override void Setup()
        {
            GroupList = new GroupList();

            SelectScreenList();
            SelectScreen(1);
        }

        public void SelectScreenList()
        {

            string dbMessage = string.Empty;
            dbMessage = DashBoardDBMessage.SelectAllGroup();
            GroupList.Dt = DatabaseConnect.Instance.Select(dbMessage);
            DashBoardDataConverter.GetGroupList(GroupList);
        }

        protected override void SubscribeEA()
        {
            _eventAggregator.GetEvent<SelectScreenNoPublisher>().Subscribe(SelectScreen);
        }

        protected override void UnsubscribeEA()
        {
            _eventAggregator.GetEvent<SelectScreenNoPublisher>().Unsubscribe(SelectScreen);
        }

        private void SelectScreen(int treeNo)
        {
            Debug.WriteLine("Config screenNo : " + treeNo);

            GroupM groupM = GroupList.Single(function => function.GroupNo == treeNo);

            int screenNo = groupM.ScreenNo;

            switch (screenNo)
            {
                case 1:
                    SettingView = new UserStateView(); 
                    break;

                case 2:
                    SettingView = new ClientTimeView();
                    break;

                case 12:
                    SettingView = new SmsSettingView();
                    break;

                case 13:
                    SettingView = new ServerManageView();
                    break;
                default:
                    Window error = new ErrorMessageBox("Error", "화면을 준비중입니다.");
                    error.ShowDialog();
                    Debug.WriteLine("구현되지 않은 화면");
                    break;
            }
        }
    }
}
