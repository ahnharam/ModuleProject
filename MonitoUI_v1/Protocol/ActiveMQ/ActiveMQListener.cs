
using Apache.NMS;
using Apache.NMS.ActiveMQ;
using Apache.NMS.ActiveMQ.Commands;
using Apache.NMS.Util;
using MySqlX.XDevAPI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Protocol.ActiveMQ
{
    public class ActiveMQListener : ActiveMQBaseClass
    {
        BackgroundWorker bg = new BackgroundWorker();
        public delegate void ObMessageArrived(string message);
        public ObMessageArrived obMessageArrived = null;

        IDestination dest;
        IMessageConsumer consumer;
        public bool startFlag = false;
        private static readonly Lazy<ActiveMQListener> lazy = new Lazy<ActiveMQListener>(() => new ActiveMQListener());

        public static ActiveMQListener Instance => lazy.Value;

        public ActiveMQListener() { }

        public void Start()
        {
            startFlag = true;
            bg.DoWork += DoWork;
            bg.WorkerSupportsCancellation = true;
            bg.RunWorkerCompleted += WorkCompleted;
            bg.RunWorkerAsync(0);
        }

        public void DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                dest = _session.GetTopic(Destination);
                Debug.WriteLine(dest.ToString());
                using (consumer = _session.CreateConsumer(dest))
                {
                    Debug.WriteLine("Listener started.");
                    Debug.WriteLine("Listener created.rn");
                    IMessage message;
                    while (startFlag)
                    {
                        message = consumer.Receive(); // 메세지 리시브 돌고있는동안 메세지 받을수있음
                        if (message != null)
                        {
                            ITextMessage textMessage = message as ITextMessage;
                            Debug.WriteLine("receive : " + textMessage.Text);
                            if (!string.IsNullOrEmpty(textMessage.Text))
                            {
                                obMessageArrived?.Invoke(textMessage.Text); // _listener.obMessageArrived 실행
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine("Listener Error : " + ex);
            }
        }

        private void WorkCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Close();
        }

        public void Close()
        {
            if (consumer != null)
            {
                consumer.Close();
            }
            if (_session != null)
            {
                _session.Close();
            }
            if (_connection != null)
            {
                _connection.Stop();
            }
        }
    } 
}
