using System;
using System.Data;
using System.Linq;

namespace SystemEditor.DBModel.DBData
{
    public class SmsReceiverInfoDBModel : IsEditUpdater, IDBQuery
    {
        // 원본 데이터 필드
        private int _no;
        private string _receiver;
        private string _receivername;

        // UI 데이터 필드
        private int _noui;
        private string _receiverui;
        private string _receivernameui;

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

        public string receiver
        {
            get { return _receiver; }
            set
            {
                if (SetProperty(ref _receiver, value))
                {
                    UserEditEvent?.Invoke();
                }
            }
        }

        public string receivername
        {
            get { return _receivername; }
            set
            {
                if (SetProperty(ref _receivername, value))
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

        public string receiverui
        {
            get { return _receiverui; }
            set
            {
                if (SetProperty(ref _receiverui, value))
                {
                    UserEditEvent?.Invoke();
                }
            }
        }

        public string receivernameui
        {
            get { return _receivernameui; }
            set
            {
                if (SetProperty(ref _receivernameui, value))
                {
                    UserEditEvent?.Invoke();
                }
            }
        }

        // 기본 생성자
        public SmsReceiverInfoDBModel() : base() { }

        // 원본 데이터를 UI 데이터로 복사
        public override void CopyOriginToUI()
        {
            noui = no;
            receiverui = receiver;
            receivernameui = receivername;
        }

        // UI 데이터를 원본 데이터로 복사
        public override void CopyUIToOrigin()
        {
            no = noui;
            receiver = receiverui;
            receivername = receivernameui;
        }

        // 사용자가 데이터를 편집했는지 확인
        public override bool IsUserEdit()
        {
            return no != noui ||
                   receiver != receiverui ||
                   receivername != receivernameui;
        }

        // Insert query
        public string InsertQuery()
        {
            return string.Format(
                "INSERT INTO smsreceiverinfo (receiver, receivername) VALUES ('{0}', '{1}')",
                receiver,
                receivername
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
                    "UPDATE smsreceiverinfo SET receiver = '{0}', receivername = '{1}' WHERE no = {2}",
                    receiver,
                    receivername,
                    no
                )
            };
        }

        // Delete query list
        public string[] DeleteQueryList()
        {
            return new string[]
            {
                string.Format("DELETE FROM smsreceiverinfo WHERE no = {0}", no)
            };
        }
    }

    public class SmsReceiverInfoDBList : BaseDBListByOC<SmsReceiverInfoDBModel>
    {
        public SmsReceiverInfoDBList() : base() { }

        // SQL query to select all records from the smsreceiverinfo table
        public string SelectAllQuery()
        {
            return "SELECT * FROM smsreceiverinfo";
        }

        // Parse dataset and populate the collection
        public void SelectAllDSParsing()
        {
            this.Clear();

            foreach (DataRow dr in dataset.Tables[0].Rows)
            {
                SmsReceiverInfoDBModel model = new SmsReceiverInfoDBModel();
                Assign(dr, model);

                this.Add(model);
            }

            dataset.Clear();
        }

        // Map DataRow to SmsReceiverInfoDBModel instance
        private void Assign(DataRow dr, SmsReceiverInfoDBModel model)
        {
            model.no = Convert.ToInt32(dr["no"].ToString());
            model.receiver = dr["receiver"]?.ToString();
            model.receivername = dr["receivername"]?.ToString();
        }

        // Method to get a model by its No property
        public SmsReceiverInfoDBModel GetByNo(int no)
        {
            return this.FirstOrDefault(a => a.no == no);
        }
    }
}
