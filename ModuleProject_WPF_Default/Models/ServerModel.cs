using System;
using System.Data;
using System.Linq;

namespace ModuleProject_WPF_Default.Models
{
    public class ServerDBModel : IsEditUpdater
    {
        // 원본 데이터 필드
        private int _serverno;
        private string _servername;
        private int? _sort;
        private string _ipaddr;
        private int? _secondaryportno;
        private string _city;

        // UI 데이터 필드
        private int _servernoui;
        private string _servernameui;
        private int? _sortui;
        private string _ipaddrui;
        private int? _secondaryportnoui;
        private string _cityui;

        // 원본 데이터 프로퍼티
        public int serverno
        {
            get { return _serverno; }
            set
            {
                if (SetProperty(ref _serverno, value))
                {
                    OnPropertyChanged(nameof(IsEdit));
                }
            }
        }

        public string servername
        {
            get { return _servername; }
            set
            {
                if (SetProperty(ref _servername, value))
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

        public string ipaddr
        {
            get { return _ipaddr; }
            set
            {
                if (SetProperty(ref _ipaddr, value))
                {
                    OnPropertyChanged(nameof(IsEdit));
                }
            }
        }

        public int? secondaryportno
        {
            get { return _secondaryportno; }
            set
            {
                if (SetProperty(ref _secondaryportno, value))
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
        public int servernoui
        {
            get { return _servernoui; }
            set
            {
                if (SetProperty(ref _servernoui, value))
                {
                    OnPropertyChanged(nameof(IsEdit));
                }
            }
        }

        public string servernameui
        {
            get { return _servernameui; }
            set
            {
                if (SetProperty(ref _servernameui, value))
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

        public string ipaddrui
        {
            get { return _ipaddrui; }
            set
            {
                if (SetProperty(ref _ipaddrui, value))
                {
                    OnPropertyChanged(nameof(IsEdit));
                }
            }
        }

        public int? secondaryportnoui
        {
            get { return _secondaryportnoui; }
            set
            {
                if (SetProperty(ref _secondaryportnoui, value))
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
        public ServerDBModel() : base() { }

        // 원본 데이터를 UI 데이터로 복사
        public override void CopyOriginToUI()
        {
            servernoui = serverno;
            servernameui = servername;
            sortui = sort;
            ipaddrui = ipaddr;
            secondaryportnoui = secondaryportno;
            cityui = city;
        }

        // UI 데이터를 원본 데이터로 복사
        public override void CopyUIToOrigin()
        {
            serverno = servernoui;
            servername = servernameui;
            sort = sortui;
            ipaddr = ipaddrui;
            secondaryportno = secondaryportnoui;
            city = cityui;
        }

        // 사용자가 데이터를 편집했는지 확인
        public override bool IsUserEdit()
        {
            return serverno != servernoui ||
                   servername != servernameui ||
                   sort != sortui ||
                   ipaddr != ipaddrui ||
                   secondaryportno != secondaryportnoui ||
                   city != cityui;
        }
    }

    public class ServerDBList : BaseDBList<ServerDBModel>
    {
        public ServerDBList() : base() { }

        // Method to generate the SQL query for selecting all entries from the server table
        public string SelectAllQuery()
        {
            return "SELECT * FROM server";
        }

        // Method to parse the dataset and populate the collection
        public void SelectAllDSParsing()
        {
            this.Clear();

            foreach (DataRow dr in dataset.Tables[0].Rows)
            {
                ServerDBModel model = new ServerDBModel();
                Assign(dr, model);

                this.Add(model);
            }

            dataset.Clear();
        }

        // Method to map a DataRow to a ServerModel instance
        private void Assign(DataRow dr, ServerDBModel model)
        {
            model.serverno = Convert.ToInt32(dr["serverno"].ToString());
            model.servername = dr["servername"]?.ToString();
            model.sort = dr["sort"] == DBNull.Value ? (int?)null : Convert.ToInt32(dr["sort"].ToString());
            model.ipaddr = dr["ipaddr"]?.ToString();
            model.secondaryportno = dr["secondaryportno"] == DBNull.Value ? (int?)null : Convert.ToInt32(dr["secondaryportno"].ToString());
            model.city = dr["city"]?.ToString();
        }

        // Method to get a model by its Serverno property
        public ServerDBModel GetByServerno(int serverno)
        {
            return this.FirstOrDefault(a => a.serverno == serverno);
        }
    }
}
