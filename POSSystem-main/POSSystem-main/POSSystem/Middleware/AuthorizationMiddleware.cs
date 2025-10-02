using System.Net;
using Microsoft.IdentityModel.Logging;

namespace POSSystem.API.Middleware
{
    public class AuthorizationMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IConfiguration _configuration;

        public AuthorizationMiddleware(RequestDelegate next, IConfiguration configuration)
        {
            _next = next;
            _configuration = configuration;
        }

        public async Task Invoke(HttpContext context)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

            if (!IsSafeLogSecurityArtifact(token))
            {
                context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                return;
            }

            await _next(context);
        }

        private bool IsSafeLogSecurityArtifact(string token)
        {
            
            return true; 
        }
    }
}
