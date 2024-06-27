using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace SystemEditor.DBModel.DBData
{
    public class ContactExtensionDBModel : IsEditUpdater, IDBQuery
    {
        // 원본 데이터 필드
        private int _no;
        private string _comp;
        private string _model;
        private int? _stationno;
        private string _ipaddr;
        private int? _port;
        private int? _inputcount;
        private int? _outputcount;
        private int? _alive;

        // UI 데이터 필드
        private int _noui;
        private string _compui;
        private string _modelui;
        private int? _stationnoui;
        private string _ipaddrui;
        private int? _portui;
        private int? _inputcountui;
        private int? _outputcountui;
        private int? _aliveui;

        // 원본 데이터 프로퍼티
        public int no
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

        public string comp
        {
            get { return _comp; }
            set
            {
                if (SetProperty(ref _comp, value))
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

        public int? port
        {
            get { return _port; }
            set
            {
                if (SetProperty(ref _port, value))
                {
                    UserEditEvent?.Invoke();
                }
            }
        }

        public int? inputcount
        {
            get { return _inputcount; }
            set
            {
                if (SetProperty(ref _inputcount, value))
                {
                    UserEditEvent?.Invoke();
                }
            }
        }

        public int? outputcount
        {
            get { return _outputcount; }
            set
            {
                if (SetProperty(ref _outputcount, value))
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

        // UI 데이터 프로퍼티
        public int noui
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

        public string compui
        {
            get { return _compui; }
            set
            {
                if (SetProperty(ref _compui, value))
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

        public int? portui
        {
            get { return _portui; }
            set
            {
                if (SetProperty(ref _portui, value))
                {
                    UserEditEvent?.Invoke();
                }
            }
        }

        public int? inputcountui
        {
            get { return _inputcountui; }
            set
            {
                if (SetProperty(ref _inputcountui, value))
                {
                    UserEditEvent?.Invoke();
                }
            }
        }

        public int? outputcountui
        {
            get { return _outputcountui; }
            set
            {
                if (SetProperty(ref _outputcountui, value))
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

        // 기본 생성자
        public ContactExtensionDBModel() : base() { }

        // 원본 데이터를 UI 데이터로 복사
        public override void CopyOriginToUI()
        {
            noui = no;
            compui = comp;
            modelui = model;
            stationnoui = stationno;
            ipaddrui = ipaddr;
            portui = port;
            inputcountui = inputcount;
            outputcountui = outputcount;
            aliveui = alive;
        }

        // UI 데이터를 원본 데이터로 복사
        public override void CopyUIToOrigin()
        {
            no = noui;
            comp = compui;
            model = modelui;
            stationno = stationnoui;
            ipaddr = ipaddrui;
            port = portui;
            inputcount = inputcountui;
            outputcount = outputcountui;
            alive = aliveui;
        }
        public void ConvertOriginToUi() { }
        public void ConvertUiToOrigin() { }

        // 사용자가 데이터를 편집했는지 확인
        public override bool IsUserEdit()
        {
            return no != noui ||
                   comp != compui ||
                   model != modelui ||
                   stationno != stationnoui ||
                   ipaddr != ipaddrui ||
                   port != portui ||
                   inputcount != inputcountui ||
                   outputcount != outputcountui ||
                   alive != aliveui;
        }

        public void SetAutoIncrementIndex(long autoincrementindex) { }

        public string InsertQuery()
        {
            return string.Format(
                "INSERT INTO contactextension (no, comp, model, stationno, ipaddr, port, inputcount, outputcount, alive) VALUES ({0}, '{1}', '{2}', {3}, '{4}', {5}, {6}, {7}, {8})",
                no,
                comp,
                model,
                stationno.HasValue ? stationno.Value.ToString() : "NULL",
                ipaddr,
                port.HasValue ? port.Value.ToString() : "NULL",
                inputcount.HasValue ? inputcount.Value.ToString() : "NULL",
                outputcount.HasValue ? outputcount.Value.ToString() : "NULL",
                alive.HasValue ? alive.Value.ToString() : "NULL"
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
                    "UPDATE contactextension SET comp = '{0}', model = '{1}', stationno = {2}, ipaddr = '{3}', port = {4}, inputcount = {5}, outputcount = {6}, alive = {7} WHERE no = {8}",
                    comp,
                    model,
                    stationno.HasValue ? stationno.Value.ToString() : "NULL",
                    ipaddr,
                    port.HasValue ? port.Value.ToString() : "NULL",
                    inputcount.HasValue ? inputcount.Value.ToString() : "NULL",
                    outputcount.HasValue ? outputcount.Value.ToString() : "NULL",
                    alive.HasValue ? alive.Value.ToString() : "NULL",
                    no
                )
            };
        }

        public string[] DeleteQueryList()
        {
            return new string[]
            {
                string.Format("DELETE FROM contactextension WHERE no = {0}", no),
            };
        }

    }

    public class ContactExtensionDBList : BaseDBListByOC<ContactExtensionDBModel>
    {
        public ContactExtensionDBList() : base() { }

        // Method to generate the SQL query for selecting all entries from the contactextension table
        public string SelectAllQuery()
        {
            return "SELECT * FROM contactextension";
        }

        // Method to parse the dataset and populate the collection
        public void SelectAllDSParsing()
        {
            this.Clear();

            foreach (DataRow dr in dataset.Tables[0].Rows)
            {
                ContactExtensionDBModel model = new ContactExtensionDBModel();
                Assign(dr, model);

                this.Add(model);
            }

            dataset.Clear();
        }

        // Method to map a DataRow to a ContactExtensionModel instance
        private void Assign(DataRow dr, ContactExtensionDBModel model)
        {
            model.no = Convert.ToInt32(dr["no"].ToString());
            model.comp = dr["comp"]?.ToString();
            model.model = dr["model"]?.ToString();
            model.stationno = dr["stationno"] == DBNull.Value ? (int?)null : Convert.ToInt32(dr["stationno"].ToString());
            model.ipaddr = dr["ipaddr"]?.ToString();
            model.port = dr["port"] == DBNull.Value ? (int?)null : Convert.ToInt32(dr["port"].ToString());
            model.inputcount = dr["inputcount"] == DBNull.Value ? (int?)null : Convert.ToInt32(dr["inputcount"].ToString());
            model.outputcount = dr["outputcount"] == DBNull.Value ? (int?)null : Convert.ToInt32(dr["outputcount"].ToString());
            model.alive = dr["alive"] == DBNull.Value ? (int?)null : Convert.ToInt32(dr["alive"].ToString());
        }

        // Method to get a model by its No property
        public ContactExtensionDBModel GetByNo(int no)
        {
            return this.FirstOrDefault(a => a.no == no);
        }
    }
}
