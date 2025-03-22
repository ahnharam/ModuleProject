using System;
using System.Data;
using System.Linq;

namespace SystemEditor.DBModel.DBData
{
    public class ScreenCameraDBModel : IsEditUpdater, IDBQuery
    {
        // 원본 데이터 필드
        private int _screenno;
        private int? _camerano;
        private int? _orderid;
        private int? _left;
        private int? _top;
        private int? _right;
        private int? _bottom;

        // UI 데이터 필드
        private int _screennoui;
        private int? _cameranoui;
        private int? _orderidui;
        private int? _leftui;
        private int? _topui;
        private int? _rightui;
        private int? _bottomui;

        // 원본 데이터 프로퍼티
        public int screenno
        {
            get { return _screenno; }
            set { if (SetProperty(ref _screenno, value)) UserEditEvent?.Invoke(); }
        }

        public int? camerano
        {
            get { return _camerano; }
            set { if (SetProperty(ref _camerano, value)) UserEditEvent?.Invoke(); }
        }

        public int? orderid
        {
            get { return _orderid; }
            set { if (SetProperty(ref _orderid, value)) UserEditEvent?.Invoke(); }
        }

        public int? left
        {
            get { return _left; }
            set { if (SetProperty(ref _left, value)) UserEditEvent?.Invoke(); }
        }

        public int? top
        {
            get { return _top; }
            set { if (SetProperty(ref _top, value)) UserEditEvent?.Invoke(); }
        }

        public int? right
        {
            get { return _right; }
            set { if (SetProperty(ref _right, value)) UserEditEvent?.Invoke(); }
        }

        public int? bottom
        {
            get { return _bottom; }
            set { if (SetProperty(ref _bottom, value)) UserEditEvent?.Invoke(); }
        }

        // UI 데이터 프로퍼티
        public int screennoui
        {
            get { return _screennoui; }
            set { if (SetProperty(ref _screennoui, value)) UserEditEvent?.Invoke(); }
        }

        public int? cameranoui
        {
            get { return _cameranoui; }
            set { if (SetProperty(ref _cameranoui, value)) UserEditEvent?.Invoke(); }
        }

        public int? orderidui
        {
            get { return _orderidui; }
            set { if (SetProperty(ref _orderidui, value)) UserEditEvent?.Invoke(); }
        }

        public int? leftui
        {
            get { return _leftui; }
            set { if (SetProperty(ref _leftui, value)) UserEditEvent?.Invoke(); }
        }

        public int? topui
        {
            get { return _topui; }
            set { if (SetProperty(ref _topui, value)) UserEditEvent?.Invoke(); }
        }

        public int? rightui
        {
            get { return _rightui; }
            set { if (SetProperty(ref _rightui, value)) UserEditEvent?.Invoke(); }
        }

        public int? bottomui
        {
            get { return _bottomui; }
            set { if (SetProperty(ref _bottomui, value)) UserEditEvent?.Invoke(); }
        }

        // 기본 생성자
        public ScreenCameraDBModel() : base() { }

        // 원본 데이터를 UI 데이터로 복사
        public override void CopyOriginToUI()
        {
            screennoui = screenno;
            cameranoui = camerano;
            orderidui = orderid;
            leftui = left;
            topui = top;
            rightui = right;
            bottomui = bottom;
        }

        // UI 데이터를 원본 데이터로 복사
        public override void CopyUIToOrigin()
        {
            screenno = screennoui;
            camerano = cameranoui;
            orderid = orderidui;
            left = leftui;
            top = topui;
            right = rightui;
            bottom = bottomui;
        }
        public void ConvertOriginToUi() { }
        public void ConvertUiToOrigin() { }

        // 사용자가 데이터를 편집했는지 확인
        public override bool IsUserEdit()
        {
            return screenno != screennoui ||
                   camerano != cameranoui ||
                   orderid != orderidui ||
                   left != leftui ||
                   top != topui ||
                   right != rightui ||
                   bottom != bottomui;
        }

        public void SetAutoIncrementIndex(long autoincrementindex) { }

        // Insert query
        public string InsertQuery()
        {
            return string.Format(
                "INSERT INTO screencamera (screenno, camerano, orderid, `left`, `top`, `right`, `bottom`) VALUES ({0}, {1}, {2}, {3}, {4}, {5}, {6})",
                _screenno,
                _camerano.HasValue ? _camerano.Value.ToString() : "NULL",
                _orderid.HasValue ? _orderid.Value.ToString() : "NULL",
                _left.HasValue ? _left.Value.ToString() : "NULL",
                _top.HasValue ? _top.Value.ToString() : "NULL",
                _right.HasValue ? _right.Value.ToString() : "NULL",
                _bottom.HasValue ? _bottom.Value.ToString() : "NULL"
            );
        }

        // Insert sub query
        public string[] InsertSubQuery()
        {
            return new string[] { };
        }

        // Update query
        public string[] UpdateQuery()
        {
            return new string[]
            {
                string.Format(
                    "UPDATE screencamera SET camerano = {0}, orderid = {1}, `left` = {2}, `top` = {3}, `right` = {4}, `bottom` = {5} WHERE screenno = {6}",
                    _camerano.HasValue ? _camerano.Value.ToString() : "NULL",
                    _orderid.HasValue ? _orderid.Value.ToString() : "NULL",
                    _left.HasValue ? _left.Value.ToString() : "NULL",
                    _top.HasValue ? _top.Value.ToString() : "NULL",
                    _right.HasValue ? _right.Value.ToString() : "NULL",
                    _bottom.HasValue ? _bottom.Value.ToString() : "NULL",
                    _screenno
                )
            };
        }

        // Delete query list
        public string[] DeleteQueryList()
        {
            return new string[]
            {
                string.Format("DELETE FROM screencamera WHERE screenno = {0}", _screenno)
            };
        }
    }

    public class ScreenCameraDBList : BaseDBListByOC<ScreenCameraDBModel>
    {
        public ScreenCameraDBList() : base() { }

        // Method to generate the SQL query for selecting all entries from the screencamera table
        public string SelectAllQuery()
        {
            return "SELECT * FROM screencamera";
        }

        // Method to parse the dataset and populate the collection
        public void SelectAllDSParsing()
        {
            this.Clear();

            foreach (DataRow dr in dataset.Tables[0].Rows)
            {
                ScreenCameraDBModel model = new ScreenCameraDBModel();
                Assign(dr, model);

                this.Add(model);
            }

            dataset.Clear();
        }

        // Method to map a DataRow to a ScreenCameraModel instance
        private void Assign(DataRow dr, ScreenCameraDBModel model)
        {
            model.screenno = Convert.ToInt32(dr["screenno"].ToString());
            model.camerano = dr["camerano"] == DBNull.Value ? (int?)null : Convert.ToInt32(dr["camerano"].ToString());
            model.orderid = dr["orderid"] == DBNull.Value ? (int?)null : Convert.ToInt32(dr["orderid"].ToString());
            model.left = dr["left"] == DBNull.Value ? (int?)null : Convert.ToInt32(dr["left"].ToString());
            model.top = dr["top"] == DBNull.Value ? (int?)null : Convert.ToInt32(dr["top"].ToString());
            model.right = dr["right"] == DBNull.Value ? (int?)null : Convert.ToInt32(dr["right"].ToString());
            model.bottom = dr["bottom"] == DBNull.Value ? (int?)null : Convert.ToInt32(dr["bottom"].ToString());
        }

        // Method to get a model by its Screenno property
        public ScreenCameraDBModel GetByScreenno(int screenno)
        {
            return this.FirstOrDefault(a => a.screenno == screenno);
        }
    }
}
