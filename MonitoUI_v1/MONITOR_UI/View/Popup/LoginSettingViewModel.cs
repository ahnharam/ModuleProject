using Prism.Commands;
using Prism.Events;
using Prism.Regions;
using Protocol.Database;
using Protocol.Login;
using Protocol.ShareLib.Cache;
using Protocol.Util;
using Protocol.ViewModel;
using System.Security;
using System.Windows;
using Unity;

namespace MONITOR_UI.View.Popup
{
    internal class LoginSettingViewModel : BaseViewModel
    {
        #region property

        private string serverIp;

        public string ServerIP
        {
            get { return serverIp; }
            set { SetProperty(ref serverIp, value); }
        }

        private string serverId;

        public string ServerId
        {
            get { return serverId; }
            set { SetProperty(ref serverId, value); }
        }

        private string port;

        public string Port
        {
            get { return port; }
            set { SetProperty(ref port, value); }
        }

        private string password;

        public string Password
        {
            get { return password; }
            set { SetProperty(ref password, value); }
        }

        private string userId;

        public string UserId
        {
            get { return userId; }
            set { SetProperty(ref userId, value); }
        }

        private SecureString userPassword;

        public SecureString UserPassword
        {
            get { return userPassword; }
            set { SetProperty(ref userPassword, value); }
        }

        private string confirm;

        public string Confirm
        {
            get { return confirm; }
            set { SetProperty(ref confirm, value); }
        }

        private Window window;

        public Window Window
        {
            get { return window; }
            set { SetProperty(ref window, value); }
        }

        public DatabaseConnect DBConnect { get; set; }

        #endregion property

        public LoginSettingViewModel(IEventAggregator ea, IRegionManager regionManager, IUnityContainer container) : base(ea, regionManager, container)
        {
            SetEA();

            // Default Setting
            ServerIP = "127.0.0.1";
            Port = "3006";
            ServerId = "root";
            Password = "root";
            UserId = "admin";
            Confirm = "";
        }

        private void SetEA()
        {
        }

        private DelegateCommand<object> cancelButtonCommand;

        public DelegateCommand<object> CancelButtonCommand
        {
            get
            {
                return cancelButtonCommand ??
                    (cancelButtonCommand = new DelegateCommand<object>(CancelButton));
            }
        }

        private void CancelButton(object obj)
        {
            if (Window != null)
            {
                Window.Close();
            }
        }

        private DelegateCommand<object> confirmButtonCommand;

        public DelegateCommand<object> ConfirmButtonCommand
        {
            get
            {
                return confirmButtonCommand ??
                    (confirmButtonCommand = new DelegateCommand<object>(ConfirmButton));
            }
        }

        private void ConfirmButton(object obj)
        {
            Cache.Instance.User = new LoginFormat(UserId, Utils.ConvertToUNSecureString(UserPassword));

            if (Password != "root")
            {
            }
            else
            {
            }
        }
    }
}