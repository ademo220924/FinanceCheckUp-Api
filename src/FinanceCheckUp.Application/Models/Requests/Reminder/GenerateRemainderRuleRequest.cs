using FinanceCheckUp.Domain.Entities.BgServer;

namespace FinanceCheckUp.Application.Models.Requests.Reminder;

public  class GenerateRemainderRuleRequest
{
    public List<ReminderRule> ReminderRules { get; set; }
}
