using System;
using System.Data;
using System.Linq;

namespace SystemEditor.DBModel.DBData
{
    public class SmsSenderInfoDBModel : IsEditUpdater, IDBQuery
    {
        // 원본 데이터 필드
        private int _no;
        private string _id;
        private string _pwd;
        private string _sender;
        private string _sendername;
        private int? _msgtype;

        // UI 데이터 필드
        private int _noui;
        private string _idui;
        private string _pwdui;
        private string _senderui;
        private string _sendernameui;
        private int? _msgtypeui;

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

        public string id
        {
            get { return _id; }
            set
            {
                if (SetProperty(ref _id, value))
                {
                    UserEditEvent?.Invoke();
                }
            }
        }

        public string pwd
        {
            get { return _pwd; }
            set
            {
                if (SetProperty(ref _pwd, value))
                {
                    UserEditEvent?.Invoke();
                }
            }
        }

        public string sender
        {
            get { return _sender; }
            set
            {
                if (SetProperty(ref _sender, value))
                {
                    UserEditEvent?.Invoke();
                }
            }
        }

        public string sendername
        {
            get { return _sendername; }
            set
            {
                if (SetProperty(ref _sendername, value))
                {
                    UserEditEvent?.Invoke();
                }
            }
        }

        public int? msgtype
        {
            get { return _msgtype; }
            set
            {
                if (SetProperty(ref _msgtype, value))
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

        public string idui
        {
            get { return _idui; }
            set
            {
                if (SetProperty(ref _idui, value))
                {
                    UserEditEvent?.Invoke();
                }
            }
        }

        public string pwdui
        {
            get { return _pwdui; }
            set
            {
                if (SetProperty(ref _pwdui, value))
                {
                    UserEditEvent?.Invoke();
                }
            }
        }

        public string senderui
        {
            get { return _senderui; }
            set
            {
                if (SetProperty(ref _senderui, value))
                {
                    UserEditEvent?.Invoke();
                }
            }
        }

        public string sendernameui
        {
            get { return _sendernameui; }
            set
            {
                if (SetProperty(ref _sendernameui, value))
                {
                    UserEditEvent?.Invoke();
                }
            }
        }

        public int? msgtypeui
        {
            get { return _msgtypeui; }
            set
            {
                if (SetProperty(ref _msgtypeui, value))
                {
                    UserEditEvent?.Invoke();
                }
            }
        }

        // 기본 생성자
        public SmsSenderInfoDBModel() : base() { }

        // 원본 데이터를 UI 데이터로 복사
        public override void CopyOriginToUI()
        {
            noui = no;
            idui = id;
            pwdui = pwd;
            senderui = sender;
            sendernameui = sendername;
            msgtypeui = msgtype;
        }

        // UI 데이터를 원본 데이터로 복사
        public override void CopyUIToOrigin()
        {
            no = noui;
            id = idui;
            pwd = pwdui;
            sender = senderui;
            sendername = sendernameui;
            msgtype = msgtypeui;
        }

        // 사용자가 데이터를 편집했는지 확인
        public override bool IsUserEdit()
        {
            return no != noui ||
                   id != idui ||
                   pwd != pwdui ||
                   sender != senderui ||
                   sendername != sendernameui ||
                   msgtype != msgtypeui;
        }

        // Insert query
        public string InsertQuery()
        {
            return string.Format(
                "INSERT INTO smssenderinfo (id, pwd, sender, sendername, msgtype) VALUES ('{0}', '{1}', '{2}', '{3}', {4})",
                id,
                pwd,
                sender,
                sendername,
                msgtype.HasValue ? msgtype.Value.ToString() : "NULL"
            );
        }

        public void SetAutoIncrementIndex(long autoincrementindex) { }

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
                    "UPDATE smssenderinfo SET id = '{0}', pwd = '{1}', sender = '{2}', sendername = '{3}', msgtype = {4} WHERE no = {5}",
                    id,
                    pwd,
                    sender,
                    sendername,
                    msgtype.HasValue ? msgtype.Value.ToString() : "NULL",
                    no
                )
            };
        }

        // Delete query list
        public string[] DeleteQueryList()
        {
            return new string[]
            {
                string.Format("DELETE FROM smssenderinfo WHERE no = {0}", no)
            };
        }
    }

    public class SmsSenderInfoDBList : BaseDBListByOC<SmsSenderInfoDBModel>
    {
        public SmsSenderInfoDBList() : base() { }

        // SQL query to select all records from the smssenderinfo table
        public string SelectAllQuery()
        {
            return "SELECT * FROM smssenderinfo";
        }

        // Parse dataset and populate the collection
        public void SelectAllDSParsing()
        {
            this.Clear();

            foreach (DataRow dr in dataset.Tables[0].Rows)
            {
                SmsSenderInfoDBModel model = new SmsSenderInfoDBModel();
                Assign(dr, model);

                this.Add(model);
            }

            dataset.Clear();
        }

        // Map DataRow to SmsSenderInfoDBModel instance
        private void Assign(DataRow dr, SmsSenderInfoDBModel model)
        {
            model.no = Convert.ToInt32(dr["no"].ToString());
            model.id = dr["id"]?.ToString();
            model.pwd = dr["pwd"]?.ToString();
            model.sender = dr["sender"]?.ToString();
            model.sendername = dr["sendername"]?.ToString();
            model.msgtype = dr["msgtype"] == DBNull.Value ? (int?)null : Convert.ToInt32(dr["msgtype"].ToString());
        }

        // Method to get a model by its No property
        public SmsSenderInfoDBModel GetByNo(int no)
        {
            return this.FirstOrDefault(a => a.no == no);
        }
    }
}
