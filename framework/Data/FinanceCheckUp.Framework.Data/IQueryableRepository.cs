using System.Linq.Expressions;

namespace FinanceCheckUp.Framework.Data;

public interface IQueryableRepository<T, TId> where T : class, IEntity<TId>, new() where TId : IEquatable<TId>
{
    Task<List<T>> GetListAsync(Expression<Func<T, bool>> predicate = null, CancellationToken cancellationToken = default);
    Task<T> GetAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default);
    Task<T> GetByIdAsync(string id, CancellationToken cancellationToken = default);
    Task<bool> AnyAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default);
    Task<long> CountAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default);
    Task<List<T>> FindAsync(Expression<Func<T, bool>> filter, int skip, int take, CancellationToken cancellationToken = default);
    Task<List<T>> FindAndOrderAsync<TKey>(Expression<Func<T, bool>> filter, int skip, int take, Expression<Func<T, TKey>> ordered, CancellationToken cancellationToken = default);
}