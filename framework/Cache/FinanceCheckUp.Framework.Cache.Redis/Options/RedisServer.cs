using Microsoft.Extensions.Configuration;
using StackExchange.Redis;

namespace FinanceCheckUp.Framework.Cache.Redis.Options;

public class RedisServer
{
    public IDatabase Database { get; }

    public RedisServer(IConfiguration configuration)
    {
        var redisSettings = configuration.GetSection("RedisSettings").Get<RedisSettings>();

        var cfgOption = new ConfigurationOptions
        {
            KeepAlive = 60,
            AbortOnConnectFail = false,
            AllowAdmin = true,
            Password = redisSettings.Password,
            ServiceName = redisSettings.MasterName
        };

        redisSettings.SentinelHosts
                     .Split(',')
                     .ToList()
                     .ForEach(host => { cfgOption.EndPoints.Add(host); });

        var connectionMultiplexer = new Lazy<ConnectionMultiplexer>(() => ConnectionMultiplexer.Connect(cfgOption));
        Database = connectionMultiplexer.Value.GetDatabase(redisSettings.Database);
    }
}