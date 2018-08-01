using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using PracticeProject.MQ;
using queue = PracticeProject.Share.RabbitMQConstant.QueueName;

using PracticeProject.Share.RabbitMQConstant;

namespace PracticeProject.MQ.Tests
{
    [Trait("RabbitMQ","生产者")]
    public class ProducerTest
    {
        [Fact(DisplayName ="正常参数情况测试")]
        public void Producer_WithExpectedParameters()
        {
            RabbitMQProducer producer = new RabbitMQProducer();
            string message = "Hello,World!";
            bool success = producer.Send(queue.Example01, message: message, durable: true, isPersistent: true);
            Assert.True(success);
        }
    }
}
