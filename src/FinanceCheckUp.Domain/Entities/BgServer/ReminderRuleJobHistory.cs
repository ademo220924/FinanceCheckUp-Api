using FinanceCheckUp.Framework.Data.MsSql;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinanceCheckUp.Domain.Entities.BgServer;

[Table("ReminderRuleJobHistory")]
public partial class ReminderRuleJobHistory : ISqlServerEntity<long>
{
    [Key]
    [Column("ID")]
    public long Id { get; set; }

    public long ReminderRuleJobId { get; set; }

    [Column(TypeName = "decimal(18, 4)")]
    public decimal ControlValue { get; set; }

    [Column(TypeName = "decimal(18, 4)")]
    public decimal CalculateValue { get; set; }

    [Column(TypeName = "decimal(18, 4)")]
    public decimal DifferentValue { get; set; }

    [Column(TypeName = "decimal(18, 4)")]
    public decimal DifferentPercentage { get; set; }

    [Required]
    [StringLength(1000)]
    public string Explanation { get; set; }

    public bool IsNotify { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreatedDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? UpdatedDate { get; set; }

    public long SourceTableControlValueId { get; set; }

    public long SourceTableCalculateValueId { get; set; }
}
