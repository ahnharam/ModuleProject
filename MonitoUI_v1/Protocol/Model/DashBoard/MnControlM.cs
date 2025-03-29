using Protocol.Model.Common;
using System.Data;

namespace Protocol.Model.Dashboard
{
    public class MnControlM : BaseM
    {
        private int no;

        public int No
        {
            get { return no; }
            set { SetProperty(ref no, value); }
        }

        private int stationNo;

        public int StationNo
        {
            get { return stationNo; }
            set { SetProperty(ref stationNo, value); }
        }

        private string name;

        public string Name
        {
            get { return name; }
            set { SetProperty(ref name, value); }
        }

        private string className;

        public string ClassName
        {
            get { return className; }
            set { SetProperty(ref className, value); }
        }

        private int device;

        public int Device
        {
            get { return device; }
            set { SetProperty(ref device, value); }
        }

        private int function;

        public int Function
        {
            get { return function; }
            set { SetProperty(ref function, value); }
        }

        private int defaultValue;

        public int DefaultValue
        {
            get { return defaultValue; }
            set { SetProperty(ref defaultValue, value); }
        }

        private int type;

        public int Type
        {
            get { return type; }
            set { SetProperty(ref type, value); }
        }

        private int sort;

        public int Sort
        {
            get { return sort; }
            set { SetProperty(ref sort, value); }
        }

        private string realTimeValue;

        public string RealTimeValue
        {
            get { return realTimeValue; }
            set { SetProperty(ref realTimeValue, value); }
        }

        private DeviceM deviceM;

        public DeviceM DeviceM
        {
            get { return deviceM; }
            set { SetProperty(ref deviceM, value); }
        }

        private DeviceFunctionList deviceFunctionList;
        public DeviceFunctionList DeviceFunctionList
        {
            get { return deviceFunctionList; }
            set { SetProperty(ref deviceFunctionList, value); }
        }


        private DeviceFunctionM deviceFunction;
        public DeviceFunctionM DeviceFunction
        {
            get { return deviceFunction; }
            set { SetProperty(ref deviceFunction, value); }
        }

        public void GetDeviceFunction(int functionValue)
        {
            foreach (var item in this.DeviceFunctionList)
            {
                if (item.FunctionValue == functionValue)
                {
                    DeviceFunction = item;
                    return;
                }
            }
        }

        public MnControlM(DataRow row) : base(row)
        { }

        public override void ConvertData(DataRow dataRow)
        {
            this.No = ConvertInt(dataRow, "no");
            this.stationNo = ConvertInt(dataRow, "stationno");
            this.Name = ConvertString(dataRow, "name");
            this.ClassName = ConvertString(dataRow, "classname");
            this.Device = ConvertInt(dataRow, "device");
            this.Function = ConvertInt(dataRow, "function");
            this.DefaultValue = ConvertInt(dataRow, "defaultvalue");
            this.Type = ConvertInt(dataRow, "type");
            this.Sort = ConvertInt(dataRow, "sort");
            this.RealTimeValue = null;
        }
    }

    public class MnControlList : BaseList<MnControlM>
    { }
}