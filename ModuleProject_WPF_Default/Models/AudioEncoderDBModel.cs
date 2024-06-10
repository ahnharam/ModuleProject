using System;
using System.Data;
using System.Linq;

namespace ModuleProject_WPF_Default.Models
{
    public class AudioEncoderDBModel : IsEditUpdater
    {
        // 원본 데이터 필드
        private int _serialno;
        private string _encodername;
        private string _displayname;
        private int? _sort;
        private int? _livevolume;
        private string _source;

        // UI 데이터 필드
        private int _serialnoui;
        private string _encodernamui;
        private string _displaynameui;
        private int? _sortui;
        private int? _livevolumeui;
        private string _sourceui;

        // 원본 데이터 프로퍼티
        public int serialno
        {
            get { return _serialno; }
            set
            {
                if (SetProperty(ref _serialno, value))
                {
                    OnPropertyChanged(nameof(IsEdit));
                }
            }
        }

        public string encodername
        {
            get { return _encodername; }
            set
            {
                if (SetProperty(ref _encodername, value))
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

        public int? sort
        {
            get { return _sort; }
            set
            {
                if (SetProperty(ref _sort, value))
                {
                    OnPropertyChanged(nameof(IsEdit));
                }
            }
        }

        public int? livevolume
        {
            get { return _livevolume; }
            set
            {
                if (SetProperty(ref _livevolume, value))
                {
                    OnPropertyChanged(nameof(IsEdit));
                }
            }
        }

        public string source
        {
            get { return _source; }
            set
            {
                if (SetProperty(ref _source, value))
                {
                    OnPropertyChanged(nameof(IsEdit));
                }
            }
        }

        // UI 데이터 프로퍼티
        public int serialnoui
        {
            get { return _serialnoui; }
            set
            {
                if (SetProperty(ref _serialnoui, value))
                {
                    OnPropertyChanged(nameof(IsEdit));
                }
            }
        }

        public string encodernamui
        {
            get { return _encodernamui; }
            set
            {
                if (SetProperty(ref _encodernamui, value))
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

        public int? sortui
        {
            get { return _sortui; }
            set
            {
                if (SetProperty(ref _sortui, value))
                {
                    OnPropertyChanged(nameof(IsEdit));
                }
            }
        }

        public int? livevolumeui
        {
            get { return _livevolumeui; }
            set
            {
                if (SetProperty(ref _livevolumeui, value))
                {
                    OnPropertyChanged(nameof(IsEdit));
                }
            }
        }

        public string sourceui
        {
            get { return _sourceui; }
            set
            {
                if (SetProperty(ref _sourceui, value))
                {
                    OnPropertyChanged(nameof(IsEdit));
                }
            }
        }

        // 기본 생성자
        public AudioEncoderDBModel() : base() { }

        // 원본 데이터를 UI 데이터로 복사
        public override void CopyOriginToUI()
        {
            serialnoui = serialno;
            encodernamui = encodername;
            displaynameui = displayname;
            sortui = sort;
            livevolumeui = livevolume;
            sourceui = source;
        }

        // UI 데이터를 원본 데이터로 복사
        public override void CopyUIToOrigin()
        {
            serialno = serialnoui;
            encodername = encodernamui;
            displayname = displaynameui;
            sort = sortui;
            livevolume = livevolumeui;
            source = sourceui;
        }

        // 사용자가 데이터를 편집했는지 확인
        public override bool IsUserEdit()
        {
            return serialno != serialnoui ||
                   encodername != encodernamui ||
                   displayname != displaynameui ||
                   sort != sortui ||
                   livevolume != livevolumeui ||
                   source != sourceui;
        }
    }

    public class AudioEncoderDBList : BaseDBList<AudioEncoderDBModel>
    {
        public AudioEncoderDBList() : base() { }

        // Method to generate the SQL query for selecting all entries from the audioencoder table
        public string SelectAllQuery()
        {
            return "SELECT * FROM audioencoder";
        }

        // Method to parse the dataset and populate the collection
        public void SelectAllDSParsing()
        {
            this.Clear();

            foreach (DataRow dr in dataset.Tables[0].Rows)
            {
                AudioEncoderDBModel model = new AudioEncoderDBModel();
                Assign(dr, model);

                this.Add(model);
            }

            dataset.Clear();
        }

        // Method to map a DataRow to an AudioEncoderModel instance
        private void Assign(DataRow dr, AudioEncoderDBModel model)
        {
            model.serialno = Convert.ToInt32(dr["serialno"].ToString());
            model.encodername = dr["encodername"]?.ToString();
            model.displayname = dr["displayname"]?.ToString();
            model.sort = dr["sort"] == DBNull.Value ? (int?)null : Convert.ToInt32(dr["sort"].ToString());
            model.livevolume = dr["livevolume"] == DBNull.Value ? (int?)null : Convert.ToInt32(dr["livevolume"].ToString());
            model.source = dr["source"]?.ToString();
        }

        // Method to get a model by its Serialno property
        public AudioEncoderDBModel GetBySerialno(int serialno)
        {
            return this.FirstOrDefault(a => a.serialno == serialno);
        }
    }
}
