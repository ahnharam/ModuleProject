using ModuleProject.GoogleSheet;
using ModuleProject.TossPay;
using Prism.Navigation.Regions;
using System.Windows;

namespace ModuleProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly int _version = 2;

        public MainWindow(IRegionManager regionManager)
        {
            InitializeComponent();

            ViewSelect(regionManager);
        }

        private void ViewSelect(IRegionManager regionManager)
        {
            switch (_version)
            {
                case 1:
                    regionManager.RegisterViewWithRegion("ContentRegion", typeof(TossPayView));
                    break;

                case 2:
                    regionManager.RegisterViewWithRegion("ContentRegion", typeof(GoogleSheetView));
                    break;
            }
        }
    }
}
