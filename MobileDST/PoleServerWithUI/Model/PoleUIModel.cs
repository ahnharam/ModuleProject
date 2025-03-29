using System;
using System.Data;
using System.Windows.Forms;

namespace PoleServerWithUI.Model
{
    /*
     * CREATE TABLE `pole_ui` (
	`no` INT(11) NOT NULL,
	`name` VARCHAR(50) NULL DEFAULT NULL COMMENT '1. 폴 이름' COLLATE 'utf8_general_ci',
	`screen` VARCHAR(50) NULL DEFAULT NULL COMMENT '표시화면 설정' COLLATE 'utf8_general_ci',
	`Type` VARCHAR(50) NULL DEFAULT NULL COMMENT '폴 종류(영상폴/발전폴/충전폴)' COLLATE 'utf8_general_ci',
	`idname` VARCHAR(50) NULL DEFAULT NULL COMMENT '2. 폴 Slave Name' COLLATE 'utf8_general_ci',
	`id` VARCHAR(50) NULL DEFAULT NULL COMMENT '폴 ID' COLLATE 'utf8_general_ci',
	`bat` VARCHAR(20) NULL DEFAULT NULL COMMENT '3. 배터리' COLLATE 'utf8_general_ci',
	`bathour` VARCHAR(20) NULL DEFAULT NULL COMMENT '4. 배터리 사용 가능시간' COLLATE 'utf8_general_ci',
	`wireless` VARCHAR(20) NULL DEFAULT NULL COMMENT '5. 무선 감도' COLLATE 'utf8_general_ci',
	`error` VARCHAR(20) NULL DEFAULT NULL COMMENT '6. 고장 여부' COLLATE 'utf8_general_ci',
	`temp` VARCHAR(20) NULL DEFAULT NULL COMMENT '7. 온도 (value / 10)으로표시' COLLATE 'utf8_general_ci',
	`humi` VARCHAR(20) NULL DEFAULT NULL COMMENT '8. 습도 (value / 10)으로표시' COLLATE 'utf8_general_ci',
	`wind` VARCHAR(20) NULL DEFAULT NULL COMMENT '9. 풍량 (value / 10)으로표시' COLLATE 'utf8_general_ci',
	`genneration` VARCHAR(20) NULL DEFAULT NULL COMMENT '10. 생산량' COLLATE 'utf8_general_ci',
	`charge` VARCHAR(20) NULL DEFAULT NULL COMMENT '11. 충전률' COLLATE 'utf8_general_ci',
	`statistic` VARCHAR(20) NULL DEFAULT NULL COMMENT '통계' COLLATE 'utf8_general_ci'
	)
	COMMENT='통합 관제 UI Display 자료\r\n'
	COLLATE='utf8_general_ci'
	ENGINE=InnoDB
	ROW_FORMAT=DYNAMIC
     */

    public class PoleUIModel : BaseModel
    {
        // `no` INT(11) NOT NULL,
        private int no;

        public int No
        {
            get { return no; }
            set { SetProperty(ref no, value); }
        }

        // `sno` INT(11) NOT NULL,
        private int sNo;

        public int SNo
        {
            get { return sNo; }
            set { SetProperty(ref sNo, value); }
        }

        //`name` VARCHAR(50) NULL DEFAULT NULL COMMENT '1. 폴 이름' COLLATE 'utf8_general_ci',
        private string name;

        public string Name
        {
            get { return name; }
            set { SetProperty(ref name, value); }
        }

        //`screen` VARCHAR(50) NULL DEFAULT NULL COMMENT '표시화면 설정' COLLATE 'utf8_general_ci',
        private string screen;

        public string Screen
        {
            get { return screen; }
            set { SetProperty(ref screen, value); }
        }

        //`Type` VARCHAR(50) NULL DEFAULT NULL COMMENT '폴 종류(영상폴/발전폴/충전폴)' COLLATE 'utf8_general_ci',
        private string type;

        public string Type
        {
            get { return type; }
            set { SetProperty(ref type, value); }
        }

        //`idname` VARCHAR(50) NULL DEFAULT NULL COMMENT '2. 폴 Slave Name' COLLATE 'utf8_general_ci',
        private string idName;

