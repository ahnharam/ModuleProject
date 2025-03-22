using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace SystemEditor.DBModel.DBData
{
    public class MultikanDBModel : IsEditUpdater, IDBQuery
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
                    UserEditEvent?.Invoke();
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

        public string devicedisplayname
        {
            get { return _devicedisplayname; }
            set
            {
                if (SetProperty(ref _devicedisplayname, value))
                {
                    UserEditEvent?.Invoke();
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

        public int? cameranum
        {
            get { return _camerano; }
            set
            {
                if (SetProperty(ref _camerano, value))
                {
                    UserEditEvent?.Invoke();
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
                    UserEditEvent?.Invoke();
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
                    UserEditEvent?.Invoke();
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
                    UserEditEvent?.Invoke();
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
                    UserEditEvent?.Invoke();
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
                    UserEditEvent?.Invoke();
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
                    UserEditEvent?.Invoke();
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
                    UserEditEvent?.Invoke();
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

        public int? groupnoui
        {
            get { return _groupnoui; }
            set
            {
                if (SetProperty(ref _groupnoui, value))
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

        public string devicedisplaynameui
        {
            get { return _devicedisplaynameui; }
            set
            {
                if (SetProperty(ref _devicedisplaynameui, value))
                {
                    UserEditEvent?.Invoke();
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

        public int? cameranoui
        {
            get { return _cameranoui; }
            set
            {
                if (SetProperty(ref _cameranoui, value))
                {
                    UserEditEvent?.Invoke();
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
                    UserEditEvent?.Invoke();
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
                    UserEditEvent?.Invoke();
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
                    UserEditEvent?.Invoke();
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
                    UserEditEvent?.Invoke();
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
                    UserEditEvent?.Invoke();
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
                    UserEditEvent?.Invoke();
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
                    UserEditEvent?.Invoke();
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
                    UserEditEvent?.Invoke();
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

        public void ConvertOriginToUi() { }
        public void ConvertUiToOrigin() { }

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

        public void SetAutoIncrementIndex(long autoincrementindex) { }

        public string InsertQuery()
        {
            return string.Format(
                "INSERT INTO multikan (serialno, groupno, sort, stationno, devicedisplayname, devicename, alive, cameranum, camerapresetno, rs232serial1, rs232serial2, rs485serial1, rs485serial2, fwuversion, isdirectsocket, isemergencycall) VALUES ({0}, {1}, {2}, {3}, '{4}', '{5}', {6}, {7}, {8}, '{9}', '{10}', '{11}', '{12}', '{13}', '{14}', '{15}')",
                _serialno,
                _groupno.HasValue ? _groupno.Value.ToString() : "NULL",
                _sort.HasValue ? _sort.Value.ToString() : "NULL",
                _stationno.HasValue ? _stationno.Value.ToString() : "NULL",
                _devicedisplayname,
                _devicename,
                _alive.HasValue ? _alive.Value.ToString() : "NULL",
                _camerano.HasValue ? _camerano.Value.ToString() : "NULL",
                _camerapresetno.HasValue ? _camerapresetno.Value.ToString() : "NULL",
                _rs232serial1,
                _rs232serial2,
                _rs485serial1,
                _rs485serial2,
                _fwuversion,
                _isdirectsocket,
                _isemergencycall
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
                    "UPDATE multikan SET groupno = {0}, sort = {1}, stationno = {2}, devicedisplayname = '{3}', devicename = '{4}', alive = {5}, cameranum = {6}, camerapresetno = {7}, rs232serial1 = '{8}', rs232serial2 = '{9}', rs485serial1 = '{10}', rs485serial2 = '{11}', fwuversion = '{12}', isdirectsocket = '{13}', isemergencycall = '{14}' WHERE serialno = {15}",
                    _groupno.HasValue ? _groupno.Value.ToString() : "NULL",
                    _sort.HasValue ? _sort.Value.ToString() : "NULL",
                    _stationno.HasValue ? _stationno.Value.ToString() : "NULL",
                    _devicedisplayname,
                    _devicename,
                    _alive.HasValue ? _alive.Value.ToString() : "NULL",
                    _camerano.HasValue ? _camerano.Value.ToString() : "NULL",
                    _camerapresetno.HasValue ? _camerapresetno.Value.ToString() : "NULL",
                    _rs232serial1,
                    _rs232serial2,
                    _rs485serial1,
                    _rs485serial2,
                    _fwuversion,
                    _isdirectsocket,
                    _isemergencycall,
                    _serialno
                )
            };
        }

        public string[] DeleteQueryList()
        {
            return new string[]
            {
                string.Format("DELETE FROM multikan WHERE serialno = {0}", _serialno),
            };
        }
    }

    public class MultikanDBList : BaseDBListByOC<MultikanDBModel>
    {
        public MultikanDBList() : base() { }

        public MultikanDBList(List<MultikanDBModel> multikandblist) : base() 
        {
            foreach (var model in multikandblist)
            {
                this.Add(model);
            }
        }

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
                model.CopyOriginToUI();

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
