using FinanceCheckUp.Client.QnbClient.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Mime;

namespace FinanceCheckUp.Client.QnbClient;

public static class QnbClientExtension
{
    private const string Accept = "Accept";
    private const string ClientBaseAddressKey = "ExternalServiceSettings:QnbClient:Host";
    private const string ClientTimeoutKey = "ExternalServiceSettings:QnbClient:Timeout";

    public static IServiceCollection AddQnbClients(this IServiceCollection service, IConfiguration configuration)
    {
        service.AddHttpClient<IQnbClient, Implementations.QnbClient>(client =>
        {
            client.BaseAddress = new Uri(configuration.GetValue<string>(ClientBaseAddressKey) ?? string.Empty);
            client.Timeout = TimeSpan.FromMilliseconds(configuration.GetValue<int>(ClientTimeoutKey));
            client.DefaultRequestHeaders.Add(Accept, MediaTypeNames.Application.Json);
        });

        return service;
    }
}