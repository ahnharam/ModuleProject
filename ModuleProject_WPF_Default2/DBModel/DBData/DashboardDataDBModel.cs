using System;
using System.Data;
using System.Linq;

namespace SystemEditor.DBModel.DBData
{
    public class DashboardDataDBModel : IsEditUpdater, IDBQuery
    {
        // 원본 데이터 필드
        private int _no;
        private int? _stationno;
        private int? _sortindex;
        private int? _sensorsot;
        private string _datasort;
        private int? _sensorno;
        private int? _subsensorno;
        private string _sensortarget;
        private string _defaultvalue;
        private string _sensorname;
        private string _alarmcode;

        // UI 데이터 필드
        private int _noui;
        private int? _stationnoui;
        private int? _sortindexui;
        private int? _sensorsotui;
        private string _datasortui;
        private int? _sensornoui;
        private int? _subsensornoui;
        private string _sensortargetui;
        private string _defaultvalueui;
        private string _sensornamedui;
        private string _alarmcodeui;

        // 원본 데이터 프로퍼티
        public int no
        {
            get { return _no; }
            set { if (SetProperty(ref _no, value)) UserEditEvent?.Invoke(); }
        }

        public int? stationno
        {
            get { return _stationno; }
            set { if (SetProperty(ref _stationno, value)) UserEditEvent?.Invoke(); }
        }

        public int? sortindex
        {
            get { return _sortindex; }
            set { if (SetProperty(ref _sortindex, value)) UserEditEvent?.Invoke(); }
        }

        public int? sensorsot
        {
            get { return _sensorsot; }
            set { if (SetProperty(ref _sensorsot, value)) UserEditEvent?.Invoke(); }
        }

        public string datasort
        {
            get { return _datasort; }
            set { if (SetProperty(ref _datasort, value)) UserEditEvent?.Invoke(); }
        }

        public int? sensorno
        {
            get { return _sensorno; }
            set { if (SetProperty(ref _sensorno, value)) UserEditEvent?.Invoke(); }
        }

        public int? subsensorno
        {
            get { return _subsensorno; }
            set { if (SetProperty(ref _subsensorno, value)) UserEditEvent?.Invoke(); }
        }

        public string sensortarget
        {
            get { return _sensortarget; }
            set { if (SetProperty(ref _sensortarget, value)) UserEditEvent?.Invoke(); }
        }

        public string defaultvalue
        {
            get { return _defaultvalue; }
            set { if (SetProperty(ref _defaultvalue, value)) UserEditEvent?.Invoke(); }
        }

        public string sensorname
        {
            get { return _sensorname; }
            set { if (SetProperty(ref _sensorname, value)) UserEditEvent?.Invoke(); }
        }

        public string alarmcode
        {
            get { return _alarmcode; }
            set { if (SetProperty(ref _alarmcode, value)) UserEditEvent?.Invoke(); }
        }

        // UI 데이터 프로퍼티
        public int noui
        {
            get { return _noui; }
            set { if (SetProperty(ref _noui, value)) UserEditEvent?.Invoke(); }
        }

        public int? stationnoui
        {
            get { return _stationnoui; }
            set { if (SetProperty(ref _stationnoui, value)) UserEditEvent?.Invoke(); }
        }

        public int? sortindexui
        {
            get { return _sortindexui; }
            set { if (SetProperty(ref _sortindexui, value)) UserEditEvent?.Invoke(); }
        }

        public int? sensorsotui
        {
            get { return _sensorsotui; }
            set { if (SetProperty(ref _sensorsotui, value)) UserEditEvent?.Invoke(); }
        }

        public string datasortui
        {
            get { return _datasortui; }
            set { if (SetProperty(ref _datasortui, value)) UserEditEvent?.Invoke(); }
        }

        public int? sensornoui
        {
            get { return _sensornoui; }
            set { if (SetProperty(ref _sensornoui, value)) UserEditEvent?.Invoke(); }
        }

        public int? subsensornoui
        {
            get { return _subsensornoui; }
            set { if (SetProperty(ref _subsensornoui, value)) UserEditEvent?.Invoke(); }
        }

        public string sensortargetui
        {
            get { return _sensortargetui; }
            set { if (SetProperty(ref _sensortargetui, value)) UserEditEvent?.Invoke(); }
        }

        public string defaultvalueui
        {
            get { return _defaultvalueui; }
            set { if (SetProperty(ref _defaultvalueui, value)) UserEditEvent?.Invoke(); }
        }

        public string sensornamedui
        {
            get { return _sensornamedui; }
            set { if (SetProperty(ref _sensornamedui, value)) UserEditEvent?.Invoke(); }
        }

        public string alarmcodeui
        {
            get { return _alarmcodeui; }
            set { if (SetProperty(ref _alarmcodeui, value)) UserEditEvent?.Invoke(); }
        }

        // 기본 생성자
        public DashboardDataDBModel() : base() { }

        // 원본 데이터를 UI 데이터로 복사
        public override void CopyOriginToUI()
        {
            noui = no;
            stationnoui = stationno;
            sortindexui = sortindex;
            sensorsotui = sensorsot;
            datasortui = datasort;
            sensornoui = sensorno;
            subsensornoui = subsensorno;
            sensortargetui = sensortarget;
            defaultvalueui = defaultvalue;
            sensornamedui = sensorname;
            alarmcodeui = alarmcode;
        }

