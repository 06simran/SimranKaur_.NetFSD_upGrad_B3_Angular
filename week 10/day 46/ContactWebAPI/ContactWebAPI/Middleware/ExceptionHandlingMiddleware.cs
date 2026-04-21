using ContactWebAPI.Models;
using System.Net;
using System.Text.Json;

namespace ContactWebAPI.Middleware
{
    /// <summary>
    /// Global exception handling middleware.
    /// Catches unhandled exceptions before they become 500 Internal Server Errors.
    ///
    /// DEBUGGING TIP:
    ///   Set a breakpoint on the 'catch' block to inspect any unhandled exception.
    ///   The Developer Exception Page (enabled in Development) also shows full stack traces.
    /// </summary>
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;

        public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                // ← SET BREAKPOINT HERE to trace the full request pipeline
                await _next(context);
            }
            catch (ArgumentNullException ex)
            {
                _logger.LogError(ex, "Null argument error in request pipeline.");
                await WriteErrorResponse(context, HttpStatusCode.BadRequest, $"Invalid input: {ex.ParamName} cannot be null.");
            }
            catch (ArgumentException ex)
            {
                _logger.LogError(ex, "Argument error in request pipeline.");
                await WriteErrorResponse(context, HttpStatusCode.BadRequest, ex.Message);
            }
            catch (Exception ex)
            {
                // ← This catches 500 Internal Server Errors — inspect 'ex.Message' and 'ex.StackTrace'
                _logger.LogError(ex, "Unhandled exception occurred. Path: {Path}", context.Request.Path);
                await WriteErrorResponse(context, HttpStatusCode.InternalServerError,
                    "An unexpected error occurred. Please try again later.");
            }
        }

        private static async Task WriteErrorResponse(HttpContext context, HttpStatusCode statusCode, string message)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode  = (int)statusCode;

            var response = ApiResponse<object>.Fail(message);
            var json = JsonSerializer.Serialize(response, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });

            await context.Response.WriteAsync(json);
        }
    }
}
