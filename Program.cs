using Microsoft.EntityFrameworkCore;
using spinalproject.src.appointDbContext;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var connectionString =
    builder.Configuration.GetConnectionString("DefaultConnection")
        ?? throw new InvalidOperationException("Connection string"
        + "'DefaultConnection' not found.");

builder.Services.AddDbContext<appointDbContext>(options =>
    options.UseSqlite(connectionString));
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddTransient<UserService>();
builder.Services.AddTransient<appointmentService>();
builder.Services.AddTransient<ReportService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
        options.RoutePrefix = string.Empty; // Swagger opens at root URL
        options.ConfigObject.DisplayRequestDuration = true; // Show request duration
    });
//}
app.UseCors(req =>
{
    req.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
});
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
