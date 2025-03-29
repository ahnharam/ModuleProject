using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
using Protocol.Database;
using Protocol.Login;
using Protocol.ShareLib.Cache;
using Protocol.Util;
using Protocol.ViewModel;
using System;
using System.Security;
using System.Windows;
using Unity;

namespace MONITOR_UI.View.Popup
{
    class CloseCheckViewModel : BaseViewModel
    {
        
        #region property
        #endregion

        public CloseCheckViewModel(IEventAggregator ea, IRegionManager regionManager, IUnityContainer container) : base(ea, regionManager, container)
        {

        }


        DelegateCommand<object> cancelButtonCommand;
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
            if(obj is Window)
            {
                Window window = obj as Window;
                window.Close();
            }
        }

        DelegateCommand<object> confirmButtonCommand;
        public DelegateCommand<object>ConfirmButtonCommand
        {
            get
            {
                return confirmButtonCommand ??
                    (confirmButtonCommand = new DelegateCommand<object>(ConfirmButton));
            }
        }

        private void ConfirmButton(object obj)
        {
            // 프로그램 종료
            Environment.Exit(0);
        }

    }
}
