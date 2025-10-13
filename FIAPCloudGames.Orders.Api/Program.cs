using System.Security.Claims;
using System.Text;
using Carter;
using FIAPCloudGames.Orders.Api;
using Azure.Monitor.OpenTelemetry.AspNetCore;
using FIAPCloudGames.Orders.Api.Commom.Extensions;
using FIAPCloudGames.Orders.Api.Commom.Middlewares;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDependecyInjection(builder.Configuration);

builder.Host.AddSerilog();

builder.Services
    .AddOpenTelemetry()
    .UseAzureMonitor(configureAzureMonitor => configureAzureMonitor.ConnectionString = builder.Configuration["ApplicationInsights:ConnectionString"]);

builder.Services
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new()
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Secret"]!)),
            ClockSkew = TimeSpan.Zero,
            RoleClaimType = ClaimTypes.Role
        };
    });

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();

    app.UseSwaggerUI();

    app.ApplyMigrations();
}

app.UseMiddleware<RequestLogContextMiddleware>();

app.UseExceptionHandler();

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.MapCarter();

app.Run();
