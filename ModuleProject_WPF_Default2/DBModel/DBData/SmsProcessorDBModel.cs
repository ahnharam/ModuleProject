using System;
using System.Data;
using System.Linq;

namespace SystemEditor.DBModel.DBData
{
    public class SmsProcessorDBModel : IsEditUpdater, IDBQuery
    {
        // 원본 데이터 필드
        private int _no;
        private string _requesturi;
        private string _contenttype;
        private string _method;
        private string _host;
        private string _smscode;
        private string _smstitle;
        private string _smsmessage;
        private int? _sendinfo;
        private string _recvinfo;
        private string _description;

        // UI 데이터 필드
        private int _noui;
        private string _requesturiui;
        private string _contenttypeui;
        private string _methodui;
        private string _hostui;
        private string _smscodeui;
        private string _smstitleui;
        private string _smsmessageui;
        private int? _sendinfoui;
        private string _recvinfoui;
        private string _descriptionui;

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

        public string requesturi
        {
            get { return _requesturi; }
            set
            {
                if (SetProperty(ref _requesturi, value))
                {
                    UserEditEvent?.Invoke();
                }
            }
        }

        public string contenttype
        {
            get { return _contenttype; }
            set
            {
                if (SetProperty(ref _contenttype, value))
                {
                    UserEditEvent?.Invoke();
                }
            }
        }

        public string method
        {
            get { return _method; }
            set
            {
                if (SetProperty(ref _method, value))
                {
                    UserEditEvent?.Invoke();
                }
            }
        }

        public string host
        {
            get { return _host; }
            set
            {
                if (SetProperty(ref _host, value))
                {
                    UserEditEvent?.Invoke();
                }
            }
        }

        public string smscode
        {
            get { return _smscode; }
            set
            {
                if (SetProperty(ref _smscode, value))
                {
                    UserEditEvent?.Invoke();
                }
            }
        }

        public string smstitle
        {
            get { return _smstitle; }
            set
            {
                if (SetProperty(ref _smstitle, value))
                {
                    UserEditEvent?.Invoke();
                }
            }
        }

        public string smsmessage
        {
            get { return _smsmessage; }
            set
            {
                if (SetProperty(ref _smsmessage, value))
                {
                    UserEditEvent?.Invoke();
                }
            }
        }

        public int? sendinfo
        {
            get { return _sendinfo; }
            set
            {
                if (SetProperty(ref _sendinfo, value))
                {
                    UserEditEvent?.Invoke();
                }
            }
        }

        public string recvinfo
        {
            get { return _recvinfo; }
            set
            {
                if (SetProperty(ref _recvinfo, value))
                {
                    UserEditEvent?.Invoke();
                }
            }
        }