        // UI 데이터를 원본 데이터로 복사
        public override void CopyUIToOrigin()
        {
            no = noui;
            stationno = stationnoui;
            sortindex = sortindexui;
            sensorsot = sensorsotui;
            datasort = datasortui;
            sensorno = sensornoui;
            subsensorno = subsensornoui;
            sensortarget = sensortargetui;
            defaultvalue = defaultvalueui;
            sensorname = sensornamedui;
            alarmcode = alarmcodeui;
        }
        public void ConvertOriginToUi() { }
        public void ConvertUiToOrigin() { }

        // 사용자가 데이터를 편집했는지 확인
        public override bool IsUserEdit()
        {
            return no != noui ||
                   stationno != stationnoui ||
                   sortindex != sortindexui ||
                   sensorsot != sensorsotui ||
                   datasort != datasortui ||
                   sensorno != sensornoui ||
                   subsensorno != subsensornoui ||
                   sensortarget != sensortargetui ||
                   defaultvalue != defaultvalueui ||
                   sensorname != sensornamedui ||
                   alarmcode != alarmcodeui;
        }

        public void SetAutoIncrementIndex(long autoincrementindex) { }

        // Insert query
        public string InsertQuery()
        {
            return string.Format(
                "INSERT INTO dashboarddata (stationno, sortindex, sensorsot, datasort, sensorno, subsensorno, sensortarget, defaultvalue, sensorname, alarmcode) VALUES ({0}, {1}, {2}, '{3}', {4}, {5}, '{6}', '{7}', '{8}', '{9}')",
                _stationno.HasValue ? _stationno.Value.ToString() : "NULL",
                _sortindex.HasValue ? _sortindex.Value.ToString() : "NULL",
                _sensorsot.HasValue ? _sensorsot.Value.ToString() : "NULL",
                _datasort,
                _sensorno.HasValue ? _sensorno.Value.ToString() : "NULL",
                _subsensorno.HasValue ? _subsensorno.Value.ToString() : "NULL",
                _sensortarget,
                _defaultvalue,
                _sensorname,
                _alarmcode
            );
        }

        // Insert sub query
        public string[] InsertSubQuery()
        {
            return new string[] { };
        }

        // Update query
        public string[] UpdateQuery()
        {
            return new string[]
            {
                string.Format(
                    "UPDATE dashboarddata SET stationno = {0}, sortindex = {1}, sensorsot = {2}, datasort = '{3}', sensorno = {4}, subsensorno = {5}, sensortarget = '{6}', defaultvalue = '{7}', sensorname = '{8}', alarmcode = '{9}' WHERE no = {10}",
                    _stationno.HasValue ? _stationno.Value.ToString() : "NULL",
                    _sortindex.HasValue ? _sortindex.Value.ToString() : "NULL",
                    _sensorsot.HasValue ? _sensorsot.Value.ToString() : "NULL",
                    _datasort,
                    _sensorno.HasValue ? _sensorno.Value.ToString() : "NULL",
                    _subsensorno.HasValue ? _subsensorno.Value.ToString() : "NULL",
                    _sensortarget,
                    _defaultvalue,
                    _sensorname,
                    _alarmcode,
                    _no
                )
            };
        }

        // Delete query list
        public string[] DeleteQueryList()
        {
            return new string[]
            {
                string.Format("DELETE FROM dashboarddata WHERE no = {0}", _no)
            };
        }
    }

    public class DashboardDataDBList : BaseDBListByOC<DashboardDataDBModel>
    {
        public DashboardDataDBList() : base() { }

        // Method to generate the SQL query for selecting all entries from the dashboarddata table
        public string SelectAllQuery()
        {
            return "SELECT * FROM dashboarddata";
        }

        // Method to parse the dataset and populate the collection
        public void SelectAllDSParsing()
        {
            this.Clear();

            foreach (DataRow dr in dataset.Tables[0].Rows)
            {
                DashboardDataDBModel model = new DashboardDataDBModel();
                Assign(dr, model);

                this.Add(model);
            }

            dataset.Clear();
        }

        // Method to map a DataRow to a DashboardDataModel instance
        private void Assign(DataRow dr, DashboardDataDBModel model)
        {
            model.no = Convert.ToInt32(dr["no"].ToString());
            model.stationno = dr["stationno"] == DBNull.Value ? (int?)null : Convert.ToInt32(dr["stationno"].ToString());
            model.sortindex = dr["sortindex"] == DBNull.Value ? (int?)null : Convert.ToInt32(dr["sortindex"].ToString());
            model.sensorsot = dr["sensorsot"] == DBNull.Value ? (int?)null : Convert.ToInt32(dr["sensorsot"].ToString());
            model.datasort = dr["datasort"]?.ToString();
            model.sensorno = dr["sensorno"] == DBNull.Value ? (int?)null : Convert.ToInt32(dr["sensorno"].ToString());
            model.subsensorno = dr["subsensorno"] == DBNull.Value ? (int?)null : Convert.ToInt32(dr["subsensorno"].ToString());
            model.sensortarget = dr["sensortarget"]?.ToString();
            model.defaultvalue = dr["defaultvalue"]?.ToString();
            model.sensorname = dr["sensorname"]?.ToString();
            model.alarmcode = dr["alarmcode"]?.ToString();
        }

        // Method to get a model by its No property
        public DashboardDataDBModel GetByNo(int no)
        {
            return this.FirstOrDefault(a => a.no == no);
        }
    }
}
