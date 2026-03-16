using FinanceCheckUp.Api.Filters;
using FinanceCheckUp.Api.Middlewares;
using FinanceCheckUp.Api.StartupConfiguration;
using FinanceCheckUp.Application;
using FinanceCheckUp.Application.Common.Providers;
using FinanceCheckUp.Application.Models.SignOperation;
using FinanceCheckUp.Framework.Core.Middlewares.Middleware;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
CustomConfigurationProvider.Configuration = builder.Configuration;


builder.Services.AddControllers(opt => { opt.Filters.Add(typeof(ExceptionFilterAttribute)); })
                .AddNewtonsoftJson(opt => { opt.SerializerSettings.NullValueHandling = NullValueHandling.Ignore; });
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwagger(builder.Configuration);
builder.Services.AddCustomApiVersioning();
builder.Services.AddCors();

FinanceCheckUp.Framework.Logging.Serilog.LoggerExtensions.ConfigureLogging(builder.Host, "FinanceCheckUp-Api-Web","FinanceCheckUp");

//var logger = new LoggerConfiguration()
//    .ReadFrom.Configuration(builder.Configuration)
//    .Enrich.FromLogContext()
//    .CreateLogger();
//builder.Logging.ClearProviders();
//builder.Logging.AddSerilog(logger);





builder.Services
    .Configure<ApiBehaviorOptions>(options => { options.SuppressModelStateInvalidFilter = true; })
    .AddHttpContextAccessor()
    .RegistrationMediatR()
    .RegistrationAutoMapper()
    .RegistrationFluentValidation()
    .RegistrationDatabases(builder.Configuration)
    .RegistrationGenericRepository()
    .AddServiceDependencies()
    .AddManagerDependencies()
    .AddClientDependencies(builder.Configuration)
    .AddConfigurationDependencies(builder.Configuration)
    .AddHealthCheckDependencies();

builder.Services.AddAntiforgery(o => o.HeaderName = "XSRF-TOKEN");
//builder.Services.AddControllers(opt => { opt.Filters.Add(typeof(ExceptionFilterAttribute)); })
//                .AddNewtonsoftJson(opt => { opt.SerializerSettings.NullValueHandling = NullValueHandling.Ignore; });





var tokenOptions = builder.Configuration.GetSection("TokenOptions").Get<TokenOptions>();
builder.Services
    .AddAuthentication(option =>
    {
        option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(options =>
    {
        options.RequireHttpsMetadata = false; // �retim ortam�nda true yapmal�s�n�z
        options.SaveToken = true;
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = false,
            ValidateIssuerSigningKey = true,
            ValidIssuer = tokenOptions.Issuer,
            ValidAudience = tokenOptions.Audience,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenOptions.SecurityKey))
        };
    });
//     .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, options =>
//                         {
//                             options.Cookie.HttpOnly = true;
//                             options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
//                             options.LoginPath = "/api/auth/login";
//                             options.LogoutPath = "/api/auth/logout";
//                             options.ExpireTimeSpan = TimeSpan.FromDays(30);
//                             options.Cookie.MaxAge = TimeSpan.FromDays(30);
//                             options.SlidingExpiration = false;
//
//                         });
//
// builder.Services.AddSession(opts =>
// {
//     opts.Cookie.IsEssential = true;
//     opts.IdleTimeout = TimeSpan.FromMinutes(30);
//     opts.Cookie.MaxAge = TimeSpan.FromDays(360);
//     opts.Cookie.HttpOnly = true;
// });







var app = builder.Build();
app.UseCustomSwagger(builder.Configuration)
    .AddReDocumet(builder.Configuration)
    .UseRouting()
    //.UseMiddleware<ExceptionHandlingMiddleware>()
    .UseMiddleware<RequestResponseLoggingMiddleware>()
    .UseMiddleware<TokenHeaderMiddleware>()
    .UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader())
    .UseAuthentication()
    .UseAuthorization()
    .UseEndpoints(endpoints =>
    {
        endpoints.MapControllers();
        app.MapHealthChecks("/healthcheck", new HealthCheckOptions
        {
            Predicate = _ => true,
            ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
        });
        endpoints.MapHealthChecks("/liveness", new HealthCheckOptions
        {
            Predicate = r => r.Name.Contains("self")
        });
    });
app.Run();