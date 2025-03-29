using PoleServerWithUI.Model;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PoleServerWithUI.Utils
{
    public class CacheManager : BindableBase
    {
        private static readonly Lazy<CacheManager> lazy = new Lazy<CacheManager>(() => new CacheManager());
        public static CacheManager Instance => lazy.Value;
        public string DBIP { get; set; }
        public string DBPort { get; set; }
        public string DBName { get; set; }
        public string DBID { get; set; }
        public string DBPW { get; set; }
        public string PolingCycle { get; set; }
        public string ReadTimeOut { get; set; }
        public string ErrorCount { get; set; }
        public string SocketClose { get; set; }
        public string ServerID { get; set; }

        public CacheManager() 
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

        public void Save()
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
