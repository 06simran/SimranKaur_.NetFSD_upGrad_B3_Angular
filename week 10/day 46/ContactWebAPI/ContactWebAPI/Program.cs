using ContactWebAPI.Interfaces;
using ContactWebAPI.Middleware;
using ContactWebAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// ── Services ──────────────────────────────────────────────────────────────

builder.Services.AddControllers();

// Register repository as Singleton so in-memory data persists across requests
// DEBUGGING TIP: Change to Scoped to see DI lifetime issues in practice
builder.Services.AddSingleton<IContactRepository, ContactRepository>();

// Swagger/OpenAPI — use to test endpoints directly in browser
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new()
    {
        Title   = "Contact Management API",
        Version = "v1",
        Description = "Week-10 Day-2 Hands-On — Debugging & Testing with Visual Studio + Postman"
    });

    // Include XML comments (controller <summary> tags show in Swagger UI)
    var xmlFile = $"{System.Reflection.Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    if (File.Exists(xmlPath))
        options.IncludeXmlComments(xmlPath);
});

// Logging — outputs to console; visible in VS Output window and terminal
builder.Logging.ClearProviders();
builder.Logging.AddConsole();
builder.Logging.SetMinimumLevel(LogLevel.Information);

var app = builder.Build();

// ── Middleware Pipeline ───────────────────────────────────────────────────
// ORDER MATTERS — middleware runs top to bottom on request, bottom to top on response

// Developer Exception Page — shows full stack trace in browser (Development only)
// DEBUGGING TIP: This is what shows detailed error info instead of just "500 Internal Server Error"
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Contact API v1");
        c.RoutePrefix = string.Empty; // Swagger UI at root: http://localhost:5000/
    });
}

// Custom middleware — registered in correct order
app.UseMiddleware<ExceptionHandlingMiddleware>(); // Must be first to catch all errors
app.UseMiddleware<RequestLoggingMiddleware>();    // Logs every request/response

app.UseRouting();
app.UseAuthorization();
app.MapControllers();

app.Run();

// Expose Program class for integration tests
public partial class Program { }
