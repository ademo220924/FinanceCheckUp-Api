using FinanceCheckUp.Application.Common.Constants;
using FinanceCheckUp.Domain.Common.Enums;
using FinanceCheckUp.Domain.Entities;
using FinanceCheckUp.Domain.Entities.BgServer;
using FinanceCheckUp.Framework.Data;
using FinanceCheckUp.Infrastructure.Repository;
using MediatR;
using System.Globalization;

namespace FinanceCheckUp.Application.Features.BaseApp.Reminder.RuleJob.Command.Compare;

public class CompareRemainderRuleJobCommandHandle(
    IGenericRepository<ReminderRule, long> reminderRuleRepository,
    IGenericRepository<ReminderRuleJob, long> reminderRuleJobRepository,
    IReminderRuleJobHistoryRepository reminderRuleJobHistoryRepository,
    ICompanyRepository companyRepository,
    IGenericRepository<ReminderAccount, long> reminderAccountRepository,
    IGenericRepository<TblmrevenueRasT, long> tblmRevenueRasTRepository,
    IGenericRepository<TblmsampleBlncoRasT, long> tblmSampleBlncoRasTRepository,
    DateTime nowDate)
    : IRequestHandler<CompareRemainderRuleJobCommand, bool>
{
    private readonly IGenericRepository<ReminderRule, long> _reminderRuleRepository = reminderRuleRepository ?? throw new ArgumentNullException(nameof(reminderRuleRepository));
    private readonly IGenericRepository<ReminderRuleJob, long> _reminderRuleJobRepository = reminderRuleJobRepository ?? throw new ArgumentNullException(nameof(reminderRuleJobRepository));
    private readonly IReminderRuleJobHistoryRepository _reminderRuleJobHistoryRepository = reminderRuleJobHistoryRepository ?? throw new ArgumentNullException(nameof(reminderRuleJobHistoryRepository));
    private readonly ICompanyRepository _companyRepository = companyRepository ?? throw new ArgumentNullException(nameof(companyRepository));
    private readonly IGenericRepository<ReminderAccount, long> _reminderAccountRepository = reminderAccountRepository ?? throw new ArgumentNullException(nameof(reminderAccountRepository));
    private readonly IGenericRepository<TblmrevenueRasT, long> _tblmRevenueRasTRepository = tblmRevenueRasTRepository ?? throw new ArgumentNullException(nameof(tblmRevenueRasTRepository));
    private readonly IGenericRepository<TblmsampleBlncoRasT, long> _tblmSampleBlncoRasTRepository = tblmSampleBlncoRasTRepository ?? throw new ArgumentNullException(nameof(tblmSampleBlncoRasTRepository));


    public async Task<bool> Handle(CompareRemainderRuleJobCommand request, CancellationToken cancellationToken)
    {
        nowDate = new DateTime(2022, 3, 1, 0, 0, 0); //DateTime.Now; //
        if (nowDate.Day != 1)
            return await Task.FromResult(false);

        var ruleJobs = await _reminderRuleJobRepository
                                               .GetListAsync(c => (c.Year == nowDate.AddDays(-1).Year && c.Month == nowDate.AddDays(-1).Month)
                                                                                   || c.JobStatus == (int)JobStatus.Retried, cancellationToken);
        if (ruleJobs.Count == 0)
            return await Task.FromResult(false);

        var jobResult = false;
        foreach (var ruleJob in ruleJobs)
        {
            #region data cek
            var reminderRuleItem = await _reminderRuleRepository.GetAsync(r => r.Id == ruleJob.ReminderRuleId, cancellationToken);
            if (reminderRuleItem == null)
                continue;

            var accountMain = await _reminderAccountRepository.GetAsync(a => a.Id.Equals(reminderRuleItem.AccountId), cancellationToken);
            if (accountMain == null)
                continue;

            var company = await _companyRepository.GetAsync(a => a.Id.Equals(ruleJob.CompanyId), cancellationToken);
            if (company == null)
                continue;

            #endregion

            jobResult = accountMain.AccountType switch
            {
                (int)AccountType.BalanceMainAccount => await BalanceMainAccountBeforeAndNowValuesCompareAsync(ruleJob, reminderRuleItem, accountMain, company, nowDate),
                (int)AccountType.BalanceType => await BalanceTypeBeforeAndNowValuesCompareAsync(ruleJob, reminderRuleItem, accountMain, company, nowDate),
                (int)AccountType.RevenueMainAccount => await RevenueMainAccountBeforeAndNowValuesCompareAsync(ruleJob, reminderRuleItem, accountMain, company, nowDate),
                (int)AccountType.RevenueType => await RevenueTypeBeforeAndNowValuesCompareAsync(ruleJob, reminderRuleItem, accountMain, company, nowDate),
                _ => jobResult
            };

            if (jobResult)
            {
                ruleJob.CompletedDate = DateTime.Now;
                await _reminderRuleJobRepository.UpdateAsync(ruleJob);
            }
        }
        return await Task.FromResult(jobResult);
    }

    private async Task<bool> RevenueTypeBeforeAndNowValuesCompareAsync(ReminderRuleJob ruleJob, ReminderRule reminderRuleItem, ReminderAccount account, Domain.Entities.Company company, DateTime workOnJobDate)
    {
        var checkData = await _tblmRevenueRasTRepository
                                                   .GetAsync(c => c.CompanyId == company.Id
                                                                                   && c.Year == ruleJob.Year
                                                                                   && c.TypeId == account.StartValue);
        if (checkData == null)
            return await SetRetryAsync(ruleJob);

        var controlValue = (decimal)(checkData[AppConst.Months.FirstOrDefault(c => c.Key.Equals(ruleJob.Month)).Value] ?? throw new InvalidOperationException());
        if (controlValue == 0 || string.IsNullOrEmpty(controlValue.ToString(CultureInfo.InvariantCulture)))
            return await SetRetryAsync(ruleJob);


        var compareData = ruleJob.CompareScheduleDate.HasValue && ruleJob.CompareScheduleDate.Value.Year == ruleJob.Year
                                            ? checkData
                                            : await _tblmRevenueRasTRepository
                                                     .GetAsync(c => c.CompanyId.Equals(company.Id)
                                                                                     && ruleJob.CompareScheduleDate.HasValue
                                                                                     && c.Year.Equals(ruleJob.CompareScheduleDate.Value.Year)
                                                                                     && c.TypeId.Equals(account.StartValue));

        if (compareData == null)
            return await SetRetryAsync(ruleJob);

        var compareValue = (decimal)(compareData[AppConst.Months.FirstOrDefault(c => ruleJob.CompareScheduleDate.HasValue && c.Key.Equals(ruleJob.CompareScheduleDate.Value.Month)).Value] ?? throw new InvalidOperationException());
        if (compareValue == 0 || string.IsNullOrEmpty(compareValue.ToString(CultureInfo.InvariantCulture)))
            return await SetRetryAsync(ruleJob);

        if (reminderRuleItem.LastGenerateDate != workOnJobDate)
        {
            reminderRuleItem.LastGenerateDate = workOnJobDate;
            await _reminderRuleRepository.UpdateAsync(reminderRuleItem);
        }

        if (ruleJob.JobStatus != (int)JobStatus.Completed)
            await SetComplete(ruleJob);

        var history = await _reminderRuleJobHistoryRepository.GetAsync(c => c.ReminderRuleJobId == ruleJob.Id);
        return await _reminderRuleJobHistoryRepository.AddOrUpdate(reminderRuleJobId: ruleJob.Id,
                                                                   controlValue: controlValue,
                                                                   compareValue: compareValue,
                                                                   reminderRuleItem,
                                                                   ruleJob,
                                                                   sourceTableControlValueId: checkData.Id,
                                                                   sourceTableCalculateValueId: compareData.Id,
                                                                   history?.Id ?? 0);
    }

    private async Task<bool> BalanceTypeBeforeAndNowValuesCompareAsync(ReminderRuleJob ruleJob, ReminderRule reminderRuleItem, ReminderAccount account, Domain.Entities.Company company, DateTime workOnJobDate)
    {
        var checkData = await _tblmSampleBlncoRasTRepository
                                                  .GetAsync(c => c.CompanyId == company.Id
                                                                                     && c.Year == ruleJob.Year
                                                                                     && c.TypeId == account.StartValue);
        if (checkData == null)
            return await SetRetryAsync(ruleJob);

        var checkValue = (decimal)(checkData[AppConst.Months.FirstOrDefault(c => c.Key.Equals(ruleJob.Month)).Value] ?? throw new InvalidOperationException());
        if (checkValue == 0 || string.IsNullOrEmpty(checkValue.ToString(CultureInfo.InvariantCulture)))
            return await SetRetryAsync(ruleJob);

        var compareData = ruleJob.CompareScheduleDate.HasValue && ruleJob.CompareScheduleDate.Value.Year == ruleJob.Year
            ? checkData
            : await _tblmSampleBlncoRasTRepository
                    .GetAsync(c => c.CompanyId == company.Id
                                                       && ruleJob.CompareScheduleDate.HasValue
                                                       && c.Year == ruleJob.CompareScheduleDate.Value.Year
                                                       && c.TypeId == account.StartValue);

        if (compareData == null)
            return await SetRetryAsync(ruleJob);

        var compareValue = (decimal)((compareData[AppConst.Months.FirstOrDefault(c => ruleJob.CompareScheduleDate.HasValue && c.Key.Equals(ruleJob.CompareScheduleDate.Value.Month)).Value]) ?? throw new InvalidOperationException());
        if (compareValue == 0 || string.IsNullOrEmpty(compareValue.ToString(CultureInfo.InvariantCulture)))
            return await SetRetryAsync(ruleJob);

        if (reminderRuleItem.LastGenerateDate != workOnJobDate)
        {
            reminderRuleItem.LastGenerateDate = workOnJobDate;
            await _reminderRuleRepository.UpdateAsync(reminderRuleItem);
        }

        if (ruleJob.JobStatus != (int)JobStatus.Completed)
            await SetComplete(ruleJob);

        var history = await _reminderRuleJobHistoryRepository.GetAsync(c => c.ReminderRuleJobId == ruleJob.Id);
        return await _reminderRuleJobHistoryRepository.AddOrUpdate(ruleJob.Id, Convert.ToDecimal(checkValue), Convert.ToDecimal(compareValue), reminderRuleItem, ruleJob, checkData.Id, compareData.Id, history?.Id ?? 0);

    }

    private async Task<bool> RevenueMainAccountBeforeAndNowValuesCompareAsync(ReminderRuleJob ruleJob, ReminderRule reminderRuleItem, ReminderAccount account, Domain.Entities.Company company, DateTime workOnJobDate)
    {
        var checkData = await _tblmRevenueRasTRepository
                                               .GetAsync(c => c.CompanyId == company.Id
                                                                               && c.Year == ruleJob.Year
                                                                               && c.AccountMainId == account.StartValue.ToString());
        if (checkData == null)
            return await SetRetryAsync(ruleJob);

        var controlValue = (decimal)(checkData[AppConst.Months.FirstOrDefault(c => c.Key.Equals(ruleJob.Month)).Value] ?? throw new InvalidOperationException());
        if (controlValue == 0 || string.IsNullOrEmpty(controlValue.ToString(CultureInfo.InvariantCulture)))
            return await SetRetryAsync(ruleJob);


        var compareData = ruleJob.CompareScheduleDate.HasValue && ruleJob.CompareScheduleDate.Value.Year == ruleJob.Year
                                            ? checkData
                                            : await _tblmRevenueRasTRepository
                                                     .GetAsync(c => c.CompanyId.Equals(company.Id)
                                                                                     && ruleJob.CompareScheduleDate.HasValue
                                                                                     && c.Year.Equals(ruleJob.CompareScheduleDate.Value.Year)
                                                                                     && c.AccountMainId.Equals(account.StartValue.ToString()));

        if (compareData == null)
            return await SetRetryAsync(ruleJob);

        var compareValue = (decimal)(compareData[AppConst.Months.FirstOrDefault(c => ruleJob.CompareScheduleDate.HasValue && c.Key.Equals(ruleJob.CompareScheduleDate.Value.Month)).Value] ?? throw new InvalidOperationException());
        if (compareValue == 0 || string.IsNullOrEmpty(compareValue.ToString(CultureInfo.InvariantCulture)))
            return await SetRetryAsync(ruleJob);

        if (reminderRuleItem.LastGenerateDate != workOnJobDate)
        {
            reminderRuleItem.LastGenerateDate = workOnJobDate;
            await _reminderRuleRepository.UpdateAsync(reminderRuleItem);
        }

        if (ruleJob.JobStatus != (int)JobStatus.Completed)
            await SetComplete(ruleJob);

        var history = await _reminderRuleJobHistoryRepository.GetAsync(c => c.ReminderRuleJobId == ruleJob.Id);
        return await _reminderRuleJobHistoryRepository.AddOrUpdate(ruleJob.Id, controlValue, compareValue, reminderRuleItem, ruleJob, checkData.Id, compareData.Id, history?.Id ?? 0);
    }

    private async Task<bool> BalanceMainAccountBeforeAndNowValuesCompareAsync(ReminderRuleJob ruleJob, ReminderRule reminderRuleItem, ReminderAccount account, Domain.Entities.Company company, DateTime workOnJobDate)
    {
        var checkData = await _tblmSampleBlncoRasTRepository
                                                  .GetAsync(c => c.CompanyId == company.Id
                                                                                     && c.Year == ruleJob.Year
                                                                                     && c.AccountMainId == account.StartValue.ToString());
        if (checkData == null)
            return await SetRetryAsync(ruleJob);

        var checkValue = (decimal)(checkData[AppConst.Months.FirstOrDefault(c => c.Key.Equals(ruleJob.Month)).Value] ?? throw new InvalidOperationException());
        if (checkValue == 0 || string.IsNullOrEmpty(checkValue.ToString(CultureInfo.InvariantCulture)))
            return await SetRetryAsync(ruleJob);

        var compareData = ruleJob.CompareScheduleDate.HasValue && ruleJob.CompareScheduleDate.Value.Year == ruleJob.Year
            ? checkData
            : await _tblmSampleBlncoRasTRepository
                    .GetAsync(c => c.CompanyId == company.Id
                                                       && ruleJob.CompareScheduleDate.HasValue
                                                       && c.Year == ruleJob.CompareScheduleDate.Value.Year
                                                       && c.AccountMainId == account.StartValue.ToString());

        if (compareData == null)
            return await SetRetryAsync(ruleJob);

        var compareValue = (decimal)(compareData[AppConst.Months.FirstOrDefault(c => ruleJob.CompareScheduleDate.HasValue && c.Key.Equals(ruleJob.CompareScheduleDate.Value.Month)).Value] ?? throw new InvalidOperationException());
        if (compareValue == 0 || string.IsNullOrEmpty(compareValue.ToString(CultureInfo.InvariantCulture)))
            return await SetRetryAsync(ruleJob);


        if (reminderRuleItem.LastGenerateDate != workOnJobDate)
        {
            reminderRuleItem.LastGenerateDate = workOnJobDate;
            await _reminderRuleRepository.UpdateAsync(reminderRuleItem);
        }

        if (ruleJob.JobStatus != (int)JobStatus.Completed)
            await SetComplete(ruleJob);


        var history = await _reminderRuleJobHistoryRepository.GetAsync(c => c.ReminderRuleJobId == ruleJob.Id);
        return await _reminderRuleJobHistoryRepository.AddOrUpdate(ruleJob.Id, checkValue, compareValue, reminderRuleItem, ruleJob, checkData.Id, compareData.Id, history?.Id ?? 0);
    }

    #region   extensions helper class tası
    private async Task SetComplete(ReminderRuleJob ruleJob)
    {
        ruleJob.JobStatus = (int)JobStatus.Completed;
        ruleJob.CompletedDate = nowDate;
        await _reminderRuleJobRepository.UpdateAsync(ruleJob);
    }
    private async Task<bool> SetRetryAsync(ReminderRuleJob ruleJob)
    {
        ruleJob.JobStatus = (int)JobStatus.Retried;
        await _reminderRuleJobRepository.UpdateAsync(ruleJob);
        return false;
    }
    #endregion
}