using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Mime;

namespace FinanceCheckUp.Client.ConnectApi;

public static class ConnectApiClientExtensions
{
    private const string Accept = "Accept";
    private const string ClientBaseAddressKey = "ExternalServiceSettings:ConnectApiService:Host";
    private const string ClientTimeoutKey = "ExternalServiceSettings:ConnectApiService:Timeout";

    public static IServiceCollection AddConnectApiServiceOperationClient(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddHttpClient<IConnectApiClient, ConnectApiClient>(client =>
        {
            client.BaseAddress = new Uri(configuration.GetValue<string>(ClientBaseAddressKey));
            client.Timeout = TimeSpan.FromMilliseconds(configuration.GetValue<int>(ClientTimeoutKey));
            client.DefaultRequestHeaders.Add(Accept, MediaTypeNames.Application.Json);
        });

        return services;
    }
}