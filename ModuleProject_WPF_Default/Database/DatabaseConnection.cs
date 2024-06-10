using ModuleProject.Interface;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleProject.Database
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
            try
            {
                _connection.Open();
            }
            catch (Exception ex)
            {
                throw new DatabaseConnectionException("Failed to open the database connection.", ex);
            }
        }

        public void Close()
        {
            try
            {
                _connection.Close();
            }
            catch (Exception ex)
            {
                throw new DatabaseConnectionException("Failed to close the database connection.", ex);
            }
        }

        public void Dispose()
        {
            _connection.Dispose();
        }
    }

}
