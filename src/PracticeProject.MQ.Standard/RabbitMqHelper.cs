using System;
using System.Threading.Tasks;
using MassTransit;
using MassTransit.RabbitMqTransport;

namespace PracticeProject.MQ.Standard
{
    public class RabbitMqHelper
    {
        #region 交换器
        public static readonly string actionLogExchange = "PracticeProject.ActionLogExchange";
        #endregion

        #region config field
        /// <summary>
        /// RabbitMQ地址
        /// </summary>
        private static readonly string mqUrl = "rabbitmq:172.18.34.189";

        /// <summary>
        /// RabbitMQ 账号
        /// </summary>
        private static readonly string mqUsername = "guest";

        /// <summary>
        /// RabbtiMQ 密码
        /// </summary>
        private static readonly string mqUPassword = "guest";
        #endregion

        private static IBusControl CreateBus(Action<IRabbitMqBusFactoryConfigurator, IRabbitMqHost> registrationAction = null)
        {
            return Bus.Factory.CreateUsingRabbitMq(cfg =>
            {
                var host = cfg.Host(new Uri(mqUrl), h =>
                {
                    h.Username(mqUsername);
                    h.Password(mqUPassword);
                });
                registrationAction?.Invoke(cfg, host);
            });
        }

        /// <summary>
        /// Producer
        /// </summary>
        /// <param name="exchange"></param>
        /// <param name="obj">be send object</param>
        /// <returns></returns>
        public static async Task Publish(string exchange, object obj)
        {
            var bus = CreateBus();
            Uri sendTo = new Uri($"{mqUrl}{exchange}");
            var endPoint = await bus.GetSendEndpoint(sendTo);
            await endPoint.Send(obj);
        }

        /// <summary>
        /// consumer
        /// </summary>
        /// <param name="exchange"></param>
        /// <param name="obj">be received object</param>
        public static void Receive(string exchange, object obj)
        {
            var bus = CreateBus((cfg, host) =>
            {
                cfg.ReceiveEndpoint(host, exchange, e =>
                {
                    e.Instance(obj);
                });
            });
            bus.Start();
            
        }
    }
}
