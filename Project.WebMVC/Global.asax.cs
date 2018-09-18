using Hangfire;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Project.WebMVC
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            MvcHandler.DisableMvcResponseHeader = true; //隐藏ASP.NET MVC版本

            //GlobalConfiguration.Configuration.UseSqlServerStorage("Data Source = localhost;Initial Catalog = Example01;User Id = sa_test;Password = 123456;");
        }
    }
}
