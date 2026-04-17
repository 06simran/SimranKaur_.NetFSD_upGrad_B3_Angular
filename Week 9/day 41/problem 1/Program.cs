using ContactCachingAPI.Repository;
using ContactCachingAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Register In-Memory Cache
builder.Services.AddMemoryCache();

// Dependency Injection
builder.Services.AddScoped<IContactRepository, ContactRepository>();
builder.Services.AddScoped<IContactService, ContactService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { Title = "Contact Caching API", Version = "v1" });
});

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Contact Caching API v1");
    c.RoutePrefix = string.Empty;
});

app.MapControllers();
app.Run();
