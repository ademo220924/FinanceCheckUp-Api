using FinanceCheckUp.Framework.Data.MsSql;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinanceCheckUp.Domain.Entities;

[Table("UserCompany")]
public partial class UserCompany : ISqlServerEntity<long>
{
    [Key]
    [Column("ID")]
    public long Id { get; set; }

    [Column("CompanyID")]
    public long CompanyId { get; set; }

    [Column("UserID")]
    public int UserId { get; set; }

    public byte IsDefault { get; set; }

    public bool IsDeleted { get; set; }
}
