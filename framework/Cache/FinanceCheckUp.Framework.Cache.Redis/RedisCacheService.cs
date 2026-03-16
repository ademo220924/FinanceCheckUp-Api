using FinanceCheckUp.Framework.Cache.Redis.Options;
using System.Text.Json;
using static System.String;

namespace FinanceCheckUp.Framework.Cache.Redis;

public class RedisCacheService(RedisServer redisServer) : ICacheService
{
    public T Get<T>(string key)
    {
        if (IsNullOrWhiteSpace(key))
            return default;

        string val = redisServer.Database.StringGet(key);
        return IsNullOrWhiteSpace(val) ? default : JsonSerializer.Deserialize<T>(val);
    }

    public async Task<T> GetAsync<T>(string key)
    {
        if (IsNullOrWhiteSpace(key))
            return default;

        string val = await redisServer.Database.StringGetAsync(key);
        return IsNullOrEmpty(val) ? default : JsonSerializer.Deserialize<T>(val);
    }

    public bool Set<T>(string key, T data, TimeSpan? expiry = null)
    {
        return !IsNullOrWhiteSpace(key) && redisServer.Database.StringSet(key, JsonSerializer.Serialize(data), expiry);
    }

    public async Task<bool> SetAsync<T>(string key, T data, TimeSpan? expiry = null)
    {
        return !IsNullOrWhiteSpace(key) &&
               await redisServer.Database.StringSetAsync(key, JsonSerializer.Serialize(data), expiry);
    }

    public bool IsExists(string key)
    {
        return !IsNullOrWhiteSpace(key) && redisServer.Database.KeyExists(key);
    }

    public async Task<bool> IsExistsAsync(string key)
    {
        return !IsNullOrWhiteSpace(key) && await redisServer.Database.KeyExistsAsync(key);
    }

    public bool Remove(string key)
    {
        return !IsNullOrWhiteSpace(key) && redisServer.Database.KeyDelete(key);
    }

    public async Task<bool> RemoveAsync(string key)
    {
        return !IsNullOrWhiteSpace(key) && await redisServer.Database.KeyDeleteAsync(key);
    }

    public async Task<TimeSpan> PingAsync()
    {
        return await redisServer.Database.PingAsync();
    }

    /// <summary>Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.</summary>
#pragma warning disable CA1816
    public void Dispose()
    {

    }
#pragma warning restore CA1816
}