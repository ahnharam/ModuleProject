using System.Data;

namespace Protocol.Model.Common
{
    public class AuthGroupModel : BaseM
    {
        private int functionGroupNo;

        public int FunctionGroupNo
        {
            get { return functionGroupNo; }
            set { SetProperty(ref functionGroupNo, value); }
        }

        private int functionNo;

        public int FunctionNo
        {
            get { return functionNo; }
            set { SetProperty(ref functionNo, value); }
        }

        public AuthGroupModel()
        { }

        public AuthGroupModel(DataRow dataRow):base(dataRow)
        { }

        public override void ConvertData(DataRow dataRow)
        {
            this.FunctionGroupNo = ConvertInt(dataRow, "functiongroupno");
            this.FunctionNo = ConvertInt(dataRow, "functionno");
        }
    }

    public class AuthGroupList : BaseList<AuthGroupModel>
    { }
}