using System;
using System.Data;

namespace Protocol.Model.Common
{
    public class ErrorProcessModel : BaseM
    {
        private int no;

        public int No
        {
            get { return no; }
            set { SetProperty(ref no, value); }
        }

        private int errorNo;

        public int ErrorNo
        {
            get { return errorNo; }
            set { SetProperty(ref errorNo, value); }
        }

        private string name;

        public string Name
        {
            get { return name; }
            set { SetProperty(ref name, value); }
        }

        private int repeatCount;

        public int RepeatCount
        {
            get { return repeatCount; }
            set { SetProperty(ref repeatCount, value); }
        }

        private TimeSpan repeatTime;

        public TimeSpan RepeatTime
        {
            get { return repeatTime; }
            set { SetProperty(ref repeatTime, value); }
        }

        private int smsYN;

        public int SmsYN
        {
            get { return smsYN; }
            set { SetProperty(ref smsYN, value); }
        }

        private int smsReceiveNo;

        public int SmsReceiveNo
        {
            get { return smsReceiveNo; }
            set { SetProperty(ref smsReceiveNo, value); }
        }

        private int voice;

        public int Voice
        {
            get { return voice; }
            set { SetProperty(ref voice, value); }
        }

        private int deviceNo;

        public int DeviceNo
        {
            get { return deviceNo; }
            set { SetProperty(ref deviceNo, value); }
        }

        private int deviceFunction;

        public int DeviceFunction
        {
            get { return deviceFunction; }
            set { SetProperty(ref deviceFunction, value); }
        }

        public ErrorProcessModel()
        { }

        public ErrorProcessModel(DataRow dataRow):base(dataRow)
        { }

        public override void ConvertData(DataRow dataRow)
        {
            this.No = ConvertInt(dataRow, "no");
            this.ErrorNo = ConvertInt(dataRow, "errorno");
            this.Name=ConvertString(dataRow, "name");
            this.RepeatCount = ConvertInt(dataRow, "repeatcount");
            this.RepeatTime = ConvertTime(dataRow, "repeattime");
            this.SmsYN = ConvertInt(dataRow, "smsyn");
            this.SmsReceiveNo = ConvertInt(dataRow, "smsreceiveno");
            this.Voice = ConvertInt(dataRow, "voice");
            this.DeviceNo = ConvertInt(dataRow, "deviceno");
            this.DeviceFunction = ConvertInt(dataRow, "devicefunction");
        }
    }

    public class ErrorProcessList:BaseList<ErrorProcessModel>
    { }
}