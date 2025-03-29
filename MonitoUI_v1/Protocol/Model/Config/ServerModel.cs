using System;
using System.Data;
using System.Diagnostics;

namespace Protocol.Model.Config
{
    public class ServerModel : BaseM
    {
        private int serverNo;

        public int ServerNo
        {
            get { return serverNo; }
            set { SetProperty(ref serverNo, value); }
        }

        private string serverName;

        public string ServerName
        {
            get { return serverName; }
            set { SetProperty(ref serverName, value); }
        }

        private int sort;

        public int Sort
        {
            get { return sort; }
            set { SetProperty(ref sort, value); }
        }

        private string ipAddr;

        public string IpAddr
        {
            get { return ipAddr; }
            set { SetProperty(ref ipAddr, value); }
        }

        private int secondaryPortNo;

        public int SecondaryPortNo
        {
            get { return secondaryPortNo; }
            set { SetProperty(ref secondaryPortNo, value); }
        }

        public ServerModel(DataRow dataRow) : base(dataRow)
        {
        }

        public override void ConvertData(DataRow dataRow)
        {
            try
            {
                this.ServerNo = ConvertInt(dataRow, "serverno");
                this.ServerName = ConvertString(dataRow, "servername");
                this.Sort = ConvertInt(dataRow, "sort");
                this.IpAddr = ConvertString(dataRow, "ipaddr");
                this.SecondaryPortNo = ConvertInt(dataRow, "secondaryportno");
            }
            catch (Exception e)
            {
                Debug.WriteLine("Error : " + e);
            }
        }
    }

    public class ServerList : BaseList<ServerModel>
    { }
}