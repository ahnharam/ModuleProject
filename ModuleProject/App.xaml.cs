using ModuleProject.GoogleSheet;
using ModuleProject.TossPay;
using Prism.Ioc;
using System.Windows;

namespace ModuleProject
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<TossPayView, TossPayViewModel>();
            containerRegistry.RegisterForNavigation<GoogleSheetView, GoogleSheetViewModel>();
            containerRegistry.RegisterSingleton<IGoogleSheetsService, GoogleSheetsService>();
        }
    }
}
