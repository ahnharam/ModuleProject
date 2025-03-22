using Prism.Ioc;
using Prism.Modularity;

namespace ModuleProject.Pay
{
    public class TossPayModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<TossPayView, TossPayViewModel>();
        }
    }
}
