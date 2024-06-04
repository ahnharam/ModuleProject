using ModuleProject.Pay;
using Prism.Regions;
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
            regionManager.RegisterViewWithRegion("ContentRegion", typeof(TossPayView));
        }
    }
}
