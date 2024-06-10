using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace ModuleProject_WPF_Default.Models
{
    public class StationInfoDBModel : IsEditUpdater
    {
        // 원본 데이터 필드
        private int _no;
        private string _fullareaname;
        private string _localareaname;
        private string _fulladdress;
        private string _localaddress;
        private string _city;
        private string _mapdirectory;
        private TimeSpan? _starttime;
        private TimeSpan? _voicetime;
        private TimeSpan? _endtime;
        private int? _scheduleinterval;
        private string _stationtype;
        private string _stationcode;
        private int? _isalive;
        private double _longitude;
        private double _latitude;
        private string _seasons;
        private int? _sunday;
        private int? _monday;
        private int? _tuseday;
        private int? _wednesday;
        private int? _thursday;
        private int? _friday;
        private int? _saturday;
        private int? _alarmoperationgroupno;

        // UI 데이터 필드
        private int _noui;
        private string _fullareanameui;
        private string _localareanameui;
        private string _fulladdressui;
        private string _localaddressui;
        private string _cityui;
        private string _mapdirectoryui;
        private TimeSpan? _starttimeui;
        private TimeSpan? _voicetimeui;
        private TimeSpan? _endtimeui;
        private int? _scheduleintervalui;
        private string _stationtypeui;
        private string _stationcodeui;
        private int? _isaliveui;
        private double _longitudeui;
        private double _latitudeui;
        private string _seasonsui;
        private int? _sundayui;
        private int? _mondayui;
        private int? _tusedayui;
        private int? _wednesdayui;
        private int? _thursdayui;
        private int? _fridayui;
        private int? _saturdayui;
        private int? _alarmoperationgroupnoui;

        // 원본 데이터 프로퍼티
        public int no
        {
            get { return _no; }
            set
            {
                if (SetProperty(ref _no, value))
                {
                    OnPropertyChanged(nameof(IsEdit));
                }
            }
        }

        public string fullareaname
        {
            get { return _fullareaname; }
            set
            {
                if (SetProperty(ref _fullareaname, value))
                {
                    OnPropertyChanged(nameof(IsEdit));
                }
            }
        }

        public string localareaname
        {
            get { return _localareaname; }
            set
            {
                if (SetProperty(ref _localareaname, value))
                {
                    OnPropertyChanged(nameof(IsEdit));
                }
            }
        }

        public string fulladdress
        {
            get { return _fulladdress; }
            set
            {
                if (SetProperty(ref _fulladdress, value))
                {
                    OnPropertyChanged(nameof(IsEdit));
                }
            }
        }

        public string localaddress
        {
            get { return _localaddress; }
            set
            {
                if (SetProperty(ref _localaddress, value))
                {
                    OnPropertyChanged(nameof(IsEdit));
                }
            }
        }

        public string city
        {
            get { return _city; }
            set
            {
                if (SetProperty(ref _city, value))
                {
                    OnPropertyChanged(nameof(IsEdit));
                }
            }
        }

        public string mapdirectory
        {
            get { return _mapdirectory; }
            set
            {
                if (SetProperty(ref _mapdirectory, value))
                {
                    OnPropertyChanged(nameof(IsEdit));
                }
            }
        }

        public TimeSpan? starttime
        {
            get { return _starttime; }
            set
            {
                if (SetProperty(ref _starttime, value))
                {
                    OnPropertyChanged(nameof(IsEdit));
                }
            }
        }

        public TimeSpan? voicetime
        {
            get { return _voicetime; }
            set
            {
                if (SetProperty(ref _voicetime, value))
                {
                    OnPropertyChanged(nameof(IsEdit));
                }
            }
        }

        public TimeSpan? endtime
        {
            get { return _endtime; }
            set
            {
                if (SetProperty(ref _endtime, value))
                {
                    OnPropertyChanged(nameof(IsEdit));
                }
            }
        }

        public int? scheduleinterval
        {
            get { return _scheduleinterval; }
            set
            {
                if (SetProperty(ref _scheduleinterval, value))
                {
                    OnPropertyChanged(nameof(IsEdit));
                }
            }
        }

        public string stationtype
        {
            get { return _stationtype; }
            set
            {
                if (SetProperty(ref _stationtype, value))
                {
                    OnPropertyChanged(nameof(IsEdit));
                }
            }
        }

        public string stationcode
        {
            get { return _stationcode; }
            set
            {
                if (SetProperty(ref _stationcode, value))
                {
                    OnPropertyChanged(nameof(IsEdit));
                }
            }
        }

        public int? isalive
        {
            get { return _isalive; }
            set
            {
                if (SetProperty(ref _isalive, value))
                {
                    OnPropertyChanged(nameof(IsEdit));
                }
            }
        }

        public double longitude
        {
            get { return _longitude; }
            set
            {
                if (SetProperty(ref _longitude, value))
                {
                    OnPropertyChanged(nameof(IsEdit));
                }
            }
        }

        public double latitude
        {
            get { return _latitude; }
            set
            {
                if (SetProperty(ref _latitude, value))
                {
                    OnPropertyChanged(nameof(IsEdit));
                }
            }
        }

        public string seasons
        {
            get { return _seasons; }
            set
            {
                if (SetProperty(ref _seasons, value))
                {
                    OnPropertyChanged(nameof(IsEdit));
                }
            }
        }

        public int? sunday
        {
            get { return _sunday; }
            set
            {
                if (SetProperty(ref _sunday, value))
                {
                    OnPropertyChanged(nameof(IsEdit));
                }
            }
        }

        public int? monday
        {
            get { return _monday; }
            set
            {
                if (SetProperty(ref _monday, value))
                {
                    OnPropertyChanged(nameof(IsEdit));
                }
            }
        }

        public int? tuseday
        {
            get { return _tuseday; }
            set
            {
                if (SetProperty(ref _tuseday, value))
                {
                    OnPropertyChanged(nameof(IsEdit));
                }
            }
        }

        public int? wednesday
        {
            get { return _wednesday; }
            set
            {
                if (SetProperty(ref _wednesday, value))
                {
                    OnPropertyChanged(nameof(IsEdit));
                }
            }
        }

        public int? thursday
        {
            get { return _thursday; }
            set
            {
                if (SetProperty(ref _thursday, value))
                {
                    OnPropertyChanged(nameof(IsEdit));
                }
            }
        }

        public int? friday
        {
            get { return _friday; }
            set
            {
                if (SetProperty(ref _friday, value))
                {
                    OnPropertyChanged(nameof(IsEdit));
                }
            }
        }

        public int? saturday
        {
            get { return _saturday; }
            set
            {
                if (SetProperty(ref _saturday, value))
                {
                    OnPropertyChanged(nameof(IsEdit));
                }
            }
        }

        public int? alarmoperationgroupno
        {
            get { return _alarmoperationgroupno; }
            set
            {
                if (SetProperty(ref _alarmoperationgroupno, value))
                {
                    OnPropertyChanged(nameof(IsEdit));
                }
            }
        }

        // UI 데이터 프로퍼티
        public int noui
        {
            get { return _noui; }
            set
            {
                if (SetProperty(ref _noui, value))
                {
                    OnPropertyChanged(nameof(IsEdit));
                }
            }
        }

        public string fullareanameui
        {
            get { return _fullareanameui; }
            set
            {
                if (SetProperty(ref _fullareanameui, value))
                {
                    OnPropertyChanged(nameof(IsEdit));
                }
            }
        }

        public string localareanameui
        {
            get { return _localareanameui; }
            set
            {
                if (SetProperty(ref _localareanameui, value))
                {
                    OnPropertyChanged(nameof(IsEdit));
                }
            }
        }

        public string fulladdressui
        {
            get { return _fulladdressui; }
            set
            {
                if (SetProperty(ref _fulladdressui, value))
                {
                    OnPropertyChanged(nameof(IsEdit));
                }
            }
        }

        public string localaddressui
        {
            get { return _localaddressui; }
            set
            {
                if (SetProperty(ref _localaddressui, value))
                {
                    OnPropertyChanged(nameof(IsEdit));
                }
            }
        }

        public string cityui
        {
            get { return _cityui; }
            set
            {
                if (SetProperty(ref _cityui, value))
                {
                    OnPropertyChanged(nameof(IsEdit));
                }
            }
        }

        public string mapdirectoryui
        {
            get { return _mapdirectoryui; }
            set
            {
                if (SetProperty(ref _mapdirectoryui, value))
                {
                    OnPropertyChanged(nameof(IsEdit));
                }
            }
        }

        public TimeSpan? starttimeui
        {
            get { return _starttimeui; }
            set
            {
                if (SetProperty(ref _starttimeui, value))
                {
                    OnPropertyChanged(nameof(IsEdit));
                }
            }
        }

        public TimeSpan? voicetimeui
        {
            get { return _voicetimeui; }
            set
            {
                if (SetProperty(ref _voicetimeui, value))
                {
                    OnPropertyChanged(nameof(IsEdit));
                }
            }
        }

        public TimeSpan? endtimeui
        {
            get { return _endtimeui; }
            set
            {
                if (SetProperty(ref _endtimeui, value))
                {
                    OnPropertyChanged(nameof(IsEdit));
                }
            }
        }

        public int? scheduleintervalui
        {
            get { return _scheduleintervalui; }
            set
            {
                if (SetProperty(ref _scheduleintervalui, value))
                {
                    OnPropertyChanged(nameof(IsEdit));
                }
            }
        }

        public string stationtypeui
        {
            get { return _stationtypeui; }
            set
            {
                if (SetProperty(ref _stationtypeui, value))
                {
                    OnPropertyChanged(nameof(IsEdit));
                }
            }
        }

        public string stationcodeui
        {
            get { return _stationcodeui; }
            set
            {
                if (SetProperty(ref _stationcodeui, value))
                {
                    OnPropertyChanged(nameof(IsEdit));
                }
            }
        }

        public int? isaliveui
        {
            get { return _isaliveui; }
            set
            {
                if (SetProperty(ref _isaliveui, value))
                {
                    OnPropertyChanged(nameof(IsEdit));
                }
            }
        }

        public double longitudeui
        {
            get { return _longitudeui; }
            set
            {
                if (SetProperty(ref _longitudeui, value))
                {
                    OnPropertyChanged(nameof(IsEdit));
                }
            }
        }

        public double latitudeui
        {
            get { return _latitudeui; }
            set
            {
                if (SetProperty(ref _latitudeui, value))
                {
                    OnPropertyChanged(nameof(IsEdit));
                }
            }
        }

        public string seasonsui
        {
            get { return _seasonsui; }
            set
            {
                if (SetProperty(ref _seasonsui, value))
                {
                    OnPropertyChanged(nameof(IsEdit));
                }
            }
        }

        public int? sundayui
        {
            get { return _sundayui; }
            set
            {
                if (SetProperty(ref _sundayui, value))
                {
                    OnPropertyChanged(nameof(IsEdit));
                }
            }
        }

        public int? mondayui
        {
            get { return _mondayui; }
            set
            {
                if (SetProperty(ref _mondayui, value))
                {
                    OnPropertyChanged(nameof(IsEdit));
                }
            }
        }

        public int? tusedayui
        {
            get { return _tusedayui; }
            set
            {
                if (SetProperty(ref _tusedayui, value))
                {
                    OnPropertyChanged(nameof(IsEdit));
                }
            }
        }

        public int? wednesdayui
        {
            get { return _wednesdayui; }
            set
            {
                if (SetProperty(ref _wednesdayui, value))
                {
                    OnPropertyChanged(nameof(IsEdit));
                }
            }
        }

        public int? thursdayui
        {
            get { return _thursdayui; }
            set
            {
                if (SetProperty(ref _thursdayui, value))
                {
                    OnPropertyChanged(nameof(IsEdit));
                }
            }
        }

        public int? fridayui
        {
            get { return _fridayui; }
            set
            {
                if (SetProperty(ref _fridayui, value))
                {
                    OnPropertyChanged(nameof(IsEdit));
                }
            }
        }

        public int? saturdayui
        {
            get { return _saturdayui; }
            set
            {
                if (SetProperty(ref _saturdayui, value))
                {
                    OnPropertyChanged(nameof(IsEdit));
                }
            }
        }

        public int? alarmoperationgroupnoui
        {
            get { return _alarmoperationgroupnoui; }
            set
            {
                if (SetProperty(ref _alarmoperationgroupnoui, value))
                {
                    OnPropertyChanged(nameof(IsEdit));
                }
            }
        }

        // 기본 생성자
        public StationInfoDBModel() : base() { }

        // 원본 데이터를 UI 데이터로 복사
        public override void CopyOriginToUI()
        {
            noui = no;
            fullareanameui = fullareaname;
            localareanameui = localareaname;
            fulladdressui = fulladdress;
            localaddressui = localaddress;
            cityui = city;
            mapdirectoryui = mapdirectory;
            starttimeui = starttime;
            voicetimeui = voicetime;
            endtimeui = endtime;
            scheduleintervalui = scheduleinterval;
            stationtypeui = stationtype;
            stationcodeui = stationcode;
            isaliveui = isalive;
            longitudeui = longitude;
            latitudeui = latitude;
            seasonsui = seasons;
            sundayui = sunday;
            mondayui = monday;
            tusedayui = tuseday;
            wednesdayui = wednesday;
            thursdayui = thursday;
            fridayui = friday;
            saturdayui = saturday;
            alarmoperationgroupnoui = alarmoperationgroupno;
        }

        // UI 데이터를 원본 데이터로 복사
        public override void CopyUIToOrigin()
        {
            no = noui;
            fullareaname = fullareanameui;
            localareaname = localareanameui;
            fulladdress = fulladdressui;
            localaddress = localaddressui;
            city = cityui;
            mapdirectory = mapdirectoryui;
            starttime = starttimeui;
            voicetime = voicetimeui;
            endtime = endtimeui;
            scheduleinterval = scheduleintervalui;
            stationtype = stationtypeui;
            stationcode = stationcodeui;
            isalive = isaliveui;
            longitude = longitudeui;
            latitude = latitudeui;
            seasons = seasonsui;
            sunday = sundayui;
            monday = mondayui;
            tuseday = tusedayui;
            wednesday = wednesdayui;
            thursday = thursdayui;
            friday = fridayui;
            saturday = saturdayui;
            alarmoperationgroupno = alarmoperationgroupnoui;
        }

        // 사용자가 데이터를 편집했는지 확인
        public override bool IsUserEdit()
        {
            return no != noui ||
                   fullareaname != fullareanameui ||
                   localareaname != localareanameui ||
                   fulladdress != fulladdressui ||
                   localaddress != localaddressui ||
                   city != cityui ||
                   mapdirectory != mapdirectoryui ||
                   starttime != starttimeui ||
                   voicetime != voicetimeui ||
                   endtime != endtimeui ||
                   scheduleinterval != scheduleintervalui ||
                   stationtype != stationtypeui ||
                   stationcode != stationcodeui ||
                   isalive != isaliveui ||
                   longitude != longitudeui ||
                   latitude != latitudeui ||
                   seasons != seasonsui ||
                   sunday != sundayui ||
                   monday != mondayui ||
                   tuseday != tusedayui ||
                   wednesday != wednesdayui ||
                   thursday != thursdayui ||
                   friday != fridayui ||
                   saturday != saturdayui ||
                   alarmoperationgroupno != alarmoperationgroupnoui;
        }
    }

    public class StationInfoDBList : BaseDBList<StationInfoDBModel>
    {
        public StationInfoDBList() : base() { }

        // Method to generate the SQL query for selecting all entries from the stationinfo table
        public string SelectAllQuery()
        {
            return "SELECT * FROM stationinfo";
        }

        // Method to parse the dataset and populate the collection
        public void SelectAllDSParsing()
        {
            this.Clear();

            foreach (DataRow dr in dataset.Tables[0].Rows)
            {
                StationInfoDBModel model = new StationInfoDBModel();
                Assign(dr, model);

                this.Add(model);
            }

            dataset.Clear();
        }

        // Method to map a DataRow to a StationInfoModel instance
        private void Assign(DataRow dr, StationInfoDBModel model)
        {
            model.no = Convert.ToInt32(dr["no"].ToString());
            model.fullareaname = dr["fullareaname"]?.ToString();
            model.localareaname = dr["localareaname"]?.ToString();
            model.fulladdress = dr["fulladdress"]?.ToString();
            model.localaddress = dr["localaddress"]?.ToString();
            model.city = dr["city"]?.ToString();
            model.mapdirectory = dr["mapdirectory"]?.ToString();
            model.starttime = dr["starttime"] == DBNull.Value ? (TimeSpan?)null : TimeSpan.Parse(dr["starttime"].ToString());
            model.voicetime = dr["voicetime"] == DBNull.Value ? (TimeSpan?)null : TimeSpan.Parse(dr["voicetime"].ToString());
            model.endtime = dr["endtime"] == DBNull.Value ? (TimeSpan?)null : TimeSpan.Parse(dr["endtime"].ToString());
            model.scheduleinterval = dr["scheduleinterval"] == DBNull.Value ? (int?)null : Convert.ToInt32(dr["scheduleinterval"].ToString());
            model.stationtype = dr["stationtype"]?.ToString();
            model.stationcode = dr["stationcode"]?.ToString();
            model.isalive = dr["isalive"] == DBNull.Value ? (int?)null : Convert.ToInt32(dr["isalive"].ToString());
            model.longitude = dr["longitude"] == DBNull.Value ? 0 : Convert.ToDouble(dr["longitude"].ToString());
            model.latitude = dr["latitude"] == DBNull.Value ? 0 : Convert.ToDouble(dr["latitude"].ToString());
            model.seasons = dr["seasons"]?.ToString();
            model.sunday = dr["sunday"] == DBNull.Value ? (int?)null : Convert.ToInt32(dr["sunday"].ToString());
            model.monday = dr["monday"] == DBNull.Value ? (int?)null : Convert.ToInt32(dr["monday"].ToString());
            model.tuseday = dr["tuseday"] == DBNull.Value ? (int?)null : Convert.ToInt32(dr["tuseday"].ToString());
            model.wednesday = dr["wednesday"] == DBNull.Value ? (int?)null : Convert.ToInt32(dr["wednesday"].ToString());
            model.thursday = dr["thursday"] == DBNull.Value ? (int?)null : Convert.ToInt32(dr["thursday"].ToString());
            model.friday = dr["friday"] == DBNull.Value ? (int?)null : Convert.ToInt32(dr["friday"].ToString());
            model.saturday = dr["saturday"] == DBNull.Value ? (int?)null : Convert.ToInt32(dr["saturday"].ToString());
            model.alarmoperationgroupno = dr["alarmoperationgroupno"] == DBNull.Value ? (int?)null : Convert.ToInt32(dr["alarmoperationgroupno"].ToString());
        }

        // Method to get a model by its No property
        public StationInfoDBModel GetByNo(int no)
        {
            return this.FirstOrDefault(a => a.no == no);
        }
    }
}
