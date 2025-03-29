using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
using Unity;

namespace Protocol.ViewModel
{
    public class BaseViewModel : BindableBase
    {
        protected IEventAggregator _eventAggregator;
        protected IRegionManager _regionManager;
        protected IUnityContainer _container;

        public BaseViewModel(IEventAggregator ea, IRegionManager regionManager, IUnityContainer container)
        {
            _eventAggregator = ea;
            _regionManager = regionManager;
            _container = container;

            SubscribeEA();
            Setup();
        }

        ~BaseViewModel()
        {
            UnsubscribeEA();
        }

        protected virtual void Setup()
        { }

        #region EA

        protected virtual void SubscribeEA()
        { }

        protected virtual void UnsubscribeEA()
        { }

        #endregion EA
    }
}