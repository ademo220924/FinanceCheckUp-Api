using Microsoft.Extensions.Configuration;

namespace FinanceCheckUp.Application.Common.Providers;

public static class CustomConfigurationProvider
{
    public static IConfiguration Configuration { get; set; }
}
