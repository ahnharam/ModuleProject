using System.Data;

namespace Protocol.Model.Common
{
    public class AuthModel : BaseM
    {
        private int functionNo;

        public int FunctionNo
        {
            get { return functionNo; }
            set { SetProperty(ref functionNo, value); }
        }

        private string functionName;

        public string FunctionName
        {
            get { return functionName; }
            set { SetProperty(ref functionName, value); }
        }

        private int auth;

        public int Auth
        {
            get { return auth; }
            set { SetProperty(ref auth, value); }
        }

        public AuthModel()
        { }

        public AuthModel(DataRow dataRow):base(dataRow)
        { }

        public override void ConvertData(DataRow dataRow)
        {
            this.FunctionNo = ConvertInt(dataRow, "functionno");
            this.FunctionName = ConvertString(dataRow, "functionname");
            this.Auth = ConvertInt(dataRow, "auth");
        }
    }

    public class AuthList:BaseList<AuthList>
    { }
}