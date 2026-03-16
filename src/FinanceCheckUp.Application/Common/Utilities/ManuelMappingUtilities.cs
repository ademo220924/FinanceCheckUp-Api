using FinanceCheckUp.Application.Dtos.BgServer.RuleJobs;
using FinanceCheckUp.Domain.Common.Enums;
using FinanceCheckUp.Domain.Common.Utilities;
using FinanceCheckUp.Domain.Entities.BgServer;

namespace FinanceCheckUp.Application.Common.Utilities;

public static class ManuelMappingUtilities
{
    public static List<ReminderRuleJobDto> SetMapping(IEnumerable<ReminderRuleJob> ruleJobList,
                                                       IEnumerable<Domain.Entities.Company> companies,
                                                       IEnumerable<ReminderRule> rules,
                                                       IEnumerable<ReminderAccount> mainAccounts,
                                                       IEnumerable<ReminderAccountGroup> accountGroups)
    {
        return (from ruleJobItem in ruleJobList
                let company = companies.First(c => c.Id.Equals(ruleJobItem.CompanyId))
                let rule = rules.First(c => c.Id.Equals(ruleJobItem.ReminderRuleId))
                let mainAccount = mainAccounts.First(c => c.Id.Equals(rule.AccountId))
                let accountGroup = accountGroups.First(c => c.Id.Equals(mainAccount.AccountGroupId))
                select new ReminderRuleJobDto
                {
                    Id = ruleJobItem.Id,
                    CompanyId = company.Id,
                    CompanyName = company.CompanyName,
                    TaxNumber = company.TaxId,
                    ReminderRuleId = rule.Id,
                    AccountId = rule.AccountId,
                    AccountName = mainAccount.Name,
                    AccountType = (AccountType)mainAccount.AccountType,
                    AccountTypeText = ((AccountType)mainAccount.AccountType).GetDescription(),
                    AccountGroupId = accountGroup.Id,
                    AccountGroupName = accountGroup.Name,
                    PeriodType = (PeriodType)rule.PeriodType,
                    PeriodTypeText = ((PeriodType)rule.PeriodType).GetDescription(),
                    ControlValue = (double)rule.ControlValue,
                    ControlValueType = (ControlValueType)rule.ControlValueType,
                    ControlValueTypeText = ((ControlValueType)rule.ControlValueType).GetDescription(),
                    Year = ruleJobItem.Year,
                    Month = ruleJobItem.Month,
                    Quarter = ruleJobItem.Quarter,
                    CreatedDate = ruleJobItem.CreatedDate,
                    ScheduledDate = ruleJobItem.ScheduledDate,
                    CompareScheduleDate = ruleJobItem.CompareScheduleDate,
                    CompletedDate = ruleJobItem.CompletedDate,
                    JobStatus = (JobStatus)ruleJobItem.JobStatus,
                    JobStatusText = ((JobStatus)ruleJobItem.JobStatus).GetDescription()
                }).ToList();
    }
}