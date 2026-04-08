using StudentCourseSystem.Data;

var builder = WebApplication.CreateBuilder(args);

// Add MVC services
builder.Services.AddControllersWithViews();

// Connection string for SQLite
var connectionString = $"Data Source={Path.Combine(builder.Environment.ContentRootPath, "studentcourse.db")}";

// Register repositories as singletons (or scoped)
builder.Services.AddScoped(_ => new StudentRepository(connectionString));
builder.Services.AddScoped(_ => new CourseRepository(connectionString));

var app = builder.Build();

// Initialize and seed database
var dbInit = new DatabaseInitializer(connectionString);
dbInit.Initialize();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
