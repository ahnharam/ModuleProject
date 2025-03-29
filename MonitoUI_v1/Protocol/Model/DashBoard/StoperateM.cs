using MySqlX.XDevAPI.Relational;
using Protocol.Model.Dashboard;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Protocol.Model.Dashboard
{
    public class StoperateM : BaseM
    {
        private int no;
        public int No
        {
            get { return no; }
            set { SetProperty(ref no, value); }
        }

        private string group;
        public string Group
        {
            get { return group; }
            set { SetProperty(ref group, value); }
        }

        private int stationNo;
        public int StationNo
        {
            get { return stationNo; }
            set { SetProperty(ref stationNo, value); }
        }

        private string stationName;
        public string StationName
        {
            get { return stationName; }
            set { SetProperty(ref stationName, value); }
        }

        private TimeSpan startTime;
        public TimeSpan StartTime
        {
            get { return startTime; }
            set { SetProperty(ref startTime, value); }
        }

        private string startTimeTT;
        public string StartTimeTT
        {
            get { return startTimeTT; }
            set { SetProperty(ref startTimeTT, value); }
        }

        private TimeSpan endTime;
        public TimeSpan EndTime
        {
            get { return endTime; }
            set { SetProperty(ref endTime, value); }
        }

        private string endTimeTT;
        public string EndTimeTT
        {
            get { return endTimeTT; }
            set { SetProperty(ref endTimeTT, value); }
        }

        private string user;
        public string User
        {
            get { return user; }
            set { SetProperty(ref user, value); }
        }

        private string visitantMon;
        public string VisitantMon
        {
            get { return visitantMon; }
            set { SetProperty(ref visitantMon, value); }
        }

        private string visitantDay;
        public string VisitantDay
        {
            get { return visitantDay; }
            set { SetProperty(ref visitantDay, value); }
        }

        private int sort;
        public int Sort
        {
            get { return sort; }
            set { SetProperty(ref sort, value); }
        }

        private UserControl timeControl;
        public UserControl TimeControl
        {
            get { return timeControl; }
            set { SetProperty(ref timeControl, value); }
        }

        public StoperateM() { }

        public StoperateM(DataRow dataRow) : base(dataRow) { }

        public override void ConvertData(DataRow dataRow)
        {
            try
            {
                TimeSpan timeSpan = new TimeSpan(12, 00, 00);
                this.No = ConvertInt(dataRow, "no");
                this.Group = ConvertString(dataRow, "group");
                this.StationNo = ConvertInt(dataRow, "stationno");
                this.StationName = ConvertString(dataRow, "stationname");
                this.StartTime = ConvertTime(dataRow, "starttime");
                this.StartTimeTT = StartTime < timeSpan ? "AM" : "PM";
                this.EndTime = ConvertTime(dataRow, "endtime");
                this.EndTimeTT = EndTime < timeSpan ? "AM" : "PM";
                this.User = ConvertString(dataRow, "user");
                this.VisitantMon = ConvertString(dataRow, "visitantmon");
                this.VisitantDay = ConvertString(dataRow, "visitantday");
                this.Sort = ConvertInt(dataRow, "sort");
            }
            catch (Exception e)
            {
                Debug.WriteLine("Create TimeM Error : " + e.Message);
            }
        }
    }


    public class StoperateList : BaseList<StoperateM>
    { }
}
