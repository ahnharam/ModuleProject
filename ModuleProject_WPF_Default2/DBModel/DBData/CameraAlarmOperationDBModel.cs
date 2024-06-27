using System;
using System.Data;
using System.Linq;

namespace SystemEditor.DBModel.DBData
{
    public class CameraAlarmOperationDBModel : IsEditUpdater, IDBQuery
    {
        // 원본 데이터 필드
        private int _no;
        private string _alarmcode;
        private int? _maincamerano;
        private string _maincameraalarmcode;
        private int? _subcamerano;
        private string _subcameraalarmcode;
        private string _alarmcombination;
        private string _islive;
        private int? _alarmoperation;

        // UI 데이터 필드
        private int _noui;
        private string _alarmcodeui;
        private int? _maincameranoui;
        private string _maincameraalarmcodeui;
        private int? _subcameranoui;
        private string _subcameraalarmcodeui;
        private string _alarmcombinationui;
        private string _isliveui;
        private int? _alarmoperationui;

        // 원본 데이터 프로퍼티
        public int no
        {
            get { return _no; }
            set { if (SetProperty(ref _no, value)) UserEditEvent?.Invoke(); }
        }

        public string alarmcode
        {
            get { return _alarmcode; }
            set { if (SetProperty(ref _alarmcode, value)) UserEditEvent?.Invoke(); }
        }

        public int? maincamerano
        {
            get { return _maincamerano; }
            set { if (SetProperty(ref _maincamerano, value)) UserEditEvent?.Invoke(); }
        }

        public string maincameraalarmcode
        {
            get { return _maincameraalarmcode; }
            set { if (SetProperty(ref _maincameraalarmcode, value)) UserEditEvent?.Invoke(); }
        }

        public int? subcamerano
        {
            get { return _subcamerano; }
            set { if (SetProperty(ref _subcamerano, value)) UserEditEvent?.Invoke(); }
        }

        public string subcameraalarmcode
        {
            get { return _subcameraalarmcode; }
            set { if (SetProperty(ref _subcameraalarmcode, value)) UserEditEvent?.Invoke(); }
        }

        public string alarmcombination
        {
            get { return _alarmcombination; }
            set { if (SetProperty(ref _alarmcombination, value)) UserEditEvent?.Invoke(); }
        }

        public string islive
        {
            get { return _islive; }
            set { if (SetProperty(ref _islive, value)) UserEditEvent?.Invoke(); }
        }

        public int? alarmoperation
        {
            get { return _alarmoperation; }
            set { if (SetProperty(ref _alarmoperation, value)) UserEditEvent?.Invoke(); }
        }

        // UI 데이터 프로퍼티
        public int noui
        {
            get { return _noui; }
            set { if (SetProperty(ref _noui, value)) UserEditEvent?.Invoke(); }
        }

        public string alarmcodeui
        {
            get { return _alarmcodeui; }
            set { if (SetProperty(ref _alarmcodeui, value)) UserEditEvent?.Invoke(); }
        }

        public int? maincameranoui
        {
            get { return _maincameranoui; }
            set { if (SetProperty(ref _maincameranoui, value)) UserEditEvent?.Invoke(); }
        }

        public string maincameraalarmcodeui
        {
            get { return _maincameraalarmcodeui; }
            set { if (SetProperty(ref _maincameraalarmcodeui, value)) UserEditEvent?.Invoke(); }
        }

        public int? subcameranoui
        {
            get { return _subcameranoui; }
            set { if (SetProperty(ref _subcameranoui, value)) UserEditEvent?.Invoke(); }
        }

        public string subcameraalarmcodeui
        {
            get { return _subcameraalarmcodeui; }
            set { if (SetProperty(ref _subcameraalarmcodeui, value)) UserEditEvent?.Invoke(); }
        }

        public string alarmcombinationui
        {
            get { return _alarmcombinationui; }
            set { if (SetProperty(ref _alarmcombinationui, value)) UserEditEvent?.Invoke(); }
        }

        public string isliveui
        {
            get { return _isliveui; }
            set { if (SetProperty(ref _isliveui, value)) UserEditEvent?.Invoke(); }
        }

        public int? alarmoperationui
        {
            get { return _alarmoperationui; }
            set { if (SetProperty(ref _alarmoperationui, value)) UserEditEvent?.Invoke(); }
        }

        // 기본 생성자
        public CameraAlarmOperationDBModel() : base() { }

        // 원본 데이터를 UI 데이터로 복사
        public override void CopyOriginToUI()
        {
            noui = no;
            alarmcodeui = alarmcode;
            maincameranoui = maincamerano;
            maincameraalarmcodeui = maincameraalarmcode;
            subcameranoui = subcamerano;
            subcameraalarmcodeui = subcameraalarmcode;
            alarmcombinationui = alarmcombination;
            isliveui = islive;
            alarmoperationui = alarmoperation;
        }

