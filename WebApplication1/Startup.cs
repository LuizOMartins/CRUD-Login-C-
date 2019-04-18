using System;
using System.Threading.Tasks;
using System.Web.Helpers;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;

[assembly: OwinStartup(typeof(WebApplication1.Startup))]

namespace WebApplication1
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCookieAuthentication(new CookieAuthenticationOptions {
                AuthenticationType = "ApplicationCookie",
                LoginPath = new PathString("/Autenticacao/Login")
            });

            AntiForgeryConfig.UniqueClaimTypeIdentifier = "Login";
        }
    }
}