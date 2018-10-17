using PracticeProject.Core.Cache;
using System;
using System.Configuration;

namespace ConsoleApp.Test
{
    class RedisOp
    {
        private static int DbIndex = 15;
        //private static string RedisHost = "127.0.0.1:6379";
        private static string CustomKey = string.Empty;

        static void Main(string[] args)
        {
            //string RedisConnectionString = ConfigurationManager.ConnectionStrings["RedisExchangeHosts"]?.ConnectionString;
            string SysCustomKey = ConfigurationManager.AppSettings["redisKey"] ?? "";

            var db = new RedisOperator(DbIndex);
            db.CustomKey = SysCustomKey;

            Console.WriteLine("start");
            for (int i = 0; i < 100; i++)
            {
                string key = $"A{i}";
                var result = db.StringSet(key, i, TimeSpan.FromSeconds(1 * (i + 1)));

                Console.WriteLine(key);
            }
            Console.WriteLine("end");
        }
    }
}
