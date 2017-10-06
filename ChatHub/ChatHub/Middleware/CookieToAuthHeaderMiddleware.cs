using System.Linq;
using System.Threading.Tasks;
using Microsoft.Owin;

namespace ChatHub.Middleware
{
    /// <summary>
    /// Preprocess request cookies to create auth header
    /// </summary>
    public class CookieToAuthHeaderMiddleware : OwinMiddleware
    {
        private const string CookieName = ".MinSideApp";
        private const string AuthorizationHeader = "Authorization";

        public CookieToAuthHeaderMiddleware(OwinMiddleware next) : base(next)
        {
        }

        public override Task Invoke(IOwinContext context)
        {
            var cookieValue = context.Request.Cookies.FirstOrDefault(x => x.Key == CookieName).Value;

            if (!string.IsNullOrEmpty(cookieValue))
            {
                context.Request.Headers.Remove(AuthorizationHeader);
                context.Request.Headers.Add(AuthorizationHeader, new[] { $"Bearer {cookieValue}" });
            }

            return Next.Invoke(context);
        }
    }
}