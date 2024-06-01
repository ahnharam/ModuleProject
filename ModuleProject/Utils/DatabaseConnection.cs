using ModuleProject.Interface;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleProject.Utils
{
    public class DatabaseConnection : IDatabaseConnection
    {
        private readonly MySqlConnection _connection;

        public DatabaseConnection(string connectionString)
        {
            _connection = new MySqlConnection(connectionString);
        }

        public MySqlConnection Connection => _connection;

        public void Open()
        {
            _connection.Open();
        }

        public void Close()
        {
            _connection.Close();
        }

        public void Dispose()
        {
            _connection.Dispose();
        }
    }

}
