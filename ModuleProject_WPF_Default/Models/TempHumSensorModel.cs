using System;
using System.Data;
using System.Linq;

namespace ModuleProject_WPF_Default.Models
{
    public class TempHumSensorDBModel : IsEditUpdater
    {
        // 원본 데이터 필드
        private int _sensorno;
        private int? _multikhanno;
        private string _ipaddr;
        private int? _networkport;
        private string _statistics;
        private string _model;
        private int? _alive;
        private int? _alarmoperation;
        private int? _temphighthight;
        private int? _temphight;
        private int? _templow;
        private int? _templowlow;
        private int? _humphighthight;
        private int? _humphigh;
        private int? _humlow;
        private int? _humlowlow;

        // UI 데이터 필드
        private int _sensornoui;
        private int? _multikhannoui;
        private string _ipaddrui;
        private int? _networkportui;
        private string _statisticsui;
        private string _modelui;
        private int? _aliveui;
        private int? _alarmoperationui;
        private int? _temphighthightui;
        private int? _temphightui;
        private int? _templowui;
        private int? _templowlowui;
        private int? _humphighthightui;
        private int? _humphighui;
        private int? _humlowui;
        private int? _humlowlowui;

        // 원본 데이터 프로퍼티
        public int sensorno
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

        public int? networkport
        {
            get { return _networkport; }
            set
            {
                if (SetProperty(ref _networkport, value))
                {
                    OnPropertyChanged(nameof(IsEdit));
                }
            }
        }

        public string statistics
        {
            get { return _statistics; }
            set
            {
                if (SetProperty(ref _statistics, value))
                {
                    OnPropertyChanged(nameof(IsEdit));
                }
            }
        }

        public string model
        {
            get { return _model; }
            set
            {
                if (SetProperty(ref _model, value))
                {
                    OnPropertyChanged(nameof(IsEdit));
                }
            }
        }

