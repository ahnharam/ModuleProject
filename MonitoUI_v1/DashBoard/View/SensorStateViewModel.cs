using DashBoard.View.SubView;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
using Protocol.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace DashBoard.View
{
    public class SensorStateViewModel : BaseViewModel
    {
        #region property
        private ObservableCollection<SensorStateSubView> sensorList;
        public ObservableCollection<SensorStateSubView> SensorList
        {
            get { return sensorList; }
            set { SetProperty(ref sensorList, value); }
        }
        #endregion

        public SensorStateViewModel(IEventAggregator ea, IRegionManager regionManager, IUnityContainer container) : base(ea, regionManager, container)
        {
            SensorList = new ObservableCollection<SensorStateSubView>();
            SensorList.Add(new SensorStateSubView());
        }
    }
}
