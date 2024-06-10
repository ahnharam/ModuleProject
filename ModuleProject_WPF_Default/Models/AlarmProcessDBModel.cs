using System;
using System.Data;
using System.Linq;

namespace ModuleProject_WPF_Default.Models
{
    public class AlarmProcessDBModel : IsEditUpdater
    {
        // 원본 데이터 필드
        private int _no;

        // UI 데이터 필드
        private int _noui;

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

        // 기본 생성자
        public AlarmProcessDBModel() : base() { }

        // 원본 데이터를 UI 데이터로 복사
        public override void CopyOriginToUI()
        {
            noui = no;
        }

        // UI 데이터를 원본 데이터로 복사
        public override void CopyUIToOrigin()
        {
            no = noui;
        }

        // 사용자가 데이터를 편집했는지 확인
        public override bool IsUserEdit()
        {
            return no != noui;
        }
    }

    public class AlarmProcessDBList : BaseDBList<AlarmProcessDBModel>
    {
        public AlarmProcessDBList() : base() { }

        // Method to generate the SQL query for selecting all entries from the alarmprocess table
        public string SelectAllQuery()
        {
            return "SELECT * FROM alarmprocess";
        }

        // Method to parse the dataset and populate the collection
        public void SelectAllDSParsing()
        {
            this.Clear();

            foreach (DataRow dr in dataset.Tables[0].Rows)
            {
                AlarmProcessDBModel model = new AlarmProcessDBModel();
                Assign(dr, model);

                this.Add(model);
            }

            dataset.Clear();
        }

        // Method to map a DataRow to an AlarmProcessModel instance
        private void Assign(DataRow dr, AlarmProcessDBModel model)
        {
            model.no = Convert.ToInt32(dr["no"].ToString());
        }

        // Method to get a model by its No property
        public AlarmProcessDBModel GetByNo(int no)
        {
            return this.FirstOrDefault(a => a.no == no);
        }
    }
}
