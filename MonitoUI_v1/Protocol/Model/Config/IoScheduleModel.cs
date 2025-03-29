using System;
using System.Data;

namespace Protocol.Model.Config
{
    public class IoScheduleModel : BaseM
    {
        private int no;

        public int No
        {
            get { return no; }
            set { SetProperty(ref no, value); }
        }

        private int section;

        public int Section
        {
            get { return section; }
            set { SetProperty(ref section, value); }
        }

        private int ioNo;

        public int IoNo
        {
            get { return ioNo; }
            set { SetProperty(ref ioNo, value); }
        }

        private DateTime date;

        public DateTime Date
        {
            get { return date; }
            set { SetProperty(ref date, value); }
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

        public IoScheduleModel()
        { }

        public IoScheduleModel(DataRow dataRow):base(dataRow)
        { }

        public override void ConvertData(DataRow dataRow)
        {
            this.No = ConvertInt(dataRow, "no");
            this.Section=ConvertInt(dataRow, "section");
            this.IoNo = ConvertInt(dataRow, "iono");
            this.Date = ConvertDate(dataRow, "date");
            this.StartTime = ConvertTime(dataRow, "starttime");
            this.EndTime = ConvertTime(dataRow, "endtime");
        }
    }

    public class IoScheduleList:BaseList<IoScheduleModel>
    { }
}