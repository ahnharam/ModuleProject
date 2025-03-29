using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Protocol.Model.Dashboard
{
    public class MnScreenM : BaseM
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

        private int arrayX;
        public int ArrayX
        {
            get { return arrayX; }
            set { SetProperty(ref arrayX, value); }
        }

        private int arrayY;
        public int ArrayY
        {
            get { return arrayY; }
            set { SetProperty(ref arrayY, value); }
        }

        private int mapNo;
        public int MapNo
        {
            get { return mapNo; }
            set { SetProperty(ref mapNo, value); }
        }

        public MnScreenM() { }

        public MnScreenM(DataRow dataRow)
        {
            ConvertData(dataRow);
        }

        public override void ConvertData(DataRow dataRow)
        {
            this.No = ConvertInt(dataRow, "no");
            this.GroupNo = ConvertInt(dataRow, "groupno");
            this.Name = ConvertString(dataRow, "name");
            this.Sort = ConvertInt(dataRow, "sort");
            this.ArrayX = ConvertInt(dataRow, "arrayx");
            this.ArrayY = ConvertInt(dataRow, "arrayy");
            this.MapNo = ConvertInt(dataRow, "mapno");
        }
    }
    public class MnScreenList : BaseList<MnScreenM>
    { }
}
