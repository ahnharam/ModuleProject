using System;
using System.Data;
using System.Linq;

namespace SystemEditor.DBModel.DBData
{
    public class ContactInputDBModel : IsEditUpdater, IDBQuery
    {
        // 원본 데이터 필드
        private int? _no;
        private int? _contactsort;
        private int? _sensorno;
        private int? _portno;
        private int? _stationno;
        private string _onstatus;
        private string _alarmstatus;
        private int? _alarmoperation;
        private int? _alarmprocess;
        private string _alarmcode;
        private int? _isalive;
        private string _description;

        // UI 데이터 필드
        private int? _noui;
        private int? _contactsortui;
        private int? _sensornoui;
        private int? _portnoui;
        private int? _stationnoui;
        private string _onstatusui;
        private string _alarmstatusui;
        private int? _alarmoperationui;
        private int? _alarmprocessui;
        private string _alarmcodeui;
        private int? _isaliveui;
        private string _descriptionui;

        // 원본 데이터 프로퍼티
        public int? no
        {
            get { return _no; }
            set
            {
                if (SetProperty(ref _no, value))
                {
                    UserEditEvent?.Invoke();
                }
            }
        }

        public int? contactsort
        {
            get { return _contactsort; }
            set
            {
                if (SetProperty(ref _contactsort, value))
                {
                    UserEditEvent?.Invoke();
                }
            }
        }

        public int? sensorno
        {
            get { return _sensorno; }
            set
            {
                if (SetProperty(ref _sensorno, value))
                {
                    UserEditEvent?.Invoke();
                }
            }
        }

        public int? portno
        {
            get { return _portno; }
            set
            {
                if (SetProperty(ref _portno, value))
                {
                    UserEditEvent?.Invoke();
                }
            }
        }

        public int? stationno
        {
            get { return _stationno; }
            set
            {
                if (SetProperty(ref _stationno, value))
                {
                    UserEditEvent?.Invoke();
                }
            }
        }

        public string onstatus
        {
            get { return _onstatus; }
            set
            {
                if (SetProperty(ref _onstatus, value))
                {
                    UserEditEvent?.Invoke();
                }
            }
        }

        public string alarmstatus
        {
            get { return _alarmstatus; }
            set
            {
                if (SetProperty(ref _alarmstatus, value))
                {
                    UserEditEvent?.Invoke();
                }
            }
        }

        public int? alarmoperation
        {
            get { return _alarmoperation; }
            set
            {
                if (SetProperty(ref _alarmoperation, value))
                {
                    UserEditEvent?.Invoke();
                }
            }
        }

        public int? alarmprocess
        {
            get { return _alarmprocess; }
            set
            {
                if (SetProperty(ref _alarmprocess, value))
                {
                    UserEditEvent?.Invoke();
                }
            }
        }

        public string alarmcode
        {
            get { return _alarmcode; }
            set
            {
                if (SetProperty(ref _alarmcode, value))
                {
                    UserEditEvent?.Invoke();
                }
            }
        }

        public int? isalive
        {
            get { return _isalive; }
            set
            {
                if (SetProperty(ref _isalive, value))
                {
                    UserEditEvent?.Invoke();
                }
            }
        }

        public string description
        {
            get { return _description; }
            set
            {
                if (SetProperty(ref _description, value))
                {
                    UserEditEvent?.Invoke();
                }
            }
        }

        // UI 데이터 프로퍼티
        public int? noui
        {
            get { return _noui; }
            set
            {
                if (SetProperty(ref _noui, value))
                {
                    UserEditEvent?.Invoke();
                }
            }
        }

        public int? contactsortui
        {
            get { return _contactsortui; }
            set
            {
                if (SetProperty(ref _contactsortui, value))
                {
                    UserEditEvent?.Invoke();
                }
            }
        }

        public int? sensornoui
        {
            get { return _sensornoui; }
            set
            {
                if (SetProperty(ref _sensornoui, value))
                {
                    UserEditEvent?.Invoke();
                }
            }
        }

        public int? portnoui
        {
            get { return _portnoui; }
            set
            {
                if (SetProperty(ref _portnoui, value))
                {
                    UserEditEvent?.Invoke();
                }
            }
        }

