using Prism.Events;
using Prism.Regions;
using Protocol.ViewModel;
using Unity;

namespace DashBoard.View.SubView
{
    public class LightViewModel : BaseViewModel
    {
        #region property

        private bool light = false;

        public bool Light
        {
            get { return light; }
            set { SetProperty(ref light, value); }
        }

        #endregion property

        public LightViewModel(IEventAggregator ea, IRegionManager regionManager, IUnityContainer container) : base(ea, regionManager, container)
        {
        }
    }
}