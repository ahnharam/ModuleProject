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
    public class ServerManageViewModel : BaseViewModel 
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

        private ObservableCollection<TopDataModel>  topLeftDataModelList;
        public ObservableCollection<TopDataModel> TopLeftDataModelList
        {
            get { return topLeftDataModelList; }
            set { SetProperty(ref topLeftDataModelList, value); }
        }

        private ObservableCollection<TopDataModel> topRightDataModelList;
        public ObservableCollection<TopDataModel> TopRightDataModelList
        {
            get { return topRightDataModelList; }
            set { SetProperty(ref topRightDataModelList, value); }
        }
        #endregion

        public ServerManageViewModel(IEventAggregator ea, IRegionManager regionManager, IUnityContainer container) : base(ea, regionManager, container)
        {
            DataSetting();
            TopLeftDataListSetting();
            TopRightDataListSetting();
            UserStateSetting();
        }

        private void DataSetting()
        {
            TopLeftDataModelList = new ObservableCollection<TopDataModel>();
            TopRightDataModelList = new ObservableCollection<TopDataModel>();
        }

        private void TopLeftDataListSetting()
        {
            TopDataModel topDataModel = new TopDataModel
            {
                HeaderWidth = 80,
                ContentWidth = 120,
                HeaderName = "Name",
                ContentName = ""
            };

            TopLeftDataModelList.Add(topDataModel);

            topDataModel = new TopDataModel
            {
                HeaderWidth = 80,
                ContentWidth = 120,
                HeaderName = "IP",
                ContentName = ""
            };


            TopLeftDataModelList.Add(topDataModel);

            topDataModel = new TopDataModel
            {
                HeaderWidth = 80,
                ContentWidth = 120,
                HeaderName = "Port",
                ContentName = ""
            };


            TopLeftDataModelList.Add(topDataModel);

            topDataModel = new TopDataModel
            {
                HeaderWidth = 80,
                ContentWidth = 120,
                HeaderName = "Scan Time",
                ContentName = ""
            };


            TopLeftDataModelList.Add(topDataModel);

            topDataModel = new TopDataModel
            {
                HeaderWidth = 80,
                ContentWidth = 120,
                HeaderName = "Count",
                ContentName = ""
            };

            TopLeftDataModelList.Add(topDataModel);

        }

        private void TopRightDataListSetting()
        {

            TopDataModel topDataModel = new TopDataModel
            {
                HeaderWidth = 80,
                ContentWidth = 120,
                HeaderName = "Name",
                ContentName = ""
            };

            TopRightDataModelList.Add(topDataModel);

            topDataModel = new TopDataModel
            {
                HeaderWidth = 80,
                ContentWidth = 120,
                HeaderName = "IP",
                ContentName = ""
            };


            TopRightDataModelList.Add(topDataModel);

            topDataModel = new TopDataModel
            {
                HeaderWidth = 80,
                ContentWidth = 120,
                HeaderName = "Port",
                ContentName = ""
            };


            TopRightDataModelList.Add(topDataModel);

            topDataModel = new TopDataModel
            {
                HeaderWidth = 80,
                ContentWidth = 120,
                HeaderName = "Scan Time",
                ContentName = ""
            };


            TopRightDataModelList.Add(topDataModel);

            topDataModel = new TopDataModel
            {
                HeaderWidth = 80,
                ContentWidth = 120,
                HeaderName = "Count",
                ContentName = ""
            };

            TopRightDataModelList.Add(topDataModel);


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
