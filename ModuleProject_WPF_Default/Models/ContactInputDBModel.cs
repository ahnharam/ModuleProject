using System;
using System.Data;
using System.Linq;

namespace ModuleProject_WPF_Default.Models
{
    public class ContactInputDBModel : IsEditUpdater
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
                    OnPropertyChanged(nameof(IsEdit));
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
                    OnPropertyChanged(nameof(IsEdit));
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
                    OnPropertyChanged(nameof(IsEdit));
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
                    OnPropertyChanged(nameof(IsEdit));
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
                    OnPropertyChanged(nameof(IsEdit));
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
                    OnPropertyChanged(nameof(IsEdit));
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
                    OnPropertyChanged(nameof(IsEdit));
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
                    OnPropertyChanged(nameof(IsEdit));
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
                    OnPropertyChanged(nameof(IsEdit));
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
                    OnPropertyChanged(nameof(IsEdit));
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
                    OnPropertyChanged(nameof(IsEdit));
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
                    OnPropertyChanged(nameof(IsEdit));
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
                    OnPropertyChanged(nameof(IsEdit));
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
                    OnPropertyChanged(nameof(IsEdit));
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
                    OnPropertyChanged(nameof(IsEdit));
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
                    OnPropertyChanged(nameof(IsEdit));
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
                    OnPropertyChanged(nameof(IsEdit));
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
                    OnPropertyChanged(nameof(IsEdit));
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
                    OnPropertyChanged(nameof(IsEdit));
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
                    OnPropertyChanged(nameof(IsEdit));
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
                    OnPropertyChanged(nameof(IsEdit));
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
                    OnPropertyChanged(nameof(IsEdit));
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
                    OnPropertyChanged(nameof(IsEdit));
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
                    OnPropertyChanged(nameof(IsEdit));
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
    }

    public class ContactInputDBList : BaseDBList<ContactInputDBModel>
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
