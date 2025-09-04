using CoursePlanner.Api.Data;
using CoursePlanner.Api.Middleware;
using CoursePlanner.Api.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// EF Core (SQLite)
builder.Services.AddDbContext<AppDbContext>(opts =>
    opts.UseSqlite(builder.Configuration.GetConnectionString("Default") 
        ?? "Data Source=CoursePlanner.db"));

// DI for services
builder.Services.AddScoped<IStudentService, StudentService>();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();

// Swagger services
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Middleware
app.UseMiddleware<RequestLoggingMiddleware>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();        // serves /swagger/v1/swagger.json
    app.UseSwaggerUI();      // serves the UI at /swagger
}

app.UseHttpsRedirection();
app.MapControllers();

// DB migrate + seed
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    await Seed.RunAsync(db);
}

await app.RunAsync();
