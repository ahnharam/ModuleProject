using Apache.NMS.ActiveMQ;
using Apache.NMS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using System.ComponentModel;
using System.Diagnostics;

namespace Protocol.ActiveMQ
{
    public class ActiveMQPublisher : ActiveMQBaseClass
    {
        IDestination destination;
        IMessageProducer producer;
        private static readonly Lazy<ActiveMQPublisher> lazy = new Lazy<ActiveMQPublisher>(() => new ActiveMQPublisher());

        public static ActiveMQPublisher Instance => lazy.Value;

        public ActiveMQPublisher() { }

        public string SendMessage(string message)
        {
            string result = string.Empty;
            try
            {
                destination = _session.GetTopic(Destination);
                Debug.WriteLine(destination.ToString());
                using (producer = _session.CreateProducer(destination))
                {
                    TimeSpan timeSpan = new TimeSpan(0, 0, 2);
                    producer.TimeToLive = timeSpan;
                    var textMessage = producer.CreateTextMessage(message);
                    producer.Send(textMessage);
                }
                result = "Message sent successfully.";
            }
            catch (Exception ex)
            {
                result = ex.Message;
                Debug.WriteLine(ex.ToString());
            }
            return result;
        }

        public void Close()
        {
            if (producer != null)
            {
                producer.Close();
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
