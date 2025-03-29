using MySql.Data.MySqlClient;
using Protocol.Login;
using Protocol.Model.Dashboard;
using Protocol.ShareLib;
using Protocol.ShareLib.Cache;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Protocol.Main
{
    public class MainViewDBMessage
    {
        public static string Login(LoginFormat loginFormat)
        {
            string login = string.Format(
                "SELECT * FROM user WHERE userid = '{0}' AND pwd = '{1}'"
                ,loginFormat.Id, loginFormat.Pw
            );

            return login;
        }


        public static string ChangePassword(LoginFormat loginFormat)
        {
            string login = string.Format(
                "UPDATE user SET pwd = '{0}' WHERE userid = '{1}'"
                , loginFormat.Pw, loginFormat.Id
            );

            return login;
        }

        public static bool CheckUser(LoginFormat loginFormat)
        {
            bool check = false;

            foreach (var row in loginFormat.Dt.AsEnumerable())
            {
                loginFormat.Id = row.Field<string>("userid");
                loginFormat.Auth = row.Field<int>("auth");
                loginFormat.Level = row.Field<int>("level");
                //loginFormat.Config = row.Field<string>("");
                //loginFormat.Confirm = row.Field<string>("");

                Cache.Instance.User = loginFormat;
                check = true;
            }

            return check;
        }
    }
}
