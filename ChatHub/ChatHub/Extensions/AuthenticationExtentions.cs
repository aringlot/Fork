using IdentityServer3.AccessTokenValidation;
using Owin;

namespace ChatHub.Extensions
{
    /// <summary>
    /// Provides extensions for Owin.AppBuilder
    /// </summary>
    public static partial class AppBuilderExtensions
    {
        /// <summary>
        /// Use identity server middleware to provide authentication and authorization
        /// </summary>
        public static IAppBuilder UseIdentityServer(this IAppBuilder app)
        {
            app.UseIdentityServerBearerTokenAuthentication(new IdentityServerBearerTokenAuthenticationOptions
            {
                Authority = "http://localhost:5000",
                ValidationMode = ValidationMode.Both,
                ClientId = "api",
                ClientSecret = "secret",
                RequiredScopes = new[] { "api" }
            });

            return app;
        }
    }
}