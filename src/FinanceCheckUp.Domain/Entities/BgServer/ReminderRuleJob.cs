using FinanceCheckUp.Framework.Data.MsSql;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinanceCheckUp.Domain.Entities.BgServer;

[Table("ReminderRuleJob")]
public partial class ReminderRuleJob : ISqlServerEntity<long>
{
    [Key]
    [Column("ID")]
    public long Id { get; set; }

    public long CompanyId { get; set; }

    public long ReminderRuleId { get; set; }

    public int Year { get; set; }

    public int Quarter { get; set; }

    public int Month { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreatedDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime ScheduledDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CompareScheduleDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CompletedDate { get; set; }

    public int JobStatus { get; set; }

    [Required]
    public string JobStatusText { get; set; }
}
