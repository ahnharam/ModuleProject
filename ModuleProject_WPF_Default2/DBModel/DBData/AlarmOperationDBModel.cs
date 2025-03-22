using System;
using System.Data;
using System.Linq;

namespace SystemEditor.DBModel.DBData
{

    public class AlarmOperationDBModel : IsEditUpdater, IDBQuery
    {
        // 원본 데이터 필드
        private int _no;
        private int? _groupno;
        private string _alarmname;
        private int? _index;
        private int? _sensorsort;
        private string _actioncode;
        private int? _param;
        private int? _subsensorsort;
        private string _subactioncode;
        private int? _subparam;
        private string _alarmcombination;
        private int? _section;
        private int? _ignoretime;
        private int? _broadcastno;
        private int? _endtime;
        private int? _checkalarmsmstime;
        private int? _alarmoccursprocessno;
        private string _alarmfiredcode;
        private int? _alarmfiredprocessno;
        private string _isstream;
        private string _isdblog;

        // UI 데이터 필드
        private int _noui;
        private int? _groupnoui;
        private string _alarmnameui;
        private int? _indexui;
        private int? _sensorsortui;
        private string _actioncodeui;
        private int? _paramui;
        private int? _subsensorsortui;
        private string _subactioncodeui;
        private int? _subparamui;
        private string _alarmcombinationui;
        private int? _sectionui;
        private int? _ignoretimeui;
        private int? _broadcastnoui;
        private int? _endtimeui;
        private int? _checkalarmsmstimeui;
        private int? _alarmoccursprocessnoui;
        private string _alarmfiredcodeui;
        private int? _alarmfiredprocessnoui;
        private string _isstreamui;
        private string _isdblogui;

        // 원본 데이터 프로퍼티
        public int no
        {
            get { return _no; }
            set { if (SetProperty(ref _no, value)) UserEditEvent?.Invoke(); }
        }

        public int? groupno
        {
            get { return _groupno; }
            set { if (SetProperty(ref _groupno, value)) UserEditEvent?.Invoke(); }
        }

        public string alarmname
        {
            get { return _alarmname; }
            set { if (SetProperty(ref _alarmname, value)) UserEditEvent?.Invoke(); }
        }

        public int? index
        {
            get { return _index; }
            set { if (SetProperty(ref _index, value)) UserEditEvent?.Invoke(); }
        }

        public int? sensorsort
        {
            get { return _sensorsort; }
            set { if (SetProperty(ref _sensorsort, value)) UserEditEvent?.Invoke(); }
        }

        public string actioncode
        {
            get { return _actioncode; }
            set { if (SetProperty(ref _actioncode, value)) UserEditEvent?.Invoke(); }
        }

        public int? param
        {
            get { return _param; }
            set { if (SetProperty(ref _param, value)) UserEditEvent?.Invoke(); }
        }

        public int? subsensorsort
        {
            get { return _subsensorsort; }
            set { if (SetProperty(ref _subsensorsort, value)) UserEditEvent?.Invoke(); }
        }

        public string subactioncode
        {
            get { return _subactioncode; }
            set { if (SetProperty(ref _subactioncode, value)) UserEditEvent?.Invoke(); }
        }

        public int? subparam
        {
            get { return _subparam; }
            set { if (SetProperty(ref _subparam, value)) UserEditEvent?.Invoke(); }
        }

        public string alarmcombination
        {
            get { return _alarmcombination; }
            set { if (SetProperty(ref _alarmcombination, value)) UserEditEvent?.Invoke(); }
        }

        public int? section
        {
            get { return _section; }
            set { if (SetProperty(ref _section, value)) UserEditEvent?.Invoke(); }
        }

        public int? ignoretime
        {
            get { return _ignoretime; }
            set { if (SetProperty(ref _ignoretime, value)) UserEditEvent?.Invoke(); }
        }

        public int? broadcastno
        {
            get { return _broadcastno; }
            set { if (SetProperty(ref _broadcastno, value)) UserEditEvent?.Invoke(); }
        }

