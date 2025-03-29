using Mysqlx;
using PoleServerWithUI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoleServerWithUI.Message
{
    public class PoleUIMessage
    {
        public static string UpdatePoleUI(string id, string masterId, string percent, string wattage, string error = "1")
        {
            return string.Format(
            "UPDATE " +
            "pole_ui " +
            "SET " +
            "bat = '{1}', " +
            "genneration = genneration + '{2}', " +
            "error = '{3}' " +
            "WHERE " +
            "id = '{0}' AND idname = '{4}'; ", id, percent, wattage, error, masterId);
        }
    }
}
