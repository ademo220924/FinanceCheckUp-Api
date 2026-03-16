namespace FinanceCheckUp.Framework.Data.MsSql;

public class SqlServerBaseEntity(int id) : ISqlServerEntity<int>
{
    public int Id { get; } = id;
    public DateTime CreatedAt { get; set; }
    public string CreatedBy { get; set; } = "default-createdBy";
    public DateTime? UpdatedAt { get; set; }
    public string UpdatedBy { get; set; } = "default-createdBy";
    //public bool IsDeleted { get; set; }
}