        public int? endtime
        {
            get { return _endtime; }
            set { if (SetProperty(ref _endtime, value)) UserEditEvent?.Invoke(); }
        }

        public int? checkalarmsmstime
        {
            get { return _checkalarmsmstime; }
            set { if (SetProperty(ref _checkalarmsmstime, value)) UserEditEvent?.Invoke(); }
        }

        public int? alarmoccursprocessno
        {
            get { return _alarmoccursprocessno; }
            set { if (SetProperty(ref _alarmoccursprocessno, value)) UserEditEvent?.Invoke(); }
        }

        public string alarmfiredcode
        {
            get { return _alarmfiredcode; }
            set { if (SetProperty(ref _alarmfiredcode, value)) UserEditEvent?.Invoke(); }
        }

        public int? alarmfiredprocessno
        {
            get { return _alarmfiredprocessno; }
            set { if (SetProperty(ref _alarmfiredprocessno, value)) UserEditEvent?.Invoke(); }
        }

        public string isstream
        {
            get { return _isstream; }
            set { if (SetProperty(ref _isstream, value)) UserEditEvent?.Invoke(); }
        }

        public string isdblog
        {
            get { return _isdblog; }
            set { if (SetProperty(ref _isdblog, value)) UserEditEvent?.Invoke(); }
        }

        // UI 데이터 프로퍼티
        public int noui
        {
            get { return _noui; }
            set { if (SetProperty(ref _noui, value)) UserEditEvent?.Invoke(); }
        }

        public int? groupnoui
        {
            get { return _groupnoui; }
            set { if (SetProperty(ref _groupnoui, value)) UserEditEvent?.Invoke(); }
        }

        public string alarmnameui
        {
            get { return _alarmnameui; }
            set { if (SetProperty(ref _alarmnameui, value)) UserEditEvent?.Invoke(); }
        }

        public int? indexui
        {
            get { return _indexui; }
            set { if (SetProperty(ref _indexui, value)) UserEditEvent?.Invoke(); }
        }

        public int? sensorsortui
        {
            get { return _sensorsortui; }
            set { if (SetProperty(ref _sensorsortui, value)) UserEditEvent?.Invoke(); }
        }

        public string actioncodeui
        {
            get { return _actioncodeui; }
            set { if (SetProperty(ref _actioncodeui, value)) UserEditEvent?.Invoke(); }
        }

        public int? paramui
        {
            get { return _paramui; }
            set { if (SetProperty(ref _paramui, value)) UserEditEvent?.Invoke(); }
        }

        public int? subsensorsortui
        {
            get { return _subsensorsortui; }
            set { if (SetProperty(ref _subsensorsortui, value)) UserEditEvent?.Invoke(); }
        }

        public string subactioncodeui
        {
            get { return _subactioncodeui; }
            set { if (SetProperty(ref _subactioncodeui, value)) UserEditEvent?.Invoke(); }
        }

        public int? subparamui
        {
            get { return _subparamui; }
            set { if (SetProperty(ref _subparamui, value)) UserEditEvent?.Invoke(); }
        }

        public string alarmcombinationui
        {
            get { return _alarmcombinationui; }
            set { if (SetProperty(ref _alarmcombinationui, value)) UserEditEvent?.Invoke(); }
        }

        public int? sectionui
        {
            get { return _sectionui; }
            set { if (SetProperty(ref _sectionui, value)) UserEditEvent?.Invoke(); }
        }

        public int? ignoretimeui
        {
            get { return _ignoretimeui; }
            set { if (SetProperty(ref _ignoretimeui, value)) UserEditEvent?.Invoke(); }
        }

        public int? broadcastnoui
        {
            get { return _broadcastnoui; }
            set { if (SetProperty(ref _broadcastnoui, value)) UserEditEvent?.Invoke(); }
        }

