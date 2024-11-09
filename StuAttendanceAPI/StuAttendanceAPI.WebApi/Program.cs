using Application.User.Services;
using Common.Application;
using StuAttendanceAPI.Config;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using System.Text.Json;
using StuAttendanceAPI.Infrastructure.Repositories.Base;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

builder.Configuration.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

var connectionString = builder.Configuration["ConnectionStrings:DefaultConnection"] ?? throw new NullReferenceException("ConnectionString is null");

BaseConstants.StuAttConnectionString = builder.Configuration["ConnectionStrings:DefaultConnection"] ?? throw new NullReferenceException("ConnectionString is null");


Bootstrapper.ConfigBootstrapper(services, connectionString);
ValidationBootstrapper.Init(services);


services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JwtConfig:Key"]!)),
        ValidateIssuer = true,
        ValidIssuer = builder.Configuration["JwtConfig:Issuer"],
        ValidateAudience = true,
        ValidAudience = builder.Configuration["JwtConfig:Audience"],
        ValidateLifetime = true,
        ClockSkew = TimeSpan.Zero
    };
});


services.AddControllers();
services.AddEndpointsApiExplorer();


services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
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
});

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;



app.Run();
