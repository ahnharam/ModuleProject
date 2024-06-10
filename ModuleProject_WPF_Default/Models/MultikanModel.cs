using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace ModuleProject_WPF_Default.Models
{
    public class MultikanDBModel : IsEditUpdater
    {
        // 원본 데이터 필드
        private int _serialno;
        private int? _groupno;
        private int? _sort;
        private int? _stationno;
        private string _devicedisplayname;
        private string _devicename;
        private int? _alive;
        private int? _camerano;
        private int? _camerapresetno;
        private string _rs232serial1;
        private string _rs232serial2;
        private string _rs485serial1;
        private string _rs485serial2;
        private string _fwuversion;
        private string _isdirectsocket;
        private string _isemergencycall;

        // UI 데이터 필드
        private int _serialnoui;
        private int? _groupnoui;
        private int? _sortui;
        private int? _stationnoui;
        private string _devicedisplaynameui;
        private string _devicenameui;
        private int? _aliveui;
        private int? _cameranoui;
        private int? _camerapresetnoui;
        private string _rs232serial1ui;
        private string _rs232serial2ui;
        private string _rs485serial1ui;
        private string _rs485serial2ui;
        private string _fwuversionui;
        private string _isdirectsocketui;
        private string _isemergencycallui;

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

        public int? groupno
        {
            get { return _groupno; }
            set
            {
                if (SetProperty(ref _groupno, value))
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

        public string devicedisplayname
        {
            get { return _devicedisplayname; }
            set
            {
                if (SetProperty(ref _devicedisplayname, value))
                {
                    OnPropertyChanged(nameof(IsEdit));
                }
            }
        }

        public string devicename
        {
            get { return _devicename; }
            set
            {
                if (SetProperty(ref _devicename, value))
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

        public int? cameranum
        {
            get { return _camerano; }
            set
            {
                if (SetProperty(ref _camerano, value))
                {
                    OnPropertyChanged(nameof(IsEdit));
                }
            }
        }

        public int? camerapresetno
        {
            get { return _camerapresetno; }
            set
            {
                if (SetProperty(ref _camerapresetno, value))
                {
                    OnPropertyChanged(nameof(IsEdit));
                }
            }
        }

        public string rs232serial1
        {
            get { return _rs232serial1; }
            set
            {
                if (SetProperty(ref _rs232serial1, value))
                {
                    OnPropertyChanged(nameof(IsEdit));
                }
            }
        }

        public string rs232serial2
        {
            get { return _rs232serial2; }
            set
            {
                if (SetProperty(ref _rs232serial2, value))
                {
                    OnPropertyChanged(nameof(IsEdit));
                }
            }
        }

        public string rs485serial1
        {
            get { return _rs485serial1; }
            set
            {
                if (SetProperty(ref _rs485serial1, value))
                {
                    OnPropertyChanged(nameof(IsEdit));
                }
            }
        }

        public string rs485serial2
        {
            get { return _rs485serial2; }
            set
            {
                if (SetProperty(ref _rs485serial2, value))
                {
                    OnPropertyChanged(nameof(IsEdit));
                }
            }
        }

        public string fwuversion
        {
            get { return _fwuversion; }
            set
            {
                if (SetProperty(ref _fwuversion, value))
                {
                    OnPropertyChanged(nameof(IsEdit));
                }
            }
        }

        public string isdirectsocket
        {
            get { return _isdirectsocket; }
            set
            {
                if (SetProperty(ref _isdirectsocket, value))
                {
                    OnPropertyChanged(nameof(IsEdit));
                }
            }
        }

        public string isemergencycall
        {
            get { return _isemergencycall; }
            set
            {
                if (SetProperty(ref _isemergencycall, value))
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

        public int? groupnoui
        {
            get { return _groupnoui; }
            set
            {
                if (SetProperty(ref _groupnoui, value))
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

        public string devicedisplaynameui
        {
            get { return _devicedisplaynameui; }
            set
            {
                if (SetProperty(ref _devicedisplaynameui, value))
                {
                    OnPropertyChanged(nameof(IsEdit));
                }
            }
        }

        public string devicenameui
        {
            get { return _devicenameui; }
            set
            {
                if (SetProperty(ref _devicenameui, value))
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

        public int? cameranoui
        {
            get { return _cameranoui; }
            set
            {
                if (SetProperty(ref _cameranoui, value))
                {
                    OnPropertyChanged(nameof(IsEdit));
                }
            }
        }

        public int? camerapresetnoui
        {
            get { return _camerapresetnoui; }
            set
            {
                if (SetProperty(ref _camerapresetnoui, value))
                {
                    OnPropertyChanged(nameof(IsEdit));
                }
            }
        }

        public string rs232serial1ui
        {
            get { return _rs232serial1ui; }
            set
            {
                if (SetProperty(ref _rs232serial1ui, value))
                {
                    OnPropertyChanged(nameof(IsEdit));
                }
            }
        }

        public string rs232serial2ui
        {
            get { return _rs232serial2ui; }
            set
            {
                if (SetProperty(ref _rs232serial2ui, value))
                {
                    OnPropertyChanged(nameof(IsEdit));
                }
            }
        }

        public string rs485serial1ui
        {
            get { return _rs485serial1ui; }
            set
            {
                if (SetProperty(ref _rs485serial1ui, value))
                {
                    OnPropertyChanged(nameof(IsEdit));
                }
            }
        }

        public string rs485serial2ui
        {
            get { return _rs485serial2ui; }
            set
            {
                if (SetProperty(ref _rs485serial2ui, value))
                {
                    OnPropertyChanged(nameof(IsEdit));
                }
            }
        }

        public string fwuversionui
        {
            get { return _fwuversionui; }
            set
            {
                if (SetProperty(ref _fwuversionui, value))
                {
                    OnPropertyChanged(nameof(IsEdit));
                }
            }
        }

        public string isdirectsocketui
        {
            get { return _isdirectsocketui; }
            set
            {
                if (SetProperty(ref _isdirectsocketui, value))
                {
                    OnPropertyChanged(nameof(IsEdit));
                }
            }
        }

        public string isemergencycallui
        {
            get { return _isemergencycallui; }
            set
            {
                if (SetProperty(ref _isemergencycallui, value))
                {
                    OnPropertyChanged(nameof(IsEdit));
                }
            }
        }

        // 기본 생성자
        public MultikanDBModel() : base() { }

        // 원본 데이터를 UI 데이터로 복사
        public override void CopyOriginToUI()
        {
            serialnoui = serialno;
            groupnoui = groupno;
            sortui = sort;
            stationnoui = stationno;
            devicedisplaynameui = devicedisplayname;
            devicenameui = devicename;
            aliveui = alive;
            cameranoui = cameranum;
            camerapresetnoui = camerapresetno;
            rs232serial1ui = rs232serial1;
            rs232serial2ui = rs232serial2;
            rs485serial1ui = rs485serial1;
            rs485serial2ui = rs485serial2;
            fwuversionui = fwuversion;
            isdirectsocketui = isdirectsocket;
            isemergencycallui = isemergencycall;
        }

        // UI 데이터를 원본 데이터로 복사
        public override void CopyUIToOrigin()
        {
            serialno = serialnoui;
            groupno = groupnoui;
            sort = sortui;
            stationno = stationnoui;
            devicedisplayname = devicedisplaynameui;
            devicename = devicenameui;
            alive = aliveui;
            cameranum = cameranoui;
            camerapresetno = camerapresetnoui;
            rs232serial1 = rs232serial1ui;
            rs232serial2 = rs232serial2ui;
            rs485serial1 = rs485serial1ui;
            rs485serial2 = rs485serial2ui;
            fwuversion = fwuversionui;
            isdirectsocket = isdirectsocketui;
            isemergencycall = isemergencycallui;
        }

        // 사용자가 데이터를 편집했는지 확인
        public override bool IsUserEdit()
        {
            return serialno != serialnoui ||
                   groupno != groupnoui ||
                   sort != sortui ||
                   stationno != stationnoui ||
                   devicedisplayname != devicedisplaynameui ||
                   devicename != devicenameui ||
                   alive != aliveui ||
                   cameranum != cameranoui ||
                   camerapresetno != camerapresetnoui ||
                   rs232serial1 != rs232serial1ui ||
                   rs232serial2 != rs232serial2ui ||
                   rs485serial1 != rs485serial1ui ||
                   rs485serial2 != rs485serial2ui ||
                   fwuversion != fwuversionui ||
                   isdirectsocket != isdirectsocketui ||
                   isemergencycall != isemergencycallui;
        }
    }

    public class MultikanDBList : BaseDBList<MultikanDBModel>
    {
        public MultikanDBList() : base() { }

        // Method to generate the SQL query for selecting all entries from the multikan table
        public string SelectAllQuery()
        {
            return "SELECT * FROM multikan";
        }

        // Method to parse the dataset and populate the collection
        public void SelectAllDSParsing()
        {
            this.Clear();

            foreach (DataRow dr in dataset.Tables[0].Rows)
            {
                MultikanDBModel model = new MultikanDBModel();
                Assign(dr, model);

                this.Add(model);
            }

            dataset.Clear();
        }

        // Method to map a DataRow to a MultikanModel instance
        private void Assign(DataRow dr, MultikanDBModel model)
        {
            model.serialno = Convert.ToInt32(dr["serialno"].ToString());
            model.groupno = dr["groupno"] == DBNull.Value ? (int?)null : Convert.ToInt32(dr["groupno"].ToString());
            model.sort = dr["sort"] == DBNull.Value ? (int?)null : Convert.ToInt32(dr["sort"].ToString());
            model.stationno = dr["stationno"] == DBNull.Value ? (int?)null : Convert.ToInt32(dr["stationno"].ToString());
            model.devicedisplayname = dr["devicedisplayname"]?.ToString();
            model.devicename = dr["devicename"]?.ToString();
            model.alive = dr["alive"] == DBNull.Value ? (int?)null : Convert.ToInt32(dr["alive"].ToString());
            model.cameranoui = dr["camerano"] == DBNull.Value ? (int?)null : Convert.ToInt32(dr["camerano"].ToString());
            model.camerapresetno = dr["camerapresetno"] == DBNull.Value ? (int?)null : Convert.ToInt32(dr["camerapresetno"].ToString());
            model.rs232serial1 = dr["rs232serial1"]?.ToString();
            model.rs232serial2 = dr["rs232serial2"]?.ToString();
            model.rs485serial1 = dr["rs485serial1"]?.ToString();
            model.rs485serial2 = dr["rs485serial2"]?.ToString();
            model.fwuversion = dr["fwuversion"]?.ToString();
            model.isdirectsocket = dr["isdirectsocket"]?.ToString();
            model.isemergencycall = dr["isemergencycall"]?.ToString();
        }

        // Method to get a model by its Serialno property
        public MultikanDBModel GetBySerialno(int serialno)
        {
            return this.FirstOrDefault(a => a.serialno == serialno);
        }
    }
}
