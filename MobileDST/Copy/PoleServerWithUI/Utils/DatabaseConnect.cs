using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PoleServerWithUI.Model;
using System.Collections.ObjectModel;

namespace PoleServerWithUI.Utils
{
    class DatabaseConnect
    {
        private MySqlConnection _conn = null;
        private bool _dbState = false;
        private string _dbTable = string.Empty;


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
            string sql = string.Format("Select * from device_info where serverid = {0}", deviceId);

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
                                Screen = reader["screen"].ToString(),
                                Type = reader["Type"].ToString(),
                                Id = reader["id"].ToString(),
                                Sid = reader["Sid"].ToString(),
                                Info = reader["Name"].ToString(),
                                Name = reader["Location"].ToString(),
                                Ip = reader["Ip"].ToString(),
                                Port = reader["Port"].ToString(),
                                Value = reader["Value"].ToString(),
                                TxData = reader["txdata"].ToString()
                            }); 
                        }
                    }
                    return deviceModels;
                }
                catch(Exception e)
                {

                    DispatcherService.Invoke((System.Action)(() =>
                    {
                        LogMessage.Instance.LogWrite("DB Select Error : " + e);
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
                            dataCheck = Convert.ToInt32( reader["genneration"].ToString() );
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

        public bool SelectVideoPolelog(int no)
        {
            bool dataCheck = false;

            ObservableCollection<DeviceModel> deviceModels = new ObservableCollection<DeviceModel>();
            string sql = string.Format(
                "SELECT " +
                "* " +
                "FROM " +
                "video_pole " +
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

        public void InsertPoleLog(PoleLogModel poleLogModel)
        {
            string sql = string.Empty;
            string poleLog = string.Empty;
            string videoLog = string.Empty;
            if (SelectId(poleLogModel.No) == true)
            {
                sql = string.Format(
                "UPDATE " +
                "pole_log_haram " +
                "SET " +
                "name = '{1}', " +
                "screen = '{2}', " +
                "Type = '{3}', " +
                "id = '{4}', " +
                "poc = '{5}', " +
                "potml = '{6}', " +
                "potmh = '{7}', " +
                "battery = '{8}', " +
                "solar = '{9}', " +
                "wind = '{10}', " +
                "outbat = '{11}', " +
                "outpowerfirst = '{12}', " +
                "outpowersecond = '{13}', " +
                "temp = '{14}', " +
                "outtemp = '{15}', " +
                "humi = '{16}', " +
                "windspeed = '{17}' " +
                "WHERE " +
                "no = {0}; ",
                poleLogModel.No,
                poleLogModel.Name,
                poleLogModel.Screen,
                poleLogModel.Type,
                poleLogModel.Id,
                poleLogModel.Poc,
                poleLogModel.Potml,
                poleLogModel.Potmh,
                poleLogModel.Battery,
                poleLogModel.Humi,
                poleLogModel.Wind,
                poleLogModel.Outbat,
                poleLogModel.Outpowerfirst,
                poleLogModel.Outpowersecond,
                poleLogModel.Temp,
                poleLogModel.Outtemp,
                poleLogModel.Humi,
                poleLogModel.Windspeed);
            }
            else
            {
                sql = string.Format(
               "Insert Into pole_log_haram" +
               "(no, " +
               "name, " +
               "screen, " +
               "Type, " +
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
               "windspeed) " +
               "VALUES " +
               "({0},'{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}'); ",
               poleLogModel.No,
               poleLogModel.Name,
               poleLogModel.Screen,
               poleLogModel.Type,
               poleLogModel.Id,
               poleLogModel.Poc,
               poleLogModel.Potml,
               poleLogModel.Potmh,
               poleLogModel.Battery,
               poleLogModel.Humi,
               poleLogModel.Wind,
               poleLogModel.Outbat,
               poleLogModel.Outpowerfirst,
               poleLogModel.Outpowersecond,
               poleLogModel.Temp,
               poleLogModel.Outtemp,
               poleLogModel.Humi,
               poleLogModel.Windspeed);
            }

            int dataCheck = SelectPolelog(Convert.ToInt32(poleLogModel.Id));
            int genneration = 0;
            if (dataCheck != -1)
            {
                genneration = 
                    Convert.ToInt32( poleLogModel.Battery )
                    + Convert.ToInt32( poleLogModel.Solar )
                    + Convert.ToInt32( poleLogModel.Wind );
                poleLog = string.Format(
                "UPDATE " +
                "pole_ui " +
                "SET " +
                "temp = '{1}', " +
                "humi = '{2}', " +
                "wind = '{3}', " +
                "genneration = '{4}' " +
                "WHERE " +
                "id = '{0}'; ", poleLogModel.Id, poleLogModel.Temp, poleLogModel.Humi, poleLogModel.Windspeed, genneration);
            }
            else
            {
                DispatcherService.Invoke((System.Action)(() =>
                {
                    LogMessage.Instance.LogWrite("pole_ui DB Data Empty");
                }));
            }

            if (SelectVideoPolelog(1) == true)
            {
                if(genneration != -1)
                {
                    videoLog = string.Format(
                   "UPDATE " +
                   "video_pole " +
                   "SET " +
                   "generation = '{1}' " +
                   "WHERE " +
                   "no = {0}; ", 1, genneration);
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
                LogMessage.Instance.Log.Add("db connection : " + _dbState);
                LogMessage.Instance.LogWrite("sql data : " + sql);
                LogMessage.Instance.LogWrite("pole_ui data : " + poleLog);
                LogMessage.Instance.LogWrite("video_pole data : " + videoLog);
            }));

            DataSend(sql + poleLog + videoLog);
        }

        public void InsertPoleUI(int id, int[] data, int error = 1)
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
                "id = '{0}'; ", id, percent, wattage, error);
            }
            else
            {
                DispatcherService.Invoke((System.Action)(() =>
                {
                    LogMessage.Instance.LogWrite("pole_ui DB Data Empty");
                }));
            }

            DataSend(sendData);
            InsertWirelessPlusPoleUI(id, true);
        }

        public void InsertWirelessPlusPoleUI(int id, bool error)
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
                        "SET "+
                        "wireless = wireless + 1 "+
                        "WHERE "+
                        "id = {0} "+
                        "AND "+
                        "wireless < 5;"
                   , id);
                }
                else
                {
                    sendData = string.Format(
                       "UPDATE " +
                       "pole_ui " +
                       "SET " +
                       "wireless = wireless - 1 " +
                       "WHERE " +
                       "id = {0} " +
                       "AND " +
                       "wireless > 0; " +

                       "UPDATE " +
                       "pole_ui " +
                       "SET " +
                       "error = 0 " +
                       "WHERE " +
                       "id = {0} " +
                       "AND " +
                       "wireless = 0; "
                  , id);
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
                LogMessage.Instance.Log.Add("db connection : " + _dbState);
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
