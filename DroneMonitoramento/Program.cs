using DroneMonitoramento.Data;
using DroneMonitoramento.Services;
using DroneMonitoringAPI.Controllers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
// Add services to the container.
builder.Services.AddDbContext<DroneContext>(options =>
    options.UseOracle(builder.Configuration.GetConnectionString("OracleDB")));

// Add services
builder.Services.AddScoped<IDroneService, DroneService>();

// Configure Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Define endpoints
app.MapDroneEndpoints();
app.MapControllers();

app.Run();
