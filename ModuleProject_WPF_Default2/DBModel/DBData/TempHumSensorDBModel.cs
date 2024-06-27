using System;
using System.Data;
using System.Linq;

namespace SystemEditor.DBModel.DBData
{
    public class TempHumSensorDBModel : IsEditUpdater, IDBQuery
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
                    UserEditEvent?.Invoke();
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

        public int? networkport
        {
            get { return _networkport; }
            set
            {
                if (SetProperty(ref _networkport, value))
                {
                    UserEditEvent?.Invoke();
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
                    UserEditEvent?.Invoke();
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
                    UserEditEvent?.Invoke();
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

        public int? temphighthight
        {
            get { return _temphighthight; }
            set
            {
                if (SetProperty(ref _temphighthight, value))
                {
                    UserEditEvent?.Invoke();
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
                    UserEditEvent?.Invoke();
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
                    UserEditEvent?.Invoke();
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
                    UserEditEvent?.Invoke();
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
                    UserEditEvent?.Invoke();
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
                    UserEditEvent?.Invoke();
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
                    UserEditEvent?.Invoke();
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
                    UserEditEvent?.Invoke();
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
                    UserEditEvent?.Invoke();
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

        public int? networkportui
        {
            get { return _networkportui; }
            set
            {
                if (SetProperty(ref _networkportui, value))
                {
                    UserEditEvent?.Invoke();
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
                    UserEditEvent?.Invoke();
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
                    UserEditEvent?.Invoke();
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

        public int? temphighthightui
        {
            get { return _temphighthightui; }
            set
            {
                if (SetProperty(ref _temphighthightui, value))
                {
                    UserEditEvent?.Invoke();
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
                    UserEditEvent?.Invoke();
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
                    UserEditEvent?.Invoke();
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
                    UserEditEvent?.Invoke();
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
                    UserEditEvent?.Invoke();
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
                    UserEditEvent?.Invoke();
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
                    UserEditEvent?.Invoke();
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
                    UserEditEvent?.Invoke();
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
        public void ConvertOriginToUi() { }
        public void ConvertUiToOrigin() { }

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

        public void SetAutoIncrementIndex(long autoincrementindex) { }

        public string InsertQuery()
        {
            return string.Format(
                "INSERT INTO temphumsensor (sensorno, multikhanno, ipaddr, networkport, statistics, model, alive, alarmoperation, temphighthight, temphight, templow, templowlow, humphighthight, humphigh, humlow, humlowlow) VALUES ({0}, {1}, '{2}', {3}, '{4}', '{5}', {6}, {7}, {8}, {9}, {10}, {11}, {12}, {13}, {14}, {15})",
                _sensorno,
                _multikhanno.HasValue ? _multikhanno.Value.ToString() : "NULL",
                _ipaddr,
                _networkport.HasValue ? _networkport.Value.ToString() : "NULL",
                _statistics,
                _model,
                _alive.HasValue ? _alive.Value.ToString() : "NULL",
                _alarmoperation.HasValue ? _alarmoperation.Value.ToString() : "NULL",
                _temphighthight.HasValue ? _temphighthight.Value.ToString() : "NULL",
                _temphight.HasValue ? _temphight.Value.ToString() : "NULL",
                _templow.HasValue ? _templow.Value.ToString() : "NULL",
                _templowlow.HasValue ? _templowlow.Value.ToString() : "NULL",
                _humphighthight.HasValue ? _humphighthight.Value.ToString() : "NULL",
                _humphigh.HasValue ? _humphigh.Value.ToString() : "NULL",
                _humlow.HasValue ? _humlow.Value.ToString() : "NULL",
                _humlowlow.HasValue ? _humlowlow.Value.ToString() : "NULL"
            );
        }

        public string[] InsertSubQuery()
        {
            // 서브 쿼리가 필요하지 않으므로 빈 배열을 반환합니다.
            return new string[] { };
        }

        public string[] UpdateQuery()
        {
            return new string[]
            {
                string.Format(
                    "UPDATE temphumsensor SET multikhanno = {0}, ipaddr = '{1}', networkport = {2}, statistics = '{3}', model = '{4}', alive = {5}, alarmoperation = {6}, temphighthight = {7}, temphight = {8}, templow = {9}, templowlow = {10}, humphighthight = {11}, humphigh = {12}, humlow = {13}, humlowlow = {14} WHERE sensorno = {15}",
                    _multikhanno.HasValue ? _multikhanno.Value.ToString() : "NULL",
                    _ipaddr,
                    _networkport.HasValue ? _networkport.Value.ToString() : "NULL",
                    _statistics,
                    _model,
                    _alive.HasValue ? _alive.Value.ToString() : "NULL",
                    _alarmoperation.HasValue ? _alarmoperation.Value.ToString() : "NULL",
                    _temphighthight.HasValue ? _temphighthight.Value.ToString() : "NULL",
                    _temphight.HasValue ? _temphight.Value.ToString() : "NULL",
                    _templow.HasValue ? _templow.Value.ToString() : "NULL",
                    _templowlow.HasValue ? _templowlow.Value.ToString() : "NULL",
                    _humphighthight.HasValue ? _humphighthight.Value.ToString() : "NULL",
                    _humphigh.HasValue ? _humphigh.Value.ToString() : "NULL",
                    _humlow.HasValue ? _humlow.Value.ToString() : "NULL",
                    _humlowlow.HasValue ? _humlowlow.Value.ToString() : "NULL",
                    _sensorno
                )
            };
        }

        public string[] DeleteQueryList()
        {
            return new string[]
            {
                string.Format("DELETE FROM temphumsensor WHERE sensorno = {0}", _sensorno),
            };
        }
    }

    public class TempHumSensorDBList : BaseDBListByOC<TempHumSensorDBModel>
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
