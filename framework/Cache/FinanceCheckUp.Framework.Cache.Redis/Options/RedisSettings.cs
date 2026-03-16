namespace FinanceCheckUp.Framework.Cache.Redis.Options;

public class RedisSettings
{
    public string SentinelHosts { get; set; }
    public string MasterName { get; set; }
    public string Password { get; set; }
    public int Database { get; set; }
}