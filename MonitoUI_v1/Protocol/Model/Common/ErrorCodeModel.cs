using System.Data;

namespace Protocol.Model.Common
{
    public class ErrorCodeModel : BaseM
    {
        private int no;

        public int No
        {
            get { return no; }
            set { SetProperty(ref no, value); }
        }

        private int errorCode;

        public int ErrorCode
        {
            get { return errorCode; }
            set { SetProperty(ref errorCode, value); }
        }

        private string errorName;

        public string ErrorName
        {
            get { return errorName; }
            set { SetProperty(ref errorName, value); }
        }

        public ErrorCodeModel()
        { }

        public ErrorCodeModel(DataRow dataRow):base(dataRow)
        { }

        public override void ConvertData(DataRow dataRow)
        {
            this.No = ConvertInt(dataRow, "no");
            this.ErrorCode = ConvertInt(dataRow, "errorcode");
            this.ErrorName = ConvertString(dataRow, "errorname");
        }
    }

    public class ErrorCodeList:BaseList<ErrorCodeModel>
    { }
}