using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using POSSystem.Domain.Entities;

namespace POSSystem.API.Middleware
{
    public class AuthenticationMiddleware 
    {
            private readonly RequestDelegate _next;
            private readonly IConfiguration _configuration;

            public AuthenticationMiddleware(RequestDelegate next, IConfiguration configuration)
            {
                _next = next;
                _configuration = configuration;
            }

            public async Task Invoke(HttpContext context)
            {
                var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

                if (token != null)
                    await AttachUserToContext(context, token);

                await _next(context);
            }

            private async Task AttachUserToContext(HttpContext context, string token)
            {
                try
                {
                    var jwtSettings = _configuration.GetSection("Jwt").Get<JWTSettings>();
                    var key = Encoding.ASCII.GetBytes(jwtSettings.SecretKey);

                    var tokenHandler = new JwtSecurityTokenHandler();
                    var validationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidIssuer = jwtSettings.Issuer,
                        ValidAudience = jwtSettings.Audience,
                        ValidateLifetime = true
                    };

                    var principal = tokenHandler.ValidateToken(token, validationParameters, out SecurityToken validatedToken);

                    context.User = principal;
                }
                catch
                {
                    Console.WriteLine("Error!");
                }
            
        }
    }
}
