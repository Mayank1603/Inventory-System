using System.Net;
using System.Text.Json;

namespace POSSystem.API.Middleware
{
    public class ErrorHandlingMiddleware
    {
        public class ErrorHandlerMiddleWare
        {
            private readonly RequestDelegate _next;

            public ErrorHandlerMiddleWare(RequestDelegate next)
            {
                _next = next;
            }
            public async Task InvokeAsync(HttpContext context)
            {
                try
                {
                    await _next(context);
                }
                catch (Exception ex)
                {
                    switch(ex){
                        case Exception e when e is ArgumentNullException:
                            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                            break;
                        case Exception e when e is InvalidOperationException:
                            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                            break;
                    }
                }
            }
        }
    }
}
