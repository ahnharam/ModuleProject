using DashBoard.View;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
using Protocol.Database;
using Protocol.Database.DashBoard;
using Protocol.Main;
using Protocol.Model.Dashboard;
using Protocol.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Unity;

namespace DashBoard
{
    public class DashBoardMainViewModel : BaseViewModel
    {
        #region Property

        private bool scenario = false;
        public bool Scenario
        {
            get { return scenario; }
            set { SetProperty(ref scenario, value); }
        }

        private bool livePanel = true;
        public bool LivePanel
        {
            get { return livePanel; }
            set { SetProperty(ref livePanel, value); }
        }

        private PanelM[] rightPanelState;
        public PanelM[] RightPanelState
        {
            get { return rightPanelState; }
            set { SetProperty(ref rightPanelState, value); }
        }


        private PanelM[] leftPanelState;
        public PanelM[] LeftPanelState
        {
            get { return leftPanelState; }
            set { SetProperty(ref leftPanelState, value); }
        }

        private UserControl[] rightPanel;
        public UserControl[] RightPanel
        {
            get { return rightPanel; }
            set { SetProperty(ref rightPanel, value); }
        }

        private string dashBoardImage;
        public string DashBoardImage
        {
            get { return dashBoardImage; }
            set { SetProperty(ref dashBoardImage, value); }
        }

        private PanelList panelList;
        public PanelList PanelList
        {
            get { return panelList; }
            set { SetProperty(ref panelList, value); }
        }


        #endregion

        public DashBoardMainViewModel(IEventAggregator ea, IRegionManager regionManager, IUnityContainer container) : base(ea, regionManager, container)
        {
            DashBoardImage = "pack://application:,,,/Protocol;component/Image/img1.jpg";

            PanelSetting();
        }

        public void PanelSetting()
        {
            PanelList = new PanelList();
            string dbMessage = string.Empty;

            dbMessage = DashBoardDBMessage.SelectPenel();
            PanelList.Dt = DatabaseConnect.Instance.Select(dbMessage);
            DashBoardDataConverter.GetPanelList(PanelList);

            if (PanelList == null) return;

            RightPanel = new UserControl[3];
            LeftPanelState = new PanelM[3];
            RightPanelState = new PanelM[2];

            foreach (var panelInfo in PanelList)
            {
                Debug.WriteLine(panelInfo.Name);
                switch (panelInfo.Panel)
                {
                    // left
                    case 1:
                        LeftPanelSetting(panelInfo);
                        break;

                    // right
                    case 2:
                        RightPanelSetting(panelInfo);
                        break;

                    // bottom
                    case 3:
                        break;

                    default:
                        break;
                }
            }
            LeftPanelHeightSetting();
            RightPanelHeightSetting();
        }
        public void LeftPanelSetting(PanelM panelInfo)
        {
            switch (panelInfo.Name)
            {
                case "Screen":
                    LeftPanelState[panelInfo.PanelNo - 1] = panelInfo;
                    LeftPanelState[panelInfo.PanelNo - 1].UserControl = new ScreenView();
                    break;
                case "Station":
                    LeftPanelState[panelInfo.PanelNo - 1] = panelInfo;
                    LeftPanelState[panelInfo.PanelNo - 1].UserControl = new StationView(panelInfo.Name);
                    break;
                case "State":
                    LeftPanelState[panelInfo.PanelNo - 1] = panelInfo;
                    LeftPanelState[panelInfo.PanelNo - 1].UserControl = new StateView();
                    break;
                default:
                    break;
            }
        }

        public void RightPanelSetting(PanelM panelInfo)
        {
            switch (panelInfo.Name)
            {
                case "Operation":
                    RightPanelState[panelInfo.PanelNo - 1] = panelInfo;
                    RightPanelState[panelInfo.PanelNo - 1].UserControl = new OperationView();
                    break;
                case "방송제어":
                    RightPanelState[panelInfo.PanelNo - 1] = panelInfo;
                    RightPanelState[panelInfo.PanelNo - 1].UserControl = new BroadcastView();
                    break;
                default:
                    break;
            }
        }

        public void LeftPanelHeightSetting()
        {
            if (LeftPanelState[2].Height == "0")
            {
                if (LeftPanelState[1].Height == "0") LeftPanelState[0].Height = "*";
                else LeftPanelState[1].Height = "*";
            }
            else LeftPanelState[2].Height = "*";
        }

        public void RightPanelHeightSetting()
        {
            if (RightPanelState[1].Height == "0") RightPanelState[0].Height = "*";
            else RightPanelState[1].Height = "auto";
        }
    }
}
