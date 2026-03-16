namespace FinanceCheckUp.Framework.Cache;

public interface ICacheService : IDisposable
{
    T Get<T>(string key);
    Task<T> GetAsync<T>(string key);
    bool Set<T>(string key, T data, TimeSpan? expiry = null);
    Task<bool> SetAsync<T>(string key, T data, TimeSpan? expiry = null);
    bool IsExists(string key);
    Task<bool> IsExistsAsync(string key);
    bool Remove(string key);
    Task<bool> RemoveAsync(string key);
    Task<TimeSpan> PingAsync();
}