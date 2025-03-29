using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
using Protocol.ViewModel;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using Unity;
using static Protocol.Enum.DashBoardEnum;

namespace DashBoard.Popup
{
    public class BroadcastPopupViewModel : BaseViewModel
    {
        private bool autoBroadcast;
        public bool AutoBroadcast
        {
            get { return autoBroadcast; }
            set { 
                SetProperty(ref autoBroadcast, value);
                ChangeBroadcastMode(BroadcastType.Auto, value);
            }
        }

        private bool liveBroadcast;
        public bool LiveBroadcast
        {
            get { return liveBroadcast; }
            set { 
                SetProperty(ref liveBroadcast, value);
                ChangeBroadcastMode(BroadcastType.Live, value);
            }
        }

        private bool comBroadcast;
        public bool ComBroadcast
        {
            get { return comBroadcast; }
            set { 
                SetProperty(ref comBroadcast, value);
                ChangeBroadcastMode(BroadcastType.Com, value);
            }
        }

        private string checkImage;
        public string CheckImage
        {
            get { return checkImage; }
            set { SetProperty(ref checkImage, value); }
        }

        private string closeImage;
        public string CloseImage
        {
            get { return closeImage; }
            set { SetProperty(ref closeImage, value); }
        }

        private ObservableCollection<string> musicList;
        public ObservableCollection<string> MusicList
        {
            get { return musicList; }
            set { SetProperty(ref musicList, value); }
        }

        public BroadcastPopupViewModel(IEventAggregator ea, IRegionManager regionManager, IUnityContainer container) : base(ea, regionManager, container)
        {
            MusicList = new ObservableCollection<string>();

            CheckImage = "pack://application:,,,/Protocol;component/Image/call_btn(shadow).png";
            CloseImage = "pack://application:,,,/Protocol;component/Image/call_btn(shadow).png";

            // Test Resource
            MusicList.Add("test1");
            MusicList.Add("test2");
            MusicList.Add("test3");
        }


        DelegateCommand<object> saveCommand;
        public DelegateCommand<object> SaveCommand
        {
            get
            {
                return saveCommand ??
                    (saveCommand = new DelegateCommand<object>(Save));
            }
        }

        private void Save(object obj)
        {
            // Message Send command
            if (obj is Window)
            {
                Window window = (Window)obj;
                window.Close();
            }
        }

        DelegateCommand<object> closeCommand;
        public DelegateCommand<object> CloseCommand
        {
            get
            {
                return closeCommand ??
                    (closeCommand = new DelegateCommand<object>(Close));
            }
        }

        private void Close(object obj)
        {
            // Message Send command
            if(obj is Window)
            {
                Window window = (Window)obj;
                window.Close();
            }
        }

        public void ChangeBroadcastMode(BroadcastType broadcastType, bool castValue)
        {
            if (castValue == false) return;

            switch (broadcastType)
            {
                case BroadcastType.Auto:
                    LiveBroadcast = false;
                    ComBroadcast = false;
                    break;
                case BroadcastType.Live:
                    AutoBroadcast = false;
                    ComBroadcast = false;
                    break;
                case BroadcastType.Com:
                    AutoBroadcast = false;
                    LiveBroadcast = false;
                    break;
                default:
                    break;
            }
        }
    }
}