using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Mvvm;

namespace PoleServerWithUI.Model
{
    class DeviceModel : BindableBase
    {
        public int No { get; set; }

        private string masterName;
        public string MasterName
        {
            get { return masterName; }
            set { SetProperty(ref masterName, value); }
        }

        private string screen;
        public string Screen
        {
            get { return screen; }
            set { SetProperty(ref screen, value); }
        }

        public string Id { get; set; }
        public string Sid { get; set; }

        private string name;
        public string Name
        {
            get { return name; }
            set { SetProperty(ref name, value); }
        }

        private string ip;
        public string Ip
        {
            get { return ip; }
            set { SetProperty(ref ip, value); }
        }

        public string Port { get; set; }

        public string TxData { get; set; }

        private string displayName;
        public string DisplayName
        {
            get { return displayName; }
            set { SetProperty(ref displayName, value); }
        }

        private bool connected;
        public bool Connected
        {
            get { return connected; }
            set { SetProperty(ref connected, value); }
        }

        private int errorCount = 0;
        public int ErrorCount
        {
            get { return errorCount; }
            set { SetProperty(ref errorCount, value); }
        }
    }
}
