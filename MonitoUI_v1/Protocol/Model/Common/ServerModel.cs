using System.Data;

namespace Protocol.Model.Common
{
    public class ServerModel : BaseM
    {
        private int no;

        public int No
        {
            get { return no; }
            set { SetProperty(ref no, value); }
        }

        private string name;

        public string Name
        {
            get { return name; }
            set { SetProperty(ref name, value); }
        }

        private int sort;

        public int Sort
        {
            get { return sort; }
            set { SetProperty(ref sort, value); }
        }

        private string ip;

        public string Ip
        {
            get { return ip; }
            set { SetProperty(ref ip, value); }
        }

        private int port;

        public int Port
        {
            get { return port; }
            set { SetProperty(ref port, value); }
        }

        private string function;

        public string Function
        {
            get { return function; }
            set { SetProperty(ref function, value); }
        }

        private string value;

        public string Value
        {
            get { return value; }
            set { SetProperty(ref value, value); }
        }

        private string remark;

        public string Remark
        {
            get { return remark; }
            set { SetProperty(ref remark, value); }
        }

        public ServerModel()
        { }

        public ServerModel(DataRow dataRow):base(dataRow)
        { }

        public override void ConvertData(DataRow dataRow)
        {
            this.No = ConvertInt(dataRow, "no");
            this.Name=ConvertString(dataRow, "name");
            this.Sort = ConvertInt(dataRow, "sort");
            this.Ip = ConvertString(dataRow, "ip");
            this.Port = ConvertInt(dataRow, "port");
            this.Function = ConvertString(dataRow, "function");
            this.Value=ConvertString(dataRow, "value");
            this.Remark = ConvertString(dataRow, "remark");
        }
    }

    public class ServerList:BaseList<ServerModel>
    { }
}