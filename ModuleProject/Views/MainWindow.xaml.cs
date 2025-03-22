using ModuleProject.Pay;
using Prism.Navigation.Regions;
using System.Windows;

namespace ModuleProject.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow(IRegionManager regionManager)
        {
            InitializeComponent();

            ViewSelect(regionManager);
        }

        private void ViewSelect(IRegionManager regionManager)
        {
            regionManager.RegisterViewWithRegion("ContentRegion", typeof(TossPayView));
        }
    }
}
