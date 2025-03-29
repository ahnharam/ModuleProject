using Mysqlx;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoleServerWithUI.Model
{
    public class PoleLogModel : BaseModel
    {
        private int no;
        public int No
        {
            get { return no; }
            set { SetProperty(ref no, value); }
        }

        private int sNo;
        public int SNo
        {
            get { return sNo; }
            set { SetProperty(ref sNo, value); }
        }

        private string name;
        public string Name
        {
            get { return name; }
            set { SetProperty(ref name, value); }
        }

        private int screen;
        public int Screen
        {
            get { return screen; }
            set { SetProperty(ref screen, value); }
        }

        private string type;
        public string Type
        {
            get { return type; }
            set { SetProperty(ref type, value); }
        }

        private string mid;
        public string Mid
        {
            get { return mid; }
            set { SetProperty(ref mid, value); }
        }

        private string id;
        public string Id
        {
            get { return id; }
            set { SetProperty(ref id, value); }
        }

        private string poc;
        public string Poc
        {
            get { return poc; }
            set { SetProperty(ref poc, value); }
        }

        private string potml;
        public string Potml
        {
            get { return potml; }
            set { SetProperty(ref potml, value); }
        }

        private string potmh;
        public string Potmh
        {
            get { return potmh; }
            set { SetProperty(ref potmh, value); }
        }

        private string battery;
        public string Battery
        {
            get { return battery; }
            set { SetProperty(ref battery, value); }
        }

        private string solar;
        public string Solar
        {
            get { return solar; }
            set { SetProperty(ref solar, value); }
        }

        private string wind;
        public string Wind
        {
            get { return wind; }
            set { SetProperty(ref wind, value); }
        }

        private string outbat;
        public string Outbat
        {
            get { return outbat; }
            set { SetProperty(ref outbat, value); }
        }

        private string outPowerFirst;
        public string OutPowerFirst
        {
            get { return outPowerFirst; }
            set { SetProperty(ref outPowerFirst, value); }
        }

        private string outPowerSecond;
        public string OutPowerSecond
        {
            get { return outPowerSecond; }
            set { SetProperty(ref outPowerSecond, value); }
        }

        private string temp;
        public string Temp
        {
            get { return temp; }
            set { SetProperty(ref temp, value); }
        }

        private string outTemp;
        public string OutTemp
        {
            get { return outTemp; }
            set { SetProperty(ref outTemp, value); }
        }

        private string humi;
        public string Humi
        {
            get { return humi; }
            set { SetProperty(ref humi, value); }
        }

        private string windSpeed;
        public string WindSpeed
        {
            get { return windSpeed; }
            set { SetProperty(ref windSpeed, value); }
        }

        private string wireLess;
        public string WireLess
        {
            get { return wireLess; }
            set { SetProperty(ref wireLess, value); }
        }

        private string broken;
        public string Broken
        {
            get { return broken; }
            set { SetProperty(ref broken, value); }
        }

        private int genneration;
        public int Genneration
        {
            get { return genneration; }
            set { SetProperty(ref genneration, value); }
        }

        private string txData;
        public string TxData
        {
            get { return txData; }
            set { SetProperty(ref txData, value); }
        }

        public PoleLogModel() { }
        public PoleLogModel(DataRow dataRow) : base(dataRow) { }

        protected override void ConvertData(DataRow dataRow)
        {
            this.No = ConvertInt(dataRow, "no");
            this.SNo = ConvertInt(dataRow, "sno");
            this.Name = ConvertString(dataRow, "name");
            this.Screen = ConvertInt(dataRow, "screen");
            this.Type = ConvertString(dataRow, "type");
            this.Mid = ConvertString(dataRow, "mid");
            this.Id = ConvertString(dataRow, "id");
            this.Poc = ConvertString(dataRow, "poc");
            this.Potml = ConvertString(dataRow, "potml");
            this.Potmh = ConvertString(dataRow, "potmh");
            this.Battery = ConvertString(dataRow, "battery");
            this.Solar = ConvertString(dataRow, "solar");
            this.Wind = ConvertString(dataRow, "wind");
            this.Outbat = ConvertString(dataRow, "outbat");
            this.OutPowerFirst = ConvertString(dataRow, "outpowerfirst");
            this.OutPowerSecond = ConvertString(dataRow, "outpowersecond");
            this.Temp = ConvertString(dataRow, "temp");
            this.OutTemp = ConvertString(dataRow, "outtemp");
            this.Humi = ConvertString(dataRow, "humi");
            this.WindSpeed = ConvertString(dataRow, "windspeed");
            this.WireLess = ConvertString(dataRow, "wireless");
            this.Broken = ConvertString(dataRow, "broken");
        }
    }


    public class PoleLogList : BaseList<PoleLogModel>
    {

        public static void GetList(PoleLogList poleLogList)
        {
            if (poleLogList == null) return;

            foreach (var row in poleLogList.dt.AsEnumerable())  // AsEnumerable() returns IEnumerable<DataRow>
            {
                PoleLogModel poleLogModel = new PoleLogModel(row);

                poleLogList.Add(poleLogModel);
            }
        }


        ///<inheritdoc/>
        public override void SelectData(object obj)
        {
            if ((obj is int) == false) return;

            int serverId = Convert.ToInt32(obj);
            dbMessage = string.Format(
                "SELECT " +
                "plh.* " +
                "FROM " +
                "pole_log_haram plh " +
                "LEFT JOIN" +
                "(" +
                    "SELECT " +
                    "no " +
                    "FROM " +
                    "device_info " +
                    "WHERE serverid = {0}" +
                ") di " +
                "ON " +
                "plh.sno = di.no;"
                , serverId);
        }

        /// <inheritdoc/>
        //public override void UpdateData(object obj)
        //{
        //    if ((obj is int) == false) return;

        //    int sno = Convert.ToInt32(obj);

        //    dbMessage = string.Format(
        //        "UPDATE " +
        //        "pole_ui " +
        //        "SET " +
        //        "bat = '{1}', " +
        //        "genneration = genneration + '{2}', " +
        //        "error = '{3}' " +
        //       "WHERE " +
        //        "sno = {0}"
        //        , sno);
        //}

        public void UpdateError(object obj, string percent, string wattage, int error = 1)
        {
            if ((obj is PoleLogModel) == false) return;

            PoleLogModel poleLogModel = (PoleLogModel)obj;

            dbMessage = string.Format(
                "UPDATE " +
                "pole_ui " +
                "SET " +
                "bat = '{1}', " +
                "genneration = genneration + '{2}', " +
                "error = '{3}' " +
               "WHERE " +
                "sno = {0}"
                , poleLogModel.SNo, percent, wattage, error);
        }

        /// <inheritdoc/>
        public override void UpdateData(object obj)
        {
            if ((obj is PoleLogModel) == false) return;

            PoleLogModel PoleLogModel = (PoleLogModel)obj;

            dbMessage = string.Format(
                "UPDATE " +
                "pole_log_haram " +
                "SET " +
                "poc = '{1}', " +
                "potml = '{2}', " +
                "potmh = '{3}', " +
                "battery = '{4}', " +
                "solar = '{5}', " +
                "wind = '{6}', " +
                "outbat = '{7}', " +
                "outpowerfirst = '{8}', " +
                "outpowersecond = '{9}', " +
                "temp = '{10}', " +
                "outtemp = '{11}', " +
                "humi = '{12}', " +
                "windspeed = '{13}', " +
                "wireless = '{14}', " +
                "broken = '{15}' " +
                "WHERE " +
                "sno = {0}; ",
                PoleLogModel.SNo,
                PoleLogModel.Poc,
                PoleLogModel.Potml,
                PoleLogModel.Potmh,
                PoleLogModel.Battery,
                PoleLogModel.Solar,
                PoleLogModel.Wind,
                PoleLogModel.Outbat,
                PoleLogModel.OutPowerFirst,
                PoleLogModel.OutPowerSecond,
                PoleLogModel.Temp,
                PoleLogModel.OutTemp,
                PoleLogModel.Humi,
                PoleLogModel.WindSpeed,
                PoleLogModel.WireLess,
                PoleLogModel.Broken);
        }

        public override void InsertData(object obj)
        {
            if ((obj is PoleLogModel) == false) return;

            PoleLogModel PoleLogModel = (PoleLogModel)obj;

            dbMessage =
                string.Format("Insert Into pole_log_haram" +
               "(no, " +
               "sno " +
               "name, " +
               "screen, " +
               "Type, " +
               "mid, " +
               "id, " +
               "poc, " +
               "potml, " +
               "potmh, " +
               "battery, " +
               "solar, " +
               "wind, " +
               "outbat, " +
               "outpowerfirst, " +
               "outpowersecond, " +
               "temp, " +
               "outtemp, " +
               "humi, " +
               "windspeed, " +
               "wireless, " +
               "broken) " +
               "VALUES " +
               "({0},{1},'{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}','{18}','{19}','{20}','{21}'); ",
               PoleLogModel.No,
               PoleLogModel.SNo,
               PoleLogModel.Name,
               PoleLogModel.Screen,
               PoleLogModel.Type,
               PoleLogModel.Mid,
               PoleLogModel.Id,
               PoleLogModel.Poc,
               PoleLogModel.Potml,
               PoleLogModel.Potmh,
               PoleLogModel.Battery,
               PoleLogModel.Solar,
               PoleLogModel.Wind,
               PoleLogModel.Outbat,
               PoleLogModel.OutPowerFirst,
               PoleLogModel.OutPowerSecond,
               PoleLogModel.Temp,
               PoleLogModel.OutTemp,
               PoleLogModel.Humi,
               PoleLogModel.WindSpeed,
               PoleLogModel.WireLess,
               PoleLogModel.Broken);
        }
    }
}
