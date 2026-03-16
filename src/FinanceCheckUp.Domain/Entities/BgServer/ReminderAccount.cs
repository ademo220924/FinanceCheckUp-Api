using FinanceCheckUp.Framework.Data.MsSql;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinanceCheckUp.Domain.Entities.BgServer;

[Table("ReminderAccount")]
public partial class ReminderAccount : ISqlServerEntity<long>
{
    [Key]
    [Column("ID")]
    public long Id { get; set; }

    [Required]
    [StringLength(500)]
    public string Name { get; set; }

    public int StartValue { get; set; }

    public int FinishValue { get; set; }

    public long AccountGroupId { get; set; }

    public int AccountType { get; set; }
}
