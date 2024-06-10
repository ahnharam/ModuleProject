using System;
using System.Data;
using System.Linq;

namespace ModuleProject_WPF_Default.Models
{
    public class CameraAlarmOperationDBModel : IsEditUpdater
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
            set { if (SetProperty(ref _no, value)) OnPropertyChanged(nameof(IsEdit)); }
        }

        public string alarmcode
        {
            get { return _alarmcode; }
            set { if (SetProperty(ref _alarmcode, value)) OnPropertyChanged(nameof(IsEdit)); }
        }

        public int? maincamerano
        {
            get { return _maincamerano; }
            set { if (SetProperty(ref _maincamerano, value)) OnPropertyChanged(nameof(IsEdit)); }
        }

        public string maincameraalarmcode
        {
            get { return _maincameraalarmcode; }
            set { if (SetProperty(ref _maincameraalarmcode, value)) OnPropertyChanged(nameof(IsEdit)); }
        }

        public int? subcamerano
        {
            get { return _subcamerano; }
            set { if (SetProperty(ref _subcamerano, value)) OnPropertyChanged(nameof(IsEdit)); }
        }

        public string subcameraalarmcode
        {
            get { return _subcameraalarmcode; }
            set { if (SetProperty(ref _subcameraalarmcode, value)) OnPropertyChanged(nameof(IsEdit)); }
        }

        public string alarmcombination
        {
            get { return _alarmcombination; }
            set { if (SetProperty(ref _alarmcombination, value)) OnPropertyChanged(nameof(IsEdit)); }
        }

        public string islive
        {
            get { return _islive; }
            set { if (SetProperty(ref _islive, value)) OnPropertyChanged(nameof(IsEdit)); }
        }

        public int? alarmoperation
        {
            get { return _alarmoperation; }
            set { if (SetProperty(ref _alarmoperation, value)) OnPropertyChanged(nameof(IsEdit)); }
        }

        // UI 데이터 프로퍼티
        public int noui
        {
            get { return _noui; }
            set { if (SetProperty(ref _noui, value)) OnPropertyChanged(nameof(IsEdit)); }
        }

        public string alarmcodeui
        {
            get { return _alarmcodeui; }
            set { if (SetProperty(ref _alarmcodeui, value)) OnPropertyChanged(nameof(IsEdit)); }
        }

        public int? maincameranoui
        {
            get { return _maincameranoui; }
            set { if (SetProperty(ref _maincameranoui, value)) OnPropertyChanged(nameof(IsEdit)); }
        }

        public string maincameraalarmcodeui
        {
            get { return _maincameraalarmcodeui; }
            set { if (SetProperty(ref _maincameraalarmcodeui, value)) OnPropertyChanged(nameof(IsEdit)); }
        }

        public int? subcameranoui
        {
            get { return _subcameranoui; }
            set { if (SetProperty(ref _subcameranoui, value)) OnPropertyChanged(nameof(IsEdit)); }
        }

        public string subcameraalarmcodeui
        {
            get { return _subcameraalarmcodeui; }
            set { if (SetProperty(ref _subcameraalarmcodeui, value)) OnPropertyChanged(nameof(IsEdit)); }
        }

        public string alarmcombinationui
        {
            get { return _alarmcombinationui; }
            set { if (SetProperty(ref _alarmcombinationui, value)) OnPropertyChanged(nameof(IsEdit)); }
        }

        public string isliveui
        {
            get { return _isliveui; }
            set { if (SetProperty(ref _isliveui, value)) OnPropertyChanged(nameof(IsEdit)); }
        }

        public int? alarmoperationui
        {
            get { return _alarmoperationui; }
            set { if (SetProperty(ref _alarmoperationui, value)) OnPropertyChanged(nameof(IsEdit)); }
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
    }

    public class CameraAlarmOperationDBList : BaseDBList<CameraAlarmOperationDBModel>
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
