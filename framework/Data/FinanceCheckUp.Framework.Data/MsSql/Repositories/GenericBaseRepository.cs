using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace FinanceCheckUp.Framework.Data.MsSql.Repositories;

public class GenericBaseRepository<T, TKey>(DbContext dbContext) :
    IGenericRepository<T, TKey>
    where T : class, ISqlServerEntity<TKey>, IEntity<TKey>, new()
    where TKey : IEquatable<TKey>
{
    public virtual async Task<bool> AddAsync(T entity, CancellationToken cancellationToken = default)
    {
        await dbContext.Set<T>().AddAsync(entity, cancellationToken);
        await dbContext.SaveChangesAsync(cancellationToken);
        return true;
    }
    public virtual async Task<bool> AddRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default)
    {
        await dbContext.Set<T>().AddRangeAsync(entities, cancellationToken);
        await dbContext.SaveChangesAsync(cancellationToken);
        return true;
    }
    public virtual async Task<bool> UpdateAsync(T entity, CancellationToken cancellationToken = default)
    {
        dbContext.Set<T>().Update(entity);
        await dbContext.SaveChangesAsync(cancellationToken);
        return true;
    }
    public virtual async Task<bool> UpdateRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default)
    {
        dbContext.Set<T>().UpdateRange(entities);
        await dbContext.SaveChangesAsync(cancellationToken);
        return true;
    }
    public async Task<bool> DeleteAsync(string id, CancellationToken cancellationToken = default)
    {
        var item = await dbContext.Set<T>().FirstOrDefaultAsync(c => c.Id.Equals(id), cancellationToken);
        if (item == null)
            return false;

        dbContext.Set<T>().Remove(item);
        await dbContext.SaveChangesAsync(cancellationToken);
        return true;

    }
    public virtual async Task<bool> DeleteAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default)
    {
        var item = await dbContext.Set<T>().FirstOrDefaultAsync(predicate, cancellationToken);
        if (item == null)
            return false;

        dbContext.Set<T>().Remove(item);
        await dbContext.SaveChangesAsync(cancellationToken);
        return true;
    }
    public virtual async Task<bool> DeleteRangeAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default)
    {
        var items = await dbContext.Set<T>().Where(predicate).ToListAsync(cancellationToken);
        if (items.Count == 0)
            return false;

        dbContext.Set<T>().RemoveRange(items);
        await dbContext.SaveChangesAsync(cancellationToken);
        return true;
    }

    public virtual async Task<List<T>> GetListAsync(Expression<Func<T, bool>> predicate = null, CancellationToken cancellationToken = default)
    {
        return predicate != null
            ? await dbContext.Set<T>()
                    .AsNoTracking()
                    .Where(predicate)
                    .ToListAsync(cancellationToken)
            : await dbContext.Set<T>()
                    .AsNoTracking()
                    //.Where(c=> !c.IsDeleted)
                    .ToListAsync(cancellationToken);
    }
    public virtual async Task<T> GetAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default)
    {
        return await dbContext.Set<T>()
                     .AsNoTracking()
                     .FirstOrDefaultAsync(predicate, cancellationToken);
    }
    public virtual async Task<T> GetByIdAsync(string id, CancellationToken cancellationToken = default)
    {
        return await dbContext.Set<T>()
            .AsNoTracking()
            .FirstOrDefaultAsync(c => c.Id.Equals(id), cancellationToken);
    }
    public virtual async Task<bool> AnyAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default)
    {
        return await dbContext.Set<T>()
            .AsNoTracking()
            .AnyAsync(predicate, cancellationToken);
    }
    public virtual async Task<long> CountAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default)
    {
        return await dbContext.Set<T>()
            .AsNoTracking()
            .CountAsync(predicate, cancellationToken);
    }
    public virtual async Task<List<T>> FindAsync(Expression<Func<T, bool>> filter, int skip, int take, CancellationToken cancellationToken = default)
    {
        return await dbContext.Set<T>()
            .AsNoTracking()
            .Where(filter)
            .Skip(skip)
            .Take(take)
            .ToListAsync(cancellationToken);
    }
    public virtual async Task<List<T>> FindAndOrderAsync<TKey1>(Expression<Func<T, bool>> filter, int skip, int take, Expression<Func<T, TKey1>> ordered, CancellationToken cancellationToken = default)
    {
        return await dbContext.Set<T>()
           .AsNoTracking()
           .OrderBy(ordered)
           .Where(filter)
           .Skip(skip)
           .Take(take)
           .ToListAsync(cancellationToken);
    }
}