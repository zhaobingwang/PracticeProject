using System;
using System.Configuration;

namespace ConsoleApp.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            string RedisConnectionString = ConfigurationManager.ConnectionStrings["RedisExchangeHosts"]?.ConnectionString;
            string RedisConnectionStrin111g = System.Configuration.ConfigurationManager.ConnectionStrings["RedisExchangeHosts"]?.ConnectionString;
            string SysCustomKey = ConfigurationManager.AppSettings["redisKey"] ?? "";
            // arrange
            Console.WriteLine("Hello World!");
        }
    }
}
