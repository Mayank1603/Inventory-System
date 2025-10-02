namespace POSSystem.API.Middleware
{
    public class LoggingMiddleware
    {
        private readonly ILogger<LoggingMiddleware> _logger;
        private readonly RequestDelegate _next;
        public LoggingMiddleware(ILogger<LoggingMiddleware> logger, RequestDelegate next)
        {
            this._logger = logger;
            this._next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            _logger.LogInformation("Incoming request: {method} {url} {timeStamp}", context.Request.Method, context.Request.Path, DateTime.Now);
            await _next(context);
            _logger.LogInformation("Response status code: {statusCode}", context.Response.StatusCode);
        }
    }
}
