using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;

namespace ModuleProject_WPF_Default.Models
{
    //public class StationInfoDBModel : IsEditUpdater
    //{
    //    #region property
    //    private int _no;
    //    private string _fullareaname;
    //    private string _localareaname;
    //    private string _fulladdress;
    //    private string _localaddress;
    //    private string _city;
    //    private DateTime _starttime;
    //    private DateTime _endtime;
    //    private bool _nextday;
    //    private string _stationtype;
    //    private string _stationcode;
    //    private double _longitude;
    //    private double _latitude;
    //    private bool _isalive;
    //    private int _noui;
    //    private string _fullareanameui;
    //    private string _localareanameui;
    //    private string _fulladdressui;
    //    private string _localaddressui;
    //    private string _cityui;
    //    private DateTime _starttimeui;
    //    private DateTime _endtimeui;
    //    private bool _nextdayui;
    //    private string _stationtypeui;
    //    private string _stationcodeui;
    //    private double _longitudeui;
    //    private double _latitudeui;
    //    private bool _isaliveui;

    //    public int no
    //    {
    //        get { return _no; }
    //        set { if (SetProperty(ref _no, value)) OnPropertyChanged(nameof(IsEdit)); }
    //    }
    //    public string fullareaname
    //    {
    //        get { return _fullareaname; }
    //        set { if (SetProperty(ref _fullareaname, value)) OnPropertyChanged(nameof(IsEdit)); }
    //    }
    //    public string localareaname
    //    {
    //        get { return _localareaname; }
    //        set { if (SetProperty(ref _localareaname, value)) OnPropertyChanged(nameof(IsEdit)); }
    //    }
    //    public string fulladdress
    //    {
    //        get { return _fulladdress; }
    //        set { if (SetProperty(ref _fulladdress, value)) OnPropertyChanged(nameof(IsEdit)); }
    //    }
    //    public string localaddress
    //    {
    //        get { return _localaddress; }
    //        set { if (SetProperty(ref _localaddress, value)) OnPropertyChanged(nameof(IsEdit)); }
    //    }
    //    public string city
    //    {
    //        get { return _city; }
    //        set { if (SetProperty(ref _city, value)) OnPropertyChanged(nameof(IsEdit)); }
    //    }
    //    public DateTime starttime
    //    {
    //        get { return _starttime; }
    //        set { if (SetProperty(ref _starttime, value)) OnPropertyChanged(nameof(IsEdit)); }
    //    }
    //    public DateTime endtime
    //    {
    //        get { return _endtime; }
    //        set { if (SetProperty(ref _endtime, value)) OnPropertyChanged(nameof(IsEdit)); }
    //    }
    //    public bool nextday
    //    {
    //        get { return _nextday; }
    //        set { if (SetProperty(ref _nextday, value)) OnPropertyChanged(nameof(IsEdit)); }
    //    }
    //    public string stationtype
    //    {
    //        get { return _stationtype; }
    //        set { if (SetProperty(ref _stationtype, value)) OnPropertyChanged(nameof(IsEdit)); }
    //    }
    //    public string stationcode
    //    {
    //        get { return _stationcode; }
    //        set { if (SetProperty(ref _stationcode, value)) OnPropertyChanged(nameof(IsEdit)); }
    //    }
    //    public double longitude
    //    {
    //        get { return _longitude; }
    //        set { if (SetProperty(ref _longitude, value)) OnPropertyChanged(nameof(IsEdit)); }
    //    }
    //    public double latitude
    //    {
    //        get { return _latitude; }
    //        set { if (SetProperty(ref _latitude, value)) OnPropertyChanged(nameof(IsEdit)); }
    //    }
    //    public bool isalive
    //    {
    //        get { return _isalive; }
    //        set { if (SetProperty(ref _isalive, value)) OnPropertyChanged(nameof(IsEdit)); }
    //    }

