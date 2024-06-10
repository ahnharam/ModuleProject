using System;
using System.Data;
using System.Linq;

namespace ModuleProject_WPF_Default.Models
{

    public class AlarmOperationDBModel : IsEditUpdater
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
            set { if (SetProperty(ref _no, value)) OnPropertyChanged(nameof(IsEdit)); }
        }

        public int? groupno
        {
            get { return _groupno; }
            set { if (SetProperty(ref _groupno, value)) OnPropertyChanged(nameof(IsEdit)); }
        }

        public string alarmname
        {
            get { return _alarmname; }
            set { if (SetProperty(ref _alarmname, value)) OnPropertyChanged(nameof(IsEdit)); }
        }

        public int? index
        {
            get { return _index; }
            set { if (SetProperty(ref _index, value)) OnPropertyChanged(nameof(IsEdit)); }
        }

        public int? sensorsort
        {
            get { return _sensorsort; }
            set { if (SetProperty(ref _sensorsort, value)) OnPropertyChanged(nameof(IsEdit)); }
        }

        public string actioncode
        {
            get { return _actioncode; }
            set { if (SetProperty(ref _actioncode, value)) OnPropertyChanged(nameof(IsEdit)); }
        }

        public int? param
        {
            get { return _param; }
            set { if (SetProperty(ref _param, value)) OnPropertyChanged(nameof(IsEdit)); }
        }

        public int? subsensorsort
        {
            get { return _subsensorsort; }
            set { if (SetProperty(ref _subsensorsort, value)) OnPropertyChanged(nameof(IsEdit)); }
        }

        public string subactioncode
        {
            get { return _subactioncode; }
            set { if (SetProperty(ref _subactioncode, value)) OnPropertyChanged(nameof(IsEdit)); }
        }

        public int? subparam
        {
            get { return _subparam; }
            set { if (SetProperty(ref _subparam, value)) OnPropertyChanged(nameof(IsEdit)); }
        }

        public string alarmcombination
        {
            get { return _alarmcombination; }
            set { if (SetProperty(ref _alarmcombination, value)) OnPropertyChanged(nameof(IsEdit)); }
        }

        public int? section
        {
            get { return _section; }
            set { if (SetProperty(ref _section, value)) OnPropertyChanged(nameof(IsEdit)); }
        }

        public int? ignoretime
        {
            get { return _ignoretime; }
            set { if (SetProperty(ref _ignoretime, value)) OnPropertyChanged(nameof(IsEdit)); }
        }

        public int? broadcastno
        {
            get { return _broadcastno; }
            set { if (SetProperty(ref _broadcastno, value)) OnPropertyChanged(nameof(IsEdit)); }
        }

        public int? endtime
        {
            get { return _endtime; }
            set { if (SetProperty(ref _endtime, value)) OnPropertyChanged(nameof(IsEdit)); }
        }

        public int? checkalarmsmstime
        {
            get { return _checkalarmsmstime; }
            set { if (SetProperty(ref _checkalarmsmstime, value)) OnPropertyChanged(nameof(IsEdit)); }
        }

        public int? alarmoccursprocessno
        {
            get { return _alarmoccursprocessno; }
            set { if (SetProperty(ref _alarmoccursprocessno, value)) OnPropertyChanged(nameof(IsEdit)); }
        }

        public string alarmfiredcode
        {
            get { return _alarmfiredcode; }
            set { if (SetProperty(ref _alarmfiredcode, value)) OnPropertyChanged(nameof(IsEdit)); }
        }

        public int? alarmfiredprocessno
        {
            get { return _alarmfiredprocessno; }
            set { if (SetProperty(ref _alarmfiredprocessno, value)) OnPropertyChanged(nameof(IsEdit)); }
        }

        public string isstream
        {
            get { return _isstream; }
            set { if (SetProperty(ref _isstream, value)) OnPropertyChanged(nameof(IsEdit)); }
        }

        public string isdblog
        {
            get { return _isdblog; }
            set { if (SetProperty(ref _isdblog, value)) OnPropertyChanged(nameof(IsEdit)); }
        }

        // UI 데이터 프로퍼티
        public int noui
        {
            get { return _noui; }
            set { if (SetProperty(ref _noui, value)) OnPropertyChanged(nameof(IsEdit)); }
        }

        public int? groupnoui
        {
            get { return _groupnoui; }
            set { if (SetProperty(ref _groupnoui, value)) OnPropertyChanged(nameof(IsEdit)); }
        }

        public string alarmnameui
        {
            get { return _alarmnameui; }
            set { if (SetProperty(ref _alarmnameui, value)) OnPropertyChanged(nameof(IsEdit)); }
        }

        public int? indexui
        {
            get { return _indexui; }
            set { if (SetProperty(ref _indexui, value)) OnPropertyChanged(nameof(IsEdit)); }
        }

        public int? sensorsortui
        {
            get { return _sensorsortui; }
            set { if (SetProperty(ref _sensorsortui, value)) OnPropertyChanged(nameof(IsEdit)); }
        }

        public string actioncodeui
        {
            get { return _actioncodeui; }
            set { if (SetProperty(ref _actioncodeui, value)) OnPropertyChanged(nameof(IsEdit)); }
        }

        public int? paramui
        {
            get { return _paramui; }
            set { if (SetProperty(ref _paramui, value)) OnPropertyChanged(nameof(IsEdit)); }
        }

        public int? subsensorsortui
        {
            get { return _subsensorsortui; }
            set { if (SetProperty(ref _subsensorsortui, value)) OnPropertyChanged(nameof(IsEdit)); }
        }

        public string subactioncodeui
        {
            get { return _subactioncodeui; }
            set { if (SetProperty(ref _subactioncodeui, value)) OnPropertyChanged(nameof(IsEdit)); }
        }

        public int? subparamui
        {
            get { return _subparamui; }
            set { if (SetProperty(ref _subparamui, value)) OnPropertyChanged(nameof(IsEdit)); }
        }

        public string alarmcombinationui
        {
            get { return _alarmcombinationui; }
            set { if (SetProperty(ref _alarmcombinationui, value)) OnPropertyChanged(nameof(IsEdit)); }
        }

        public int? sectionui
        {
            get { return _sectionui; }
            set { if (SetProperty(ref _sectionui, value)) OnPropertyChanged(nameof(IsEdit)); }
        }

        public int? ignoretimeui
        {
            get { return _ignoretimeui; }
            set { if (SetProperty(ref _ignoretimeui, value)) OnPropertyChanged(nameof(IsEdit)); }
        }

        public int? broadcastnoui
        {
            get { return _broadcastnoui; }
            set { if (SetProperty(ref _broadcastnoui, value)) OnPropertyChanged(nameof(IsEdit)); }
        }

        public int? endtimeui
        {
            get { return _endtimeui; }
            set { if (SetProperty(ref _endtimeui, value)) OnPropertyChanged(nameof(IsEdit)); }
        }

        public int? checkalarmsmstimeui
        {
            get { return _checkalarmsmstimeui; }
            set { if (SetProperty(ref _checkalarmsmstimeui, value)) OnPropertyChanged(nameof(IsEdit)); }
        }

        public int? alarmoccursprocessnoui
        {
            get { return _alarmoccursprocessnoui; }
            set { if (SetProperty(ref _alarmoccursprocessnoui, value)) OnPropertyChanged(nameof(IsEdit)); }
        }

        public string alarmfiredcodeui
        {
            get { return _alarmfiredcodeui; }
            set { if (SetProperty(ref _alarmfiredcodeui, value)) OnPropertyChanged(nameof(IsEdit)); }
        }

        public int? alarmfiredprocessnoui
        {
            get { return _alarmfiredprocessnoui; }
            set { if (SetProperty(ref _alarmfiredprocessnoui, value)) OnPropertyChanged(nameof(IsEdit)); }
        }

        public string isstreamui
        {
            get { return _isstreamui; }
            set { if (SetProperty(ref _isstreamui, value)) OnPropertyChanged(nameof(IsEdit)); }
        }

        public string isdblogui
        {
            get { return _isdblogui; }
            set { if (SetProperty(ref _isdblogui, value)) OnPropertyChanged(nameof(IsEdit)); }
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
    }


    public class AlarmOperationDBList : BaseDBList<AlarmOperationDBModel>
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
