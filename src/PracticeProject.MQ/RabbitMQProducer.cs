using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabbitMQ.Client;

namespace PracticeProject.MQ
{
    public class RabbitMQProducer
    {
        private IConnection _connection = null;
        public RabbitMQProducer(string host = "127.0.0.1")
        {
            var factory = new ConnectionFactory() { HostName = host };
            _connection = factory.CreateConnection();
        }

        public bool Send(string queue, string message, bool durable = true, bool isPersistent = true)
        {
            using (var channel = _connection.CreateModel())
            {
                channel.QueueDeclare(queue: queue, durable: isPersistent, exclusive: false, autoDelete: false, arguments: null);
                channel.ConfirmSelect();
                var body = Encoding.UTF8.GetBytes(message);

                var properties = channel.CreateBasicProperties();
                properties.Persistent = true;
                channel.BasicPublish(exchange: "", routingKey: queue, basicProperties: properties, body: body);
                bool isSuccess = channel.WaitForConfirms(new TimeSpan(0, 0, 10));
                _connection.Close();
                return isSuccess;
            }
        }
    }
}
