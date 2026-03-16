using System.Linq.Expressions;

namespace FinanceCheckUp.Framework.Data;

public interface IExecutableRepository<T, TId> where T : class, IEntity<TId>, new() where TId : IEquatable<TId>
{
    Task<bool> AddAsync(T entity, CancellationToken cancellationToken = default);
    Task<bool> AddRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default);
    Task<bool> UpdateAsync(T entity, CancellationToken cancellationToken = default);
    Task<bool> UpdateRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default);
    Task<bool> DeleteAsync(string id, CancellationToken cancellationToken = default);
    Task<bool> DeleteAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default);
    Task<bool> DeleteRangeAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default);
}