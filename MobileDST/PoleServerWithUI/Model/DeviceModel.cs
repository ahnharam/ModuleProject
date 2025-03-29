using PoleServerWithUI.Utils;
using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;

namespace PoleServerWithUI.Model
{
    public class DeviceModel : BaseModel
    {
        private int no;

        public int No
        {
            get { return no; }
            set { SetProperty(ref no, value); }
        }

        private string masterName;

        public string MasterName
        {
            get { return masterName; }
            set { SetProperty(ref masterName, value); }
        }

        private int screen;

        public int Screen
        {
            get { return screen; }
            set { SetProperty(ref screen, value); }
        }

        private string id;

        public string Id
        {
            get { return id; }
            set { SetProperty(ref id, value); }
        }

        private string sid;

        public string Sid
        {
            get { return sid; }
            set { SetProperty(ref sid, value); }
        }

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

        private int port;

        public int Port
        {
            get { return port; }
            set { SetProperty(ref port, value); }
        }

        private string txData;

        public string TxData
        {
            get { return txData; }
            set { SetProperty(ref txData, value); }
        }

        private string displayName;

        public string DisplayName
        {
            get { return displayName; }
            set { SetProperty(ref displayName, value); }
        }

        private ConnectionState connected;

        public ConnectionState Connected
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

        private DeviceModelDataList deviceDataList;

        public DeviceModelDataList DeviceDataList
        {
            get { return deviceDataList; }
            set { SetProperty(ref deviceDataList, value); }
        }

        public DeviceModel()
        { }

        public DeviceModel(DataRow dataRow) : base(dataRow)
        {
        }

        protected override void ConvertData(DataRow dataRow)
        {
            this.No = ConvertInt(dataRow, "no");
            this.MasterName = ConvertString(dataRow, "mastername");
            this.Screen = ConvertInt(dataRow, "screen");
            this.Id = ConvertString(dataRow, "id");
            this.Sid = ConvertInt(dataRow, "sid").ToString();
            this.DisplayName = ConvertInt(dataRow, "sid").ToString() + "(" + ConvertInt(dataRow, "sid").ToString("X") + ")";
            this.Name = ConvertString(dataRow, "name");
            this.Ip = ConvertString(dataRow, "ip");
            this.Port = ConvertInt(dataRow, "port");
            this.TxData = ConvertString(dataRow, "txdata");
            this.DeviceDataList = new DeviceModelDataList();
            DeviceModelDataList.Setting(this.DeviceDataList, No, Id, Sid, Screen, TxData);
        }

        public class DeviceModelData
        {
            public string Label { get; set; }
            public string Value { get; set; }

            public DeviceModelData(string label, string value)
            {
                Label = label;
                Value = value;
            }
        }

        public class DeviceModelDataList : ObservableCollection<DeviceModelData>
        {
            public DeviceModelDataList()
            { }

            public static void Setting(DeviceModelDataList deviceModelDataList, int no, string id, string sid, int screen, string txData)
            {
                PoleLogModel poleLogModel = new PoleLogModel();
                deviceModelDataList.Add(new DeviceModelData(nameof(poleLogModel.SNo), no.ToString()));
                deviceModelDataList.Add(new DeviceModelData(nameof(poleLogModel.Mid), id));
                deviceModelDataList.Add(new DeviceModelData(nameof(poleLogModel.Id), sid));
                deviceModelDataList.Add(new DeviceModelData(nameof(poleLogModel.Screen), screen.ToString()));
                deviceModelDataList.Add(new DeviceModelData(nameof(poleLogModel.TxData), txData));
                deviceModelDataList.Add(new DeviceModelData(nameof(poleLogModel.Poc), ""));
                deviceModelDataList.Add(new DeviceModelData(nameof(poleLogModel.Potml), ""));
                deviceModelDataList.Add(new DeviceModelData(nameof(poleLogModel.Potmh), ""));
                deviceModelDataList.Add(new DeviceModelData(nameof(poleLogModel.Battery), ""));
                deviceModelDataList.Add(new DeviceModelData(nameof(poleLogModel.Solar), ""));
                deviceModelDataList.Add(new DeviceModelData(nameof(poleLogModel.Wind), ""));
                deviceModelDataList.Add(new DeviceModelData(nameof(poleLogModel.Outbat), ""));
                deviceModelDataList.Add(new DeviceModelData(nameof(poleLogModel.OutPowerFirst), ""));
                deviceModelDataList.Add(new DeviceModelData(nameof(poleLogModel.OutPowerSecond), ""));
                deviceModelDataList.Add(new DeviceModelData(nameof(poleLogModel.Temp), ""));
                deviceModelDataList.Add(new DeviceModelData(nameof(poleLogModel.OutTemp), ""));
                deviceModelDataList.Add(new DeviceModelData(nameof(poleLogModel.Humi), ""));
                deviceModelDataList.Add(new DeviceModelData(nameof(poleLogModel.WindSpeed), ""));
                deviceModelDataList.Add(new DeviceModelData(nameof(poleLogModel.Genneration), ""));
            }

            public static void ConvertPolLog(DeviceModelDataList deviceModelDataList, PoleLogModel poleLogModel)
            {
                if (poleLogModel == null) return;
                //deviceModelDataList = new DeviceModelDataList();

                DispatcherService.Invoke((System.Action)(() =>
                {
                    foreach (var item in deviceModelDataList)
                    {
                        switch (item.Label)
                        {
                            case nameof(poleLogModel.Poc): item.Value = poleLogModel.Poc; break;
                            case nameof(poleLogModel.Potml): item.Value = poleLogModel.Potml; break;
                            case nameof(poleLogModel.Potmh): item.Value = poleLogModel.Potmh; break;
                            case nameof(poleLogModel.Battery): item.Value = poleLogModel.Battery; break;
                            case nameof(poleLogModel.Solar): item.Value = poleLogModel.Solar; break;
                            case nameof(poleLogModel.Wind): item.Value = poleLogModel.Wind; break;
                            case nameof(poleLogModel.Outbat): item.Value = poleLogModel.Outbat; break;
                            case nameof(poleLogModel.OutPowerFirst): item.Value = poleLogModel.OutPowerFirst; break;
                            case nameof(poleLogModel.OutPowerSecond): item.Value = poleLogModel.OutPowerSecond; break;
                            case nameof(poleLogModel.Temp): item.Value = poleLogModel.Temp; break;
                            case nameof(poleLogModel.OutTemp): item.Value = poleLogModel.OutTemp; break;
                            case nameof(poleLogModel.Humi): item.Value = poleLogModel.Humi; break;
                            case nameof(poleLogModel.WindSpeed): item.Value = poleLogModel.WindSpeed; break;
                            case nameof(poleLogModel.Genneration): item.Value = poleLogModel.Genneration.ToString(); break;
                        }
                    }
                }));
            }
        }
    }

    public class DeviceList : BaseList<DeviceModel>
    {
        public static void GetList(DeviceList deviceList)
        {
            if (deviceList == null) return;

            foreach (var row in deviceList.dt.AsEnumerable())  // AsEnumerable() returns IEnumerable<DataRow>
            {
                DeviceModel deviceM = new DeviceModel(row);

                deviceList.Add(deviceM);
            }
        }

        public override void SelectData(object obj)
        {
            if ((obj is int) == false) return;

            int serverId = Convert.ToInt32(obj);

            dbMessage = string.Format("Select * from device_info where serverid = {0}", serverId);
        }

        public void SelectData(int serverId, string masterIp)
        {
            dbMessage = string.Format("Select * from device_info where serverid = {0} AND ip = '{1}'", serverId, masterIp);
        }
    }
}