using Hangfire;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Project.WebMVC.Startup))]
namespace Project.WebMVC
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            GlobalConfiguration.Configuration.UseSqlServerStorage("Data Source = localhost;Initial Catalog = Example01;User Id = sa_test;Password = 123456;");

            app.UseHangfireDashboard();
            app.UseHangfireServer();
        }
    }
}