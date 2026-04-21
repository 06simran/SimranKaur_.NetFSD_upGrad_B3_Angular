namespace ContactWebAPI.Middleware
{
    /// <summary>
    /// Request/Response logging middleware.
    /// Logs every incoming request and outgoing response — useful for debugging
    /// differences between Browser vs Postman behaviour.
    ///
    /// DEBUGGING TIP:
    ///   Check the console output after each Postman request.
    ///   You will see: method, path, status code, and elapsed time.
    ///   This helps identify: wrong HTTP method, wrong route, slow queries.
    /// </summary>
    public class RequestLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<RequestLoggingMiddleware> _logger;

        public RequestLoggingMiddleware(RequestDelegate next, ILogger<RequestLoggingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var stopwatch = System.Diagnostics.Stopwatch.StartNew();

            _logger.LogInformation(
                "➡ Request:  {Method} {Path}{QueryString}",
                context.Request.Method,
                context.Request.Path,
                context.Request.QueryString);

            await _next(context);

            stopwatch.Stop();

            _logger.LogInformation(
                "⬅ Response: {Method} {Path} → {StatusCode} ({Elapsed}ms)",
                context.Request.Method,
                context.Request.Path,
                context.Response.StatusCode,
                stopwatch.ElapsedMilliseconds);
        }
    }
}
