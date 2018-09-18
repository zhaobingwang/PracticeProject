using Hangfire;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;

namespace Project.WebMVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            RecurringJob.AddOrUpdate(
                () => DoSomething(),
                Cron.Minutely);
            return View();
        }

        public void DoSomething()
        {
            if (!System.IO.File.Exists($"{AppDomain.CurrentDomain.BaseDirectory}/logs.log"))
            {
                System.IO.File.Create($"{AppDomain.CurrentDomain.BaseDirectory}/logs.log");
            }
            System.IO.File.AppendAllText($"{AppDomain.CurrentDomain.BaseDirectory}/logs.log", $"# {DateTime.Now.ToString()}\n");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}