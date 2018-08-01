using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using NLog;

namespace Project.WebAPI.Controllers
{
    public class IISThreadController : ApiController
    {
        private static Logger logger;

        public IISThreadController()
        {
            logger = LogManager.GetCurrentClassLogger();
        }

        [HttpGet]
        public IHttpActionResult Get(string param)
        {
            //DoSomething();
            Task.Run(() =>
            {
                DoSomething(param);
            });
            return Ok($"Get message:{param}");
        }

        public void DoSomething(string param)
        {
            try
            {
                for (int i = 0; i < 10; i++)
                {
                    logger.Info($" #{nameof(DoSomething)} [{param}]");
                    Thread.Sleep(3000);
                }
            }
            catch (Exception ex)
            {
                logger.Warn($" #{nameof(DoSomething)} [{param}] \n \t {ex}");
            }
        }
    }
}
