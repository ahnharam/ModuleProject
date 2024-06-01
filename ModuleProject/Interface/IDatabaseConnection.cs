using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleProject.Interface
{
    public interface IDatabaseConnection : IDisposable
    {
        MySqlConnection Connection { get; }
        void Open();
        void Close();
    }

}
