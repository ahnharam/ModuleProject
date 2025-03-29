using MySql.Data.MySqlClient;
using Protocol.ActiveMQ;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Protocol.Database
{
    public class DatabaseConnect
    {
        string _dbcon = string.Empty;
        public MySqlConnection _conn { get; set; }

        private static readonly Lazy<DatabaseConnect> lazy = new Lazy<DatabaseConnect>(() => new DatabaseConnect());
        public static DatabaseConnect Instance => lazy.Value;

        public DatabaseConnect() { }

        public void Setup(string server, string db, string id, string pwd, string port)
        {
            _dbcon = "SERVER = " + server + "; ";
            _dbcon += "DATABASE = " + db + "; ";
            _dbcon += "UID = " + id + "; ";
            _dbcon += "PWD = " + pwd + "; ";
            _dbcon += "PORT = " + port + "; ";
            _dbcon += "Charset=utf8; Pooling=true; SslMode=none; convert zero datetime=True";
        }

        public void Connect()
        {
            _conn = new MySqlConnection(_dbcon);

            try
            {
                _conn.Open();
            }
            catch (Exception e)
            {
                throw new Exception("DB Connection Error : " + e);
            }
        }

        public DataTable Select(string sql)
        {
            MySqlDataAdapter adapter = null;
            try
            {
                var dt = new DataTable();

                adapter = new MySqlDataAdapter(sql, _conn);

                DataTable table = new DataTable();
                adapter.Fill(table);

                return table;
            }
            catch (Exception e)
            {
                Debug.WriteLine("Select Error : " + e);
                return null;
            }
            finally
            {
                Debug.WriteLine("sql : " + sql);
                if ( adapter != null ) adapter.Dispose();
            }
        }

        public void Insert()
        {

        }

        public void Update()
        {

        }

        public void Delete()
        {

        }

        public void Disconnect()
        {

        }
    }
}