using FinanceCheckUp.Framework.Data.MsSql;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinanceCheckUp.Domain.Entities;

[Table("UserType")]
public partial class UserType : ISqlServerEntity<int>
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [StringLength(50)]
    public string Type { get; set; }
}
