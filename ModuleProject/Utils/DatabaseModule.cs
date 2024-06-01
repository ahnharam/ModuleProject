using MySql.Data.MySqlClient;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleProject.Utils
{
    public class DatabaseModule : BindableBase
    {
        private static readonly Lazy<DatabaseModule> lazy = new Lazy<DatabaseModule>(() => new DatabaseModule());
        public static DatabaseModule Instance => lazy.Value;

        #region DB Setting property
        private string serverIp;
        public string ServerIp
        {
            get { return serverIp; }
            set { SetProperty(ref serverIp, value); }
        }

        private string serverPort;
        public string ServerPort
        {
            get { return serverPort; }
            set { SetProperty(ref serverPort, value); }
        }

        private string database;
        public string Database
        {
            get { return database; }
            set { SetProperty(ref database, value); }
        }

        private string uid;
        public string Uid
        {
            get { return uid; }
            set { SetProperty(ref uid, value); }
        }

        private string pwd;
        public string Pwd
        {
            get { return pwd; }
            set { SetProperty(ref pwd, value); }
        }
        #endregion

        private string _dbcon = string.Empty;
        private readonly object _dbLock = new object();
        public MySqlConnection Conn { get; set; }

        public void ServerSetting(string serverIp, string database, string uid, string pwd, string serverPort)
        {
            this.serverIp = serverIp;
            this.database = database;
            this.uid = uid;
            this.pwd = pwd;
            this.serverPort = serverPort;

            CheckServerSetting();
            Setup();
        }

        public void CheckServerSetting()
        {
            if (string.IsNullOrWhiteSpace(ServerIp))
            {
                throw new DatabaseConnectionException("Server IP cannot be null or empty.");
            }

            if (string.IsNullOrWhiteSpace(Database))
            {
                throw new DatabaseConnectionException("Database name cannot be null or empty.");
            }

            if (string.IsNullOrWhiteSpace(Uid))
            {
                throw new DatabaseConnectionException("User ID cannot be null or empty.");
            }

            if (string.IsNullOrWhiteSpace(Pwd))
            {
                throw new DatabaseConnectionException("Password cannot be null or empty.");
            }

            if (string.IsNullOrWhiteSpace(ServerPort))
            {
                throw new DatabaseConnectionException("Server port cannot be null or empty.");
            }
        }

        public void Setup()
        {
            _dbcon = $"SERVER = {ServerIp}; "
                + $"DATABASE = {Database}; "
                + $"UID = {Uid}; "
                + $"PWD = {Pwd}; "
                + $"PORT = {ServerPort}; "
                + $"Charset=utf8; Pooling=true; SslMode=none; convert zero datetime=True";
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
            catch (InvalidOperationException ex)
            {
                connected = false;
                // 잘못된 작업 예외 처리 (예: 연결이 이미 열려 있을 때)
                Console.WriteLine($"Invalid Operation: {ex.Message}");
            }
            catch (Exception ex)
            {
                connected = false;
                // 일반적인 예외 처리
                Console.WriteLine($"General Error: {ex.Message}");
            }
            finally
            {
                // 연결을 닫거나 다른 정리 작업을 수행할 수 있습니다.
                if (!connected && Conn != null)
                {
                    Conn.Dispose();
                }
            }

            return connected;
        }

        //public DataTable Select(string sql)
        //{
        //    lock (_dbLock)
        //    {
        //        if (Conn.State == ConnectionState.Closed)
        //        {
        //            Debug.WriteLine("DB Connection Closed");
        //            if (Connect() == false)
        //            {
        //                Debug.WriteLine("Database Reconnection Faild");
        //                return null;
        //            }
        //        }

        //        Debug.WriteLine("sql : " + sql);

        //        try
        //        {
        //            using (var adapter = new MySqlDataAdapter(sql, Conn))
        //            {
        //                DataTable table = new();
        //                adapter.Fill(table);
        //                Task.Delay(100);
        //                return table;
        //            }
        //        }
        //        catch (Exception e)
        //        {
        //            Debug.WriteLine("Select Error : " + e);
        //            Task.Delay(100);
        //            return null;
        //        }
        //    }
        //}

        public async Task<DataTable> SelectAsync(string sql)
        {
            if (Conn == null)
            {
                Debug.WriteLine("Connection object is null");
                return null;
            }

            try
            {
                lock (_dbLock)
                {
                    if (Conn.State == ConnectionState.Closed)
                    {
                        Debug.WriteLine("DB Connection Closed");
                        if (!Connect())
                        {
                            Debug.WriteLine("Database Reconnection Failed");
                            return null;
                        }
                    }
                }

                Debug.WriteLine("sql : " + sql);

                using (var command = new MySqlCommand(sql, Conn))
                {
                    // 매개변수화된 쿼리로 수정
                    // 예시: command.Parameters.AddWithValue("@parameter", value);

                    using (var adapter = new MySqlDataAdapter(command))
                    {
                        DataTable table = new();
                        await Task.Run(() => adapter.Fill(table)); // 비동기 작업으로 변경
                        return table;
                    }
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine("Select Error : " + e);
                return null;
            }
        }


        public async void InsertOrUpdate(string sql)
        {
            Debug.WriteLine("Database Insert Data : " + sql);
            lock (_dbLock) // 동시 액세스를 제어하기 위해 lock 사용
            {
                if (Conn.State == ConnectionState.Closed)
                {
                    Debug.WriteLine("Database Inserting Error, Database Connection is Close");

                    if (Connect() == false)
                    {
                        Debug.WriteLine("Database Reconnection Faild");
                        return;
                    }
                }

                try
                {
                    using (MySqlCommand cmd = new MySqlCommand(sql, Conn))
                    {
                        int insertCheck = cmd.ExecuteNonQuery();

                        if (insertCheck != -1)
                        {
                            Debug.WriteLine("Insert Complete");
                        }
                        else
                        {
                            Debug.WriteLine("Database Can't Insert");
                        }
                    }
                }
                catch (Exception e)
                {
                    Debug.WriteLine("Database Insert Exception :" + e);
                }
            }
            await Task.Delay(100);
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
                Debug.WriteLine("DB DisConnected Error : " + e);
            }
        }
    }
}