        public string IDName
        {
            get { return idName; }
            set { SetProperty(ref idName, value); }
        }

        //`id` VARCHAR(50) NULL DEFAULT NULL COMMENT '폴 ID' COLLATE 'utf8_general_ci',
        private string id;

        public string ID
        {
            get { return id; }
            set { SetProperty(ref id, value); }
        }

        //`bat` VARCHAR(20) NULL DEFAULT NULL COMMENT '3. 배터리' COLLATE 'utf8_general_ci',
        private string bat;

        public string Bat
        {
            get { return bat; }
            set { SetProperty(ref bat, value); }
        }

        //`bathour` VARCHAR(20) NULL DEFAULT NULL COMMENT '4. 배터리 사용 가능시간' COLLATE 'utf8_general_ci',
        private string batHour;

        public string BatHour
        {
            get { return batHour; }
            set { SetProperty(ref batHour, value); }
        }

        //`wireless` VARCHAR(20) NULL DEFAULT NULL COMMENT '5. 무선 감도' COLLATE 'utf8_general_ci',
        private string wireLess;

        public string WireLess
        {
            get { return wireLess; }
            set { SetProperty(ref wireLess, value); }
        }

        //`error` VARCHAR(20) NULL DEFAULT NULL COMMENT '6. 고장 여부' COLLATE 'utf8_general_ci',
        private string error;

        public string Error
        {
            get { return error; }
            set { SetProperty(ref error, value); }
        }

        //`temp` VARCHAR(20) NULL DEFAULT NULL COMMENT '7. 온도 (value / 10)으로표시' COLLATE 'utf8_general_ci',
        private string temp;

        public string Temp
        {
            get { return temp; }
            set { SetProperty(ref temp, value); }
        }

        //`humi` VARCHAR(20) NULL DEFAULT NULL COMMENT '8. 습도 (value / 10)으로표시' COLLATE 'utf8_general_ci',
        private string humi;

        public string Humi
        {
            get { return humi; }
            set { SetProperty(ref humi, value); }
        }

        //`wind` VARCHAR(20) NULL DEFAULT NULL COMMENT '9. 풍량 (value / 10)으로표시' COLLATE 'utf8_general_ci',
        private string wind;

        public string Wind
        {
            get { return wind; }
            set { SetProperty(ref wind, value); }
        }

        //`genneration` VARCHAR(20) NULL DEFAULT NULL COMMENT '10. 생산량' COLLATE 'utf8_general_ci',
        private string genneration;

        public string Genneration
        {
            get { return genneration; }
            set { SetProperty(ref genneration, value); }
        }

        //`charge` VARCHAR(20) NULL DEFAULT NULL COMMENT '11. 충전률' COLLATE 'utf8_general_ci',
        private string charge;

        public string Charge
        {
            get { return charge; }
            set { SetProperty(ref charge, value); }
        }

        //`statistic` VARCHAR(20) NULL DEFAULT NULL COMMENT '통계' COLLATE 'utf8_general_ci'
        private string statistic;

        public string Statistic
        {
            get { return statistic; }
            set { SetProperty(ref statistic, value); }
        }

        public PoleUIModel()
        { }

        public PoleUIModel(DataRow dataRow) : base(dataRow)
        {
        }

        protected override void ConvertData(DataRow dataRow)
        {
            No = ConvertInt(dataRow, "no");
            SNo = ConvertInt(dataRow, "sno");
            Name = ConvertString(dataRow, "name");
            Screen = ConvertString(dataRow, "screen");
            Type = ConvertString(dataRow, "type");
            IDName = ConvertString(dataRow, "idname");
            ID = ConvertString(dataRow, "id");
            Bat = ConvertString(dataRow, "bat");
            BatHour = ConvertString(dataRow, "batour");
            WireLess = ConvertString(dataRow, "wireless");
            Error = ConvertString(dataRow, "error");
            Temp = ConvertString(dataRow, "temp");
            Humi = ConvertString(dataRow, "humi");
            Wind = ConvertString(dataRow, "wind");
            Genneration = ConvertString(dataRow, "genneration");
            Charge = ConvertString(dataRow, "charge");
            Statistic = ConvertString(dataRow, "statistic");
        }
    }

