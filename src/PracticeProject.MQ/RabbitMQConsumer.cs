using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace PracticeProject.MQ
{
    public class RabbitMQConsumer
    {
        private IConnection _connection = null;
        public RabbitMQConsumer(string host = "127.0.0.1")
        {
            var factory = new ConnectionFactory() { HostName = host };
            _connection = factory.CreateConnection();
        }

        public void Receive(string queue, bool durable = true)
        {
            using (var channel = _connection.CreateModel())
            {
                channel.QueueDeclare(queue: queue, durable: durable, exclusive: false, autoDelete: false, arguments: null);

                channel.BasicQos(prefetchSize: 0, prefetchCount: 1, global: false);

                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += (model, ea) =>
                {
                    var body = ea.Body;
                    var message = Encoding.UTF8.GetString(body);
                    Console.WriteLine($" [x] Received {message}");
                    channel.BasicAck(deliveryTag: ea.DeliveryTag, multiple: false);
                };
                channel.BasicConsume(queue: queue, autoAck: false, consumer: consumer);
                _connection.Close();
            }
        }
    }
}