        public int? endtimeui
        {
            get { return _endtimeui; }
            set { if (SetProperty(ref _endtimeui, value)) UserEditEvent?.Invoke(); }
        }

        public int? checkalarmsmstimeui
        {
            get { return _checkalarmsmstimeui; }
            set { if (SetProperty(ref _checkalarmsmstimeui, value)) UserEditEvent?.Invoke(); }
        }

        public int? alarmoccursprocessnoui
        {
            get { return _alarmoccursprocessnoui; }
            set { if (SetProperty(ref _alarmoccursprocessnoui, value)) UserEditEvent?.Invoke(); }
        }

        public string alarmfiredcodeui
        {
            get { return _alarmfiredcodeui; }
            set { if (SetProperty(ref _alarmfiredcodeui, value)) UserEditEvent?.Invoke(); }
        }

        public int? alarmfiredprocessnoui
        {
            get { return _alarmfiredprocessnoui; }
            set { if (SetProperty(ref _alarmfiredprocessnoui, value)) UserEditEvent?.Invoke(); }
        }

        public string isstreamui
        {
            get { return _isstreamui; }
            set { if (SetProperty(ref _isstreamui, value)) UserEditEvent?.Invoke(); }
        }

        public string isdblogui
        {
            get { return _isdblogui; }
            set { if (SetProperty(ref _isdblogui, value)) UserEditEvent?.Invoke(); }
        }

        // 기본 생성자
        public AlarmOperationDBModel() : base() { }

        // 원본 데이터를 UI 데이터로 복사
        public override void CopyOriginToUI()
        {
            noui = no;
            groupnoui = groupno;
            alarmnameui = alarmname;
            indexui = index;
            sensorsortui = sensorsort;
            actioncodeui = actioncode;
            paramui = param;
            subsensorsortui = subsensorsort;
            subactioncodeui = subactioncode;
            subparamui = subparam;
            alarmcombinationui = alarmcombination;
            sectionui = section;
            ignoretimeui = ignoretime;
            broadcastnoui = broadcastno;
            endtimeui = endtime;
            checkalarmsmstimeui = checkalarmsmstime;
            alarmoccursprocessnoui = alarmoccursprocessno;
            alarmfiredcodeui = alarmfiredcode;
            alarmfiredprocessnoui = alarmfiredprocessno;
            isstreamui = isstream;
            isdblogui = isdblog;
        }

        // UI 데이터를 원본 데이터로 복사
        public override void CopyUIToOrigin()
        {
            no = noui;
            groupno = groupnoui;
            alarmname = alarmnameui;
            index = indexui;
            sensorsort = sensorsortui;
            actioncode = actioncodeui;
            param = paramui;
            subsensorsort = subsensorsortui;
            subactioncode = subactioncodeui;
            subparam = subparamui;
            alarmcombination = alarmcombinationui;
            section = sectionui;
            ignoretime = ignoretimeui;
            broadcastno = broadcastnoui;
            endtime = endtimeui;
            checkalarmsmstime = checkalarmsmstimeui;
            alarmoccursprocessno = alarmoccursprocessnoui;
            alarmfiredcode = alarmfiredcodeui;
            alarmfiredprocessno = alarmfiredprocessnoui;
            isstream = isstreamui;
            isdblog = isdblogui;
        }
        public void ConvertOriginToUi() { }
        public void ConvertUiToOrigin() { }

        // 사용자가 데이터를 편집했는지 확인
        public override bool IsUserEdit()
        {
            return no != noui ||
                   groupno != groupnoui ||
                   alarmname != alarmnameui ||
                   index != indexui ||
                   sensorsort != sensorsortui ||
                   actioncode != actioncodeui ||
                   param != paramui ||
                   subsensorsort != subsensorsortui ||
                   subactioncode != subactioncodeui ||
                   subparam != subparamui ||
                   alarmcombination != alarmcombinationui ||
                   section != sectionui ||
                   ignoretime != ignoretimeui ||
                   broadcastno != broadcastnoui ||
                   endtime != endtimeui ||
                   checkalarmsmstime != checkalarmsmstimeui ||
                   alarmoccursprocessno != alarmoccursprocessnoui ||
                   alarmfiredcode != alarmfiredcodeui ||
                   alarmfiredprocessno != alarmfiredprocessnoui ||
                   isstream != isstreamui ||
                   isdblog != isdblogui;
        }