    public class PoleUIList : BaseList<PoleUIModel>
    {
        public static void GetList(PoleUIList poleUIList)
        {
            foreach (var row in poleUIList.dt.AsEnumerable())  // AsEnumerable() returns IEnumerable<DataRow>
            {
                PoleUIModel poleLogModel = new PoleUIModel(row);

                poleUIList.Add(poleLogModel);
            }
        }

        public override void SelectData(object obj)
        {
            if ((obj is int) == false) return;

            int sno = Convert.ToInt32(obj);

            dbMessage = string.Format(
                "SELECT " +
                "* " +
                "FROM " +
                "pole_ui " +
                "WHERE " +
                "sno = {0}"
                , sno);
        }

        public void SelectSid(object obj)
        {
            if ((obj is int) == false) return;

            int sid = Convert.ToInt32(obj);

            dbMessage = string.Format(
                "SELECT " +
                "* " +
                "FROM " +
                "pole_ui " +
                "WHERE " +
                "id = {0}"
                , sid);
        }

        //public void UpdatePoleUI(string id, string masterId, string percent, string wattage, string error = "1")
        //{
        //    return string.Format(
        //    "UPDATE " +
        //    "pole_ui " +
        //    "SET " +
        //    "bat = '{1}', " +
        //    "genneration = genneration + '{2}', " +
        //    "error = '{3}' " +
        //    "WHERE " +
        //    "id = '{0}' AND idname = '{4}'; ", id, percent, wattage, error, masterId);
        //}

        public override void UpdateData(object obj)
        {
            if ((obj is PoleLogModel) == false) return;

            PoleLogModel poleLogModel = (PoleLogModel)obj;

            dbMessage = string.Format(
             "UPDATE " +
                "pole_ui " +
                "SET " +
                "temp = '{1}', " +
                "humi = '{2}', " +
                "wind = '{3}', " +
                "genneration = '{4}' " +
                "WHERE " +
                "sno = '{0}' ; ", poleLogModel.SNo, poleLogModel.Temp, poleLogModel.Humi, poleLogModel.WindSpeed, poleLogModel.Genneration);
        }

        public void UpdateBattery(int sNo, string percent, string wattage, int error = 1)
        {
            dbMessage = string.Format(
                "UPDATE " +
                "pole_ui " +
                "SET " +
                "bat = '{1}', " +
                "charge = '{2}', " +
                "error = '{3}' " +
               "WHERE " +
                "sno = {0}; "
                , sNo, percent, wattage, error);

            if (error != 1) return;

            dbMessage += string.Format(
                "UPDATE " +
                "pole_ui " +
                "SET " +
                "wireless = wireless + 1 " +
                "WHERE " +
                "sno = {0} " +
                "AND " +
                "wireless < 5;", sNo);
        }

        public void UpdateReception(int sNo)
        {
            dbMessage = string.Format(
                "UPDATE " +
                "pole_ui " +
                "SET " +
                "wireless = wireless - 1 " +
                "WHERE " +
                "sno = {0} " +
                "AND " +
                "wireless > 0;", sNo);

            dbMessage += string.Format(
                "UPDATE " +
                "pole_ui " +
                "SET " +
                "error = 0 " +
                "WHERE " +
                "sno = {0} " +
                "AND " +
                "wireless = 0; ", sNo);
        }

        public void UpdatePhonePoleLog(int genneration, string tableName)
        {
            dbMessage = string.Format(
                "UPDATE " +
                "{1} " +
                "SET " +
                "generation =  generation + {0}, " +
                "netzero =  ROUND((SELECT SUM(genneration) FROM pole_ui WHERE screen = '3')/10 * 0.4662,2) " +
                "WHERE " +
                "no = 1;", genneration, tableName);
        }

        public void UpdateTotalLog(int genneration, string screen)
        {
            dbMessage = string.Format(
                "UPDATE " +
                "pole_ui_total " +
                "SET " +
                "cumulative_charge = cumulative_charge + 1, " +
                "cumulative_gen =  {0}," +
                "netzero = (SELECT SUM(genneration) FROM pole_ui WHERE screen = '{1}')/10 * 0.4662 " +
                "WHERE " +
                "screen = {1}; ", genneration, screen);
        }
    }
}