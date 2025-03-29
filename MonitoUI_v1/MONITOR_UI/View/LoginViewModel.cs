using MONITOR_UI.View.Popup;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
using Protocol.Login;
using Protocol.Message;
using Protocol.ShareLib;
using Protocol.Util;
using Protocol.ViewModel;
using System;
using System.Security;
using System.Windows;
using Unity;

namespace MONITOR_UI.View
{
    class LoginViewModel : BaseViewModel
    {
        #region property
        private string id = "root";
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

        public LoginViewModel(IEventAggregator ea, IRegionManager regionManager, IUnityContainer container) : base(ea, regionManager, container)
        {

        }

        DelegateCommand<object> loginButtonCommand;
        public DelegateCommand<object> LoginButtonCommand
        {
            get
            {
                return loginButtonCommand ??
                    (loginButtonCommand = new DelegateCommand<object>(LoginButton));
            }
        }

        private void LoginButton(object obj)
        {
            if (string.IsNullOrEmpty(Id) == false && Pw != null)
            {
                // ID 및 Password  DB에 전송 및 확인
                _eventAggregator.GetEvent<LoginPublisher>().Publish(new LoginFormat(Id, Utils.ConvertToUNSecureString(Pw)));
            }
        }

        DelegateCommand<object> loginSettingButtonCommand;
        public DelegateCommand<object> LoginSettingButtonCommand
        {
            get
            {
                return loginSettingButtonCommand ??
                    (loginSettingButtonCommand = new DelegateCommand<object>(LoginSettingButton));
            }
        }

        private void LoginSettingButton(object obj)
        {
            Window loginSettingView = new LoginSettingView();
            loginSettingView.Show();
        }

        DelegateCommand<object> exitButtonCommand;
        public DelegateCommand<object> ExitButtonCommand
        {
            get
            {
                return exitButtonCommand ??
                    (exitButtonCommand = new DelegateCommand<object>(ExitButton));
            }
        }

        private void ExitButton(object obj)
        {
            Window window = new CloseCheckView();
            window.Show();
        }
    }
}
