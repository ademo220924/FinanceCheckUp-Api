using FinanceCheckUp.Framework.Cache.Redis.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RedLockNet;
using RedLockNet.SERedis;
using RedLockNet.SERedis.Configuration;
using StackExchange.Redis;

namespace FinanceCheckUp.Framework.Cache.Redis;

public static class RedisCacheExtensions
{
    public static IServiceCollection AddRedisCacheDependencies(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton<RedisServer>();
        services.AddScoped<ICacheService, RedisCacheService>();
        return services;
    }

    public static IServiceCollection AddRedLockDependencies(this IServiceCollection services, IConfiguration configuration)
    {
        var redisOption = configuration.GetSection(nameof(RedisSettings)).Get<RedisSettings>();
        var connectionString = $"{redisOption.SentinelHosts},serviceName={redisOption.MasterName},password={redisOption.Password}";
        var existingConnectionMultiplexer = ConnectionMultiplexer.Connect(connectionString);
        var multiplexers = new List<RedLockMultiplexer>
        {
            existingConnectionMultiplexer
        };

        services.AddSingleton<IDistributedLockFactory, RedLockFactory>(x => RedLockFactory.Create(multiplexers))
            .AddSingleton<RedisServer>();

        return services;
    }
}