        public void SetAutoIncrementIndex(long autoincrementindex) { }

        public string InsertQuery()
        {
            return string.Format(
                "INSERT INTO alarmoperation (no, groupno, alarmname, index, sensorsort, actioncode, param, subsensorsort, subactioncode, subparam, alarmcombination, section, ignoretime, broadcastno, endtime, checkalarmsmstime, alarmoccursprocessno, alarmfiredcode, alarmfiredprocessno, isstream, isdblog) VALUES ({0}, {1}, '{2}', {3}, {4}, '{5}', {6}, {7}, '{8}', {9}, '{10}', {11}, {12}, {13}, {14}, {15}, {16}, '{17}', {18}, '{19}', '{20}')",
                _no,
                _groupno.HasValue ? _groupno.Value.ToString() : "NULL",
                _alarmname,
                _index.HasValue ? _index.Value.ToString() : "NULL",
                _sensorsort.HasValue ? _sensorsort.Value.ToString() : "NULL",
                _actioncode,
                _param.HasValue ? _param.Value.ToString() : "NULL",
                _subsensorsort.HasValue ? _subsensorsort.Value.ToString() : "NULL",
                _subactioncode,
                _subparam.HasValue ? _subparam.Value.ToString() : "NULL",
                _alarmcombination,
                _section.HasValue ? _section.Value.ToString() : "NULL",
                _ignoretime.HasValue ? _ignoretime.Value.ToString() : "NULL",
                _broadcastno.HasValue ? _broadcastno.Value.ToString() : "NULL",
                _endtime.HasValue ? _endtime.Value.ToString() : "NULL",
                _checkalarmsmstime.HasValue ? _checkalarmsmstime.Value.ToString() : "NULL",
                _alarmoccursprocessno.HasValue ? _alarmoccursprocessno.Value.ToString() : "NULL",
                _alarmfiredcode,
                _alarmfiredprocessno.HasValue ? _alarmfiredprocessno.Value.ToString() : "NULL",
                _isstream,
                _isdblog
            );
        }

        public string[] InsertSubQuery()
        {
            return new string[] { };
        }

        public string[] UpdateQuery()
        {
            return new string[]
            {
                string.Format(
                    "UPDATE alarmoperation SET groupno = {0}, alarmname = '{1}', index = {2}, sensorsort = {3}, actioncode = '{4}', param = {5}, subsensorsort = {6}, subactioncode = '{7}', subparam = {8}, alarmcombination = '{9}', section = {10}, ignoretime = {11}, broadcastno = {12}, endtime = {13}, checkalarmsmstime = {14}, alarmoccursprocessno = {15}, alarmfiredcode = '{16}', alarmfiredprocessno = {17}, isstream = '{18}', isdblog = '{19}' WHERE no = {20}",
                    _groupno.HasValue ? _groupno.Value.ToString() : "NULL",
                    _alarmname,
                    _index.HasValue ? _index.Value.ToString() : "NULL",
                    _sensorsort.HasValue ? _sensorsort.Value.ToString() : "NULL",
                    _actioncode,
                    _param.HasValue ? _param.Value.ToString() : "NULL",
                    _subsensorsort.HasValue ? _subsensorsort.Value.ToString() : "NULL",
                    _subactioncode,
                    _subparam.HasValue ? _subparam.Value.ToString() : "NULL",
                    _alarmcombination,
                    _section.HasValue ? _section.Value.ToString() : "NULL",
                    _ignoretime.HasValue ? _ignoretime.Value.ToString() : "NULL",
                    _broadcastno.HasValue ? _broadcastno.Value.ToString() : "NULL",
                    _endtime.HasValue ? _endtime.Value.ToString() : "NULL",
                    _checkalarmsmstime.HasValue ? _checkalarmsmstime.Value.ToString() : "NULL",
                    _alarmoccursprocessno.HasValue ? _alarmoccursprocessno.Value.ToString() : "NULL",
                    _alarmfiredcode,
                    _alarmfiredprocessno.HasValue ? _alarmfiredprocessno.Value.ToString() : "NULL",
                    _isstream,
                    _isdblog,
                    _no
                )
            };
        }

