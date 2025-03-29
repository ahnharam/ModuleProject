using MySql.Data.MySqlClient;
using PoleServerWithUI.Model;
using System;
using System.Collections.ObjectModel;
using System.Windows.Threading;

namespace PoleServerWithUI.Utils
{
    internal class DatabaseConnect
    {
        private MySqlConnection _conn = null;
        private bool _dbState = false;
        private string _dbTable = string.Empty;

        private DatabaseModel _databaseModel = null;

        // Property
        private static DatabaseConnect _instance { get; set; }

        public static DatabaseConnect Instance
        {
            get
            {
                return _instance ?? (_instance = new DatabaseConnect());
            }
        }

        public bool ConnectCheck()
        {
            if (_conn == null)
                return false;
            else if (_conn.State.ToString() == "Open")
                return true;
            else
                return false;
        }

        public bool ConnectDB(DatabaseModel DatabaseModel)
        {
            string connectString =
                string.Format("Server={0};Port={1};Database={2};Uid ={3};Pwd={4};CharSet=utf8;",
                DatabaseModel.ServerIp,
                DatabaseModel.ServerPort,
                DatabaseModel.Database,
                DatabaseModel.Uid,
                DatabaseModel.Pwd);

            _conn = new MySqlConnection(connectString);

            try
            {
                _conn.Open();
                _dbState = true;
                _dbTable = DatabaseModel.Database;
                return _dbState;
            }
            catch (Exception e)
            {
                _dbState = false;
                DispatcherService.Invoke((System.Action)(() =>
                {
                    LogMessage.Instance.LogWrite("DB Connected Error : " + e);
                }));
                return _dbState;
            }
        }

        public void DBTimer(DatabaseModel DatabaseModel)
        {
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(10000);    //시간간격 설정
            timer.Tick += new EventHandler(ConnectingCheckEvent);          //이벤트 추가
            timer.Start();                                       //타이머 시작. 종료는 timer.Stop(); 으로 한다
            _databaseModel = DatabaseModel;
        }

        private void ConnectingCheckEvent(object sender, EventArgs e)
        {
            //여기에 실행시킬 구문을 입력하면 된다

            if (ConnectCheck() == false)
            {
                ConnectDB(_databaseModel);
            }
        }

        private void ConnectingCheckEvent()
        {
            //여기에 실행시킬 구문을 입력하면 된다

            if (ConnectCheck() == false)
            {
                ConnectDB(_databaseModel);
            }
        }

        public void Disconnect()
        {
            try
            {
                _conn.Close();
            }
            catch (Exception e)
            {
                DispatcherService.Invoke((System.Action)(() =>
                {
                    LogMessage.Instance.LogWrite("DB DisConnected Error : " + e);
                }));
            }
        }

