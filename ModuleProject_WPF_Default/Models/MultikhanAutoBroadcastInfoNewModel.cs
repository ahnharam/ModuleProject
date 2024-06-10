using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace ModuleProject_WPF_Default.Models
{
    public class MultikhanAutoBroadcastInfoNewDBModel : IsEditUpdater
    {
        // 원본 데이터 필드
        private int _no;
        private int? _multikhanno;
        private int? _sourceno;
        private int? _multikhansourceno;
        private string _displayname;
        private int _volume;
        private string _isalarmbroadcast;

        // UI 데이터 필드
        private int _noui;
        private int? _multikhannoui;
        private int? _sourcenoui;
        private int? _multikhansourcenoui;
        private string _displaynameui;
        private int _volumeui;
        private string _isalarmbroadcastui;

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

        public int? multikhanno
        {
            get { return _multikhanno; }
            set
            {
                if (SetProperty(ref _multikhanno, value))
                {
                    OnPropertyChanged(nameof(IsEdit));
                }
            }
        }

        public int? sourceno
        {
            get { return _sourceno; }
            set
            {
                if (SetProperty(ref _sourceno, value))
                {
                    OnPropertyChanged(nameof(IsEdit));
                }
            }
        }

        public int? multikhansourceno
        {
            get { return _multikhansourceno; }
            set
            {
                if (SetProperty(ref _multikhansourceno, value))
                {
                    OnPropertyChanged(nameof(IsEdit));
                }
            }
        }

        public string displayname
        {
            get { return _displayname; }
            set
            {
                if (SetProperty(ref _displayname, value))
                {
                    OnPropertyChanged(nameof(IsEdit));
                }
            }
        }

        public int volume
        {
            get { return _volume; }
            set
            {
                if (SetProperty(ref _volume, value))
                {
                    OnPropertyChanged(nameof(IsEdit));
                }
            }
        }

        public string isalarmbroadcast
        {
            get { return _isalarmbroadcast; }
            set
            {
                if (SetProperty(ref _isalarmbroadcast, value))
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

        public int? multikhannoui
        {
            get { return _multikhannoui; }
            set
            {
                if (SetProperty(ref _multikhannoui, value))
                {
                    OnPropertyChanged(nameof(IsEdit));
                }
            }
        }

        public int? sourcenoui
        {
            get { return _sourcenoui; }
            set
            {
                if (SetProperty(ref _sourcenoui, value))
                {
                    OnPropertyChanged(nameof(IsEdit));
                }
            }
        }

        public int? multikhansourcenoui
        {
            get { return _multikhansourcenoui; }
            set
            {
                if (SetProperty(ref _multikhansourcenoui, value))
                {
                    OnPropertyChanged(nameof(IsEdit));
                }
            }
        }

        public string displaynameui
        {
            get { return _displaynameui; }
            set
            {
                if (SetProperty(ref _displaynameui, value))
                {
                    OnPropertyChanged(nameof(IsEdit));
                }
            }
        }

        public int volumeui
        {
            get { return _volumeui; }
            set
            {
                if (SetProperty(ref _volumeui, value))
                {
                    OnPropertyChanged(nameof(IsEdit));
                }
            }
        }

        public string isalarmbroadcastui
        {
            get { return _isalarmbroadcastui; }
            set
            {
                if (SetProperty(ref _isalarmbroadcastui, value))
                {
                    OnPropertyChanged(nameof(IsEdit));
                }
            }
        }

        // 기본 생성자
        public MultikhanAutoBroadcastInfoNewDBModel() : base() { }

        // 원본 데이터를 UI 데이터로 복사
        public override void CopyOriginToUI()
        {
            noui = no;
            multikhannoui = multikhanno;
            sourcenoui = sourceno;
            multikhansourcenoui = multikhansourceno;
            displaynameui = displayname;
            volumeui = volume;
            isalarmbroadcastui = isalarmbroadcast;
        }

        // UI 데이터를 원본 데이터로 복사
        public override void CopyUIToOrigin()
        {
            no = noui;
            multikhanno = multikhannoui;
            sourceno = sourcenoui;
            multikhansourceno = multikhansourcenoui;
            displayname = displaynameui;
            volume = volumeui;
            isalarmbroadcast = isalarmbroadcastui;
        }

        // 사용자가 데이터를 편집했는지 확인
        public override bool IsUserEdit()
        {
            return no != noui ||
                   multikhanno != multikhannoui ||
                   sourceno != sourcenoui ||
                   multikhansourceno != multikhansourcenoui ||
                   displayname != displaynameui ||
                   volume != volumeui ||
                   isalarmbroadcast != isalarmbroadcastui;
        }
    }

    public class MultikhanAutoBroadcastInfoNewDBList : BaseDBList<MultikhanAutoBroadcastInfoNewDBModel>
    {
        public MultikhanAutoBroadcastInfoNewDBList() : base() { }

        // Method to generate the SQL query for selecting all entries from the multikhanautobroadcastinfo_new table
        public string SelectAllQuery()
        {
            return "SELECT * FROM multikhanautobroadcastinfo_new";
        }

        // Method to parse the dataset and populate the collection
        public void SelectAllDSParsing()
        {
            this.Clear();

            foreach (DataRow dr in dataset.Tables[0].Rows)
            {
                MultikhanAutoBroadcastInfoNewDBModel model = new MultikhanAutoBroadcastInfoNewDBModel();
                Assign(dr, model);

                this.Add(model);
            }

            dataset.Clear();
        }

        // Method to map a DataRow to a MultikhanAutoBroadcastInfoNewModel instance
        private void Assign(DataRow dr, MultikhanAutoBroadcastInfoNewDBModel model)
        {
            model.no = Convert.ToInt32(dr["no"].ToString());
            model.multikhanno = dr["multikhanno"] == DBNull.Value ? (int?)null : Convert.ToInt32(dr["multikhanno"].ToString());
            model.sourceno = dr["sourceno"] == DBNull.Value ? (int?)null : Convert.ToInt32(dr["sourceno"].ToString());
            model.multikhansourceno = dr["multikhansourceno"] == DBNull.Value ? (int?)null : Convert.ToInt32(dr["multikhansourceno"].ToString());
            model.displayname = dr["displayname"]?.ToString();
            model.volume = Convert.ToInt32(dr["volume"].ToString());
            model.isalarmbroadcast = dr["isalarmbroadcast"]?.ToString();
        }

        // Method to get a model by its No property
        public MultikhanAutoBroadcastInfoNewDBModel GetByNo(int no)
        {
            return this.FirstOrDefault(a => a.no == no);
        }
    }
}