        public string description
        {
            get { return _description; }
            set
            {
                if (SetProperty(ref _description, value))
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

        public string requesturiui
        {
            get { return _requesturiui; }
            set
            {
                if (SetProperty(ref _requesturiui, value))
                {
                    UserEditEvent?.Invoke();
                }
            }
        }

        public string contenttypeui
        {
            get { return _contenttypeui; }
            set
            {
                if (SetProperty(ref _contenttypeui, value))
                {
                    UserEditEvent?.Invoke();
                }
            }
        }

        public string methodui
        {
            get { return _methodui; }
            set
            {
                if (SetProperty(ref _methodui, value))
                {
                    UserEditEvent?.Invoke();
                }
            }
        }

        public string hostui
        {
            get { return _hostui; }
            set
            {
                if (SetProperty(ref _hostui, value))
                {
                    UserEditEvent?.Invoke();
                }
            }
        }

        public string smscodeui
        {
            get { return _smscodeui; }
            set
            {
                if (SetProperty(ref _smscodeui, value))
                {
                    UserEditEvent?.Invoke();
                }
            }
        }

        public string smstitleui
        {
            get { return _smstitleui; }
            set
            {
                if (SetProperty(ref _smstitleui, value))
                {
                    UserEditEvent?.Invoke();
                }
            }
        }

        public string smsmessageui
        {
            get { return _smsmessageui; }
            set
            {
                if (SetProperty(ref _smsmessageui, value))
                {
                    UserEditEvent?.Invoke();
                }
            }
        }

        public int? sendinfoui
        {
            get { return _sendinfoui; }
            set
            {
                if (SetProperty(ref _sendinfoui, value))
                {
                    UserEditEvent?.Invoke();
                }
            }
        }

        public string recvinfoui
        {
            get { return _recvinfoui; }
            set
            {
                if (SetProperty(ref _recvinfoui, value))
                {
                    UserEditEvent?.Invoke();
                }
            }
        }

        public string descriptionui
        {
            get { return _descriptionui; }
            set
            {
                if (SetProperty(ref _descriptionui, value))
                {
                    UserEditEvent?.Invoke();
                }
            }
        }

        // 기본 생성자
        public SmsProcessorDBModel() : base() { }

        // 원본 데이터를 UI 데이터로 복사
        public override void CopyOriginToUI()
        {
            noui = no;
            requesturiui = requesturi;
            contenttypeui = contenttype;
            methodui = method;
            hostui = host;
            smscodeui = smscode;
            smstitleui = smstitle;
            smsmessageui = smsmessage;
            sendinfoui = sendinfo;
            recvinfoui = recvinfo;
            descriptionui = description;
        }

        // UI 데이터를 원본 데이터로 복사
        public override void CopyUIToOrigin()
        {
            no = noui;
            requesturi = requesturiui;
            contenttype = contenttypeui;
            method = methodui;
            host = hostui;
            smscode = smscodeui;
            smstitle = smstitleui;
            smsmessage = smsmessageui;
            sendinfo = sendinfoui;
            recvinfo = recvinfoui;
            description = descriptionui;
        }

        // 사용자가 데이터를 편집했는지 확인
        public override bool IsUserEdit()
        {
            return no != noui ||
                   requesturi != requesturiui ||
                   contenttype != contenttypeui ||
                   method != methodui ||
                   host != hostui ||
                   smscode != smscodeui ||
                   smstitle != smstitleui ||
                   smsmessage != smsmessageui ||
                   sendinfo != sendinfoui ||
                   recvinfo != recvinfoui ||
                   description != descriptionui;
        }
        public void SetAutoIncrementIndex(long autoincrementindex) { }

        // Insert query
        public string InsertQuery()
        {
            return string.Format(
                "INSERT INTO smsprocessor (requesturi, contenttype, method, host, smscode, smstitle, smsmessage, sendinfo, recvinfo, description) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', {7}, '{8}', '{9}')",
                requesturi,
                contenttype,
                method,
                host,
                smscode,
                smstitle,
                smsmessage,
                sendinfo.HasValue ? sendinfo.Value.ToString() : "NULL",
                recvinfo,
                description
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
                    "UPDATE smsprocessor SET requesturi = '{0}', contenttype = '{1}', method = '{2}', host = '{3}', smscode = '{4}', smstitle = '{5}', smsmessage = '{6}', sendinfo = {7}, recvinfo = '{8}', description = '{9}' WHERE no = {10}",
                    requesturi,
                    contenttype,
                    method,
                    host,
                    smscode,
                    smstitle,
                    smsmessage,
                    sendinfo.HasValue ? sendinfo.Value.ToString() : "NULL",
                    recvinfo,
                    description,
                    no
                )
            };
        }

        // Delete query list
        public string[] DeleteQueryList()
        {
            return new string[]
            {
                string.Format("DELETE FROM smsprocessor WHERE no = {0}", no)
            };
        }
    }

    public class SmsProcessorDBList : BaseDBListByOC<SmsProcessorDBModel>
    {
        public SmsProcessorDBList() : base() { }

        // SQL query to select all records from the smsprocessor table
        public string SelectAllQuery()
        {
            return "SELECT * FROM smsprocessor";
        }

        // Parse dataset and populate the collection
        public void SelectAllDSParsing()
        {
            this.Clear();

            foreach (DataRow dr in dataset.Tables[0].Rows)
            {
                SmsProcessorDBModel model = new SmsProcessorDBModel();
                Assign(dr, model);

                this.Add(model);
            }

            dataset.Clear();
        }

        // Map DataRow to SmsProcessorDBModel instance
        private void Assign(DataRow dr, SmsProcessorDBModel model)
        {
            model.no = Convert.ToInt32(dr["no"].ToString());
            model.requesturi = dr["requesturi"]?.ToString();
            model.contenttype = dr["contenttype"]?.ToString();
            model.method = dr["method"]?.ToString();
            model.host = dr["host"]?.ToString();
            model.smscode = dr["smscode"]?.ToString();
            model.smstitle = dr["smstitle"]?.ToString();
            model.smsmessage = dr["smsmessage"]?.ToString();
            model.sendinfo = dr["sendinfo"] == DBNull.Value ? (int?)null : Convert.ToInt32(dr["sendinfo"].ToString());
            model.recvinfo = dr["recvinfo"]?.ToString();
            model.description = dr["description"]?.ToString();
        }

        // Method to get a model by its No property
        public SmsProcessorDBModel GetByNo(int no)
        {
            return this.FirstOrDefault(a => a.no == no);
        }
    }
}
