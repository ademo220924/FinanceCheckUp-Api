using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Mime;

namespace FinanceCheckUp.Client.Wsdl;

public static class FinansmanEntegrasyonServiceClientExtensions
{
    private const string Accept = "Accept";
    private const string ClientBaseAddressKey = "ExternalServiceSettings:FinansmanEntegrasyonService:Host";
    private const string ClientTimeoutKey = "ExternalServiceSettings:FinansmanEntegrasyonService:Timeout";

    public static IServiceCollection AddFinansmanEntegrasyonServiceOperationClient(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddHttpClient<IFinansmanClient, FinansmanClient>(client =>
        {
            client.BaseAddress = new Uri(configuration.GetValue<string>(ClientBaseAddressKey));
            client.Timeout = TimeSpan.FromMilliseconds(configuration.GetValue<int>(ClientTimeoutKey));
            client.DefaultRequestHeaders.Add(Accept, MediaTypeNames.Application.Json);
        });

        return services;
    }

}