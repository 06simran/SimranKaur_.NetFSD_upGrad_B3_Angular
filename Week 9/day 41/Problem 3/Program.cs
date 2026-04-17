using System.Threading.RateLimiting;
using ContactRateLimitAPI.Repository;
using Microsoft.AspNetCore.RateLimiting;

var builder = WebApplication.CreateBuilder(args);

// Dependency Injection
builder.Services.AddScoped<IContactRepository, ContactRepository>();

// ── Configure Built-in Rate Limiting (Fixed Window) ──────────────────────────
builder.Services.AddRateLimiter(options =>
{
    // Define a named policy called "fixed"
    options.AddFixedWindowLimiter(policyName: "fixed", limiterOptions =>
    {
        limiterOptions.PermitLimit         = 5;                        // Max 5 requests
        limiterOptions.Window              = TimeSpan.FromSeconds(60); // per 60-second window
        limiterOptions.QueueProcessingOrder = QueueProcessingOrder.OldestFirst;
        limiterOptions.QueueLimit          = 0;                        // No queuing — reject immediately
    });

    // Custom 429 response
    options.OnRejected = async (context, cancellationToken) =>
    {
        context.HttpContext.Response.StatusCode  = StatusCodes.Status429TooManyRequests;
        context.HttpContext.Response.ContentType = "application/json";
        await context.HttpContext.Response.WriteAsync(
            "{\"message\": \"Too many requests. Please try again later.\"}",
            cancellationToken);
    };

    // Identify client by IP address
    options.RejectionStatusCode = StatusCodes.Status429TooManyRequests;
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { Title = "Contact Rate Limit API", Version = "v1" });
});

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Contact Rate Limit API v1");
    c.RoutePrefix = string.Empty;
});

// IMPORTANT: UseRateLimiter must be added to the pipeline
app.UseRateLimiter();

app.MapControllers();
app.Run();
