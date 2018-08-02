using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using queue = PracticeProject.Share.RabbitMQConstant.QueueName;

namespace PracticeProject.MQ.Tests
{
    [Trait("RabbitMQ","消费者")]
    public class ConsumerTest
    {
        [Fact(DisplayName ="正常参数情况测试")]
        public void Comsumer_WithExpectedParameters()
        {
            RabbitMQConsumer consumer = new RabbitMQConsumer();
            consumer.Receive(queue.Example01, durable: true);
        }
    }
}
