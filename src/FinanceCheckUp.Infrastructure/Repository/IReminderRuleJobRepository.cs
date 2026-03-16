using FinanceCheckUp.Domain.Entities.BgServer;
using FinanceCheckUp.Framework.Data;

namespace FinanceCheckUp.Infrastructure.Repository;

public interface IReminderRuleJobRepository : IGenericRepository<ReminderRuleJob, long>
{
    Task<List<ReminderRuleJob>> GetFilterAsync(long companyId, long accountId);
}