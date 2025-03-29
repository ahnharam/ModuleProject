using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Protocol.Login
{
    public class LoginFormat
    {
        public string Id { get; set; }
        public string Pw { get; set; }
        public int Confirm { get; set; }
        public int Auth { get; set; }
        public int Level { get; set; }
        public int Config { get; set; }
        public int Function { get; set; }

        public DataTable Dt { get; set; }

        public LoginFormat(string id, string pw)
        {
            this.Id = id;
            this.Pw = pw;
        }
        public LoginFormat(string id, string pw, int confirm)
        {
            this.Id = id;
            this.Pw = pw;
            this.Confirm = confirm;

        }
        public LoginFormat(string id, string pw, int confirm, int auth, int level, int config, int function)
        {
            this.Id = id;
            this.Pw = pw;
            this.Confirm = confirm;
            this.Auth = auth;
            this.Level = level;
            this.Config = config;
            this.Function = function;
        }
    }
}
