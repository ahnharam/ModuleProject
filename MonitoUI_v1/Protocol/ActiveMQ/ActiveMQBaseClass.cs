using Apache.NMS.ActiveMQ;
using Apache.NMS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Protocol.ActiveMQ
{
    public class ActiveMQBaseClass
    {
        public string Destination { get; set; }
        public IConnectionFactory connectionFactory;
        public IConnection _connection;
        public ISession _session;

        public ActiveMQBaseClass() { }

        public void Setup(string uri, string dest, string name)
        {
            Destination = dest;
            connectionFactory = new ConnectionFactory(uri);

            if (_connection == null)
            {
                try
                {
                    _connection = connectionFactory.CreateConnection();
                    _connection.Start();
                    _session = _connection.CreateSession();
                }
                catch (Exception e)
                {
                    throw new Exception(name + " - ActiveMQ Connect Failed : " + e);
                }
            }
            else
            {
                throw new Exception("ActiveMQ Connect exist");
            }
        }
    }
}
