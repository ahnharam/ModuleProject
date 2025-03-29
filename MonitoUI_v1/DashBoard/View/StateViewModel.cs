using DashBoard.View.SubView;
using Prism.Events;
using Prism.Regions;
using Protocol.Model.Dashboard;
using Protocol.ViewModel;
using System.Diagnostics;
using System.Windows.Controls;
using Unity;

namespace DashBoard.View
{
    public class StateViewModel : BaseViewModel
    {
        private string[] tabHeaderName = { "power", "control" };

        #region property

        private StateTabItemList tabHeaderNameList;

        public StateTabItemList TabHeaderNameList
        {
            get { return tabHeaderNameList; }
            set { SetProperty(ref tabHeaderNameList, value); }
        }

        #endregion property

        public StateViewModel(IEventAggregator ea, IRegionManager regionManager, IUnityContainer container) : base(ea, regionManager, container)
        {
            TabHeaderSetting();
        }

        private void TabHeaderSetting()
        {
            TabHeaderNameList = new StateTabItemList();

            foreach (var header in tabHeaderName)
            {
                UserControl userControl = null;

                switch (header)
                {
                    case "power":
                        Debug.WriteLine("power header : " + header);
                        userControl = new PowerControlView();
                        break;

                    case "control":
                        Debug.WriteLine("control header : " + header);
                        userControl = new ControlView();
                        break;

                    default:
                        Debug.WriteLine("default header : " + header);
                        break;
                }

                TabHeaderNameList.Add(new StateTabItemM(header, userControl));
            }
        }
    }
}