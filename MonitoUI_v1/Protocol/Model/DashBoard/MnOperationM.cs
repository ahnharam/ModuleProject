using MySqlX.XDevAPI.Relational;
using Prism.Mvvm;
using Protocol.Model.Common;
using Protocol.Model.Dashboard;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Protocol.Model.Dashboard
{
    public class MnOperationM : BaseM
    {
        private int no;
        public int No
        {
            get { return no; }
            set { SetProperty(ref no, value); }
        }

        private int groupNo;
        public int GroupNo
        {
            get { return groupNo; }
            set { SetProperty(ref groupNo, value); }
        }

        private string stationName;
        public string StationName
        {
            get { return stationName; }
            set { SetProperty(ref stationName, value); }
        }

        private int device;
        public int Device
        {
            get { return device; }
            set { SetProperty(ref device, value); }
        }

        private int dIcon;
        public int DIcon
        {
            get { return dIcon; }
            set { SetProperty(ref dIcon, value); }
        }

        private int defaultValue;
        public int DefaultValue
        {
            get { return defaultValue; }
            set { SetProperty(ref defaultValue, value); }
        }

        private int sort;
        public int Sort
        {
            get { return sort; }
            set { SetProperty(ref sort, value); }
        }

        private string function;
        public string Function
        {
            get { return function; }
            set { SetProperty(ref function, value); }
        }

        private int functionValue;
        public int FunctionValue
        {
            get { return functionValue; }
            set { SetProperty(ref functionValue, value); }
        }

        private string functionName;
        public string FunctionName
        {
            get { return functionName; }
            set { SetProperty(ref functionName, value); }
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

        public MnOperationM() { }

        public MnOperationM(DataRow dataRow) : base(dataRow)
        {
        }

        public override void ConvertData(DataRow dataRow)
        {
            try
            {
                this.No = ConvertInt(dataRow, "no");
                this.GroupNo = ConvertInt(dataRow, "groupno");
                this.StationName = ConvertString(dataRow, "stationname");
                this.Device = ConvertInt(dataRow, "device");
                this.DIcon = ConvertInt(dataRow, "dicon");
                this.DefaultValue = ConvertInt(dataRow, "defaultvalue");
                this.Sort = ConvertInt(dataRow, "sort");
            
                //if(this.DefaultValue != 0)
                //{
                //    this.Function = ConvertString(dataRow, "function");
                //    this.FunctionValue = ConvertInt(dataRow, "functionvalue");
                //    this.FunctionName = ConvertString(dataRow, "name");
                //}
                //this.RealTimeValue = null;
            }
            catch(Exception e)
            {
                Debug.WriteLine("Create MnOperationM Error : " + e.Message);
            }
        }
    }

    public class MnOperationList : BaseList<MnOperationM> { }
}
