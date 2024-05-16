using Serilog.Events;
using Serilog.Formatting.Json;
using Serilog;
using InvenProConnect.Models;
using InvenProConnect.DAOs.Interfaces;
using InvenProConnect.DAOs.Implementations;
using InvenProConnect.Managers.Interfaces;
using InvenProConnect.Managers.Implementations;

var builder = WebApplication.CreateBuilder(args);

// Add Serilog
Log.Logger = new LoggerConfiguration()
                            .WriteTo.Console()
                            .WriteTo.File(new JsonFormatter(), "important.json")
                            .WriteTo.File("all.logs",
                                          restrictedToMinimumLevel: LogEventLevel.Information,
                                          rollingInterval: RollingInterval.Day)
                            .MinimumLevel.Information()
                            .CreateLogger();

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddAutoMapper(typeof(Program).Assembly);
builder.Services.AddDbContext<InventoryManagementSystemContext>();
builder.Services.AddScoped<IDaoWrapper, DaoWrapper>();
builder.Services.AddScoped<IUserManager, UserManager>();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
