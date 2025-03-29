using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;

namespace PoleServerWithUI.Model
{
    public class DeviceGroupModel : BaseModel
    {
        private string ip;

        public string Ip
        {
            get { return ip; }
            set { SetProperty(ref ip, value); }
        }

        private string masterName;

        public string MasterName
        {
            get { return masterName; }
            set { SetProperty(ref masterName, value); }
        }

        private ConnectionState connected = ConnectionState.Closed;

        public ConnectionState Connected
        {
            get { return connected; }
            set { SetProperty(ref connected, value); }
        }

        private DeviceList devices;

        public DeviceList Devices
        {
            get { return devices; }
            set { SetProperty(ref devices, value); }
        }

        public DeviceGroupModel()
        { }

        public DeviceGroupModel(DataRow dataRow) : base(dataRow)
        {
        }

        protected override void ConvertData(DataRow dataRow)
        {
            this.Ip = ConvertString(dataRow, "ip");
            this.MasterName = ConvertString(dataRow, "mastername");
            this.Devices = new DeviceList();
        }
    }

    public class DeviceGroupList : BaseList<DeviceGroupModel>
    {
        public static void GetList(DeviceGroupList deviceGroupList)
        {
            if (deviceGroupList == null) return;

            foreach (var row in deviceGroupList.dt.AsEnumerable())  // AsEnumerable() returns IEnumerable<DataRow>
            {
                DeviceGroupModel deviceGroupModel = new DeviceGroupModel(row);

                deviceGroupList.Add(deviceGroupModel);
            }
        }

        public override void SelectData(object obj)
        {
            if ((obj is int) == false) return;

            int serverId = Convert.ToInt32(obj);

            dbMessage = string.Format("SELECT `ip`, `mastername` FROM `device_info` WHERE `serverid` = {0} GROUP BY `ip`", serverId);
        }
    }
}