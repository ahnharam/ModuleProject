using System;
using System.Data;
using System.Linq;

namespace SystemEditor.DBModel.DBData
{
    public enum ServerSort
    {
        PERIDECTSERVER = 1,
        ACTIVEMQSERVER = 2,
        MULTIKANSERVER = 3,
        DISTRIBUTIONSERVER = 4,
        EVENTSERVER = 5,
        MAPSERVER = 6,
        OPERATIONSERVER = 7,
        AICAMERASERVER = 8
    }

    public class ServerDBModel : IsEditUpdater, IDBQuery
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
                    UserEditEvent?.Invoke();
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

        public string ipaddr
        {
            get { return _ipaddr; }
            set
            {
                if (SetProperty(ref _ipaddr, value))
                {
                    UserEditEvent?.Invoke();
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
                    UserEditEvent?.Invoke();
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
                    UserEditEvent?.Invoke();
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
                    UserEditEvent?.Invoke();
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

        public string ipaddrui
        {
            get { return _ipaddrui; }
            set
            {
                if (SetProperty(ref _ipaddrui, value))
                {
                    UserEditEvent?.Invoke();
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
                    UserEditEvent?.Invoke();
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
                    UserEditEvent?.Invoke();
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
        public void ConvertOriginToUi() { }
        public void ConvertUiToOrigin() { }

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

        public void SetAutoIncrementIndex(long autoincrementindex) { }

        public string InsertQuery()
        {
            return string.Format(
                "INSERT INTO server (serverno, servername, sort, ipaddr, secondaryportno, city) VALUES ({0}, '{1}', {2}, '{3}', {4}, '{5}')",
                _serverno,
                _servername,
                _sort.HasValue ? _sort.Value.ToString() : "NULL",
                _ipaddr,
                _secondaryportno.HasValue ? _secondaryportno.Value.ToString() : "NULL",
                _city
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
                    "UPDATE server SET servername = '{0}', sort = {1}, ipaddr = '{2}', secondaryportno = {3}, city = '{4}' WHERE serverno = {5}",
                    _servername,
                    _sort.HasValue ? _sort.Value.ToString() : "NULL",
                    _ipaddr,
                    _secondaryportno.HasValue ? _secondaryportno.Value.ToString() : "NULL",
                    _city,
                    _serverno
                )
            };
        }

        public string[] DeleteQueryList()
        {
            return new string[]
            {
                string.Format("DELETE FROM server WHERE serverno = {0}", _serverno),
            };
        }

    }

    public class ServerDBList : BaseDBListByOC<ServerDBModel>
    {
        public ServerDBList() : base() { }

        public string SelectAllQuery()
        {
            return "select * from server where sort = 2;";
        }

        public string SelectBySortQuery(ServerSort serversort)
        {
            return string.Format("select * from server where sort = {0};", (int)serversort);
        }

        public string SelectBySortAndIPQuery(ServerSort serversort, string ipaddr)
        {
            return string.Format("select * from server where sort = {0} AND ipaddr = '{1}';", (int)serversort, ipaddr);
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
