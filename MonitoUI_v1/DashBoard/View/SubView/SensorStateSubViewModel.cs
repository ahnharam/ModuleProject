using Prism.Events;
using Prism.Regions;
using Protocol.ViewModel;
using System.Windows;
using Unity;

namespace DashBoard.View.SubView
{
    public class SensorStateSubViewModel : BaseViewModel
    {
        #region property

        private string title;

        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }

        private string message;

        public string Message
        {
            get { return message; }
            set { SetProperty(ref message, value); }
        }

        private string image;

        public string Image
        {
            get { return image; }
            set { SetProperty(ref image, value); }
        }

        private Visibility[] type = new Visibility[3];

        public Visibility[] Type
        {
            get { return type; }
            set { SetProperty(ref type, value); }
        }

        #endregion property

        public SensorStateSubViewModel(IEventAggregator ea, IRegionManager regionManager, IUnityContainer container) : base(ea, regionManager, container)
        {
            // Sample Data
            Title = "Sample";
            Message = "Sample Message";
            Image = "pack://application:,,,/Resources/call_btn(shadow).png";
            Type[0] = Visibility.Collapsed;
            Type[1] = Visibility.Visible;
            Type[2] = Visibility.Collapsed;
        }
    }
}