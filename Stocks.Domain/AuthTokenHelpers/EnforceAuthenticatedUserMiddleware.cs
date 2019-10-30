using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;

namespace Stocks.Domain.AuthTokenHelpers
{
    public class EnforceAuthenticatedUserMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            if (!context.User.Identity.IsAuthenticated)
            {
                await context.ChallengeAsync();
                return;
            }

            await next(context);
        }
    }
}
