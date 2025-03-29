using MySql.Data.MySqlClient;
using System;

namespace ModuleProject.Database
{
    public interface IDatabaseConnection : IDisposable
    {
        MySqlConnection Connection { get; }
        void Open();
        void Close();
    }

}
