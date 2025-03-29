using System.Data;

namespace Protocol.Model.Common
{
    public class GroupM : BaseM
    {
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

        private int higherGroupNo;

        public int HigherGroupNo
        {
            get { return higherGroupNo; }
            set { SetProperty(ref higherGroupNo, value); }
        }

        private int sort;

        public int Sort
        {
            get { return sort; }
            set { SetProperty(ref sort, value); }
        }

        private int screenNo;

        public int ScreenNo
        {
            get { return screenNo; }
            set { SetProperty(ref screenNo, value); }
        }

        private int screenType;

        public int ScreenType
        {
            get { return screenType; }
            set { SetProperty(ref screenType, value); }
        }


        public GroupM()
        { }

        public GroupM(DataRow dataRow) : base(dataRow)
        { }

        public override void ConvertData(DataRow dataRow)
        {
            this.GroupNo = ConvertInt(dataRow, "no");
            this.GroupName = ConvertString(dataRow, "name");
            this.HigherGroupNo = ConvertInt(dataRow, "higherno");
            this.Sort = ConvertInt(dataRow, "sort");
            this.ScreenNo = ConvertInt(dataRow, "screenno");
            this.ScreenType = ConvertInt(dataRow, "screentype");
        }
    }

    public class GroupList : BaseList<GroupM>
    { }
}