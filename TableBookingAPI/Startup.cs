using System;
using System.Web.Http;
using Microsoft.Owin;
using Owin;
using Microsoft.Owin.Cors;
using Microsoft.Owin.Security.OAuth;

[assembly: OwinStartup(typeof(TableBookingAPI.Startup))]

namespace TableBookingAPI
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=316888

            //Enable CORS 
            app.UseCors(CorsOptions.AllowAll);

            var myProvider = new MyOAuthAuthorizationServerProvider();
            OAuthAuthorizationServerOptions options = new OAuthAuthorizationServerOptions()
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromHours(1),
                Provider = myProvider
            };
            app.UseOAuthAuthorizationServer(options);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());

            HttpConfiguration config = new HttpConfiguration();
            WebApiConfig.Register(config);
        }
    }
}
