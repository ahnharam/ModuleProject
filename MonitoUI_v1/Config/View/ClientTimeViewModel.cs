using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
using Protocol.Database.DashBoard;
using Protocol.Database;
using Protocol.Enum;
using Protocol.Model.Config;
using Protocol.Model.Dashboard;
using Protocol.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using Unity;
using Protocol.Database.Config;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Runtime.Remoting.Messaging;

namespace Config.View
{
    public class ClientTimeViewModel : BaseViewModel 
    {
        #region property
        private string gridImage;
        public string GridImage
        {
            get { return gridImage; }
            set { SetProperty(ref gridImage, value); }
        }

        private string userStateListCount;
        public string UserStateListCount
        {
            get { return userStateListCount; }
            set { SetProperty(ref userStateListCount, value); }
        }

        private UserStateModel userStateModel;
        public UserStateModel UserStateModel
        {
            get { return userStateModel; }
            set { SetProperty(ref userStateModel, value); }
        }

        private ObservableCollection<TopDataModel>  topDataModelList;
        public ObservableCollection<TopDataModel> TopDataModelList
        {
            get { return topDataModelList; }
            set { SetProperty(ref topDataModelList, value); }
        }

        private ObservableCollection<string> timeList;
        public ObservableCollection<string> TimeList
        {
            get { return timeList; }
            set { SetProperty(ref timeList, value); }
        }
        #endregion

        public ClientTimeViewModel(IEventAggregator ea, IRegionManager regionManager, IUnityContainer container) : base(ea, regionManager, container)
        {
            TopDataListSetting();
            UserStateSetting();
        }

        protected override void Setup()
        {
            TimeList = new ObservableCollection<string>();
            TopDataModelList = new ObservableCollection<TopDataModel>();

            TimeList.Add("test");
        }

        private void TopDataListSetting()
        {
            TopDataModel topDataModel = new TopDataModel
            {
                HeaderWidth = 80,
                ContentWidth = 120,
                HeaderName = "Station",
                ContentName = ""
            };

            TopDataModelList.Add(topDataModel);

            topDataModel = new TopDataModel
            {
                HeaderWidth = 80,
                ContentWidth = 120,
                HeaderName = "시작",
                ContentName = ""
            };


            TopDataModelList.Add(topDataModel);

            topDataModel = new TopDataModel
            {
                HeaderWidth = 80,
                ContentWidth = 120,
                HeaderName = "종료",
                ContentName = ""
            };


            TopDataModelList.Add(topDataModel);

        }

        private void UserStateSetting()
        {

            string dbMessage = string.Empty;
            this.UserStateModel = new UserStateModel();

            dbMessage = ConfigDBMessage.SelectUserState();
            UserStateModel.UserStateTable = DatabaseConnect.Instance.Select(dbMessage);
        }



        #region event
        DelegateCommand<object> buttonCommand;
        public DelegateCommand<object> ButtonCommand
        {
            get
            {
                return buttonCommand ??
                    (buttonCommand = new DelegateCommand<object>(Button));
            }
        }

        public void Button(object obj)
        {

        }

        #endregion
    }
}
