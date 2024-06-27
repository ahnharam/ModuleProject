using System;
using System.Data;
using System.Linq;

namespace SystemEditor.DBModel.DBData
{
    public class AudioEncoderDBModel : IsEditUpdater, IDBQuery
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
                    UserEditEvent?.Invoke();
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
                    UserEditEvent?.Invoke();
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
                    UserEditEvent?.Invoke();
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
                    UserEditEvent?.Invoke();
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
                    UserEditEvent?.Invoke();
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
                    UserEditEvent?.Invoke();
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
                    UserEditEvent?.Invoke();
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
                    UserEditEvent?.Invoke();
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
                    UserEditEvent?.Invoke();
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
                    UserEditEvent?.Invoke();
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
                    UserEditEvent?.Invoke();
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
                    UserEditEvent?.Invoke();
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
        public void ConvertOriginToUi() { }
        public void ConvertUiToOrigin() { }

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

        public void SetAutoIncrementIndex(long autoincrementindex) { }

        public string InsertQuery()
        {
            return string.Format(
                "INSERT INTO audioencoder (serialno, encodername, displayname, sort, livevolume, source) VALUES ({0}, '{1}', '{2}', {3}, {4}, '{5}')",
                _serialno,
                _encodername,
                _displayname,
                _sort.HasValue ? _sort.Value.ToString() : "NULL",
                _livevolume.HasValue ? _livevolume.Value.ToString() : "NULL",
                _source
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
                    "UPDATE audioencoder SET encodername = '{0}', displayname = '{1}', sort = {2}, livevolume = {3}, source = '{4}' WHERE serialno = {5}",
                    _encodername,
                    _displayname,
                    _sort.HasValue ? _sort.Value.ToString() : "NULL",
                    _livevolume.HasValue ? _livevolume.Value.ToString() : "NULL",
                    _source,
                    _serialno
                )
            };
        }

        public string[] DeleteQueryList()
        {
            return new string[]
            {
                string.Format("DELETE FROM audioencoder WHERE serialno = {0}", _serialno),
            };
        }

    }

    public class AudioEncoderDBList : BaseDBListByOC<AudioEncoderDBModel>
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
