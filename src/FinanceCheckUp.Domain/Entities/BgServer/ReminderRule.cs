using FinanceCheckUp.Framework.Data.MsSql;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinanceCheckUp.Domain.Entities.BgServer;

[Table("ReminderRule")]
public partial class ReminderRule : ISqlServerEntity<long>
{
    [Key]
    [Column("ID")]
    public long Id { get; set; }

    public long AccountId { get; set; }

    public int PeriodType { get; set; }

    [Column(TypeName = "decimal(18, 4)")]
    public decimal ControlValue { get; set; }

    public int ControlValueType { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? LastGenerateDate { get; set; }

    public bool IsRunScheduled { get; set; }
}
