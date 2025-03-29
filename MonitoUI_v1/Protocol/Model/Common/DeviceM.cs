using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Protocol.Model.Common
{
    public class DeviceM : BaseM, IBaseMInterface
    {
        private int no;
        public int No
        {
            get { return no; }
            set { SetProperty(ref no, value); }
        }

        private string deviceName;
        public string DeviceName
        {
            get { return deviceName; }
            set { SetProperty(ref deviceName, value); }
        }

        private int type;
        public int Type
        {
            get { return type; }
            set { SetProperty(ref type, value); }
        }

        private int powerPort;
        public int PowerPort
        {
            get { return powerPort; }
            set { SetProperty(ref powerPort, value); }
        }

        private int sio;
        public int Sio
        {
            get { return sio; }
            set { SetProperty(ref sio, value); }
        }

        private string dataValue;
        public string DataValue
        {
            get { return dataValue; }
            set { SetProperty(ref dataValue, value); }
        }

        public DeviceM() { }

        public DeviceM(DataRow dataRow) : base(dataRow)
        {
        }

        public override void ConvertData(DataRow dataRow)
        {
            this.No = ConvertInt(dataRow, "no");
            this.DeviceName = ConvertString(dataRow, "devicename");
            this.Type = ConvertInt(dataRow, "type");
            this.PowerPort = ConvertInt(dataRow, "powerport");
            this.Sio = ConvertInt(dataRow, "sio");
            this.DataValue = ConvertString(dataRow, "datavalue");
        }
    }

    public class DeviceList : BaseList<DeviceM> { }
}