        public ObservableCollection<DeviceModel> SelectDB(int deviceId)
        {
            ObservableCollection<DeviceModel> deviceModels = new ObservableCollection<DeviceModel>();
            string sql = string.Format("Select * from device_info where serverid = {0} ORDER BY sid", deviceId);

            if (_dbState)
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand(sql, _conn);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            deviceModels.Add(new DeviceModel
                            {
                                No = Convert.ToInt32(reader["NO"]),
                                MasterName = reader["mastername"].ToString().Replace(" ", "").Replace("\r\n", ""),
                                Screen = reader["screen"].ToString().Replace(" ", "").Replace("\r\n", ""),
                                Id = reader["id"].ToString().Replace(" ", "").Replace("\r\n", ""),
                                Sid = reader["sid"].ToString().Replace(" ", "").Replace("\r\n", ""),
                                DisplayName = reader["sid"].ToString().Replace(" ", "").Replace("\r\n", "") + "(" + Convert.ToInt32(reader["sid"].ToString().Replace(" ", "").Replace("\r\n", "")).ToString("X") + ")",
                                Name = reader["name"].ToString().Replace(" ", "").Replace("\r\n", ""),
                                Ip = reader["ip"].ToString().Replace(" ", "").Replace("\r\n", ""),
                                Port = reader["port"].ToString().Replace(" ", "").Replace("\r\n", ""),
                                TxData = reader["txdata"].ToString().Replace(" ", "").Replace("\r\n", "")
                            });
                        }
                    }
                    return deviceModels;
                }
                catch (Exception e)
                {
                    DispatcherService.Invoke((System.Action)(() =>
                    {
                        LogMessage.Instance.LogWrite("DB Select Error : " + e);
                        ConnectingCheckEvent();
                    }));
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

        public bool SelectId(int no)
        {
            bool dataCheck = false;

            ObservableCollection<DeviceModel> deviceModels = new ObservableCollection<DeviceModel>();
            string sql = string.Format(
                "SELECT " +
                "* " +
                "FROM " +
                "pole_log_haram " +
                "WHERE " +
                "no = {0}"
                , no);

            try
            {
                if (_dbState)
                {
                    MySqlCommand cmd = new MySqlCommand(sql, _conn);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                            dataCheck = true;
                    }
                }

                return dataCheck;
            }
            catch (Exception e)
            {
                DispatcherService.Invoke((System.Action)(() =>
                {
                    LogMessage.Instance.LogWrite("DB Select Error : " + e);
                }));
                return dataCheck;
            }
        }

        public bool SelectPole(int id)
        {
            bool dataCheck = false;

            ObservableCollection<DeviceModel> deviceModels = new ObservableCollection<DeviceModel>();
            string sql = string.Format(
                "SELECT " +
                "* " +
                "FROM " +
                "pole_ui " +
                "WHERE " +
                "id = {0}"
                , id);

            try
            {
                if (_dbState)
                {
                    MySqlCommand cmd = new MySqlCommand(sql, _conn);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            dataCheck = true;
                        }
                    }
                }

                return dataCheck;
            }
            catch (Exception e)
            {
                DispatcherService.Invoke((System.Action)(() =>
                {
                    LogMessage.Instance.LogWrite("DB Select Error : " + e);
                }));
                return dataCheck;
            }
        }

        public int SelectPolelog(int id)
        {
            int dataCheck = -1;

            ObservableCollection<DeviceModel> deviceModels = new ObservableCollection<DeviceModel>();
            string sql = string.Format(
                "SELECT " +
                "genneration " +
                "FROM " +
                "pole_ui " +
                "WHERE " +
                "id = {0}"
                , id);

            try
            {
                if (_dbState)
                {
                    MySqlCommand cmd = new MySqlCommand(sql, _conn);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            dataCheck = Convert.ToInt32(reader["genneration"].ToString());
                        }
                    }
                }

                return dataCheck;
            }
            catch (Exception e)
            {
                DispatcherService.Invoke((System.Action)(() =>
                {
                    LogMessage.Instance.LogWrite("DB Select Error : " + e);
                }));
                return dataCheck;
            }
        }

        public int[] SelectBatVInfo(PoleLogModel poleLogModel)
        {
            int[] dataCheck = new int[2];

            int bat = Convert.ToInt32(poleLogModel.Battery);

            string sql = string.Format(
                "SELECT " +
                "wattage, percent " +
                "FROM " +
                "batV_info b " +
                "WHERE " +
                "b.from <= {0} " +
                "AND b.to >= {0} "
                , bat);

            try
            {
                if (_dbState)
                {
                    MySqlCommand cmd = new MySqlCommand(sql, _conn);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            dataCheck[0] = Convert.ToInt32(reader["wattage"].ToString());
                            dataCheck[1] = Convert.ToInt32(reader["percent"].ToString());
                        }
                    }
                }

                return dataCheck;
            }
            catch (Exception e)
            {
                DispatcherService.Invoke((System.Action)(() =>
                {
                    LogMessage.Instance.LogWrite("DB Select Error : " + e);
                }));
                return null;
            }
        }

        public bool SelectPolelog(string tableName)
        {
            bool dataCheck = false;

            ObservableCollection<DeviceModel> deviceModels = new ObservableCollection<DeviceModel>();
            string sql = string.Format(
                "SELECT " +
                "* " +
                "FROM " +
                "`{0}` " +
                "WHERE " +
                "no = 1"
                , tableName);

            try
            {
                if (_dbState)
                {
                    MySqlCommand cmd = new MySqlCommand(sql, _conn);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                            dataCheck = true;
                    }
                }

                return dataCheck;
            }
            catch (Exception e)
            {
                DispatcherService.Invoke((System.Action)(() =>
                {
                    LogMessage.Instance.LogWrite("DB Select Error : " + e);
                }));
                return dataCheck;
            }
        }

        public bool SelectPoleUiTotal(string tableName, int screen)
        {
            bool dataCheck = false;

            ObservableCollection<DeviceModel> deviceModels = new ObservableCollection<DeviceModel>();
            string sql = string.Format(
                "SELECT " +
                "* " +
                "FROM " +
                "`{0}` " +
                "WHERE " +
                "screen = {1}"
                , tableName, screen);

            try
            {
                if (_dbState)
                {
                    MySqlCommand cmd = new MySqlCommand(sql, _conn);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                            dataCheck = true;
                    }
                }

                return dataCheck;
            }
            catch (Exception e)
            {
                DispatcherService.Invoke((System.Action)(() =>
                {
                    LogMessage.Instance.LogWrite("DB Select Error : " + e);
                }));
                return dataCheck;
            }
        }

        public void InsertPoleLog(PoleLogModel poleLogModel)
        {
            string sql = string.Empty;
            string poleLog = string.Empty;
            string dataLog = string.Empty;
            if (SelectId(poleLogModel.No) == true)
            {
                sql = string.Format(
                "UPDATE " +
                "pole_log_haram " +
                "SET " +
                "name = '{1}', " +
                "screen = '{2}', " +
                "Type = '{3}', " +
                "mid = '{4}', " +
                "id = '{5}', " +
                "poc = '{6}', " +
                "potml = '{7}', " +
                "potmh = '{8}', " +
                "battery = '{9}', " +
                "solar = '{10}', " +
                "wind = '{11}', " +
                "outbat = '{12}', " +
                "outpowerfirst = '{13}', " +
                "outpowersecond = '{14}', " +
                "temp = '{15}', " +
                "outtemp = '{16}', " +
                "humi = '{17}', " +
                "windspeed = '{18}', " +
                "wireless = '{19}', " +
                "broken = '{20}' " +
                "WHERE " +
                "no = {0}; ",
                poleLogModel.No,
                poleLogModel.Name,
                poleLogModel.Screen,
                poleLogModel.Type,
                poleLogModel.MId,
                poleLogModel.Id,
                poleLogModel.Poc,
                poleLogModel.Potml,
                poleLogModel.Potmh,
                poleLogModel.Battery,
                poleLogModel.Solar,
                poleLogModel.Wind,
                poleLogModel.Outbat,
                poleLogModel.Outpowerfirst,
                poleLogModel.Outpowersecond,
                poleLogModel.Temp,
                poleLogModel.Outtemp,
                poleLogModel.Humi,
                poleLogModel.Windspeed,
                poleLogModel.Wireless,
                poleLogModel.Broken);
            }
            else
            {
                sql = string.Format(
               "Insert Into pole_log_haram" +
               "(no, " +
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
               "({0},'{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}','{18}','{19}','{20}'); ",
               poleLogModel.No,
               poleLogModel.Name,
               poleLogModel.Screen,
               poleLogModel.Type,
               poleLogModel.MId,
               poleLogModel.Id,
               poleLogModel.Poc,
               poleLogModel.Potml,
               poleLogModel.Potmh,
               poleLogModel.Battery,
               poleLogModel.Solar,
               poleLogModel.Wind,
               poleLogModel.Outbat,
               poleLogModel.Outpowerfirst,
               poleLogModel.Outpowersecond,
               poleLogModel.Temp,
               poleLogModel.Outtemp,
               poleLogModel.Humi,
               poleLogModel.Windspeed,
               poleLogModel.Wireless,
               poleLogModel.Broken);
            }

            int dataCheck = SelectPolelog(Convert.ToInt32(poleLogModel.Id));
            int genneration = 0;
            if (dataCheck != -1)
            { 
                genneration =
                    Convert.ToInt32(poleLogModel.Battery)
                    + Convert.ToInt32(poleLogModel.Solar)
                    + Convert.ToInt32(poleLogModel.Wind);
                poleLog = string.Format(
                "UPDATE " +
                "pole_ui " +
                "SET " +
                "temp = '{1}', " +
                "humi = '{2}', " +
                "wind = '{3}', " +
                "genneration = '{4}' " +
                "WHERE " +
                "id = '{0}' AND idname = '{5}' ; ", poleLogModel.Id, poleLogModel.Temp, poleLogModel.Humi, poleLogModel.Windspeed, genneration, poleLogModel.MId);
            }
            else
            {
                DispatcherService.Invoke((System.Action)(() =>
                {
                    LogMessage.Instance.LogWrite("pole_ui DB Data Empty");
                }));
            }

            switch (poleLogModel.Screen)
            {
                case "1":
                    dataLog = UpdateVideoPoleLog(genneration);
                    break;

                case "2":
                    dataLog = UpdateCabonPoleLog(genneration);
                    dataLog += UpdatePoleUiTotal(genneration, 2);
                    break;

                case "3":
                    dataLog = UpdatePhonePoleLog(genneration);
                    dataLog += UpdatePoleUiTotal(genneration, 3);
                    break;
            }

            DispatcherService.Invoke((System.Action)(() =>
            {
                LogMessage.Instance.LogWrite("db connection : " + _dbState);
                LogMessage.Instance.LogWrite("sql data : " + sql);
                LogMessage.Instance.LogWrite("pole_ui data : " + poleLog);
                LogMessage.Instance.LogWrite("total data : " + dataLog);
            }));

            DataSend(sql + poleLog + dataLog);
        }

        public string UpdateVideoPoleLog(int genneration)
        {
            string videoLog = string.Empty;

            if (SelectPolelog("video_pole") == true)
            {
                if (genneration != -1)
                {
                    videoLog = string.Format(
                       "UPDATE " +
                       "video_pole " +
                       "SET " +
                       "generation = generation + '{0}', " +
                       "netzero =  ROUND((SELECT SUM(genneration) FROM pole_ui WHERE screen = '1')/10 * 0.4662,2) " +
                       "WHERE " +
                       "no = 1 ; ", genneration);
                }
                else
                {
                    DispatcherService.Invoke((System.Action)(() =>
                    {
                        LogMessage.Instance.LogWrite("pole_ui DB Data Empty");
                    }));
                }
            }
            else
            {
                DispatcherService.Invoke((System.Action)(() =>
                {
                    LogMessage.Instance.LogWrite("video_pole DB Data Empty");
                }));
            }
            DispatcherService.Invoke((System.Action)(() =>
            {
                LogMessage.Instance.LogWrite("video_pole data : " + videoLog);
            }));

            return videoLog;
        }

        public string UpdateCabonPoleLog(int genneration)
        {
            string videoLog = string.Empty;

            if (SelectPolelog("cabon_pole") == true)
            {
                videoLog = string.Format(
                    "UPDATE " +
                    "cabon_pole " +
                    "SET " +
                    "generation =  generation +  {0}, " +
                    "netzero =  ROUND((SELECT SUM(genneration) FROM pole_ui WHERE screen = '2')/10 * 0.4662,2) " +
                    "WHERE " +
                    "cabon_pole.`no` = 1;", genneration);
            }
            else
            {
                DispatcherService.Invoke((System.Action)(() =>
                {
                    LogMessage.Instance.LogWrite("video_pole DB Data Empty");
                }));
            }
            DispatcherService.Invoke((System.Action)(() =>
            {
                LogMessage.Instance.LogWrite("video_pole data : " + videoLog);
            }));

            return videoLog;
        }

        public string UpdatePhonePoleLog(int genneration)
        {
            string videoLog = string.Empty;

            if (SelectPolelog("phone_pole") == true)
            {
                videoLog = string.Format(
                    "UPDATE " +
                    "phone_pole " +
                    "SET " +
                    "generation =  generation + {0}, " +
                    "netzero =  ROUND((SELECT SUM(genneration) FROM pole_ui WHERE screen = '3')/10 * 0.4662,2) " +
                    "WHERE " +
                    "phone_pole.`no` = 1;", genneration);
            }
            else
            {
                DispatcherService.Invoke((System.Action)(() =>
                {
                    LogMessage.Instance.LogWrite("video_pole DB Data Empty");
                }));
            }
            DispatcherService.Invoke((System.Action)(() =>
            {
                LogMessage.Instance.LogWrite("video_pole data : " + videoLog);
            }));

            return videoLog;
        }

        public string UpdatePoleUiTotal(int genneration, int screen)
        {
            string poleUiTotalLog = string.Empty;

            if (SelectPoleUiTotal("pole_ui_total", screen) == true)
            {
                poleUiTotalLog = string.Format(
                    "UPDATE " +
                    "pole_ui_total " +
                    "SET " +
                    "cumulative_charge = cumulative_charge + 1, " +
                    "cumulative_gen =  {0}," +
                    "netzero = (SELECT SUM(genneration) FROM pole_ui WHERE screen = '{1}')/10 * 0.4662 " +
                    "WHERE " +
                    "screen = {1}; ", genneration, screen);
            }
            else
            {
                DispatcherService.Invoke((System.Action)(() =>
                {
                    LogMessage.Instance.LogWrite("poleUiTotalLog DB Data Empty");
                }));
            }
            DispatcherService.Invoke((System.Action)(() =>
            {
                LogMessage.Instance.LogWrite("poleUiTotalLog data : " + poleUiTotalLog);
            }));

            return poleUiTotalLog;
        }

        public void InsertPoleUI(string masterId, int id, int[] data, int error = 1)
        {
            string sql = string.Empty;
            string sendData = string.Empty;
            string videoLog = string.Empty;

            int dataCheck = SelectPolelog(id);
            int wattage = data[1];
            int percent = data[0];
            if (dataCheck != -1)
            {
                sendData = string.Format(
                "UPDATE " +
                "pole_ui " +
                "SET " +
                "bat = '{1}', " +
                "genneration = genneration + '{2}', " +
                "error = '{3}' " +
                "WHERE " +
                "id = '{0}' AND idname = '{4}'; ", id, percent, wattage, error, masterId);
            }
            else
            {
                DispatcherService.Invoke((System.Action)(() =>
                {
                    LogMessage.Instance.LogWrite("pole_ui DB Data Empty");
                }));
            }

            DataSend(sendData);
            InsertWirelessPlusPoleUI(masterId, id, true);
        }

        public void InsertWirelessPlusPoleUI(string mid, int id, bool error)
        {
            string sql = string.Empty;
            string sendData = string.Empty;
            string videoLog = string.Empty;

            int dataCheck = SelectPolelog(id);
            if (dataCheck != -1)
            {
                if (error)
                {
                    sendData = string.Format(
                        "UPDATE " +
                        "pole_ui " +
                        "SET " +
                        "wireless = wireless + 1 " +
                        "WHERE " +
                        "id = {0}  AND idname = '{1}' " +
                        "AND " +
                        "wireless < 5;"
                   , id, mid);
                }
                else
                {
                    sendData = string.Format(
                       "UPDATE " +
                       "pole_ui " +
                       "SET " +
                       "wireless = wireless - 1 " +
                       "WHERE " +
                       "id = {0}  AND idname = '{1}' " +
                       "AND " +
                       "wireless > 0; " +

                       "UPDATE " +
                       "pole_ui " +
                       "SET " +
                       "error = 0 " +
                       "WHERE " +
                       "id = {0}  AND idname = '{1}' " +
                       "AND " +
                       "wireless = 0; "
                  , id, mid);
                }
            }
            else
            {
                DispatcherService.Invoke((System.Action)(() =>
                {
                    LogMessage.Instance.LogWrite("pole_ui DB Data Empty");
                }));
            }

            DataSend(sendData);
        }

        public void DataSend(string data)
        {
            DispatcherService.Invoke((System.Action)(() =>
            {
                //LogMessage.Instance.LogWrite("db connection : " + _dbState);
                LogMessage.Instance.LogWrite("pole_ui data : " + data);
            }));

            if (_dbState)
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand(data, _conn);
                    int insertCheck = cmd.ExecuteNonQuery();

                    if (insertCheck != -1)
                    {
                        DispatcherService.Invoke((System.Action)(() =>
                        {
                            LogMessage.Instance.LogWrite("Insert Complete");
                        }));
                    }
                    else
                    {
                        DispatcherService.Invoke((System.Action)(() =>
                        {
                            LogMessage.Instance.LogWrite("DB Insert Error");
                        }));
                    }
                }
                catch (Exception e)
                {
                    DispatcherService.Invoke((System.Action)(() =>
                    {
                        LogMessage.Instance.LogWrite("DB Insert Error " + e);
                    }));
                }
            }
            else
            {
                DispatcherService.Invoke((System.Action)(() =>
                {
                    LogMessage.Instance.LogWrite("DB Connection Error");
                }));
            }
        }
    }
}