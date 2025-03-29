using System.Data;

namespace Protocol.Model.Common
{
    public class ServerGroupModel : BaseM
    {
        private int no;

        public int No
        {
            get { return no; }
            set { SetProperty(ref no, value); }
        }

        private int groupNo;

        public int GroupNo
        {
            get { return groupNo; }
            set { SetProperty(ref groupNo, value); }
        }

        private string groupName;

        public string GroupName
        {
            get { return groupName; }
            set { SetProperty(ref groupName, value); }
        }

        private int serverNo;

        public int ServerNo
        {
            get { return serverNo; }
            set { SetProperty(ref serverNo, value); }
        }

        public ServerGroupModel()
        { }

        public ServerGroupModel(DataRow dataRow):base(dataRow)
        { }

        public override void ConvertData(DataRow dataRow)
        {
            this.No = ConvertInt(dataRow, "No");
            this.GroupNo = ConvertInt(dataRow, "groupno");
            this.GroupName = ConvertString(dataRow, "groupname");
            this.ServerNo = ConvertInt(dataRow, "serverno");
        }
    }

    public class ServerGroupList : BaseList<ServerGroupModel>
    { }
}