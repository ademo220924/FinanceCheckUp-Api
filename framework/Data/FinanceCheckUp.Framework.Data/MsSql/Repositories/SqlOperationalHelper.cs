using Microsoft.EntityFrameworkCore;

namespace FinanceCheckUp.Framework.Data.MsSql.Repositories;

public class SqlOperationalHelper(DbContext dbContext) : ISqlOperationalHelper
{
    public T QueryOfSingle<T>(string sql)
    {
        return dbContext.Database.SqlQueryRaw<T>(sql).FirstOrDefault();
    }
    public T QueryOfSingle<T>(string sql, params object[] parameters)
    {
        return parameters != null
            ? dbContext.Database.SqlQueryRaw<T>(sql, parameters).FirstOrDefault()
            : QueryOfSingle<T>(sql);
    }

    public List<T> QueryOfList<T>(string sql)
    {
        return [.. dbContext.Database.SqlQueryRaw<T>(sql)];
    }

    public List<T> QueryOfList<T>(string sql, params object[] parameters)
    {
        return parameters != null
            ? [.. dbContext.Database.SqlQueryRaw<T>(sql, parameters)]
            : QueryOfList<T>(sql);
    }

    public async Task<int> ExecuteSqlRawAsync(string sql, CancellationToken cancellationToken)
    {
        return await dbContext.Database.ExecuteSqlRawAsync(sql, cancellationToken: cancellationToken);
    }
    public int ExecuteSqlRaw(string sql, params object[] parameters)
    {
        return dbContext.Database.ExecuteSqlRaw(sql, parameters);
    }

    public string GetConnectionString()
    {
        return dbContext.Database.GetConnectionString();
    }

    public DbContext GetDbContext()
    {
        return dbContext;
    }
}