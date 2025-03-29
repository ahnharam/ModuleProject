using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Mvvm;

namespace PoleServerWithUI.Model
{
    class DeviceGroupModel : BindableBase
    {
        private string ip;
        public string Ip
        {
            get { return ip; }
            set { SetProperty(ref ip, value); }
        }

        private bool connected = false;
        public bool Connected
        {
            get { return connected; }
            set { SetProperty(ref connected, value); }
        }

        private ObservableCollection<DeviceModel> devices;
        public ObservableCollection<DeviceModel> Devices
        {
            get { return devices; }
            set { SetProperty(ref devices, value); }
        }
    }
}
