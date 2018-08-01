using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using PracticeProject.MQ;

namespace PracticeProject.MQ.Tests
{
    public class ProducerTest
    {
        [Fact]
        public void Producer_WithExpectedParameters()
        {
            RabbitMQProducer producer = new RabbitMQProducer();
            string message = "Hello,World!";
            bool success = producer.Send("example_queue01", message: message, durable: true, isPersistent: true);
            Assert.True(success);
        }
    }
}