        public int? alive
        {
            get { return _alive; }
            set
            {
                if (SetProperty(ref _alive, value))
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

        public int? temphighthight
        {
            get { return _temphighthight; }
            set
            {
                if (SetProperty(ref _temphighthight, value))
                {
                    OnPropertyChanged(nameof(IsEdit));
                }
            }
        }

        public int? temphight
        {
            get { return _temphight; }
            set
            {
                if (SetProperty(ref _temphight, value))
                {
                    OnPropertyChanged(nameof(IsEdit));
                }
            }
        }

        public int? templow
        {
            get { return _templow; }
            set
            {
                if (SetProperty(ref _templow, value))
                {
                    OnPropertyChanged(nameof(IsEdit));
                }
            }
        }

        public int? templowlow
        {
            get { return _templowlow; }
            set
            {
                if (SetProperty(ref _templowlow, value))
                {
                    OnPropertyChanged(nameof(IsEdit));
                }
            }
        }

        public int? humphighthight
        {
            get { return _humphighthight; }
            set
            {
                if (SetProperty(ref _humphighthight, value))
                {
                    OnPropertyChanged(nameof(IsEdit));
                }
            }
        }

        public int? humphigh
        {
            get { return _humphigh; }
            set
            {
                if (SetProperty(ref _humphigh, value))
                {
                    OnPropertyChanged(nameof(IsEdit));
                }
            }
        }

        public int? humlow
        {
            get { return _humlow; }
            set
            {
                if (SetProperty(ref _humlow, value))
                {
                    OnPropertyChanged(nameof(IsEdit));
                }
            }
        }

        public int? humlowlow
        {
            get { return _humlowlow; }
            set
            {
                if (SetProperty(ref _humlowlow, value))
                {
                    OnPropertyChanged(nameof(IsEdit));
                }
            }
        }

        // UI 데이터 프로퍼티
        public int sensornoui
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

        public int? networkportui
        {
            get { return _networkportui; }
            set
            {
                if (SetProperty(ref _networkportui, value))
                {
                    OnPropertyChanged(nameof(IsEdit));
                }
            }
        }

        public string statisticsui
        {
            get { return _statisticsui; }
            set
            {
                if (SetProperty(ref _statisticsui, value))
                {
                    OnPropertyChanged(nameof(IsEdit));
                }
            }
        }

        public string modelui
        {
            get { return _modelui; }
            set
            {
                if (SetProperty(ref _modelui, value))
                {
                    OnPropertyChanged(nameof(IsEdit));
                }
            }
        }

        public int? aliveui
        {
            get { return _aliveui; }
            set
            {
                if (SetProperty(ref _aliveui, value))
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

        public int? temphighthightui
        {
            get { return _temphighthightui; }
            set
            {
                if (SetProperty(ref _temphighthightui, value))
                {
                    OnPropertyChanged(nameof(IsEdit));
                }
            }
        }

        public int? temphightui
        {
            get { return _temphightui; }
            set
            {
                if (SetProperty(ref _temphightui, value))
                {
                    OnPropertyChanged(nameof(IsEdit));
                }
            }
        }

        public int? templowui
        {
            get { return _templowui; }
            set
            {
                if (SetProperty(ref _templowui, value))
                {
                    OnPropertyChanged(nameof(IsEdit));
                }
            }
        }

        public int? templowlowui
        {
            get { return _templowlowui; }
            set
            {
                if (SetProperty(ref _templowlowui, value))
                {
                    OnPropertyChanged(nameof(IsEdit));
                }
            }
        }

        public int? humphighthightui
        {
            get { return _humphighthightui; }
            set
            {
                if (SetProperty(ref _humphighthightui, value))
                {
                    OnPropertyChanged(nameof(IsEdit));
                }
            }
        }

        public int? humphighui
        {
            get { return _humphighui; }
            set
            {
                if (SetProperty(ref _humphighui, value))
                {
                    OnPropertyChanged(nameof(IsEdit));
                }
            }
        }

        public int? humlowui
        {
            get { return _humlowui; }
            set
            {
                if (SetProperty(ref _humlowui, value))
                {
                    OnPropertyChanged(nameof(IsEdit));
                }
            }
        }

        public int? humlowlowui
        {
            get { return _humlowlowui; }
            set
            {
                if (SetProperty(ref _humlowlowui, value))
                {
                    OnPropertyChanged(nameof(IsEdit));
                }
            }
        }

        // 기본 생성자
        public TempHumSensorDBModel() : base() { }

        // 원본 데이터를 UI 데이터로 복사
        public override void CopyOriginToUI()
        {
            sensornoui = sensorno;
            multikhannoui = multikhanno;
            ipaddrui = ipaddr;
            networkportui = networkport;
            statisticsui = statistics;
            modelui = model;
            aliveui = alive;
            alarmoperationui = alarmoperation;
            temphighthightui = temphighthight;
            temphightui = temphight;
            templowui = templow;
            templowlowui = templowlow;
            humphighthightui = humphighthight;
            humphighui = humphigh;
            humlowui = humlow;
            humlowlowui = humlowlow;
        }

        // UI 데이터를 원본 데이터로 복사
        public override void CopyUIToOrigin()
        {
            sensorno = sensornoui;
            multikhanno = multikhannoui;
            ipaddr = ipaddrui;
            networkport = networkportui;
            statistics = statisticsui;
            model = modelui;
            alive = aliveui;
            alarmoperation = alarmoperationui;
            temphighthight = temphighthightui;
            temphight = temphightui;
            templow = templowui;
            templowlow = templowlowui;
            humphighthight = humphighthightui;
            humphigh = humphighui;
            humlow = humlowui;
            humlowlow = humlowlowui;
        }

        // 사용자가 데이터를 편집했는지 확인
        public override bool IsUserEdit()
        {
            return sensorno != sensornoui ||
                   multikhanno != multikhannoui ||
                   ipaddr != ipaddrui ||
                   networkport != networkportui ||
                   statistics != statisticsui ||
                   model != modelui ||
                   alive != aliveui ||
                   alarmoperation != alarmoperationui ||
                   temphighthight != temphighthightui ||
                   temphight != temphightui ||
                   templow != templowui ||
                   templowlow != templowlowui ||
                   humphighthight != humphighthightui ||
                   humphigh != humphighui ||
                   humlow != humlowui ||
                   humlowlow != humlowlowui;
        }
    }

    public class TempHumSensorDBList : BaseDBList<TempHumSensorDBModel>
    {
        public TempHumSensorDBList() : base() { }

        // Method to generate the SQL query for selecting all entries from the temphumsensor table
        public string SelectAllQuery()
        {
            return "SELECT * FROM temphumsensor";
        }

        // Method to parse the dataset and populate the collection
        public void SelectAllDSParsing()
        {
            this.Clear();

            foreach (DataRow dr in dataset.Tables[0].Rows)
            {
                TempHumSensorDBModel model = new TempHumSensorDBModel();
                Assign(dr, model);

                this.Add(model);
            }

            dataset.Clear();
        }

        // Method to map a DataRow to a TempHumSensorModel instance
        private void Assign(DataRow dr, TempHumSensorDBModel model)
        {
            model.sensorno = Convert.ToInt32(dr["sensorno"].ToString());
            model.multikhanno = dr["multikhanno"] == DBNull.Value ? (int?)null : Convert.ToInt32(dr["multikhanno"].ToString());
            model.ipaddr = dr["ipaddr"]?.ToString();
            model.networkport = dr["networkport"] == DBNull.Value ? (int?)null : Convert.ToInt32(dr["networkport"].ToString());
            model.statistics = dr["statistics"]?.ToString();
            model.model = dr["model"]?.ToString();
            model.alive = dr["alive"] == DBNull.Value ? (int?)null : Convert.ToInt32(dr["alive"].ToString());
            model.alarmoperation = dr["alarmoperation"] == DBNull.Value ? (int?)null : Convert.ToInt32(dr["alarmoperation"].ToString());
            model.temphighthight = dr["temphighthight"] == DBNull.Value ? (int?)null : Convert.ToInt32(dr["temphighthight"].ToString());
            model.temphight = dr["temphight"] == DBNull.Value ? (int?)null : Convert.ToInt32(dr["temphight"].ToString());
            model.templow = dr["templow"] == DBNull.Value ? (int?)null : Convert.ToInt32(dr["templow"].ToString());
            model.templowlow = dr["templowlow"] == DBNull.Value ? (int?)null : Convert.ToInt32(dr["templowlow"].ToString());
            model.humphighthight = dr["humphighthight"] == DBNull.Value ? (int?)null : Convert.ToInt32(dr["humphighthight"].ToString());
            model.humphigh = dr["humphigh"] == DBNull.Value ? (int?)null : Convert.ToInt32(dr["humphigh"].ToString());
            model.humlow = dr["humlow"] == DBNull.Value ? (int?)null : Convert.ToInt32(dr["humlow"].ToString());
            model.humlowlow = dr["humlowlow"] == DBNull.Value ? (int?)null : Convert.ToInt32(dr["humlowlow"].ToString());
        }

        // Method to get a model by its Sensorno property
        public TempHumSensorDBModel GetBySensorno(int sensorno)
        {
            return this.FirstOrDefault(a => a.sensorno == sensorno);
        }
    }
}
