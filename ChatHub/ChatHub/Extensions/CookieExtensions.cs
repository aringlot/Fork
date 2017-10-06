using ChatHub.Middleware;
using Owin;

namespace ChatHub.Extensions
{
    /// <summary>
    /// Provides extensions for Owin.AppBuilder
    /// </summary>
    public static partial class AppBuilderExtensions
    {
        /// <summary>
        /// Use middleware to convert cookie to auth header
        /// </summary>
        public static IAppBuilder UseCookieToAuthHeader(this IAppBuilder app)
        {
            app.Use<CookieToAuthHeaderMiddleware>();
            return app;
        }
    }
}