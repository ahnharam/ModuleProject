using Config;
using DashBoard;
using MONITOR_UI.View.Popup;
using Prism.Events;
using Prism.Regions;
using Protocol.ActiveMQ;
using Protocol.ViewModel;
using Protocol.Database;
using Protocol.Database.DashBoard;
using Protocol.Login;
using Protocol.Main;
using Protocol.Message;
using Protocol.Model.Common;
using Protocol.ShareLib;
using Protocol.ShareLib.Cache;
using System;
using System.Configuration;
using System.Diagnostics;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using Unity;
using static Protocol.Enum.CommonEnum;

namespace MONITOR_UI.View
{
    internal class MainViewModel : BaseViewModel
    {
        #region Property

        public bool DBConnectionCheck { get; set; }

        private Visibility loginViewVisible;

        public Visibility LoginViewVisible
        {
            get { return loginViewVisible; }
            set { SetProperty(ref loginViewVisible, value); }
        }

        private Visibility mainViewVisible;

        public Visibility MainViewVisible
        {
            get { return mainViewVisible; }
            set { SetProperty(ref mainViewVisible, value); }
        }

        private UserControl view;

        public UserControl View
        {
            get { return view; }
            set { SetProperty(ref view, value); }
        }

        #endregion Property

        public MainViewModel(IEventAggregator ea, IRegionManager regionManager, IUnityContainer container) : base(ea, regionManager, container)
        {
            LoginViewVisible = Visibility.Visible;
            MainViewVisible = Visibility.Collapsed;

            ConnectDatabase();
            //ConnectActiveMQ();
            SettingDeivce();
        }

        ~MainViewModel()
        {
            //DisconnectActiveMQ();
        }

        #region EA

        protected override void SubscribeEA()
        {
            _eventAggregator.GetEvent<LoginPublisher>().Subscribe(Login);
            _eventAggregator.GetEvent<ViewPanelChangePublisher>().Subscribe(ViewPanelChange);
        }

        protected override void UnsubscribeEA()
        {
            _eventAggregator.GetEvent<LoginPublisher>().Unsubscribe(Login);
            _eventAggregator.GetEvent<ViewPanelChangePublisher>().Unsubscribe(ViewPanelChange);
        }

        private void Login(LoginFormat loginModel)
        {
            try
            {
                // DB Connection Check
                // DB 연결 불가, 임시 주석처리 

                //if (DBConnectionCheck == false)
                //{
                //    Window error = new ErrorMessageBox("Error", "Database 연결이 불가능합니다.");
                //    error.ShowDialog();
                //    return;
                //}

                //string dbMessage = MainViewDBMessage.Login(loginModel);
                //loginModel.Dt = DatabaseConnect.Instance.Select(dbMessage);

                //if (loginModel.Dt == null)
                //{
                //    Window error = new ErrorMessageBox("Error", "아이디 혹은 비밀번호가 잘못되었습니다.");
                //    error.ShowDialog();
                //    return;
                //}

                //bool checkUser = MainViewDBMessage.CheckUser(loginModel);

                //if (checkUser)
                //{
                //    Debug.WriteLine("로그인 성공");
                //}
                //else
                //{
                //    Debug.WriteLine("유저 정보 없음");
                //    return;
                //}

                if (loginModel.Id == "root" && loginModel.Pw == "root")
                {
                    Window loginSettingView = new LoginSettingView();
                    loginSettingView.Show();
                }

                LoginViewVisible = Visibility.Collapsed;
                MainViewVisible = Visibility.Visible;
                View = new DashBoardMainView();
            }
            catch (Exception e)
            {
                Debug.WriteLine("Login Error : " + e);
            }
        }

        private void ViewPanelChange(ViewPanel viewPanel)
        {
            switch (viewPanel)
            {
                case ViewPanel.DASHBOARD:
                    View = new DashBoardMainView();
                    break;

                case ViewPanel.GISMAP:
                    //View = new GISMapMainView();
                    break;

                case ViewPanel.VIEWER:
                    //View = new ViewerMainView();
                    break;

                case ViewPanel.FIND:
                    //View = new FindMainView();
                    break;

                case ViewPanel.CONFIG:
                    View = new ConfigMainView();
                    break;

                case ViewPanel.ALARM:
                    //View = new AlarmMainView();
                    break;

                case ViewPanel.SYSTEM:
                    //View = new SystemMainView();
                    break;

                default:
                    break;
            }
        }

        #endregion EA

        #region Method

        private void ConnectDatabase()
        {
            string server = ConfigurationManager.AppSettings["DBSV"];
            string db = ConfigurationManager.AppSettings["DBNM"];
            string id = ConfigurationManager.AppSettings["DBID"];
            string pwd = ConfigurationManager.AppSettings["DBPW"];
            string port = ConfigurationManager.AppSettings["DBPORT"];

            try
            {
                DatabaseConnect.Instance.Setup(server, db, id, pwd, port);
                DatabaseConnect.Instance.Connect();
                DBConnectionCheck = true;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                DBConnectionCheck = false;

                Window error = new ErrorMessageBox("Error", "Database 연결에 실패하였습니다.");
                error.ShowDialog();
            }
        }

        private void SettingDeivce()
        {
            if (DBConnectionCheck == false)
                return;

            string dbMessage = string.Empty;
            DeviceList deviceList = new DeviceList();

            dbMessage = CommonDBMessage.SelectDevice();
            deviceList.Dt = DatabaseConnect.Instance.Select(dbMessage);
            CommonDataConverter.GetDeviceList(deviceList);

            Cache.Instance.DeviceList = deviceList;
        }

        private void ConnectActiveMQ()
        {
            //ActiveMQListener.Instance.EnumerateTopics();
            string host = "192.168.1.253";
            string port = "61616";
            string dest = "testing";
            string uri = "tcp://" + host + ":" + port + "?trace=true";

            try
            {
                ActiveMQPublisher.Instance.Setup(uri, dest, "ActiveMQ_Publisher");
                ActiveMQListener.Instance.Setup(uri, dest, "ActiveMQ_Listener");

                ActiveMQListener.Instance.Start();

                Thread.Sleep(1000);

                ActiveMQPublisher.Instance.SendMessage("Connection");
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);

                Window error = new ErrorMessageBox("Error", "ActiveMQ 연결에 실패하였습니다.");
                error.ShowDialog();
            }
        }

        private void DisconnectActiveMQ()
        {
            ActiveMQListener.Instance.Close();
            ActiveMQPublisher.Instance.Close();
        }

        #endregion Method
    }
}