        public string[] DeleteQueryList()
        {
            return new string[]
            {
                string.Format("DELETE FROM alarmoperation WHERE no = {0}", _no),
            };
        }

    }


    public class AlarmOperationDBList : BaseDBListByOC<AlarmOperationDBModel>
    {
        public AlarmOperationDBList() : base() { }

        public string SelectAllQuery()
        {
            return "SELECT * FROM alarmoperation";
        }

        public void SelectAllDSParsing()
        {
            this.Clear();

            foreach (DataRow dr in dataset.Tables[0].Rows)
            {
                AlarmOperationDBModel model = new AlarmOperationDBModel();
                Assign(dr, model);

                this.Add(model);
            }

            dataset.Clear();
        }

        private void Assign(DataRow dr, AlarmOperationDBModel model)
        {
            model.no = Convert.ToInt32(dr["no"].ToString());
            model.groupno = dr["groupno"] == DBNull.Value ? (int?)null : Convert.ToInt32(dr["groupno"].ToString());
            model.alarmname = dr["alarmname"]?.ToString();
            model.index = dr["index"] == DBNull.Value ? (int?)null : Convert.ToInt32(dr["index"].ToString());
            model.sensorsort = dr["sensorsort"] == DBNull.Value ? (int?)null : Convert.ToInt32(dr["sensorsort"].ToString());
            model.actioncode = dr["actioncode"]?.ToString();
            model.param = dr["param"] == DBNull.Value ? (int?)null : Convert.ToInt32(dr["param"].ToString());
            model.subsensorsort = dr["subsensorsort"] == DBNull.Value ? (int?)null : Convert.ToInt32(dr["subsensorsort"].ToString());
            model.subactioncode = dr["subactioncode"]?.ToString();
            model.subparam = dr["subparam"] == DBNull.Value ? (int?)null : Convert.ToInt32(dr["subparam"].ToString());
            model.alarmcombination = dr["alarmcombination"]?.ToString();
            model.section = dr["section"] == DBNull.Value ? (int?)null : Convert.ToInt32(dr["section"].ToString());
            model.ignoretime = dr["ignoretime"] == DBNull.Value ? (int?)null : Convert.ToInt32(dr["ignoretime"].ToString());
            model.broadcastno = dr["broadcastno"] == DBNull.Value ? (int?)null : Convert.ToInt32(dr["broadcastno"].ToString());
            model.endtime = dr["endtime"] == DBNull.Value ? (int?)null : Convert.ToInt32(dr["endtime"].ToString());
            model.checkalarmsmstime = dr["checkalarmsmstime"] == DBNull.Value ? (int?)null : Convert.ToInt32(dr["checkalarmsmstime"].ToString());
            model.alarmoccursprocessno = dr["alarmoccursprocessno"] == DBNull.Value ? (int?)null : Convert.ToInt32(dr["alarmoccursprocessno"].ToString());
            model.alarmfiredcode = dr["alarmfiredcode"]?.ToString();
            model.alarmfiredprocessno = dr["alarmfiredprocessno"] == DBNull.Value ? (int?)null : Convert.ToInt32(dr["alarmfiredprocessno"].ToString());
            model.isstream = dr["isstream"]?.ToString();
            model.isdblog = dr["isdblog"]?.ToString();
        }

        public AlarmOperationDBModel GetByNo(int no)
        {
            return this.FirstOrDefault(a => a.no == no);
        }
    }
}
