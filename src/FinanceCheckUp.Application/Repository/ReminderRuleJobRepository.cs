using FinanceCheckUp.Application.Contexts.Concretes.Databases;
using FinanceCheckUp.Domain.Common.Enums;
using FinanceCheckUp.Domain.Common.Utilities;
using FinanceCheckUp.Domain.Entities.BgServer;
using FinanceCheckUp.Framework.Data.MsSql.Repositories;
using FinanceCheckUp.Infrastructure.Repository;

namespace FinanceCheckUp.Application.Repository;

public class ReminderRuleJobRepository(FinanceCheckUpDbContext dbContext) : GenericBaseRepository<ReminderRuleJob, long>(dbContext), IReminderRuleJobRepository
{
    public Task<List<ReminderRuleJob>> GetFilterAsync(long companyId, long accountId)
    {
        var response = (from ruleJobItem in dbContext.ReminderRuleJobs
                        join company in dbContext.Companies on ruleJobItem.CompanyId equals company.Id
                        join rule in dbContext.ReminderRules on ruleJobItem.ReminderRuleId equals rule.Id
                        where ruleJobItem.CompanyId == companyId && rule.AccountId == accountId
                        select new ReminderRuleJob
                        {
                            Id = ruleJobItem.Id,
                            CompanyId = company.Id,
                            ReminderRuleId = rule.Id,
                            Year = ruleJobItem.Year,
                            Month = ruleJobItem.Month,
                            Quarter = ruleJobItem.Quarter,
                            CreatedDate = ruleJobItem.CreatedDate,
                            ScheduledDate = ruleJobItem.ScheduledDate,
                            CompareScheduleDate = ruleJobItem.CompareScheduleDate,
                            CompletedDate = ruleJobItem.CompletedDate,
                            JobStatus = ruleJobItem.JobStatus,
                            JobStatusText = ((JobStatus)ruleJobItem.JobStatus).GetDescription()
                        }).ToList();

        return Task.FromResult<List<ReminderRuleJob>>(response);
    }
}