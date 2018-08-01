using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Project.APIClient
{
    class Program
    {
        static void Main(string[] args)
        {
            var baseUri = "http://localhost/Project.WebAPI/api/";

            Console.WriteLine("请求状态 \t 信息 \t 调用线程ID \t 时间");

            var tasks = new Task[5];
            for (int i = 0; i < 5; i++)
            {

                tasks[i] = Task.Run(() =>
                {
                    var client = new HttpClient();
                    client.BaseAddress = new Uri(baseUri);
                    var response = client.GetAsync($"iisthread/get?param={Guid.NewGuid()}").Result;
                    Console.WriteLine($" {response.StatusCode} \t {response.Content.ReadAsStringAsync().Result} \t {Thread.CurrentThread.ManagedThreadId} \t {DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss fff")}");
                });
            }

            #region MyRegion
            //Task t1 = Task.Run(() =>
            //{
            //    var client = new HttpClient();
            //    client.BaseAddress = new Uri(baseUri);
            //    var response = client.GetAsync("iisthread/get").Result;
            //    Console.WriteLine($" {response.StatusCode} \t {response.Content.ReadAsStringAsync().Result} \t {DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss fff")}");
            //}).ContinueWith((t) => {
            //    Console.WriteLine($"aa:{t.Exception.InnerException.Message}");
            //}, TaskContinuationOptions.OnlyOnFaulted); 
            #endregion


            Console.WriteLine("A");
            Task.WaitAll(tasks);
            Console.WriteLine("B");
            //Thread.Sleep(1000);
        }
    }
}