        public int? stationnoui
        {
            get { return _stationnoui; }
            set
            {
                if (SetProperty(ref _stationnoui, value))
                {
                    UserEditEvent?.Invoke();
                }
            }
        }

        public string onstatusui
        {
            get { return _onstatusui; }
            set
            {
                if (SetProperty(ref _onstatusui, value))
                {
                    UserEditEvent?.Invoke();
                }
            }
        }

        public string alarmstatusui
        {
            get { return _alarmstatusui; }
            set
            {
                if (SetProperty(ref _alarmstatusui, value))
                {
                    UserEditEvent?.Invoke();
                }
            }
        }

        public int? alarmoperationui
        {
            get { return _alarmoperationui; }
            set
            {
                if (SetProperty(ref _alarmoperationui, value))
                {
                    UserEditEvent?.Invoke();
                }
            }
        }

        public int? alarmprocessui
        {
            get { return _alarmprocessui; }
            set
            {
                if (SetProperty(ref _alarmprocessui, value))
                {
                    UserEditEvent?.Invoke();
                }
            }
        }

        public string alarmcodeui
        {
            get { return _alarmcodeui; }
            set
            {
                if (SetProperty(ref _alarmcodeui, value))
                {
                    UserEditEvent?.Invoke();
                }
            }
        }

        public int? isaliveui
        {
            get { return _isaliveui; }
            set
            {
                if (SetProperty(ref _isaliveui, value))
                {
                    UserEditEvent?.Invoke();
                }
            }
        }

        public string descriptionui
        {
            get { return _descriptionui; }
            set
            {
                if (SetProperty(ref _descriptionui, value))
                {
                    UserEditEvent?.Invoke();
                }
            }
        }

        // 기본 생성자
        public ContactInputDBModel() : base() { }

        // 원본 데이터를 UI 데이터로 복사
        public override void CopyOriginToUI()
        {
            noui = no;
            contactsortui = contactsort;
            sensornoui = sensorno;
            portnoui = portno;
            stationnoui = stationno;
            onstatusui = onstatus;
            alarmstatusui = alarmstatus;
            alarmoperationui = alarmoperation;
            alarmprocessui = alarmprocess;
            alarmcodeui = alarmcode;
            isaliveui = isalive;
            descriptionui = description;
        }

        // UI 데이터를 원본 데이터로 복사
        public override void CopyUIToOrigin()
        {
            no = noui;
            contactsort = contactsortui;
            sensorno = sensornoui;
            portno = portnoui;
            stationno = stationnoui;
            onstatus = onstatusui;
            alarmstatus = alarmstatusui;
            alarmoperation = alarmoperationui;
            alarmprocess = alarmprocessui;
            alarmcode = alarmcodeui;
            isalive = isaliveui;
            description = descriptionui;
        }
        public void ConvertOriginToUi() { }
        public void ConvertUiToOrigin() { }

        // 사용자가 데이터를 편집했는지 확인
        public override bool IsUserEdit()
        {
            return no != noui ||
                   contactsort != contactsortui ||
                   sensorno != sensornoui ||
                   portno != portnoui ||
                   stationno != stationnoui ||
                   onstatus != onstatusui ||
                   alarmstatus != alarmstatusui ||
                   alarmoperation != alarmoperationui ||
                   alarmprocess != alarmprocessui ||
                   alarmcode != alarmcodeui ||
                   isalive != isaliveui ||
                   description != descriptionui;
        }

        public void SetAutoIncrementIndex(long autoincrementindex) { }

