using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleProject.Interface
{
    public interface IMySqlDataAdapter
    {
        int Fill(DataTable dataTable);
    }

    public class MySqlDataAdapterWrapper : IMySqlDataAdapter
    {
        private readonly MySqlDataAdapter _adapter;

        public MySqlDataAdapterWrapper(MySqlCommand command)
        {
            _adapter = new MySqlDataAdapter(command);
        }

        public int Fill(DataTable dataTable)
        {
            return _adapter.Fill(dataTable);
        }
    }
}
