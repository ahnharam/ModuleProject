using MySqlX.XDevAPI.Relational;
using Protocol.Model.Dashboard;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Protocol.Database
{
    public class BaseConverter
    {
        public static string ConvertString(DataRow dataRow, string name)
        {
            return dataRow.Field<string>(name);
        }

        public static int ConvertInt(DataRow dataRow, string name)
        {
            return dataRow.Field<int>(name);
        }

        public static double ConvertDouble(DataRow dataRow, string name)
        {
            return dataRow.Field<double>(name);
        }

        public static bool ListNullCheck(object list)
        {
            if (list == null) return false;
            else return true;            
        }
    }
}
