using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleProject_WPF_Default.Models
{
    public class ExampleModel : IsEditUpdater
    {
        #region property
        private int _no;

        public int no
        {
            get { return _no; }
            set { if (SetProperty(ref _no, value)) OnPropertyChanged(nameof(IsEdit)); }
        }
        #endregion

        public ExampleModel() : base()
        {

        }

        public override void CopyOriginToUI()
        {
            //noui = no;
            //fullareanameui = fullareaname;
        }

        public override void CopyUIToOrigin()
        {
            //no = noui;
            //fullareaname = fullareanameui;
        }

        public override bool IsUserEdit()
        {
            //if (no != noui ||
            //    fullareaname != fullareanameui)
            //    return true;
            //else
            //    return false;
            return true;
        }
    }

    public class ExampleDBOB : ObservableCollection<ExampleModel>
    {
        public DataSet dataset { get; set; }

        public ExampleDBOB()
        {
            dataset = new DataSet();
        }

        public ExampleDBOB(List<ExampleModel> stationInfodblist)
        {
            dataset = new DataSet();

            foreach (var model in stationInfodblist)
            {
                this.Add(model);
            }
        }

        public string SelectAllQuery()
        {
            return "SELECT * FROM ";
        }

        public string SelectCityQuery(string city)
        {
            return string.Format("SELECT * FROM  WHERE  = '{0}'", city);
        }

        public void SelectAllDSParsing()
        {
            this.Clear();

            foreach (DataRow dr in dataset.Tables[0].Rows)
            {
                ExampleModel exampleModel = new ExampleModel();
                Assign(dr, exampleModel);

                this.Add(exampleModel);
            }

            dataset.Clear();
        }

        public ExampleModel SelectStationByNo(int stationno)
        {
            foreach (ExampleModel station in this)
            {
                if (station.no == stationno)
                {
                    return station;
                }
            }

            return null;
        }

        private void Assign(DataRow dr, ExampleModel stationinfodbmodel)
        {
            //stationinfodbmodel.no = Convert.ToInt32(dr["no"].ToString());
            //stationinfodbmodel.fullareaname = dr["fullareaname"].ToString();
            //stationinfodbmodel.localareaname = dr["localareaname"].ToString();
            //stationinfodbmodel.fulladdress = dr["fulladdress"].ToString();
            //stationinfodbmodel.localaddress = dr["localaddress"].ToString();
            //stationinfodbmodel.city = dr["city"].ToString();
            //stationinfodbmodel.starttime = DateTime.MinValue.Add(TimeSpan.Parse(dr["starttime"].ToString()));
            //stationinfodbmodel.endtime = DateTime.MinValue.Add(TimeSpan.Parse(dr["endtime"].ToString()));
            //stationinfodbmodel.nextday = stationinfodbmodel.endtime.Day == 2 ? true : false;
            //stationinfodbmodel.stationtype = dr["stationtype"].ToString();
            //stationinfodbmodel.stationcode = dr["stationcode"].ToString();
            //stationinfodbmodel.latitude = Convert.ToDouble(dr["latitude"].ToString());
            //stationinfodbmodel.longitude = Convert.ToDouble(dr["longitude"].ToString());
            //stationinfodbmodel.isalive = Convert.ToBoolean(Convert.ToInt32(dr["isalive"].ToString()));
        }

        internal ExampleModel GetByCityAndName(string groupName, string itemName)
        {
            ExampleModel result = null;

            //foreach (var model in this)
            //{
            //    if (model.city == groupName &&
            //        model.fullareaname == itemName)
            //    {
            //        result = model;

            //        break;
            //    }
            //}

            return result;
        }
    }

}
