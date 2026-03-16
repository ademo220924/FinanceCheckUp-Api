using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Events;
using Serilog.Exceptions;
using Serilog.Extensions.Logging;
using Serilog.Formatting.Compact;
using Serilog.Formatting.Elasticsearch;
using System.Reflection;

namespace FinanceCheckUp.Framework.Logging.Serilog;

public static class LoggerExtensions
{
    public static IHostBuilder RegisterConfigureSerilog(this IHostBuilder builder,
                                                IEnumerable<string>? excludeLogItems = null,
                                                string? applicationName = null,
                                                bool dispose = true)
    {


        var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
        if (environment == null)
            return builder;

        applicationName ??= Assembly.GetExecutingAssembly().GetName().Name;
        if (applicationName == null)
            return builder;

        builder.ConfigureLogging((context, loggingBuilder) =>
        {
            loggingBuilder.ClearProviders();

            var logger = new LoggerConfiguration()
                .ReadFrom.Configuration(context.Configuration)
                .MinimumLevel.Information()
                .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
                .MinimumLevel.Override("Microsoft.AspNetCore", LogEventLevel.Warning)
                .Enrich.FromLogContext()
                .Enrich.WithMachineName()
                .Enrich.WithEnvironmentUserName()
                .Enrich.WithProcessId()
                .Enrich.WithProcessName()
                .Enrich.WithThreadId()
                .Enrich.WithThreadName()
                .Enrich.WithProperty("Environment", environment)
                .Enrich.WithProperty("ApplicationName", $"{applicationName}")
                .Enrich.WithCorrelationId()
                .Enrich.WithExceptionDetails()
                .Filter.ByExcluding(c => c.Properties.Any(p => excludeLogItems!.Contains(p.Value.ToString())))
                .WriteTo.Async(writeTo => writeTo.Debug(new RenderedCompactJsonFormatter()))
                .WriteTo.Async(writeTo => writeTo.Console(new ElasticsearchJsonFormatter()))
                .WriteTo.Async(writeTo => writeTo.File(path: "/logs/webapi-.log",
                                                                                  rollingInterval: RollingInterval.Day,
                                                                                  outputTemplate: "[{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} {CorrelationId} {Level:u3}] {Username} {Message:lj}{NewLine}{Exception}"))
                .CreateLogger();

            loggingBuilder.Services.AddSingleton(services => new SerilogLoggerFactory(logger, dispose) as ILoggerFactory);
        });

        return builder;
    }

    public static IHostBuilder RegisterUseSerilog(this IHostBuilder builder)
    {
        return builder.UseSerilog();
    }



    public static IHostBuilder ConfigureLogging(this IHostBuilder hostBuilder, string applicationName, string applicationGroup = "default",Action<LoggerConfiguration> customConfiguration = null, IEnumerable<string>? excludeLogItems = null)

    {
        const LogEventLevel minimumSerilogLogLevel = LogEventLevel.Information;

        Action<HostBuilderContext, ILoggingBuilder> configureLogging = (context, builder) =>
        {
            var configuration = context.Configuration;
            context.HostingEnvironment.ApplicationName = applicationName;

            var logConfiguration = new LoggerConfiguration()
                .ReadFrom.Configuration(configuration)
                .WriteTo.Async(writeTo => writeTo.Debug(new RenderedCompactJsonFormatter()))
                .WriteTo.Console(new RenderedCompactJsonFormatter())
                .WriteTo.Async(writeTo => writeTo.File(path: "/logs/webapi-.log",
                                                                                  rollingInterval: RollingInterval.Day,
                                                                                  outputTemplate: "[{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} {CorrelationId} {Level:u3}] {Username} {Message:lj}{NewLine}{Exception}"))
                .Enrich.FromLogContext()
                .Enrich.WithMachineName()
                .Enrich.WithExceptionDetails()
                .Enrich.WithExceptionDetails()
                .Enrich.WithCorrelationIdHeader()
                .Enrich.WithCorrelationIdHeader("X-Correlation-Id")
                .Enrich.WithProperty("Environment", context.HostingEnvironment.EnvironmentName)
                .Enrich.WithProperty("Application", applicationName)
                .Enrich.WithProperty("ApplicationGroup", applicationGroup)
                .MinimumLevel.Override("Microsoft", minimumSerilogLogLevel)
                .MinimumLevel.Override("System.Net.Http.HttpClient", minimumSerilogLogLevel)
                .MinimumLevel.Override("Microsoft.AspNetCore", LogEventLevel.Warning)
                .MinimumLevel.Override("Microsoft.Hosting.Lifetime", LogEventLevel.Warning)

                //.Filter.ByExcluding(c => c.Properties.Any(p => excludeLogItems!.Contains(p.Value.ToString())));
                .Filter.ByExcluding(c => c.Properties.Any(p =>p.Value.ToString().Contains("swagger") ||c.Level != LogEventLevel.Error && p.Value.ToString().Contains("health")));

            customConfiguration?.Invoke(logConfiguration);

            Log.Logger = logConfiguration.CreateBootstrapLogger();

            builder.AddSerilog(dispose: true);
        };

        return hostBuilder.ConfigureLogging((context, builder) =>
        {
            configureLogging(context, builder);
        }).UseSerilog();
    }
}