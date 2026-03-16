namespace FinanceCheckUp.Framework.Data;

public interface IEntity
{ }


public interface IEntity<out TKey> : IEntity where TKey : IEquatable<TKey>
{
    TKey Id { get; }
    //bool IsDeleted { get; set; }
}


public interface IEntityCreatedAudit : IEntity
{
    DateTime CreatedAt { get; set; }
    string CreatedBy { get; set; }

}

public interface IEntityFullAudit : IEntityCreatedAudit
{
    DateTime UpdatedAt { get; set; }
    string UpdatedBy { get; set; }
}

//ToDo: domain nesnelerine uygun olan type eklenmeli hepsinde full gerek yok
//ToDo: Required ve nullable nesneleri net olarak belirle

public interface IQueryableBaseEntity
{

}
