using System.Data;

namespace Protocol.Model.Common
{
    public class UserModel : BaseM
    {
        private string id;

        public string Id
        {
            get { return id; }
            set { SetProperty(ref id, value); }
        }

        private string pwd;

        public string Pwd
        {
            get { return pwd; }
            set { SetProperty(ref pwd, value); }
        }

        private string name;

        public string Name
        {
            get { return name; }
            set { SetProperty(ref name, value); }
        }

        private string email;

        public string Email
        {
            get { return email; }
            set { SetProperty(ref email, value); }
        }

        private int groupNo;
        public int GroupNo
        {
            get { return groupNo; }
            set { SetProperty(ref groupNo, value); }
        }

        private int authGroupNo;

        public int AuthGroupNo
        {
            get { return authGroupNo; }
            set { SetProperty(ref authGroupNo, value); }
        }

        public UserModel()
        { }

        public UserModel(DataRow dataRow):base(dataRow)
        { }

        public override void ConvertData(DataRow dataRow)
        {
            this.Id = ConvertString(dataRow, "id");
            this.Pwd = ConvertString(dataRow, "pwd");
            this.Name=ConvertString(dataRow, "name");
            this.Email = ConvertString(dataRow, "email");
            this.GroupNo = ConvertInt(dataRow, "groupno");
            this.AuthGroupNo = ConvertInt(dataRow, "authgroupno");
        }
    }

    public class UserList:BaseList<UserModel>
    { }
}