        public string InsertQuery()
        {
            return string.Format(
                "INSERT INTO contactinput (no, contactsort, sensorno, portno, stationno, onstatus, alarmstatus, alarmoperation, alarmprocess, alarmcode, isalive, description) VALUES ({0}, {1}, {2}, {3}, {4}, '{5}', '{6}', {7}, {8}, '{9}', {10}, '{11}')",
                no.HasValue ? no.Value.ToString() : "NULL",
                contactsort.HasValue ? contactsort.Value.ToString() : "NULL",
                sensorno.HasValue ? sensorno.Value.ToString() : "NULL",
                portno.HasValue ? portno.Value.ToString() : "NULL",
                stationno.HasValue ? stationno.Value.ToString() : "NULL",
                onstatus,
                alarmstatus,
                alarmoperation.HasValue ? alarmoperation.Value.ToString() : "NULL",
                alarmprocess.HasValue ? alarmprocess.Value.ToString() : "NULL",
                alarmcode,
                isalive.HasValue ? isalive.Value.ToString() : "NULL",
                description
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
                    "UPDATE contactinput SET contactsort = {0}, sensorno = {1}, portno = {2}, stationno = {3}, onstatus = '{4}', alarmstatus = '{5}', alarmoperation = {6}, alarmprocess = {7}, alarmcode = '{8}', isalive = {9}, description = '{10}' WHERE no = {11}",
                    contactsort.HasValue ? contactsort.Value.ToString() : "NULL",
                    sensorno.HasValue ? sensorno.Value.ToString() : "NULL",
                    portno.HasValue ? portno.Value.ToString() : "NULL",
                    stationno.HasValue ? stationno.Value.ToString() : "NULL",
                    onstatus,
                    alarmstatus,
                    alarmoperation.HasValue ? alarmoperation.Value.ToString() : "NULL",
                    alarmprocess.HasValue ? alarmprocess.Value.ToString() : "NULL",
                    alarmcode,
                    isalive.HasValue ? isalive.Value.ToString() : "NULL",
                    description,
                    no.HasValue ? no.Value.ToString() : "NULL"
                )
            };
        }

        public string[] DeleteQueryList()
        {
            return new string[]
            {
                string.Format("DELETE FROM contactinput WHERE no = {0}", no.HasValue ? no.Value.ToString() : "NULL"),
            };
        }

    }

    public class ContactInputDBList : BaseDBListByOC<ContactInputDBModel>
    {
        public ContactInputDBList() : base() { }

        // Method to generate the SQL query for selecting all entries from the contactinput table
        public string SelectAllQuery()
        {
            return "SELECT * FROM contactinput";
        }

        // Method to parse the dataset and populate the collection
        public void SelectAllDSParsing()
        {
            this.Clear();

            foreach (DataRow dr in dataset.Tables[0].Rows)
            {
                ContactInputDBModel model = new ContactInputDBModel();
                Assign(dr, model);

                this.Add(model);
            }

            dataset.Clear();
        }

        // Method to map a DataRow to a ContactInputModel instance
        private void Assign(DataRow dr, ContactInputDBModel model)
        {
            model.no = dr["no"] == DBNull.Value ? (int?)null : Convert.ToInt32(dr["no"].ToString());
            model.contactsort = dr["contactsort"] == DBNull.Value ? (int?)null : Convert.ToInt32(dr["contactsort"].ToString());
            model.sensorno = dr["sensorno"] == DBNull.Value ? (int?)null : Convert.ToInt32(dr["sensorno"].ToString());
            model.portno = dr["portno"] == DBNull.Value ? (int?)null : Convert.ToInt32(dr["portno"].ToString());
            model.stationno = dr["stationno"] == DBNull.Value ? (int?)null : Convert.ToInt32(dr["stationno"].ToString());
            model.onstatus = dr["onstatus"]?.ToString();
            model.alarmstatus = dr["alarmstatus"]?.ToString();
            model.alarmoperation = dr["alarmoperation"] == DBNull.Value ? (int?)null : Convert.ToInt32(dr["alarmoperation"].ToString());
            model.alarmprocess = dr["alarmprocess"] == DBNull.Value ? (int?)null : Convert.ToInt32(dr["alarmprocess"].ToString());
            model.alarmcode = dr["alarmcode"]?.ToString();
            model.isalive = dr["isalive"] == DBNull.Value ? (int?)null : Convert.ToInt32(dr["isalive"].ToString());
            model.description = dr["description"]?.ToString();
        }

        // Method to get a model by its No property
        public ContactInputDBModel GetByNo(int no)
        {
            return this.FirstOrDefault(a => a.no == no);
        }
    }
}
