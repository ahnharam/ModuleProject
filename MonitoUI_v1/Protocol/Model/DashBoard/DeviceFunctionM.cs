using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Protocol.Model.Dashboard
{
    public  class DeviceFunctionM : BaseM
    {
        private int no;
        public int No
        {
            get { return no; }
            set { SetProperty(ref no, value); }
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

        private string name;
        public string Name
        {
            get { return name; }
            set { SetProperty(ref name, value); }
        }

        private int groupNo;
        public int GroupNo
        {
            get { return groupNo; }
            set { SetProperty(ref groupNo, value); }
        }

        public DeviceFunctionM() { }

        public DeviceFunctionM(DataRow dataRow) : base(dataRow) { }

        public override void ConvertData(DataRow dataRow)
        {
            try
            {
                this.No = ConvertInt(dataRow, "no");
                this.Function = ConvertString(dataRow, "function");
                this.FunctionValue = ConvertInt(dataRow, "functionvalue");
                this.Name = ConvertString(dataRow, "name");
                this.GroupNo = ConvertInt(dataRow, "groupno");
            }
            catch (Exception e)
            {
                Debug.WriteLine("스테이션 정보를 불러오는 중에 오류가 발생하였습니다. Error : " + e);
            }
        }
    }

    public class DeviceFunctionList : BaseList<DeviceFunctionM> {
    }
}
