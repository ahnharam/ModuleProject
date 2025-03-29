using System;
using System.Data;
using System.Diagnostics;

namespace Protocol.Model.Dashboard
{
    public class MnStationM : BaseM
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

        private string name;

        public string Name
        {
            get { return name; }
            set { SetProperty(ref name, value); }
        }

        private int deviceNo;

        public int DeviceNo
        {
            get { return deviceNo; }
            set { SetProperty(ref deviceNo, value); }
        }

        private string ip;

        public string Ip
        {
            get { return ip; }
            set { SetProperty(ref ip, value); }
        }

        private int sort;

        public int Sort
        {
            get { return sort; }
            set { SetProperty(ref sort, value); }
        }

        private bool defaultYN;

        public bool DefaultYN
        {
            get { return defaultYN; }
            set { SetProperty(ref defaultYN, value); }
        }

        public MnStationM()
        { }

        public MnStationM(DataRow dataRow) : base(dataRow)
        { }

        public override void ConvertData(DataRow dataRow)
        {
            try
            {
                this.No = ConvertInt(dataRow, "no");
                this.GroupNo = ConvertInt(dataRow, "groupno");
                this.Name = ConvertString(dataRow, "name");
                this.DeviceNo = ConvertInt(dataRow, "deviceno");
                this.Ip = ConvertString(dataRow, "ip");
                this.Sort = ConvertInt(dataRow, "sort");
                this.DefaultYN = ConvertBoolean(dataRow, "defaultyn");
            }

            catch(Exception e)
            {
                Debug.WriteLine("스테이션 정보를 불러오는 중에 오류가 발생하였습니다. Error : " + e);
            }
        }
    }

    public class MnStationList : BaseList<MnStationM>
    { }
}