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
    public class UserStateViewModel : BaseViewModel 
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
        #endregion

        public UserStateViewModel(IEventAggregator ea, IRegionManager regionManager, IUnityContainer container) : base(ea, regionManager, container)
        {
            TopDataListSetting(GetTopDataModelList());
            UserStateSetting();
        }

        private ObservableCollection<TopDataModel> GetTopDataModelList()
        {
            return TopDataModelList;
        }

        private void TopDataListSetting(ObservableCollection<TopDataModel> topDataModelList)
        {
            TopDataModelList = new ObservableCollection<TopDataModel>();
            TopDataModel topDataModel = new TopDataModel
            {
                ContentWidth = 100,
                HeaderName = "ID",
                ContentName = ""
            };

            TopDataModelList.Add(topDataModel);

            topDataModel = new TopDataModel
            {
                ContentWidth = 100,
                HeaderName = "Password",
                ContentName = ""
            };

            TopDataModelList.Add(topDataModel);

            topDataModel = new TopDataModel
            {
                ContentWidth = 100,
                HeaderName = "Group",
                ContentName = ""
            };

            TopDataModelList.Add(topDataModel);

            topDataModel = new TopDataModel
            {
                ContentWidth = 100,
                HeaderName = "Name",
                ContentName = ""
            };
            TopDataModelList.Add(topDataModel);

            topDataModel = new TopDataModel
            {
                ContentWidth = 100,
                HeaderName = "Phone",
                ContentName = ""
            };

            TopDataModelList.Add(topDataModel);

            topDataModel = new TopDataModel
            {
                ContentWidth = 100,
                HeaderName = "E-Mail",
                ContentName = ""
            };
            TopDataModelList.Add(topDataModel);

        }

        private void UserStateSetting()
        {

            string dbMessage = string.Empty;
            this.UserStateModel = new UserStateModel();

            dbMessage = CommonDBMessage.SelectUserState();
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
