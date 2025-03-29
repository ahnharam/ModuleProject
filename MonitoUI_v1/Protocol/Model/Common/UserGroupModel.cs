using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Protocol.Model.Common
{
    public class UserGroupModel:BaseM
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

        public UserGroupModel()
        { }

        public UserGroupModel(DataRow dataRow):base(dataRow)
        { }

        public override void ConvertData(DataRow dataRow)
        {
            this.No = ConvertInt(dataRow, "no");
            this.Name = ConvertString(dataRow, "name");
        }
    }

    public class UserGroupList:BaseList<UserGroupModel>
    { }
}