    //    public int noui
    //    {
    //        get { return _noui; }
    //        set { if (SetProperty(ref _noui, value)) OnPropertyChanged(nameof(IsEdit)); }
    //    }
    //    public string fullareanameui
    //    {
    //        get { return _fullareanameui; }
    //        set { if (SetProperty(ref _fullareanameui, value)) OnPropertyChanged(nameof(IsEdit)); }
    //    }
    //    public string localareanameui
    //    {
    //        get { return _localareanameui; }
    //        set { if (SetProperty(ref _localareanameui, value)) OnPropertyChanged(nameof(IsEdit)); }
    //    }
    //    public string fulladdressui
    //    {
    //        get { return _fulladdressui; }
    //        set { if (SetProperty(ref _fulladdressui, value)) OnPropertyChanged(nameof(IsEdit)); }
    //    }
    //    public string localaddressui
    //    {
    //        get { return _localaddressui; }
    //        set { if (SetProperty(ref _localaddressui, value)) OnPropertyChanged(nameof(IsEdit)); }
    //    }
    //    public string cityui
    //    {
    //        get { return _cityui; }
    //        set { if (SetProperty(ref _cityui, value)) OnPropertyChanged(nameof(IsEdit)); }
    //    }
    //    public DateTime starttimeui
    //    {
    //        get { return _starttimeui; }
    //        set { if (SetProperty(ref _starttimeui, value)) OnPropertyChanged(nameof(IsEdit)); }
    //    }
    //    public DateTime endtimeui
    //    {
    //        get { return _endtimeui; }
    //        set { if (SetProperty(ref _endtimeui, value)) OnPropertyChanged(nameof(IsEdit)); }
    //    }
    //    public bool nextdayui
    //    {
    //        get { return _nextdayui; }
    //        set { if (SetProperty(ref _nextdayui, value)) OnPropertyChanged(nameof(IsEdit)); }
    //    }
    //    public string stationtypeui
    //    {
    //        get { return _stationtypeui; }
    //        set { if (SetProperty(ref _stationtypeui, value)) OnPropertyChanged(nameof(IsEdit)); }
    //    }
    //    public string stationcodeui
    //    {
    //        get { return _stationcodeui; }
    //        set { if (SetProperty(ref _stationcodeui, value)) OnPropertyChanged(nameof(IsEdit)); }
    //    }
    //    public double longitudeui
    //    {
    //        get { return _longitudeui; }
    //        set { if (SetProperty(ref _longitudeui, value)) OnPropertyChanged(nameof(IsEdit)); }
    //    }
    //    public double latitudeui
    //    {
    //        get { return _latitudeui; }
    //        set { if (SetProperty(ref _latitudeui, value)) OnPropertyChanged(nameof(IsEdit)); }
    //    }
    //    public bool isaliveui
    //    {
    //        get { return _isaliveui; }
    //        set { if (SetProperty(ref _isaliveui, value)) OnPropertyChanged(nameof(IsEdit)); }
    //    }
    //    #endregion

    //    public StationInfoDBModel() : base()
    //    {

    //    }

    //    public override void CopyOriginToUI()
    //    {
    //        noui = no;
    //        fullareanameui = fullareaname;
    //    }

    //    public override void CopyUIToOrigin()
    //    {
    //        no = noui;
    //        fullareaname = fullareanameui;
    //    }

    //    public override bool IsUserEdit()
    //    {
    //        if (no != noui ||
    //            fullareaname != fullareanameui)
    //            return true;
    //        else
    //            return false;
    //    }
    //}

    //public class StationInfoDBList : ObservableCollection<StationInfoDBModel>
    //{
    //    public DataSet dataset { get; set; }

    //    public StationInfoDBList()
    //    {
    //        dataset = new DataSet();
    //    }

    //    public StationInfoDBList(List<StationInfoDBModel> stationInfodblist)
    //    {
    //        dataset = new DataSet();

    //        foreach (var model in stationInfodblist)
    //        {
    //            this.Add(model);
    //        }
    //    }

    //    public string SelectAllQuery()
    //    {
    //        return "SELECT * FROM stationinfo";
    //    }

    //    public string SelectCityQuery(string city)
    //    {
    //        return string.Format("SELECT * FROM stationinfo WHERE city = '{0}'", city);
    //    }

    //    public StationInfoDBModel SelectStationByNo(int stationno)
    //    {
    //        foreach (StationInfoDBModel station in this)
    //        {
    //            if (station.no == stationno)
    //            {
    //                return station;
    //            }
    //        }

    //        return null;
    //    }

    //    public void SelectAllDSParsing()
    //    {
    //        this.Clear();

    //        foreach (DataRow dr in dataset.Tables[0].Rows)
    //        {
    //            StationInfoDBModel stationinfodbmodel = new StationInfoDBModel();
    //            Assign(dr, stationinfodbmodel);

    //            this.Add(stationinfodbmodel);
    //        }

    //        dataset.Clear();
    //    }


    //    private void Assign(DataRow dr, StationInfoDBModel stationinfodbmodel)
    //    {
    //        stationinfodbmodel.no = Convert.ToInt32(dr["no"].ToString());
    //        stationinfodbmodel.fullareaname = dr["fullareaname"].ToString();
    //        stationinfodbmodel.localareaname = dr["localareaname"].ToString();
    //        stationinfodbmodel.fulladdress = dr["fulladdress"].ToString();
    //        stationinfodbmodel.localaddress = dr["localaddress"].ToString();
    //        stationinfodbmodel.city = dr["city"].ToString();
    //        stationinfodbmodel.starttime = DateTime.MinValue.Add(TimeSpan.Parse(dr["starttime"].ToString()));
    //        stationinfodbmodel.endtime = DateTime.MinValue.Add(TimeSpan.Parse(dr["endtime"].ToString()));
    //        stationinfodbmodel.nextday = stationinfodbmodel.endtime.Day == 2 ? true : false;
    //        stationinfodbmodel.stationtype = dr["stationtype"].ToString();
    //        stationinfodbmodel.stationcode = dr["stationcode"].ToString();
    //        stationinfodbmodel.latitude = Convert.ToDouble(dr["latitude"].ToString());
    //        stationinfodbmodel.longitude = Convert.ToDouble(dr["longitude"].ToString());
    //        stationinfodbmodel.isalive = Convert.ToBoolean(Convert.ToInt32(dr["isalive"].ToString()));
    //    }

    //    internal StationInfoDBModel GetByCityAndName(string groupName, string itemName)
    //    {
    //        StationInfoDBModel result = null;

    //        foreach (var model in this)
    //        {
    //            if (model.city == groupName &&
    //                model.fullareaname == itemName)
    //            {
    //                result = model;

    //                break;
    //            }
    //        }

    //        return result;
    //    }
    //}
}
