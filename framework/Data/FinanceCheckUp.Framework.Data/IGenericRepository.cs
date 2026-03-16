namespace FinanceCheckUp.Framework.Data;

public interface IGenericRepository<T, TId> :
    IExecutableRepository<T, TId>,
    IQueryableRepository<T, TId>
            where T : class, IEntity<TId>, new()
            where TId : IEquatable<TId>
{
}
