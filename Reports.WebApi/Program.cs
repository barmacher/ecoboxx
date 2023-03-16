using MediatR;
using Microsoft.EntityFrameworkCore;
using ReportsApplication;
using ReportsApplication.Common.Mapping;
using ReportsApplication.Interfaces;
using ReportsPersistence;
using System.Reflection;
using Microsoft.Extensions.Configuration;
using Reports.WebApi.Middleware;
using Reports.WebApi.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var config = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .Build();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddAutoMapper(config =>
{
    config.AddProfile(new AssebmlyMappingProfile(Assembly.GetExecutingAssembly()));
    config.AddProfile(new AssebmlyMappingProfile(typeof(IReportsDbContext).Assembly));
});
builder.Services.AddApplication();
builder.Services.AddPersistence(config);
builder.Services.AddControllers();


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyHeader();
        policy.AllowAnyMethod();
        policy.AllowAnyOrigin();
    });
});




var app = builder.Build();

// Configure the HTTP request pipeline.

    app.UseSwagger();
    app.UseSwaggerUI();

app.UseCustomExceptionHandler();

app.UseCors("AllowAll");

app.UseHttpsRedirection();


app.UseAuthorization();

app.MapControllers();

app.Run();


