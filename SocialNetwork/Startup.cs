using Microsoft.Owin;
using Owin;
using Microsoft.Owin.Security.OAuth;
using System;
using SocialNetwork.Providers;

[assembly: OwinStartup(typeof(SocialNetwork.Startup))]
namespace SocialNetwork
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            OAuthAuthorizationServerOptions options = new OAuthAuthorizationServerOptions
            {
                AllowInsecureHttp = false, 
                TokenEndpointPath = new PathString("/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromMinutes(30),
                Provider = new ApplicationOAuthProvider()
            };

            app.UseOAuthAuthorizationServer(options);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
        }
    }
}
