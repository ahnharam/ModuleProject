using System;
using System.Data;
using System.Linq;

namespace ModuleProject_WPF_Default.Models
{
    public class UserDBModel : IsEditUpdater
    {
        // 원본 데이터 필드
        private string _userid;
        private string _username;
        private int? _sort;
        private string _pwd;
        private string _auth;
        private int? _level;
        private int? _mkencoderno;
        private string _city;

        // UI 데이터 필드
        private string _useridui;
        private string _usernameui;
        private int? _sortui;
        private string _pwdui;
        private string _authui;
        private int? _levelui;
        private int? _mkencodernoui;
        private string _cityui;

        // 원본 데이터 프로퍼티
        public string userid
        {
            get { return _userid; }
            set
            {
                if (SetProperty(ref _userid, value))
                {
                    OnPropertyChanged(nameof(IsEdit));
                }
            }
        }

        public string username
        {
            get { return _username; }
            set
            {
                if (SetProperty(ref _username, value))
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

        public string pwd
        {
            get { return _pwd; }
            set
            {
                if (SetProperty(ref _pwd, value))
                {
                    OnPropertyChanged(nameof(IsEdit));
                }
            }
        }

        public string auth
        {
            get { return _auth; }
            set
            {
                if (SetProperty(ref _auth, value))
                {
                    OnPropertyChanged(nameof(IsEdit));
                }
            }
        }

        public int? level
        {
            get { return _level; }
            set
            {
                if (SetProperty(ref _level, value))
                {
                    OnPropertyChanged(nameof(IsEdit));
                }
            }
        }

        public int? mkencoderno
        {
            get { return _mkencoderno; }
            set
            {
                if (SetProperty(ref _mkencoderno, value))
                {
                    OnPropertyChanged(nameof(IsEdit));
                }
            }
        }

        public string city
        {
            get { return _city; }
            set
            {
                if (SetProperty(ref _city, value))
                {
                    OnPropertyChanged(nameof(IsEdit));
                }
            }
        }

        // UI 데이터 프로퍼티
        public string useridui
        {
            get { return _useridui; }
            set
            {
                if (SetProperty(ref _useridui, value))
                {
                    OnPropertyChanged(nameof(IsEdit));
                }
            }
        }

        public string usernameui
        {
            get { return _usernameui; }
            set
            {
                if (SetProperty(ref _usernameui, value))
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

        public string pwdui
        {
            get { return _pwdui; }
            set
            {
                if (SetProperty(ref _pwdui, value))
                {
                    OnPropertyChanged(nameof(IsEdit));
                }
            }
        }

        public string authui
        {
            get { return _authui; }
            set
            {
                if (SetProperty(ref _authui, value))
                {
                    OnPropertyChanged(nameof(IsEdit));
                }
            }
        }

        public int? levelui
        {
            get { return _levelui; }
            set
            {
                if (SetProperty(ref _levelui, value))
                {
                    OnPropertyChanged(nameof(IsEdit));
                }
            }
        }

        public int? mkencodernoui
        {
            get { return _mkencodernoui; }
            set
            {
                if (SetProperty(ref _mkencodernoui, value))
                {
                    OnPropertyChanged(nameof(IsEdit));
                }
            }
        }

        public string cityui
        {
            get { return _cityui; }
            set
            {
                if (SetProperty(ref _cityui, value))
                {
                    OnPropertyChanged(nameof(IsEdit));
                }
            }
        }

        // 기본 생성자
        public UserDBModel() : base() { }

        // 원본 데이터를 UI 데이터로 복사
        public override void CopyOriginToUI()
        {
            useridui = userid;
            usernameui = username;
            sortui = sort;
            pwdui = pwd;
            authui = auth;
            levelui = level;
            mkencodernoui = mkencoderno;
            cityui = city;
        }

        // UI 데이터를 원본 데이터로 복사
        public override void CopyUIToOrigin()
        {
            userid = useridui;
            username = usernameui;
            sort = sortui;
            pwd = pwdui;
            auth = authui;
            level = levelui;
            mkencoderno = mkencodernoui;
            city = cityui;
        }

        // 사용자가 데이터를 편집했는지 확인
        public override bool IsUserEdit()
        {
            return userid != useridui ||
                   username != usernameui ||
                   sort != sortui ||
                   pwd != pwdui ||
                   auth != authui ||
                   level != levelui ||
                   mkencoderno != mkencodernoui ||
                   city != cityui;
        }
    }

    public class UserDBList : BaseDBList<UserDBModel>
    {
        public UserDBList() : base() { }

        // Method to generate the SQL query for selecting all entries from the user table
        public string SelectAllQuery()
        {
            return "SELECT * FROM user";
        }

        // Method to parse the dataset and populate the collection
        public void SelectAllDSParsing()
        {
            this.Clear();

            foreach (DataRow dr in dataset.Tables[0].Rows)
            {
                UserDBModel model = new UserDBModel();
                Assign(dr, model);

                this.Add(model);
            }

            dataset.Clear();
        }

        // Method to map a DataRow to a UserModel instance
        private void Assign(DataRow dr, UserDBModel model)
        {
            model.userid = dr["userid"]?.ToString();
            model.username = dr["username"]?.ToString();
            model.sort = dr["sort"] == DBNull.Value ? (int?)null : Convert.ToInt32(dr["sort"].ToString());
            model.pwd = dr["pwd"]?.ToString();
            model.auth = dr["auth"]?.ToString();
            model.level = dr["level"] == DBNull.Value ? (int?)null : Convert.ToInt32(dr["level"].ToString());
            model.mkencoderno = dr["mkencoderno"] == DBNull.Value ? (int?)null : Convert.ToInt32(dr["mkencoderno"].ToString());
            model.city = dr["city"]?.ToString();
        }

        // Method to get a model by its Userid property
        public UserDBModel GetByUserid(string userid)
        {
            return this.FirstOrDefault(a => a.userid == userid);
        }
    }
}
