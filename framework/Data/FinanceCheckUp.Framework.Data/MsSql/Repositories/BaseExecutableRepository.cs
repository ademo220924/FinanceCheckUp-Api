using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace FinanceCheckUp.Framework.Data.MsSql.Repositories;

public class BaseExecutableRepository<T, TKey>(DbContext writeDbDatabaseContext) : IExecutableRepository<T, TKey>
    where T : class, ISqlServerEntity<TKey>, new()
    where TKey : IEquatable<TKey>
{

    public virtual async Task<bool> AddAsync(T entity, CancellationToken cancellationToken = default)
    {
        await writeDbDatabaseContext.Set<T>().AddAsync(entity, cancellationToken);
        await writeDbDatabaseContext.SaveChangesAsync(cancellationToken);
        return true;
    }
    public virtual async Task<bool> AddRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default)
    {
        await writeDbDatabaseContext.Set<T>().AddRangeAsync(entities, cancellationToken);
        await writeDbDatabaseContext.SaveChangesAsync(cancellationToken);
        return true;
    }
    public virtual async Task<bool> UpdateAsync(T entity, CancellationToken cancellationToken = default)
    {
        writeDbDatabaseContext.Set<T>().Update(entity);
        await writeDbDatabaseContext.SaveChangesAsync(cancellationToken);
        return true;
    }
    public virtual async Task<bool> UpdateRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default)
    {
        writeDbDatabaseContext.Set<T>().UpdateRange(entities);
        await writeDbDatabaseContext.SaveChangesAsync(cancellationToken);
        return true;
    }
    public async Task<bool> DeleteAsync(string id, CancellationToken cancellationToken = default)
    {
        var item = await writeDbDatabaseContext.Set<T>().FirstOrDefaultAsync(c => c.Id.Equals(id), cancellationToken);
        if (item == null)
            return false;

        writeDbDatabaseContext.Set<T>().Remove(item);
        await writeDbDatabaseContext.SaveChangesAsync(cancellationToken);
        return true;

    }
    public virtual async Task<bool> DeleteAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default)
    {
        var item = await writeDbDatabaseContext.Set<T>().FirstOrDefaultAsync(predicate, cancellationToken);
        if (item == null)
            return false;

        writeDbDatabaseContext.Set<T>().Remove(item);
        await writeDbDatabaseContext.SaveChangesAsync(cancellationToken);
        return true;
    }
    public virtual async Task<bool> DeleteRangeAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default)
    {
        var items = await writeDbDatabaseContext.Set<T>().Where(predicate).ToListAsync(cancellationToken);
        if (items.Count == 0)
            return false;

        writeDbDatabaseContext.Set<T>().RemoveRange(items);
        await writeDbDatabaseContext.SaveChangesAsync(cancellationToken);
        return true;
    }
}