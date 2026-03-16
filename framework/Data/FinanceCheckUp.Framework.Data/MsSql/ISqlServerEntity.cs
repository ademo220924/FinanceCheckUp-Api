

namespace FinanceCheckUp.Framework.Data.MsSql;

public interface ISqlServerEntity<out TKey> : IEntity<TKey> where TKey : IEquatable<TKey>
{

}