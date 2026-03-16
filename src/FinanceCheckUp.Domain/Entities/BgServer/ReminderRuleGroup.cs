using FinanceCheckUp.Framework.Data.MsSql;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinanceCheckUp.Domain.Entities.BgServer;

[Table("ReminderRuleGroup")]
public partial class ReminderRuleGroup : ISqlServerEntity<int>
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [Column("ReminderAccountID")]
    public long ReminderAccountId { get; set; }

    [Column("RuleGroupID")]
    public long RuleGroupId { get; set; }
}
