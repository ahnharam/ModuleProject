using DevExpress.Xpf.Editors.Helpers;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace SystemEditor.DBModel.DBData
{
    public class MultikhanAutoBroadcastInfoDBModel : IsEditUpdater, IDBQuery
    {
        // 원본 데이터 필드
        private int _no;
        private int? _multikhanno;
        private int? _sourceno;
        private int? _multikhansourceno;
        private string _displayname;
        private int _volume;
        private string _isalarmbroadcast;

        // UI 데이터 필드
        private int _noui;
        private int? _multikhannoui;
        private int? _sourcenoui;
        private int? _multikhansourcenoui;
        private string _displaynameui;
        private int _volumeui;
        private string _isalarmbroadcastui;

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

        public int? sourceno
        {
            get { return _sourceno; }
            set
            {
                if (SetProperty(ref _sourceno, value))
                {
                    UserEditEvent?.Invoke();
                }
            }
        }

        public int? multikhansourceno
        {
            get { return _multikhansourceno; }
            set
            {
                if (SetProperty(ref _multikhansourceno, value))
                {
                    UserEditEvent?.Invoke();
                }
            }
        }

        public string displayname
        {
            get { return _displayname; }
            set
            {
                if (SetProperty(ref _displayname, value))
                {
                    UserEditEvent?.Invoke();
                }
            }
        }

        public int volume
        {
            get { return _volume; }
            set
            {
                if (SetProperty(ref _volume, value))
                {
                    UserEditEvent?.Invoke();
                }
            }
        }

        public string isalarmbroadcast
        {
            get { return _isalarmbroadcast; }
            set
            {
                if (SetProperty(ref _isalarmbroadcast, value))
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

        public int? sourcenoui
        {
            get { return _sourcenoui; }
            set
            {
                if (SetProperty(ref _sourcenoui, value))
                {
                    UserEditEvent?.Invoke();
                }
            }
        }

        public int? multikhansourcenoui
        {
            get { return _multikhansourcenoui; }
            set
            {
                if (SetProperty(ref _multikhansourcenoui, value))
                {
                    UserEditEvent?.Invoke();
                }
            }
        }

        public string displaynameui
        {
            get { return _displaynameui; }
            set
            {
                if (SetProperty(ref _displaynameui, value))
                {
                    UserEditEvent?.Invoke();
                }
            }
        }

        public int volumeui
        {
            get { return _volumeui; }
            set
            {
                if (SetProperty(ref _volumeui, value))
                {
                    UserEditEvent?.Invoke();
                }
            }
        }

        public string isalarmbroadcastui
        {
            get { return _isalarmbroadcastui; }
            set
            {
                if (SetProperty(ref _isalarmbroadcastui, value))
                {
                    UserEditEvent?.Invoke();
                }
            }
        }

        // 기본 생성자
        public MultikhanAutoBroadcastInfoDBModel() : base() { }

        // 원본 데이터를 UI 데이터로 복사
        public override void CopyOriginToUI()
        {
            noui = no;
            multikhannoui = multikhanno;
            sourcenoui = sourceno;
            multikhansourcenoui = multikhansourceno;
            displaynameui = displayname;
            volumeui = volume;
            isalarmbroadcastui = isalarmbroadcast;
        }

        // UI 데이터를 원본 데이터로 복사
        public override void CopyUIToOrigin()
        {
            no = noui;
            multikhanno = multikhannoui;
            sourceno = sourcenoui;
            multikhansourceno = multikhansourcenoui;
            displayname = displaynameui;
            volume = volumeui;
            isalarmbroadcast = isalarmbroadcastui;
        }
        public void ConvertOriginToUi() { }
        public void ConvertUiToOrigin() { }

        // 사용자가 데이터를 편집했는지 확인
        public override bool IsUserEdit()
        {
            return no != noui ||
                   multikhanno != multikhannoui ||
                   sourceno != sourcenoui ||
                   multikhansourceno != multikhansourcenoui ||
                   displayname != displaynameui ||
                   volume != volumeui ||
                   isalarmbroadcast != isalarmbroadcastui;
        }

        public void SetAutoIncrementIndex(long autoincrementindex) { }

        // InsertQuery 메서드
        public string InsertQuery()
        {
            return string.Format(
                "INSERT INTO multikhanautobroadcastinfo_new (no, multikhanno, sourceno, multikhansourceno, displayname, volume, isalarmbroadcast) VALUES ({0}, {1}, {2}, {3}, '{4}', {5}, '{6}')",
                _no,
                _multikhanno.HasValue ? _multikhanno.Value.ToString() : "NULL",
                _sourceno.HasValue ? _sourceno.Value.ToString() : "NULL",
                _multikhansourceno.HasValue ? _multikhansourceno.Value.ToString() : "NULL",
                _displayname,
                _volume,
                _isalarmbroadcast
            );
        }

        // InsertSubQuery 메서드
        public string[] InsertSubQuery()
        {
            return new string[] { };
        }

        // UpdateQuery 메서드
        public string[] UpdateQuery()
        {
            return new string[]
            {
                string.Format(
                    "UPDATE multikhanautobroadcastinfo_new SET multikhanno = {0}, sourceno = {1}, multikhansourceno = {2}, displayname = '{3}', volume = {4}, isalarmbroadcast = '{5}' WHERE no = {6}",
                    _multikhanno.HasValue ? _multikhanno.Value.ToString() : "NULL",
                    _sourceno.HasValue ? _sourceno.Value.ToString() : "NULL",
                    _multikhansourceno.HasValue ? _multikhansourceno.Value.ToString() : "NULL",
                    _displayname,
                    _volume,
                    _isalarmbroadcast,
                    _no
                )
            };
        }

        // DeleteQueryList 메서드
        public string[] DeleteQueryList()
        {
            return new string[]
            {
                string.Format("DELETE FROM multikhanautobroadcastinfo_new WHERE no = {0}", _no),
            };
        }
    }

    public class MultikhanAutoBroadcastInfoDBList : BaseDBListByOC<MultikhanAutoBroadcastInfoDBModel>
    {
        public MultikhanAutoBroadcastInfoDBList() : base() { }

        // Method to generate the SQL query for selecting all entries from the multikhanautobroadcastinfo_new table
        public string SelectAllQuery()
        {
            return "SELECT * FROM multikhanautobroadcastinfo_new";
        }

        // Method to parse the dataset and populate the collection
        public void SelectAllDSParsing()
        {
            this.Clear();

            foreach (DataRow dr in dataset.Tables[0].Rows)
            {
                MultikhanAutoBroadcastInfoDBModel model = new MultikhanAutoBroadcastInfoDBModel();
                Assign(dr, model);
                model.CopyOriginToUI();

                this.Add(model);
            }

            dataset.Clear();
        }

        // Method to map a DataRow to a MultikhanAutoBroadcastInfoNewModel instance
        private void Assign(DataRow dr, MultikhanAutoBroadcastInfoDBModel model)
        {
            model.no = Convert.ToInt32(dr["no"].ToString());
            model.multikhanno = dr["multikhanno"] == DBNull.Value ? (int?)null : Convert.ToInt32(dr["multikhanno"].ToString());
            model.sourceno = dr["sourceno"] == DBNull.Value ? (int?)null : Convert.ToInt32(dr["sourceno"].ToString());
            model.multikhansourceno = dr["multikhansourceno"] == DBNull.Value ? (int?)null : Convert.ToInt32(dr["multikhansourceno"].ToString());
            model.displayname = dr["displayname"]?.ToString();
            model.volume = Convert.ToInt32(dr["volume"].ToString());
            model.isalarmbroadcast = dr["isalarmbroadcast"]?.ToString();
        }

        // Method to get a model by its No property
        public MultikhanAutoBroadcastInfoDBModel GetByNo(int no)
        {
            return this.FirstOrDefault(a => a.no == no);
        }
    }
}
