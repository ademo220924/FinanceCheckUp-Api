using FinanceCheckUp.Domain.Entities.BgServer;
using FinanceCheckUp.Framework.Data;

namespace FinanceCheckUp.Infrastructure.Repository;

public interface IReminderRuleJobHistoryRepository : IGenericRepository<ReminderRuleJobHistory, long>
{
    Task<bool> AddOrUpdate(
        long reminderRuleJobId,
        decimal controlValue,
        decimal compareValue,
        ReminderRule reminderRule,
        ReminderRuleJob reminderRuleJob,
        long sourceTableControlValueId,
        long sourceTableCalculateValueId,
        long id = 0);
}