using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
using Protocol.Database.DashBoard;
using Protocol.Database;
using Protocol.Enum;
using Protocol.Model.Config;
using Protocol.Model.Dashboard;
using Protocol.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using Unity;
using Protocol.Database.Config;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Runtime.Remoting.Messaging;

namespace Config.View
{
    public class OperateTimeViewModel : BaseViewModel 
    {
        #region property
        #endregion

        public OperateTimeViewModel(IEventAggregator ea, IRegionManager regionManager, IUnityContainer container) : base(ea, regionManager, container)
        {
        }

        protected override void Setup()
        {
        }

        #region event
        DelegateCommand<object> buttonCommand;
        public DelegateCommand<object> ButtonCommand
        {
            get
            {
                return buttonCommand ??
                    (buttonCommand = new DelegateCommand<object>(Button));
            }
        }

        public void Button(object obj)
        {

        }

        #endregion
    }
}
