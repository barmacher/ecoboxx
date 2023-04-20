using MediatR;
using Microsoft.EntityFrameworkCore;
using ApplicationsApp;
using ApplicationsApp.Common.Mapping;
using ApplicationsApp.Interfaces;
using EcoboxPersistence;
using System.Reflection;
using Microsoft.Extensions.Configuration;
using Applications.WebApi.Middleware;
using Applications.WebApi.Middleware;
using Ecobox.WebApi;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Hosting;
using Microsoft.OpenApi.Models;
using Ecobox.WebApi.Auth;
using Ecobox.Domain;
using Applications.Domain;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var config = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .Build();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddIdentity<User, Role>().AddEntityFrameworkStores<ApplicationsDbContext>();
builder.Services.AddScoped<AuthService>();
builder.Services.AddScoped<UserManager<User>>();

builder.Services.AddSwaggerGen(x =>
            {
            x.SwaggerDoc("v1", new OpenApiInfo { Version = "v1", Title = "Thesis" });

            x.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                In = ParameterLocation.Header,
                Description = "Please enter JWT with Bearer into field",
                Name = "Authorization",
                Type = SecuritySchemeType.ApiKey,
                Scheme = "bearer",
            });

            x.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        Array.Empty<string>()
                    }
                });

            x.CustomSchemaIds(t => t.FullName);
            });

var jwtsection = config.GetSection(nameof(JwtSettings));
builder.Services.Configure<JwtSettings>(jwtsection);
var jwtsettings = jwtsection.Get<JwtSettings>();
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ClockSkew = TimeSpan.Zero,
        ValidateIssuerSigningKey= true,
        ValidIssuer = jwtsettings.Issuer,
        ValidAudience= jwtsettings.Audience,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtsettings.Key))
    };
});


builder.Services.AddAutoMapper(config =>
{
    config.AddProfile(new AssebmlyMappingProfile(Assembly.GetExecutingAssembly()));
    config.AddProfile(new AssebmlyMappingProfile(typeof(IApplicationsDbContext).Assembly));
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

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();