        // UI 데이터를 원본 데이터로 복사
        public override void CopyUIToOrigin()
        {
            no = noui;
            alarmcode = alarmcodeui;
            maincamerano = maincameranoui;
            maincameraalarmcode = maincameraalarmcodeui;
            subcamerano = subcameranoui;
            subcameraalarmcode = subcameraalarmcodeui;
            alarmcombination = alarmcombinationui;
            islive = isliveui;
            alarmoperation = alarmoperationui;
        }
        public void ConvertOriginToUi() { }
        public void ConvertUiToOrigin() { }

        // 사용자가 데이터를 편집했는지 확인
        public override bool IsUserEdit()
        {
            return no != noui ||
                   alarmcode != alarmcodeui ||
                   maincamerano != maincameranoui ||
                   maincameraalarmcode != maincameraalarmcodeui ||
                   subcamerano != subcameranoui ||
                   subcameraalarmcode != subcameraalarmcodeui ||
                   alarmcombination != alarmcombinationui ||
                   islive != isliveui ||
                   alarmoperation != alarmoperationui;
        }

        public void SetAutoIncrementIndex(long autoincrementindex) { }

        public string InsertQuery()
        {
            return string.Format(
                "INSERT INTO cameraalarmoperation (no, alarmcode, maincamerano, maincameraalarmcode, subcamerano, subcameraalarmcode, alarmcombination, islive, alarmoperation) VALUES ({0}, '{1}', {2}, '{3}', {4}, '{5}', '{6}', '{7}', {8})",
                _no,
                _alarmcode,
                _maincamerano.HasValue ? _maincamerano.Value.ToString() : "NULL",
                _maincameraalarmcode,
                _subcamerano.HasValue ? _subcamerano.Value.ToString() : "NULL",
                _subcameraalarmcode,
                _alarmcombination,
                _islive,
                _alarmoperation.HasValue ? _alarmoperation.Value.ToString() : "NULL"
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
                    "UPDATE cameraalarmoperation SET alarmcode = '{0}', maincamerano = {1}, maincameraalarmcode = '{2}', subcamerano = {3}, subcameraalarmcode = '{4}', alarmcombination = '{5}', islive = '{6}', alarmoperation = {7} WHERE no = {8}",
                    _alarmcode,
                    _maincamerano.HasValue ? _maincamerano.Value.ToString() : "NULL",
                    _maincameraalarmcode,
                    _subcamerano.HasValue ? _subcamerano.Value.ToString() : "NULL",
                    _subcameraalarmcode,
                    _alarmcombination,
                    _islive,
                    _alarmoperation.HasValue ? _alarmoperation.Value.ToString() : "NULL",
                    _no
                )
            };
        }

        public string[] DeleteQueryList()
        {
            return new string[]
            {
                string.Format("DELETE FROM cameraalarmoperation WHERE no = {0}", _no),
            };
        }

    }

    public class CameraAlarmOperationDBList : BaseDBListByOC<CameraAlarmOperationDBModel>
    {
        public CameraAlarmOperationDBList() : base() { }

        // Method to generate the SQL query for selecting all entries from the cameraalarmoperation table
        public string SelectAllQuery()
        {
            return "SELECT * FROM cameraalarmoperation";
        }

        // Method to parse the dataset and populate the collection
        public void SelectAllDSParsing()
        {
            this.Clear();

            foreach (DataRow dr in dataset.Tables[0].Rows)
            {
                CameraAlarmOperationDBModel model = new CameraAlarmOperationDBModel();
                Assign(dr, model);

                this.Add(model);
            }

            dataset.Clear();
        }

        // Method to map a DataRow to a CameraAlarmOperationModel instance
        private void Assign(DataRow dr, CameraAlarmOperationDBModel model)
        {
            model.no = Convert.ToInt32(dr["no"].ToString());
            model.alarmcode = dr["alarmcode"]?.ToString();
            model.maincamerano = dr["maincamerano"] == DBNull.Value ? (int?)null : Convert.ToInt32(dr["maincamerano"].ToString());
            model.maincameraalarmcode = dr["maincameraalarmcode"]?.ToString();
            model.subcamerano = dr["subcamerano"] == DBNull.Value ? (int?)null : Convert.ToInt32(dr["subcamerano"].ToString());
            model.subcameraalarmcode = dr["subcameraalarmcode"]?.ToString();
            model.alarmcombination = dr["alarmcombination"]?.ToString();
            model.islive = dr["islive"]?.ToString();
            model.alarmoperation = dr["alarmoperation"] == DBNull.Value ? (int?)null : Convert.ToInt32(dr["alarmoperation"].ToString());
        }

        // Method to get a model by its No property
        public CameraAlarmOperationDBModel GetByNo(int no)
        {
            return this.FirstOrDefault(a => a.no == no);
        }
    }
}
