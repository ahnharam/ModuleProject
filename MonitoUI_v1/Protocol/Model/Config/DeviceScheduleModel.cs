using System;
using System.Data;

namespace Protocol.Model.Config
{
    public class DeviceScheduleModel : BaseM
    {
        private int no;

        public int No
        {
            get { return no; }
            set { SetProperty(ref no, value); }
        }

        private DateTime date;

        public DateTime Date
        {
            get { return date; }
            set { SetProperty(ref date, value); }
        }

        private int deviceNo;

        public int DeviceNo
        {
            get { return deviceNo; }
            set { SetProperty(ref deviceNo, value); }
        }

        private TimeSpan startTime;

        public TimeSpan StartTime
        {
            get { return startTime; }
            set { SetProperty(ref startTime, value); }
        }

        private TimeSpan endTime;

        public TimeSpan EndTime
        {
            get { return endTime; }
            set { SetProperty(ref endTime, value); }
        }

        private int errorValue;

        public int ErrorValue
        {
            get { return errorValue; }
            set { SetProperty(ref errorValue, value); }
        }

        private int settingValue;

        public int SettingValue
        {
            get { return settingValue; }
            set { SetProperty(ref settingValue, value); }
        }

        private int maxValue;

        public int MaxValue
        {
            get { return maxValue; }
            set { SetProperty(ref maxValue, value); }
        }

        private int minValue;

        public int MinValue
        {
            get { return minValue; }
            set { SetProperty(ref minValue, value); }
        }

        private int settingMode;

        public int SettingMode
        {
            get { return settingMode; }
            set { SetProperty(ref settingMode, value); }
        }

        private int smsReceiveNo;

        public int SmsReceiveNo
        {
            get { return smsReceiveNo; }
            set { SetProperty(ref smsReceiveNo, value); }
        }

        public DeviceScheduleModel()
        { }

        public DeviceScheduleModel(DataRow dataRow):base(dataRow)
        { }

        public override void ConvertData(DataRow dataRow)
        {
            this.No = ConvertInt(dataRow, "no");
            this.Date = ConvertDate(dataRow, "date");
            this.DeviceNo = ConvertInt(dataRow, "deviceno");
            this.StartTime = ConvertTime(dataRow, "starttime");
            this.EndTime = ConvertTime(dataRow, "endtime");
            this.ErrorValue = ConvertInt(dataRow, "errorvalue");
            this.SettingValue = ConvertInt(dataRow, "settingvalue");
            this.MaxValue = ConvertInt(dataRow, "maxvalue");
            this.MinValue = ConvertInt(dataRow, "minvalue");
            this.SettingMode = ConvertInt(dataRow, "settingmode");
            this.SmsReceiveNo = ConvertInt(dataRow, "smsreceiveno");
        }
    }

    public class DeviceScheduleList:BaseList<DeviceScheduleModel>
    { }
}