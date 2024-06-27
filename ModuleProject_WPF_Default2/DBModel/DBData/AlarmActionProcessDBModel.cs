using DevExpress.Xpf.Editors.Helpers;
using System;
using System.Data;
using System.Linq;

namespace SystemEditor.DBModel.DBData
{
    public class AlarmActionProcessDBModel : IsEditUpdater, IDBQuery
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
            set { if (SetProperty(ref _no, value)) UserEditEvent?.Invoke(); }
        }

        public int? groupno
        {
            get { return _groupno; }
            set { if (SetProperty(ref _groupno, value)) UserEditEvent?.Invoke(); }
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

        public string actiontarget
        {
            get { return _actiontarget; }
            set { if (SetProperty(ref _actiontarget, value)) UserEditEvent?.Invoke(); }
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

        public int? delay
        {
            get { return _delay; }
            set { if (SetProperty(ref _delay, value)) UserEditEvent?.Invoke(); }
        }

        public string description
        {
            get { return _description; }
            set { if (SetProperty(ref _description, value)) UserEditEvent?.Invoke(); }
        }
        #endregion

        #region ui property
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

        public string actiontargetui
        {
            get { return _actiontargetui; }
            set { if (SetProperty(ref _actiontargetui, value)) UserEditEvent?.Invoke(); }
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

        public int? delayui
        {
            get { return _delayui; }
            set { if (SetProperty(ref _delayui, value)) UserEditEvent?.Invoke(); }
        }

        public string descriptionui
        {
            get { return _descriptionui; }
            set { if (SetProperty(ref _descriptionui, value)) UserEditEvent?.Invoke(); }
        }
        #endregion
        public AlarmActionProcessDBModel() : base() { }

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
        public void ConvertOriginToUi() { }
        public void ConvertUiToOrigin() { }

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

        public void SetAutoIncrementIndex(long autoincrementindex) { }

        public string InsertQuery()
        {
            return string.Format(
                "INSERT INTO alarmactionprocess (no, groupno, index, sensorsort, actiontarget, actioncode, param, delay, description) VALUES ({0}, {1}, {2}, {3}, '{4}', '{5}', {6}, {7}, '{8}')",
                _no,
                _groupno.HasValue ? _groupno.Value.ToString() : "NULL",
                _index.HasValue ? _index.Value.ToString() : "NULL",
                _sensorsort.HasValue ? _sensorsort.Value.ToString() : "NULL",
                _actiontarget,
                _actioncode,
                _param.HasValue ? _param.Value.ToString() : "NULL",
                _delay.HasValue ? _delay.Value.ToString() : "NULL",
                _description
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
                    "UPDATE alarmactionprocess SET groupno = {0}, index = {1}, sensorsort = {2}, actiontarget = '{3}', actioncode = '{4}', param = {5}, delay = {6}, description = '{7}' WHERE no = {8}",
                    _groupno.HasValue ? _groupno.Value.ToString() : "NULL",
                    _index.HasValue ? _index.Value.ToString() : "NULL",
                    _sensorsort.HasValue ? _sensorsort.Value.ToString() : "NULL",
                    _actiontarget,
                    _actioncode,
                    _param.HasValue ? _param.Value.ToString() : "NULL",
                    _delay.HasValue ? _delay.Value.ToString() : "NULL",
                    _description,
                    _no
                )
            };
        }

        public string[] DeleteQueryList()
        {
            return new string[]
            {
                string.Format("DELETE FROM alarmactionprocess WHERE no = {0}", _no),
            };
        }

    }

    public class AlarmActionProcessDBList : BaseDBListByOC<AlarmActionProcessDBModel>
    {
        public AlarmActionProcessDBList() : base()
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
                AlarmActionProcessDBModel model = new AlarmActionProcessDBModel();
                Assign(dr, model);
                model.CopyOriginToUI();

                this.Add(model);
            }

            dataset.Clear();
        }

        private void Assign(DataRow dr, AlarmActionProcessDBModel model)
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

        public AlarmActionProcessDBModel GetByNo(int no)
        {
            return this.FirstOrDefault(a => a.no == no);
        }
    }

}
