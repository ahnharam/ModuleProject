using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace SystemEditor.DBModel.DBData
{
    public class StationInfoDBModel : IsEditUpdater, IDBQuery
    {
        // 원본 데이터 필드
        private int _no;
        private string _fullareaname;
        private string _localareaname;
        private string _fulladdress;
        private string _localaddress;
        private string _city;
        private string _mapdirectory;
        private DateTime _starttime;
        private DateTime _voicetime;
        private DateTime _endtime;
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
        private bool _isnextday;
        private bool _isnextdayui;

        // UI 데이터 필드
        private int _noui;
        private string _fullareanameui;
        private string _localareanameui;
        private string _fulladdressui;
        private string _localaddressui;
        private string _cityui;
        private string _mapdirectoryui;
        private DateTime _starttimeui;
        private DateTime _voicetimeui;
        private DateTime _endtimeui;
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
                    UserEditEvent?.Invoke();
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
                    UserEditEvent?.Invoke();
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
                    UserEditEvent?.Invoke();
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
                    UserEditEvent?.Invoke();
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
                    UserEditEvent?.Invoke();
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
                    UserEditEvent?.Invoke();
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
                    UserEditEvent?.Invoke();
                }
            }
        }

        public DateTime starttime
        {
            get { return _starttime; }
            set
            {
                if (SetProperty(ref _starttime, value))
                {
                    UserEditEvent?.Invoke();
                }
            }
        }

        public DateTime voicetime
        {
            get { return _voicetime; }
            set
            {
                if (SetProperty(ref _voicetime, value))
                {
                    UserEditEvent?.Invoke();
                }
            }
        }

        public DateTime endtime
        {
            get { return _endtime; }
            set
            {
                if (SetProperty(ref _endtime, value))
                {
                    UserEditEvent?.Invoke();
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
                    UserEditEvent?.Invoke();
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
                    UserEditEvent?.Invoke();
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
                    UserEditEvent?.Invoke();
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
                    UserEditEvent?.Invoke();
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
                    UserEditEvent?.Invoke();
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
                    UserEditEvent?.Invoke();
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
                    UserEditEvent?.Invoke();
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
                    UserEditEvent?.Invoke();
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
                    UserEditEvent?.Invoke();
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
                    UserEditEvent?.Invoke();
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
                    UserEditEvent?.Invoke();
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
                    UserEditEvent?.Invoke();
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
                    UserEditEvent?.Invoke();
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
                    UserEditEvent?.Invoke();
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
                    UserEditEvent?.Invoke();
                }
            }
        }
        public bool IsNextDay
        {
            get { return _isnextday; }
            set
            {
                if (SetProperty(ref _isnextday, value))
                {
                    UserEditEvent?.Invoke();
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
                    UserEditEvent?.Invoke();
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
                    UserEditEvent?.Invoke();
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
                    UserEditEvent?.Invoke();
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
                    UserEditEvent?.Invoke();
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
                    UserEditEvent?.Invoke();
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
                    UserEditEvent?.Invoke();
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
                    UserEditEvent?.Invoke();
                }
            }
        }

        public DateTime starttimeui
        {
            get { return _starttimeui; }
            set
            {
                if (SetProperty(ref _starttimeui, value))
                {
                    UserEditEvent?.Invoke();
                }
            }
        }

        public DateTime voicetimeui
        {
            get { return _voicetimeui; }
            set
            {
                if (SetProperty(ref _voicetimeui, value))
                {
                    UserEditEvent?.Invoke();
                }
            }
        }

        public DateTime endtimeui
        {
            get { return _endtimeui; }
            set
            {
                if (SetProperty(ref _endtimeui, value))
                {
                    UserEditEvent?.Invoke();
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
                    UserEditEvent?.Invoke();
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
                    UserEditEvent?.Invoke();
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
                    UserEditEvent?.Invoke();
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
                    UserEditEvent?.Invoke();
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
                    UserEditEvent?.Invoke();
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
                    UserEditEvent?.Invoke();
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
                    UserEditEvent?.Invoke();
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
                    UserEditEvent?.Invoke();
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
                    UserEditEvent?.Invoke();
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
                    UserEditEvent?.Invoke();
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
                    UserEditEvent?.Invoke();
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
                    UserEditEvent?.Invoke();
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
                    UserEditEvent?.Invoke();
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
                    UserEditEvent?.Invoke();
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
                    UserEditEvent?.Invoke();
                }
            }
        }
        public bool IsNextDayUI
        {
            get { return _isnextdayui; }
            set
            {
                if (SetProperty(ref _isnextdayui, value))
                {
                    UserEditEvent?.Invoke();
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

        public void ConvertOriginToUi() { }
        public void ConvertUiToOrigin() { }

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

        public void SetAutoIncrementIndex(long autoincrementindex) { }

        // InsertQuery 메서드
        public string InsertQuery()
        {
            return string.Format(
                "INSERT INTO stationinfo (no, fullareaname, localareaname, fulladdress, localaddress, city, mapdirectory, starttime, voicetime, endtime, scheduleinterval, stationtype, stationcode, isalive, longitude, latitude, seasons, sunday, monday, tuseday, wednesday, thursday, friday, saturday, alarmoperationgroupno) VALUES ({0}, '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', {10}, '{11}', '{12}', {13}, {14}, {15}, '{16}', {17}, {18}, {19}, {20}, {21}, {22}, {23}, {24})",
                _no,
                _fullareaname,
                _localareaname,
                _fulladdress,
                _localaddress,
                _city,
                _mapdirectory,
                _starttime.ToString("yyyy-MM-dd HH:mm:ss"),
                _voicetime.ToString("yyyy-MM-dd HH:mm:ss"),
                _endtime.ToString("yyyy-MM-dd HH:mm:ss"),
                _scheduleinterval.HasValue ? _scheduleinterval.Value.ToString() : "NULL",
                _stationtype,
                _stationcode,
                _isalive.HasValue ? _isalive.Value.ToString() : "NULL",
                _longitude,
                _latitude,
                _seasons,
                _sunday.HasValue ? _sunday.Value.ToString() : "NULL",
                _monday.HasValue ? _monday.Value.ToString() : "NULL",
                _tuseday.HasValue ? _tuseday.Value.ToString() : "NULL",
                _wednesday.HasValue ? _wednesday.Value.ToString() : "NULL",
                _thursday.HasValue ? _thursday.Value.ToString() : "NULL",
                _friday.HasValue ? _friday.Value.ToString() : "NULL",
                _saturday.HasValue ? _saturday.Value.ToString() : "NULL",
                _alarmoperationgroupno.HasValue ? _alarmoperationgroupno.Value.ToString() : "NULL"
            );
        }

        // InsertSubQuery 메서드
        public string[] InsertSubQuery()
        {
            // 서브 쿼리가 필요하지 않으므로 빈 배열을 반환합니다.
            return new string[] { };
        }

        // UpdateQuery 메서드
        public string[] UpdateQuery()
        {
            return new string[]
            {
                string.Format(
                    "UPDATE stationinfo SET fullareaname = '{0}', localareaname = '{1}', fulladdress = '{2}', localaddress = '{3}', city = '{4}', mapdirectory = '{5}', starttime = '{6}', voicetime = '{7}', endtime = '{8}', scheduleinterval = {9}, stationtype = '{10}', stationcode = '{11}', isalive = {12}, longitude = {13}, latitude = {14}, seasons = '{15}', sunday = {16}, monday = {17}, tuseday = {18}, wednesday = {19}, thursday = {20}, friday = {21}, saturday = {22}, alarmoperationgroupno = {23} WHERE no = {24}",
                    _fullareaname,
                    _localareaname,
                    _fulladdress,
                    _localaddress,
                    _city,
                    _mapdirectory,
                    _starttime.ToString("yyyy-MM-dd HH:mm:ss"),
                    _voicetime.ToString("yyyy-MM-dd HH:mm:ss"),
                    _endtime.ToString("yyyy-MM-dd HH:mm:ss"),
                    _scheduleinterval.HasValue ? _scheduleinterval.Value.ToString() : "NULL",
                    _stationtype,
                    _stationcode,
                    _isalive.HasValue ? _isalive.Value.ToString() : "NULL",
                    _longitude,
                    _latitude,
                    _seasons,
                    _sunday.HasValue ? _sunday.Value.ToString() : "NULL",
                    _monday.HasValue ? _monday.Value.ToString() : "NULL",
                    _tuseday.HasValue ? _tuseday.Value.ToString() : "NULL",
                    _wednesday.HasValue ? _wednesday.Value.ToString() : "NULL",
                    _thursday.HasValue ? _thursday.Value.ToString() : "NULL",
                    _friday.HasValue ? _friday.Value.ToString() : "NULL",
                    _saturday.HasValue ? _saturday.Value.ToString() : "NULL",
                    _alarmoperationgroupno.HasValue ? _alarmoperationgroupno.Value.ToString() : "NULL",
                    _no
                )
            };
        }

        // DeleteQueryList 메서드
        public string[] DeleteQueryList()
        {
            return new string[]
            {
                string.Format("DELETE FROM stationinfo WHERE no = {0}", _no),
            };
        }
    }

    public class StationInfoDBList : BaseDBListByOC<StationInfoDBModel>
    {
        public StationInfoDBList() : base()
        {

        }

        public StationInfoDBList(List<StationInfoDBModel> stationInfodblist) : base()
        {
            foreach (var model in stationInfodblist)
            {
                this.Add(model);
            }
        }

        // Method to generate the SQL query for selecting all entries from the stationinfo table
        public string SelectAllQuery()
        {
            return "SELECT * FROM stationinfo";
        }

        public string SelectCityQuery(string city)
        {
            return string.Format("SELECT * FROM stationinfo WHERE city = '{0}'", city);
        }

        // Method to parse the dataset and populate the collection
        public void SelectAllDSParsing()
        {
            this.Clear();

            foreach (DataRow dr in dataset.Tables[0].Rows)
            {
                StationInfoDBModel model = new StationInfoDBModel();
                Assign(dr, model);
                model.CopyOriginToUI();

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
            model.starttime = dr["starttime"] == DBNull.Value ? DateTime.MinValue : DateTime.MinValue.Add(TimeSpan.Parse(dr["starttime"].ToString()));
            model.voicetime = dr["voicetime"] == DBNull.Value ? DateTime.MinValue : DateTime.MinValue.Add(TimeSpan.Parse(dr["voicetime"].ToString()));
            model.endtime = dr["endtime"] == DBNull.Value ? DateTime.MinValue : DateTime.MinValue.Add(TimeSpan.Parse(dr["endtime"].ToString()));
            model.IsNextDay = model.endtime.Day == 2 ? true : false;
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

        public StationInfoDBModel GetByFullAreaName(string fullareaname)
        {
            return this.FirstOrDefault(a => a.fullareaname == fullareaname);
        }

        internal StationInfoDBModel GetByCityAndName(string groupName, string itemName)
        {
            return this.FirstOrDefault(model => model.city == groupName && model.fullareaname == itemName);
        }
    }
}
