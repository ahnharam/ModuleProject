using System;
using System.Data;
using System.Linq;

namespace ModuleProject_WPF_Default.Models
{
    public class AlarmactionprocessDBModel : IsEditUpdater
    {
        // db
        private int _no;
        private int? _groupno;
        private int? _index;
        private int? _sensorsort;
        private string _actiontarget;
        private string _actioncode;
        private int? _param;
        private int? _delay;
        private string _description;

        // ui
        private int _noui;
        private int? _groupnoui;
        private int? _indexui;
        private int? _sensorsortui;
        private string _actiontargetui;
        private string _actioncodeui;
        private int? _paramui;
        private int? _delayui;
        private string _descriptionui;

        #region db property
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

        public string actiontarget
        {
            get { return _actiontarget; }
            set { if (SetProperty(ref _actiontarget, value)) OnPropertyChanged(nameof(IsEdit)); }
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

        public int? delay
        {
            get { return _delay; }
            set { if (SetProperty(ref _delay, value)) OnPropertyChanged(nameof(IsEdit)); }
        }

        public string description
        {
            get { return _description; }
            set { if (SetProperty(ref _description, value)) OnPropertyChanged(nameof(IsEdit)); }
        }
        #endregion

        #region ui property
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

        public string actiontargetui
        {
            get { return _actiontargetui; }
            set { if (SetProperty(ref _actiontargetui, value)) OnPropertyChanged(nameof(IsEdit)); }
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

        public int? delayui
        {
            get { return _delayui; }
            set { if (SetProperty(ref _delayui, value)) OnPropertyChanged(nameof(IsEdit)); }
        }

        public string descriptionui
        {
            get { return _descriptionui; }
            set { if (SetProperty(ref _descriptionui, value)) OnPropertyChanged(nameof(IsEdit)); }
        }
        #endregion
        public AlarmactionprocessDBModel() : base() { }

        // 원본 데이터를 UI 데이터로 복사
        public override void CopyOriginToUI()
        {
            noui = no;
            groupnoui = groupno;
            indexui = index;
            sensorsortui = sensorsort;
            actiontargetui = actiontarget;
            actioncodeui = actioncode;
            paramui = param;
            delayui = delay;
            descriptionui = description;
        }

        // UI 데이터를 원본 데이터로 복사
        public override void CopyUIToOrigin()
        {
            no = noui;
            groupno = groupnoui;
            index = indexui;
            sensorsort = sensorsortui;
            actiontarget = actiontargetui;
            actioncode = actioncodeui;
            param = paramui;
            delay = delayui;
            description = descriptionui;
        }

        // 사용자가 데이터를 편집했는지 확인
        public override bool IsUserEdit()
        {
            if (no != noui ||
                groupno != groupnoui ||
                index != indexui ||
                sensorsort != sensorsortui ||
                actiontarget != actiontargetui ||
                actioncode != actioncodeui ||
                param != paramui ||
                delay != delayui ||
                description != descriptionui)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    public class AlarmactionprocessDBList : BaseDBList<AlarmactionprocessDBModel>
    {
        public AlarmactionprocessDBList() : base()
        {
        }

        public string SelectAllQuery()
        {
            return "SELECT * FROM alarmactionprocess";
        }

        public void SelectAllDSParsing()
        {
            this.Clear();

            foreach (DataRow dr in dataset.Tables[0].Rows)
            {
                AlarmactionprocessDBModel model = new AlarmactionprocessDBModel();
                Assign(dr, model);

                this.Add(model);
            }

            dataset.Clear();
        }

        private void Assign(DataRow dr, AlarmactionprocessDBModel model)
        {
            model.no = Convert.ToInt32(dr["no"].ToString());
            model.groupno = dr["groupno"] == DBNull.Value ? (int?)null : Convert.ToInt32(dr["groupno"].ToString());
            model.index = dr["index"] == DBNull.Value ? (int?)null : Convert.ToInt32(dr["index"].ToString());
            model.sensorsort = dr["sensorsort"] == DBNull.Value ? (int?)null : Convert.ToInt32(dr["sensorsort"].ToString());
            model.actiontarget = dr["actiontarget"]?.ToString();
            model.actioncode = dr["actioncode"]?.ToString();
            model.param = dr["param"] == DBNull.Value ? (int?)null : Convert.ToInt32(dr["param"].ToString());
            model.delay = dr["delay"] == DBNull.Value ? (int?)null : Convert.ToInt32(dr["delay"].ToString());
            model.description = dr["description"]?.ToString();
        }

        public AlarmactionprocessDBModel GetByNo(int no)
        {
            return this.FirstOrDefault(a => a.no == no);
        }
    }

}
