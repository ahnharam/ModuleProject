using PoleServerWithUI.View;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Windows;

namespace PoleServerWithUI.ViewModel
{
    public class SettingViewModel : BindableBase
    {
        private string dbIp;
        public string DBIP
        {
            get { return dbIp; }
            set { SetProperty(ref dbIp, value); }
        }

        private string dbPort;
        public string DBPort
        {
            get { return dbPort; }
            set { SetProperty(ref dbPort, value); }
        }

        private string dbName;
        public string DBName
        {
            get { return dbName; }
            set { SetProperty(ref dbName, value); }
        }

        private string dbId;
        public string DBID
        {
            get { return dbId; }
            set { SetProperty(ref dbId, value); }
        }

        private string dbPw;
        public string DBPW
        {
            get { return dbPw; }
            set { SetProperty(ref dbPw, value); }
        }

        private string polingCycle;
        public string PolingCycle
        {
            get { return polingCycle; }
            set { SetProperty(ref polingCycle, value); }
        }

        private string readTimeOut;
        public string ReadTimeOut
        {
            get { return readTimeOut; }
            set { SetProperty(ref readTimeOut, value); }
        }

        private string errorCount;
        public string ErrorCount
        {
            get { return errorCount; }
            set { SetProperty(ref errorCount, value); }
        }

        private string socketClose;
        public string SocketClose
        {
            get { return socketClose; }
            set { SetProperty(ref socketClose, value); }
        }

        private string serverId;
        public string ServerID
        {
            get { return serverId; }
            set { SetProperty(ref serverId, value); }
        }

        public SettingViewModel()
        {
            DBIP = ConfigurationManager.AppSettings["DBIP"];
            DBPort = ConfigurationManager.AppSettings["DBPORT"];
            DBName = ConfigurationManager.AppSettings["DBNAME"];
            DBID = ConfigurationManager.AppSettings["DBID"];
            DBPW = ConfigurationManager.AppSettings["DBPW"];

            PolingCycle = ConfigurationManager.AppSettings["POLINGTIME"];
            ReadTimeOut = ConfigurationManager.AppSettings["READTIMEOUT"];
            ErrorCount = ConfigurationManager.AppSettings["ERRORCOUNT"];
            
            SocketClose = ConfigurationManager.AppSettings["ERRORCLIENTCLOSE"];

            ServerID = ConfigurationManager.AppSettings["DEVICEID"];
        }

        private DelegateCommand<object> cancelButton;
        public DelegateCommand<object> CancelButton
        {
            get
            {
                if (cancelButton == null)
                    cancelButton = new DelegateCommand<object>(Cancel);
                return cancelButton;
            }
        }

        private void Cancel(object obj)
        {
            if(obj is Window)
            {
                Window window = (Window)obj;
                window.Close();
            }
        }

        private DelegateCommand<object> saveButton;
        public DelegateCommand<object> SaveButton
        {
            get
            {
                if (saveButton == null)
                    saveButton = new DelegateCommand<object>(Save);
                return saveButton;
            }
        }

        private void Save(object obj)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            config.AppSettings.Settings["DBIP"].Value = DBIP;
            config.AppSettings.Settings["DBPORT"].Value = DBPort;
            config.AppSettings.Settings["DBNAME"].Value = DBName;
            config.AppSettings.Settings["DBID"].Value = DBID;
            config.AppSettings.Settings["DBPW"].Value = DBPW;

            config.AppSettings.Settings["POLINGTIME"].Value = PolingCycle;
            config.AppSettings.Settings["READTIMEOUT"].Value = ReadTimeOut;
            config.AppSettings.Settings["ERRORCOUNT"].Value = ErrorCount;

            config.AppSettings.Settings["ERRORCLIENTCLOSE"].Value = SocketClose;

            config.AppSettings.Settings["DEVICEID"].Value = ServerID;
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
        }
    }
}
