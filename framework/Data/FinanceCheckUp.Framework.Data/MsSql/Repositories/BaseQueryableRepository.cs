using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace FinanceCheckUp.Framework.Data.MsSql.Repositories;

public class BaseQueryableRepository<TResult, TKey>(DbContext readDbDatabaseContext) :
    IQueryableRepository<TResult, TKey>
    where TResult : class, ISqlServerEntity<TKey>, new()
    where TKey : IEquatable<TKey>
{

    public virtual async Task<List<TResult>> GetListAsync(Expression<Func<TResult, bool>> predicate = null, CancellationToken cancellationToken = default)
    {
        return predicate != null
            ? await readDbDatabaseContext.Set<TResult>()
                    .AsNoTracking()
                    .Where(predicate)
                    .ToListAsync(cancellationToken)
            : await readDbDatabaseContext.Set<TResult>()
                    .AsNoTracking()
                    //.Where(c=>!c.IsDeleted)
                    .ToListAsync(cancellationToken);
    }
    public virtual async Task<TResult> GetAsync(Expression<Func<TResult, bool>> predicate, CancellationToken cancellationToken = default)
    {
        return await readDbDatabaseContext.Set<TResult>()
                     .AsNoTracking()
                     .FirstOrDefaultAsync(predicate, cancellationToken);
    }
    public virtual async Task<TResult> GetByIdAsync(string id, CancellationToken cancellationToken = default)
    {
        return await readDbDatabaseContext.Set<TResult>()
            .AsNoTracking()
            .FirstOrDefaultAsync(c => c.Id.Equals(id), cancellationToken);
    }
    public virtual async Task<bool> AnyAsync(Expression<Func<TResult, bool>> predicate, CancellationToken cancellationToken = default)
    {
        return await readDbDatabaseContext.Set<TResult>()
            .AsNoTracking()
            .AnyAsync(predicate, cancellationToken);
    }
    public virtual async Task<long> CountAsync(Expression<Func<TResult, bool>> predicate, CancellationToken cancellationToken = default)
    {
        return await readDbDatabaseContext.Set<TResult>()
            .AsNoTracking()
            .CountAsync(predicate, cancellationToken);
    }
    public virtual async Task<List<TResult>> FindAsync(Expression<Func<TResult, bool>> filter, int skip, int take, CancellationToken cancellationToken = default)
    {
        return await readDbDatabaseContext.Set<TResult>()
            .AsNoTracking()
            .Where(filter)
            .Skip(skip)
            .Take(take)
            .ToListAsync(cancellationToken);
    }
    public virtual async Task<List<TResult>> FindAndOrderAsync<TKey1>(Expression<Func<TResult, bool>> filter, int skip, int take, Expression<Func<TResult, TKey1>> ordered, CancellationToken cancellationToken = default)
    {
        return await readDbDatabaseContext.Set<TResult>()
           .AsNoTracking()
           .OrderBy(ordered)
           .Where(filter)
           .Skip(skip)
           .Take(take)
           .ToListAsync(cancellationToken);
    }
}