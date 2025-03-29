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

namespace Config.View
{
    public class SmsSettingViewModel : BaseViewModel
    {
        #region property
        private string gridImage;
        public string GridImage
        {
            get { return gridImage; }
            set { SetProperty(ref gridImage, value); }
        }

        private string snsListCount;
        public string SnsListCount
        {
            get { return snsListCount; }
            set { SetProperty(ref snsListCount, value); }
        }

        private SnsModel snsListModel;
        public SnsModel SnsListModel
        {
            get { return snsListModel; }
            set { SetProperty(ref snsListModel, value); }
        }

        private SnsModel snsReceiverModel;
        public SnsModel SnsReceiverModel
        {
            get { return snsReceiverModel; }
            set { SetProperty(ref snsReceiverModel, value); }
        }

        private ObservableCollection<TopDataModel>  topDataModelList;
        public ObservableCollection<TopDataModel> TopDataModelList
        {
            get { return topDataModelList; }
            set { SetProperty(ref topDataModelList, value); }
        }
        #endregion

        public SmsSettingViewModel(IEventAggregator ea, IRegionManager regionManager, IUnityContainer container) : base(ea, regionManager, container)
        {
            TopDataListSetting();
            SnsSetting();
        }
        public void TopDataListSetting()
        {
            TopDataModelList = new ObservableCollection<TopDataModel>();
            TopDataModel topDataModel = new TopDataModel();
            topDataModel.ContentWidth = 100;
            topDataModel.HeaderName = "Station";
            topDataModel.ContentName = "";

            TopDataModelList.Add(topDataModel);

            topDataModel = new TopDataModel();
            topDataModel.ContentWidth = 100;
            topDataModel.HeaderName = "Server ID";
            topDataModel.ContentName = "";

            TopDataModelList.Add(topDataModel);

            topDataModel = new TopDataModel();
            topDataModel.ContentWidth = 100;
            topDataModel.HeaderName = "Pass";
            topDataModel.ContentName = "";

            TopDataModelList.Add(topDataModel);

            topDataModel = new TopDataModel();
            topDataModel.ContentWidth = 100;
            topDataModel.HeaderName = "발신자 번호";
            topDataModel.ContentName = "";

            TopDataModelList.Add(topDataModel);
        }

        public void SnsSetting()
        {
            GetSnsList();
            GetSnsReciver();
        }

        public void GetSnsList()
        {

            string dbMessage = string.Empty;
            this.SnsListModel = new SnsModel();

            dbMessage = ConfigDBMessage.SelectSnsMessage();
            SnsListModel.SnsTable = DatabaseConnect.Instance.Select(dbMessage);
        }

        public void GetSnsReciver()
        {
            string dbMessage = string.Empty;
            this.SnsReceiverModel = new SnsModel();

            dbMessage = ConfigDBMessage.SelectSnsReceiver();
            SnsReceiverModel.SnsTable = DatabaseConnect.Instance.Select(dbMessage);
        }


        #region event
        DelegateCommand<object> searchButtonCommand;
        public DelegateCommand<object> SearchButtonCommand
        {
            get
            {
                return searchButtonCommand ??
                    (searchButtonCommand = new DelegateCommand<object>(SearchButton));
            }
        }

        public void SearchButton(object obj)
        {

        }

        #endregion
    }
}
