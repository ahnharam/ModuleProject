using PoleServerWithUI.Utils;
using System;
using System.Data;
using System.Linq;

namespace PoleServerWithUI.Model
{
    public class BatVInfoModel : BaseModel
    {
        private int no;

        public int No
        {
            get { return no; }
            set { SetProperty(ref no, value); }
        }

        private int from;

        public int From
        {
            get { return from; }
            set { SetProperty(ref from, value); }
        }

        private int to;

        public int To
        {
            get { return to; }
            set { SetProperty(ref to, value); }
        }

        private string voltage;

        public string Voltage
        {
            get { return voltage; }
            set { SetProperty(ref voltage, value); }
        }

        private string percent;

        public string Percent
        {
            get { return percent; }
            set { SetProperty(ref percent, value); }
        }

        private string wattage;

        public string Wattage
        {
            get { return wattage; }
            set { SetProperty(ref wattage, value); }
        }

        public BatVInfoModel()
        { }

        public BatVInfoModel(DataRow dataRow) : base(dataRow)
        {
        }

        protected override void ConvertData(DataRow dataRow)
        {
            this.Wattage = ConvertString(dataRow, "wattage");
            this.Percent = ConvertString(dataRow, "percent");
        }
    }

    public class BatVInfoList : BaseList<BatVInfoModel>
    {
        public static void GetOne(BatVInfoList batVInfoList, out BatVInfoModel batVInfoModel)
        {
            if (batVInfoList == null)
            {
                batVInfoModel = null;
                return;
            }

            try
            {
                batVInfoModel = new BatVInfoModel(batVInfoList.dt.AsEnumerable().Single());
            }
            catch (Exception e)
            {
                LogMessage.Instance.LogWrite("BatVInfoList is null Or Not Single : " + e);
                batVInfoModel = null;
            }
        }

        public override void SelectData(object obj)
        {
            if ((obj is string) == false) return;

            int bat = Convert.ToInt32(obj);

            dbMessage = string.Format(
                "SELECT " +
                "wattage, percent " +
                "FROM " +
                "batV_info b " +
                "WHERE " +
                "b.from <= {0} " +
                "AND b.to >= {0} ", bat);
        }
    }
}