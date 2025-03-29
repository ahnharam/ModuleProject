using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using Unity;
using Protocol.Database;
using Protocol.ShareLib;
using Protocol.Login;
using System.Windows;
using MONITOR_UI.View.Popup;
using Protocol.ViewModel;
using Protocol.Util;
using static Protocol.Enum.CommonEnum;

namespace MONITOR_UI.View
{
    class MainToolbarViewModel : BaseViewModel
    {
        #region property
        private string id = "test";
        public string Id
        {
            get { return id; }
            set { SetProperty(ref id, value); }
        }

        private SecureString pw;
        public SecureString Pw
        {
            get { return pw; }
            set { SetProperty(ref pw, value); }
        }
        #endregion

        public MainToolbarViewModel(IEventAggregator ea, IRegionManager regionManager, IUnityContainer container) : base(ea, regionManager, container)
        {
        }


        public string convertToUNSecureString(SecureString secstrPassword)
        {
            IntPtr unmanagedString = IntPtr.Zero;
            try
            {
                unmanagedString = Marshal.SecureStringToGlobalAllocUnicode(secstrPassword);
                return Marshal.PtrToStringUni(unmanagedString);
            }
            catch (Exception e)
            {
                return "";
            }
            finally
            {
                Marshal.ZeroFreeGlobalAllocUnicode(unmanagedString);
            }
        }

        DelegateCommand<object> closeButtonCommand;
        public DelegateCommand<object> CloseButtonCommand
        {
            get
            {
                return closeButtonCommand ??
                    (closeButtonCommand = new DelegateCommand<object>(CloseButton));
            }
        }

        private void CloseButton(object obj)
        {
            Window window = new CloseCheckView();
            window.Show();
        }


        DelegateCommand<string> viewPanelChangeButtonCommand;
        public DelegateCommand<string> ViewPanelChangeButtonCommand
        {
            get
            {
                return viewPanelChangeButtonCommand ??
                    (viewPanelChangeButtonCommand = new DelegateCommand<string>(ViewPanelChangeButton));
            }
        }

        private void ViewPanelChangeButton(string panelName)
        {
            if (panelName == null) return;

            ViewPanel viewPanel;

            switch (panelName)
            {
                case "CONFIG": viewPanel = ViewPanel.CONFIG; 
                    break;
                case "ALARM": viewPanel = ViewPanel.ALARM; 
                    break;
                case "SYSTEM": viewPanel = ViewPanel.SYSTEM; 
                    break;
                default:
                    return;
            }

            _eventAggregator.GetEvent<ViewPanelChangePublisher>().Publish(viewPanel);
        }
    }
}
