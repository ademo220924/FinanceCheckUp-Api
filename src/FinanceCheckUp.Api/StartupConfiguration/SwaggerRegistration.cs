using FinanceCheckUp.Api.Filters;
using FinanceCheckUp.Application.Features.BaseApp.Beyanname.Command.MoodUploadCreate;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using System.Reflection;

namespace FinanceCheckUp.Api.StartupConfiguration;

public static class SwaggerConfiguration
{
    public static IServiceCollection AddSwagger(this IServiceCollection services, IConfiguration configuration)
    {
        var section = configuration.GetSection("SwaggerSettings");
        services.AddSwaggerGen(options =>
        {
            var apiName = section.GetValue<string>("Name");
            var apiDesc = section.GetValue<string>("Description");

            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = apiName,
                Version = "v1",
                Description = apiDesc
            });


            options.MapType<IFormFile>(() => new OpenApiSchema
            {
                Type = "string",
                Format = "binary"
            }); ;

            options.OperationFilter<SwaggerJsonIgnoreFilter>();
            options.OperationFilter<SwaggerFileOperationFilter>();

            var folder = Environment.CurrentDirectory.Replace(Assembly.GetExecutingAssembly().GetName().Name, "");
            if (!string.IsNullOrEmpty(folder))
                foreach (var name in Directory.GetFiles(folder, "*.xml", SearchOption.AllDirectories))
                    options.IncludeXmlComments(name);

            options.ExampleFilters();

            options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Description = "JWT Authorization header using the Bearer scheme.",
                Name = "Authorization",
                In = ParameterLocation.Header,
                Scheme = "Bearer",
                Type = SecuritySchemeType.ApiKey,
                BearerFormat = "JWT"
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
                        new string[] {}

                    }
                });


        });

        services.AddSwaggerExamplesFromAssemblies(typeof(MoodUploadCreateCommandExample).GetTypeInfo().Assembly);
        return services;
    }

    public static IApplicationBuilder UseCustomSwagger(this IApplicationBuilder app, IConfiguration configuration)
    {
        var section = configuration.GetSection("SwaggerSettings");
        app.UseSwagger()
            .UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint($"{section.GetValue<string>("BasePath")}{"v1"}/swagger.json",
                    section.GetValue<string>("Name") + " v1");
            });

        return app;
    }

    public static IApplicationBuilder AddReDocumet(this IApplicationBuilder app, IConfiguration configuration)
    {
        var section = configuration.GetSection("SwaggerSettings");
        app.UseReDoc(options =>
        {
            options.DocumentTitle = "ReDoc Sample Project";
            options.SpecUrl = $"{section.GetValue<string>("BasePath")}{"v1"}/swagger.json" + section.GetValue<string>("Name") + " v1";
        });
        return app;
    }
}