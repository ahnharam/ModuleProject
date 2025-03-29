using MySql.Data.MySqlClient;
using PoleServerWithUI.Model;
using System;
using System.Data;

namespace PoleServerWithUI.Utils
{
    public class DatabaseConnect
    {
        private string _dbcon = string.Empty;
        public MySqlConnection Conn { get; set; }

        private static readonly Lazy<DatabaseConnect> lazy = new Lazy<DatabaseConnect>(() => new DatabaseConnect());
        public static DatabaseConnect Instance => lazy.Value;

        DatabaseModel DatabaseModel;

        public DatabaseConnect()
        {
            DatabaseModel = new DatabaseModel();
        }

        public void Setup(DatabaseModel databaseModel)
        {
            this.DatabaseModel = databaseModel;
            this.Setup();
        }

        public void Setup()
        {
            _dbcon = "SERVER = " + DatabaseModel.ServerIp + "; ";
            _dbcon += "DATABASE = " + DatabaseModel.Database + "; ";
            _dbcon += "UID = " + DatabaseModel.Uid + "; ";
            _dbcon += "PWD = " + DatabaseModel.Pwd + "; ";
            _dbcon += "PORT = " + DatabaseModel.ServerPort + "; ";
            _dbcon += "Charset=utf8; Pooling=true; SslMode=none; convert zero datetime=True";
        }

        public bool DatabaseSettingCheck()
        {
            if (DatabaseModel.ServerIp == null)
            {
                LogMessage.Instance.LogWrite("DB IP 입력 필요");
                return false;
            }
            else if (DatabaseModel.Database == null)
            {
                LogMessage.Instance.LogWrite("DB Database 입력 필요");
                return false;
            }
            else if (DatabaseModel.Uid == null)
            {
                LogMessage.Instance.LogWrite("DB Uid 입력 필요");
                return false;
            }
            else if (DatabaseModel.Pwd == null)
            {
                LogMessage.Instance.LogWrite("DB Pwd 입력 필요");
                return false;
            }
            else return true;
        }

        public bool Connect()
        {
            bool connected = false;

            try
            {
                Conn = new MySqlConnection(_dbcon);
                Conn.Open();
                connected = true;
            }
            catch (Exception e)
            {
                LogMessage.Instance.LogWrite("DB Connection Error: " + e);
                connected = false;
            }
            finally
            {
                LogMessage.Instance.LogWrite("DB Connection : " + connected);
            }

            return connected;
        }

        public DataTable Select(string sql)
        {
            MySqlDataAdapter adapter = null;
            if(Conn.State == ConnectionState.Closed)
            {
                LogMessage.Instance.LogWrite("DB Connection Closed");
                return null;
            }

            LogMessage.Instance.LogWrite("sql : " + sql);

            try
            {
                var dt = new DataTable();

                adapter = new MySqlDataAdapter(sql, Conn);

                DataTable table = new DataTable();
                adapter.Fill(table);

                return table;
            }
            catch (Exception e)
            {
                LogMessage.Instance.LogWrite("Select Error : " + e);
                return null;
            }
        }

        public void InsertOrUpdate(string sql)
        {
            LogMessage.Instance.LogWrite("Database Insert Data : " + sql);

            if (Conn.State == ConnectionState.Closed)
            {
                LogMessage.Instance.LogWrite("Database Inserting Error, Database Connection is Close");
                return;
            }

            try
            {
                MySqlCommand cmd = new MySqlCommand(sql, Conn);
                int insertCheck = cmd.ExecuteNonQuery();

                if (insertCheck != -1)
                {
                    LogMessage.Instance.LogWrite("Insert Complete");
                }
                else
                {
                    LogMessage.Instance.LogWrite("Database Can't Insert");
                }
            }
            catch (Exception e)
            {
                LogMessage.Instance.LogWrite("Database Insert Exception :" + e);
            }
        }

        public void Update()
        {
        }

        public void Delete()
        {
        }

        public void Disconnect()
        {
            try
            {
                Conn.Close();
            }
            catch (Exception e)
            {
                DispatcherService.Invoke((System.Action)(() =>
                {
                    LogMessage.Instance.LogWrite("DB DisConnected Error : " + e);
                }));
            }
        }
    }
}