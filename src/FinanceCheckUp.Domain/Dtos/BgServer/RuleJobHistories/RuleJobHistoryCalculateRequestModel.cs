using FinanceCheckUp.Domain.Entities.BgServer;

namespace FinanceCheckUp.Domain.Dtos.BgServer.RuleJobHistories;

public class RuleJobHistoryCalculateRequestModel
{
    public RuleJobHistoryCalculateRequestModel(long reminderRuleJobId, double controlValue, double compareValue, ReminderRule reminderRule, ReminderRuleJob reminderRuleJob, long id, long sourceTableControlValueId, long sourceTableCalculateValueId)
    {
        ReminderRuleJobId = reminderRuleJobId;
        ControlValue = controlValue;
        CompareValue = compareValue;
        ReminderRule = reminderRule;
        ReminderRuleJob = reminderRuleJob;
        Id = id;
        SourceTableControlValueId = sourceTableControlValueId;
        SourceTableCalculateValueId = sourceTableCalculateValueId;
    }

    public long ReminderRuleJobId { get; set; }
    public double ControlValue { get; set; }
    public double CompareValue { get; set; }
    public ReminderRule ReminderRule { get; set; }
    public ReminderRuleJob ReminderRuleJob { get; set; }
    public long Id { get; set; }
    public long SourceTableControlValueId { get; set; }
    public long SourceTableCalculateValueId { get; set; }
}