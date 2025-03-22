using MySql.Data.MySqlClient;
using System;

namespace ModuleProject.Interface
{
    public interface IDatabaseConnection : IDisposable
    {
        MySqlConnection Connection { get; }
        void Open();
        void Close();
    }

}
