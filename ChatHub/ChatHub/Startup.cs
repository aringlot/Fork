using System.IdentityModel.Tokens;
using Microsoft.AspNet.SignalR;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Owin;

using ChatHub.Extensions;

[assembly: OwinStartup(typeof(ChatHub.Startup))]

namespace ChatHub
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            JwtSecurityTokenHandler.InboundClaimTypeMap.Clear();

            app.Map("/signalr", map =>
            {
                map.UseCookieToAuthHeader();
                map.UseIdentityServer();

                map.UseCors(CorsOptions.AllowAll);

                var hubConfiguration = new HubConfiguration
                {
                    EnableDetailedErrors = true,
                    EnableJavaScriptProxies = true
                };

                map.RunSignalR(hubConfiguration);
            });
        }
    }
}
