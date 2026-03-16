using FinanceCheckUp.Application.Common.Constants;
using FinanceCheckUp.Application.Common.Utilities;
using FinanceCheckUp.Application.Dtos.BgServer.RuleJobs;
using FinanceCheckUp.Domain.Common.Enums;
using FinanceCheckUp.Domain.Entities.BgServer;
using FinanceCheckUp.Framework.Core.Exceptions;
using FinanceCheckUp.Framework.Core.Models;
using FinanceCheckUp.Framework.Data;
using FinanceCheckUp.Infrastructure.Repository;
using MediatR;

namespace FinanceCheckUp.Application.Features.BaseApp.Reminder.RuleJob.Command.Generate;



public class GenerateRemainderRuleJobCommandHandle(
    IGenericRepository<ReminderRule, long> reminderRuleRepository,
    IGenericRepository<ReminderRuleJob, long> reminderRuleJobRepository,
    ICompanyRepository companyRepository,
    IGenericRepository<ReminderAccount, long> reminderAccountRepository,
    IGenericRepository<ReminderAccountGroup, long> reminderAccountGroupRepository) : IRequestHandler<GenerateRemainderRuleJobCommand, GenericResult<List<ReminderRuleJobDto>>>
{

    private readonly IGenericRepository<ReminderRule, long> _reminderRuleRepository = reminderRuleRepository ?? throw new ArgumentNullException(nameof(reminderRuleRepository));
    private readonly IGenericRepository<ReminderRuleJob, long> _reminderRuleJobRepository = reminderRuleJobRepository ?? throw new ArgumentNullException(nameof(reminderRuleJobRepository));
    private readonly ICompanyRepository _companyRepository = companyRepository ?? throw new ArgumentNullException(nameof(companyRepository));
    private readonly IGenericRepository<ReminderAccount, long> _reminderAccountRepository = reminderAccountRepository ?? throw new ArgumentNullException(nameof(reminderAccountRepository));
    private readonly IGenericRepository<ReminderAccountGroup, long> _reminderAccountGroupRepository = reminderAccountGroupRepository ?? throw new ArgumentNullException(nameof(reminderAccountGroupRepository));

    public async Task<GenericResult<List<ReminderRuleJobDto>>> Handle(GenerateRemainderRuleJobCommand request, CancellationToken cancellationToken)
    {
        DateTime? compareScheduleDate = null;
        var nowDate = new DateTime(2022, 2, 28, 0, 0, 0); //DateTime.Now; asıl kod , testler sonrası bu hale alınacak
        if (nowDate.Day == 1)
            return GenericResult<List<ReminderRuleJobDto>>.Success([]);

        var creatingJobDate = nowDate.AddMonths(1);
        var scheduleDate = new DateTime(creatingJobDate.Year, creatingJobDate.Month, 1, 0, 0, 0);

        var thisMonthQuarter = AppConst.Quarters.Where(c => c.Value.Contains(nowDate.Month));
        var nextMonthQuarter = AppConst.Quarters.Where(c => c.Value.Contains(scheduleDate.Month));
        var scheduleDateIsNextQuarter = !Equals(thisMonthQuarter.First().Key, nextMonthQuarter.First().Key);

        #region Model Data Get

        var rules = await _reminderRuleRepository.GetListAsync(x => x.LastGenerateDate == null || x.LastGenerateDate <= scheduleDate, cancellationToken);
        if (rules.Count == 0)
            return GenericResult<List<ReminderRuleJobDto>>.Success([]);

        var mainAccounts = await _reminderAccountRepository.GetListAsync(cancellationToken: cancellationToken);
        if (mainAccounts.Count == 0)
            return GenericResult<List<ReminderRuleJobDto>>.Success([]);

        var accountGroups = await _reminderAccountGroupRepository.GetListAsync(cancellationToken: cancellationToken);
        if (accountGroups.Count == 0)
            return GenericResult<List<ReminderRuleJobDto>>.Success([]);

        var companies = await _companyRepository.GetListAsync(cancellationToken: cancellationToken);
        if (companies.Count == 0)
            return GenericResult<List<ReminderRuleJobDto>>.Success([]);

        var ruleJobs = await _reminderRuleJobRepository.GetListAsync(cancellationToken: cancellationToken);

        #endregion

        var ruleJobList = new List<ReminderRuleJob>();
        foreach (var ruleItem in rules)
        {
            compareScheduleDate = null;
            var mainAccount = mainAccounts.Any(c => c.Id == ruleItem.AccountId);
            if (!mainAccount)
                continue;

            if (ruleItem.PeriodType == (int)PeriodType.Quarterly && scheduleDateIsNextQuarter)
                compareScheduleDate = scheduleDate.AddMonths(-4);
            else if (ruleItem.PeriodType == (int)PeriodType.Quarterly)
                continue;
            else if (ruleItem.PeriodType == (int)PeriodType.Yearly && scheduleDate.Month == 1)
                compareScheduleDate = scheduleDate.AddMonths(-1).AddYears(-1);
            else if (ruleItem.PeriodType == (int)PeriodType.Yearly)
                continue;
            else if (ruleItem.PeriodType == (int)PeriodType.Monthly)
                compareScheduleDate = scheduleDate.AddMonths(-2);
            else
                throw new ArgumentException(nameof(PeriodType));


            if (ruleJobs.Any(c => c.ReminderRuleId == ruleItem.Id && c.ScheduledDate == scheduleDate))
                continue;

            ruleJobList.AddRange(companies.Select(companyItem => new ReminderRuleJob
            {
                CompanyId = companyItem.Id,
                ReminderRuleId = ruleItem.Id,
                Year = nowDate.Year,
                Month = nowDate.Month,
                Quarter = AppConst.Quarters.First(c => c.Value.Contains(nowDate.Month)).Key,
                CreatedDate = nowDate,
                ScheduledDate = scheduleDate,
                CompareScheduleDate = compareScheduleDate,
                JobStatus = (int)JobStatus.Created,
                CompletedDate = null
            }));

            if (ruleItem.PeriodType == (int)PeriodType.Quarterly && scheduleDateIsNextQuarter)
            {
                ruleJobList.AddRange(companies.Select(companyItem => new ReminderRuleJob
                {
                    CompanyId = companyItem.Id,
                    ReminderRuleId = ruleItem.Id,
                    Year = nowDate.Year,
                    Month = nowDate.Month,
                    Quarter = AppConst.Quarters.First(c => c.Value.Contains(nowDate.Month)).Key,
                    CreatedDate = nowDate,
                    ScheduledDate = scheduleDate,
                    CompareScheduleDate = scheduleDate.AddMonths(-13),
                    JobStatus = (int)JobStatus.Created,
                    CompletedDate = null
                }));
            }
        }

        if (ruleJobList.Count > 0)
        {
            var create = await _reminderRuleJobRepository.AddRangeAsync(ruleJobList, cancellationToken);
            if (!create)
                throw new CreateOperationException(nameof(ReminderRuleJob), ruleJobList);

            var updated = await _reminderRuleRepository.UpdateRangeAsync(rules, cancellationToken);
            if (!updated)
                throw new UpdateOperationException(nameof(ReminderRule), rules);
        }

        var resultMap = ManuelMappingUtilities.SetMapping(ruleJobList, companies, rules, mainAccounts, accountGroups);
        return GenericResult<List<ReminderRuleJobDto>>.Success(resultMap);
    }



}