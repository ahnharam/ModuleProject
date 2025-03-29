using System.Data;

namespace Protocol.Model.Common
{
    public class UserStateModel : BaseM
    {
        private int no;

        public int No
        {
            get { return no; }
            set { SetProperty(ref no, value); }
        }

        private string group;

        public string Group
        {
            get { return group; }
            set { SetProperty(ref group, value); }
        }

        private int status;

        public int Status
        {
            get { return status; }
            set { SetProperty(ref status, value); }
        }

        private int userNo;

        public int UserNo
        {
            get { return userNo; }
            set { SetProperty(ref userNo, value); }
        }

        public UserStateModel()
        { }

        public UserStateModel(DataRow dataRow) : base(dataRow)
        { }

        public override void ConvertData(DataRow dataRow)
        {
            this.No = ConvertInt(dataRow, "no");
            this.Group = ConvertString(dataRow, "group");
            this.Status = ConvertInt(dataRow, "status");
            this.UserNo = ConvertInt(dataRow, "userno");
        }
    }

    public class UserStateList : BaseList<UserStateModel>
    { }
}