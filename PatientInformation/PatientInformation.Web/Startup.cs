using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using PatientInformation.Web.App_Start;
[assembly: OwinStartup(typeof(PatientInformation.Web.Startup))]
namespace PatientInformation.Web
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            DependencyConfig.RegisterDependencies(app);
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = "ApplicationCookie",
                LoginPath = new PathString("/Admin/Account/Login")
            });
        }
    }
}
