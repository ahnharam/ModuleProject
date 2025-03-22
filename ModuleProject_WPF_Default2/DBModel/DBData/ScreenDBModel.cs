using System;
using System.Data;
using System.Linq;

namespace SystemEditor.DBModel.DBData
{
    public class ScreenDBModel : IsEditUpdater, IDBQuery
    {
        // 원본 데이터 필드
        private int _screenno;
        private string _screenname;
        private int? _screensort;
        private int? _arrayx;
        private int? _arrayy;
        private int? _mapno;

        // UI 데이터 필드
        private int _screennoui;
        private string _screennameui;
        private int? _screensortui;
        private int? _arrayxui;
        private int? _arrayyui;
        private int? _mapnoui;

        // 원본 데이터 프로퍼티
        public int screenno
        {
            get { return _screenno; }
            set
            {
                if (SetProperty(ref _screenno, value))
                {
                    UserEditEvent?.Invoke();
                }
            }
        }

        public string screenname
        {
            get { return _screenname; }
            set
            {
                if (SetProperty(ref _screenname, value))
                {
                    UserEditEvent?.Invoke();
                }
            }
        }

        public int? screensort
        {
            get { return _screensort; }
            set
            {
                if (SetProperty(ref _screensort, value))
                {
                    UserEditEvent?.Invoke();
                }
            }
        }

        public int? arrayx
        {
            get { return _arrayx; }
            set
            {
                if (SetProperty(ref _arrayx, value))
                {
                    UserEditEvent?.Invoke();
                }
            }
        }

        public int? arrayy
        {
            get { return _arrayy; }
            set
            {
                if (SetProperty(ref _arrayy, value))
                {
                    UserEditEvent?.Invoke();
                }
            }
        }

        public int? mapno
        {
            get { return _mapno; }
            set
            {
                if (SetProperty(ref _mapno, value))
                {
                    UserEditEvent?.Invoke();
                }
            }
        }

        // UI 데이터 프로퍼티
        public int screennoui
        {
            get { return _screennoui; }
            set
            {
                if (SetProperty(ref _screennoui, value))
                {
                    UserEditEvent?.Invoke();
                }
            }
        }

        public string screennameui
        {
            get { return _screennameui; }
            set
            {
                if (SetProperty(ref _screennameui, value))
                {
                    UserEditEvent?.Invoke();
                }
            }
        }

        public int? screensortui
        {
            get { return _screensortui; }
            set
            {
                if (SetProperty(ref _screensortui, value))
                {
                    UserEditEvent?.Invoke();
                }
            }
        }

        public int? arrayxui
        {
            get { return _arrayxui; }
            set
            {
                if (SetProperty(ref _arrayxui, value))
                {
                    UserEditEvent?.Invoke();
                }
            }
        }

        public int? arrayyui
        {
            get { return _arrayyui; }
            set
            {
                if (SetProperty(ref _arrayyui, value))
                {
                    UserEditEvent?.Invoke();
                }
            }
        }

        public int? mapnoui
        {
            get { return _mapnoui; }
            set
            {
                if (SetProperty(ref _mapnoui, value))
                {
                    UserEditEvent?.Invoke();
                }
            }
        }

        // 기본 생성자
        public ScreenDBModel() : base() { }

        // 원본 데이터를 UI 데이터로 복사
        public override void CopyOriginToUI()
        {
            screennoui = screenno;
            screennameui = screenname;
            screensortui = screensort;
            arrayxui = arrayx;
            arrayyui = arrayy;
            mapnoui = mapno;
        }

        // UI 데이터를 원본 데이터로 복사
        public override void CopyUIToOrigin()
        {
            screenno = screennoui;
            screenname = screennameui;
            screensort = screensortui;
            arrayx = arrayxui;
            arrayy = arrayyui;
            mapno = mapnoui;
        }

        public void ConvertOriginToUi() { }
        public void ConvertUiToOrigin() { }

        // 사용자가 데이터를 편집했는지 확인
        public override bool IsUserEdit()
        {
            return screenno != screennoui ||
                   screenname != screennameui ||
                   screensort != screensortui ||
                   arrayx != arrayxui ||
                   arrayy != arrayyui ||
                   mapno != mapnoui;
        }

        public void SetAutoIncrementIndex(long autoincrementindex) { }

        public string InsertQuery()
        {
            return string.Format(
                "INSERT INTO screen (screenno, screenname, screensort, arrayx, arrayy, mapno) VALUES ({0}, '{1}', {2}, {3}, {4}, {5})",
                _screenno,
                _screenname,
                _screensort.HasValue ? _screensort.Value.ToString() : "NULL",
                _arrayx.HasValue ? _arrayx.Value.ToString() : "NULL",
                _arrayy.HasValue ? _arrayy.Value.ToString() : "NULL",
                _mapno.HasValue ? _mapno.Value.ToString() : "NULL"
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
                    "UPDATE screen SET screenname = '{0}', screensort = {1}, arrayx = {2}, arrayy = {3}, mapno = {4} WHERE screenno = {5}",
                    _screenname,
                    _screensort.HasValue ? _screensort.Value.ToString() : "NULL",
                    _arrayx.HasValue ? _arrayx.Value.ToString() : "NULL",
                    _arrayy.HasValue ? _arrayy.Value.ToString() : "NULL",
                    _mapno.HasValue ? _mapno.Value.ToString() : "NULL",
                    _screenno
                )
            };
        }

        public string[] DeleteQueryList()
        {
            return new string[]
            {
                string.Format("DELETE FROM screen WHERE screenno = {0}", _screenno),
            };
        }
    }

    public class ScreenDBList : BaseDBListByOC<ScreenDBModel>
    {
        public ScreenDBList() : base() { }

        // Method to generate the SQL query for selecting all entries from the screen table
        public string SelectAllQuery()
        {
            return "SELECT * FROM screen";
        }

        // Method to parse the dataset and populate the collection
        public void SelectAllDSParsing()
        {
            this.Clear();

            foreach (DataRow dr in dataset.Tables[0].Rows)
            {
                ScreenDBModel model = new ScreenDBModel();
                Assign(dr, model);

                this.Add(model);
            }

            dataset.Clear();
        }

        // Method to map a DataRow to a ScreenModel instance
        private void Assign(DataRow dr, ScreenDBModel model)
        {
            model.screenno = Convert.ToInt32(dr["screenno"].ToString());
            model.screenname = dr["screenname"]?.ToString();
            model.screensort = dr["screensort"] == DBNull.Value ? (int?)null : Convert.ToInt32(dr["screensort"].ToString());
            model.arrayx = dr["arrayx"] == DBNull.Value ? (int?)null : Convert.ToInt32(dr["arrayx"].ToString());
            model.arrayy = dr["arrayy"] == DBNull.Value ? (int?)null : Convert.ToInt32(dr["arrayy"].ToString());
            model.mapno = dr["mapno"] == DBNull.Value ? (int?)null : Convert.ToInt32(dr["mapno"].ToString());
        }

        // Method to get a model by its Screenno property
        public ScreenDBModel GetByScreenno(int screenno)
        {
            return this.FirstOrDefault(a => a.screenno == screenno);
        }
    }
}
