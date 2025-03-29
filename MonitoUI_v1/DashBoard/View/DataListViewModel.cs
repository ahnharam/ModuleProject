using DashBoard.Model;
using Prism.Events;
using Prism.Regions;
using Protocol.ViewModel;
using System.Collections.ObjectModel;
using Unity;

namespace DashBoard.View
{
    public class DataListViewModel : BaseViewModel
    {
        #region Property

        private DataListModel dataListModel;

        public DataListModel DataListModel
        {
            get { return dataListModel; }
            set { SetProperty(ref dataListModel, value); }
        }

        private ObservableCollection<DataListModel> dataList;

        public ObservableCollection<DataListModel> DataList
        {
            get { return dataList; }
            set { SetProperty(ref dataList, value); }
        }

        #endregion Property

        public DataListViewModel(IEventAggregator ea, IRegionManager regionManager, IUnityContainer container) : base(ea, regionManager, container)
        {
        }
    }
}