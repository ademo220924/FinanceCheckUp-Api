using Microsoft.EntityFrameworkCore;

namespace FinanceCheckUp.Framework.Data;

public interface ISqlOperationalHelper
{
    T QueryOfSingle<T>(string sql);
    T QueryOfSingle<T>(string sql, params object[] parameters);
    List<T> QueryOfList<T>(string sql);
    List<T> QueryOfList<T>(string sql, params object[] parameters);
    int ExecuteSqlRaw(string sql, params object[] parameters);
    Task<int> ExecuteSqlRawAsync(string sql, CancellationToken cancellationToken);
    string GetConnectionString();
    DbContext GetDbContext();
}
