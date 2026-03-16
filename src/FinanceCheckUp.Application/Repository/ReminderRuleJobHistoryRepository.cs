using FinanceCheckUp.Application.Common.Constants;
using FinanceCheckUp.Application.Contexts.Concretes.Databases;
using FinanceCheckUp.Domain.Common.Enums;
using FinanceCheckUp.Domain.Common.Utilities;
using FinanceCheckUp.Domain.Entities.BgServer;
using FinanceCheckUp.Framework.Data.MsSql.Repositories;
using FinanceCheckUp.Infrastructure.Repository;

namespace FinanceCheckUp.Application.Repository;

public class ReminderRuleJobHistoryRepository(FinanceCheckUpDbContext dbContext) : GenericBaseRepository<ReminderRuleJobHistory, long>(dbContext), IReminderRuleJobHistoryRepository
{
    public async Task<bool> AddOrUpdate(
        long reminderRuleJobId,
        decimal controlValue,
        decimal compareValue,
        ReminderRule reminderRule,
        ReminderRuleJob reminderRuleJob,
        long sourceTableControlValueId,
        long sourceTableCalculateValueId,
        long id = 0)
    {
        try
        {
            var model = CalculateModel(reminderRuleJobId, controlValue, compareValue, reminderRule, reminderRuleJob, id, sourceTableControlValueId, sourceTableCalculateValueId);
            if (model is { Id: 0 })
            {
                await dbContext.ReminderRuleJobHistories.AddAsync(model);
                await dbContext.SaveChangesAsync();
                return true;
            }

            dbContext.ReminderRuleJobHistories.Update(model);
            await dbContext.SaveChangesAsync();
            return true;


        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return false;
        }
    }
    private static ReminderRuleJobHistory CalculateModel(long reminderRuleJobId,
                                                         decimal controlValue,
                                                         decimal compareValue,
                                                         ReminderRule reminderRule,
                                                         ReminderRuleJob reminderRuleJob,
                                                         long id,
                                                         long sourceTableControlValueId,
                                                         long sourceTableCalculateValueId)
    {
        var differentValue = controlValue - compareValue;
        var differentPercentage = ((controlValue - compareValue) / controlValue) * 100;
        var lastDifferent = Math.Round(differentPercentage < 0 ? differentPercentage * -1 : differentPercentage, 2);

        var isExplanation = reminderRule.ControlValueType == (int)ControlValueType.Decrease && lastDifferent <= reminderRule.ControlValue && differentValue < 0
                            || reminderRule.ControlValueType == (int)ControlValueType.Increment && lastDifferent >= reminderRule.ControlValue && differentValue > 0;

        var model = new ReminderRuleJobHistory
        {
            ReminderRuleJobId = reminderRuleJobId,
            ControlValue = controlValue,
            CalculateValue = compareValue,
            DifferentValue = differentValue,
            DifferentPercentage = lastDifferent,
            CreatedDate = DateTime.Now,
            IsNotify = isExplanation,
            Explanation = isExplanation ? SetExplanation(lastDifferent, reminderRule, reminderRuleJob) : string.Empty,
            SourceTableControlValueId = sourceTableControlValueId,
            SourceTableCalculateValueId = sourceTableCalculateValueId
        };

        if (id == 0)
            return model;

        model.Id = id;
        model.UpdatedDate = DateTime.Now;

        return model;
    }

    private static string SetExplanation(decimal diff, ReminderRule reminderRule, ReminderRuleJob reminderRuleJob)
    {
        return reminderRule.PeriodType switch
        {
            (int)PeriodType.Monthly => $"{reminderRuleJob.CompareScheduleDate?.Year} {AppConst.MonthsForTurkish.FirstOrDefault(c => c.Key == reminderRuleJob.CompareScheduleDate?.Month).Value} ayı ile {reminderRuleJob.CreatedDate.Year} {AppConst.MonthsForTurkish.FirstOrDefault(c => c.Key == reminderRuleJob.CreatedDate.Month).Value} ayı arasında  %{diff} oranında {((ControlValueType)reminderRule.ControlValueType).GetDescription()}.",
            (int)PeriodType.Quarterly => $"{reminderRuleJob.CompareScheduleDate?.Year} yılı,{reminderRuleJob.CompareScheduleDate?.Month.ToString()} kümülatif dönem ile {reminderRuleJob.CreatedDate.Year} senesi {AppConst.Months.FirstOrDefault(c => c.Key == reminderRuleJob.CreatedDate.Month).Value} kümülatif dönemine  göre %{diff} oranında {((ControlValueType)reminderRule.ControlValueType).GetDescription()}.Detaylı olarak incelenmesi önerilir.",
            (int)PeriodType.Yearly => $"{reminderRuleJob.CompareScheduleDate?.Year} yılı ile {reminderRuleJob.CreatedDate.Year} yılı arasında %{diff} oranında {((ControlValueType)reminderRule.ControlValueType).GetDescription()}.Detaylı olarak incelenmesi önerilir.",
            _ => throw new ArgumentOutOfRangeException(nameof(reminderRule.PeriodType), reminderRule.PeriodType, "Invalid PeriodType")
        };
    }

    public Task<bool> AddOrUpdate(long reminderRuleJobId, decimal controlValue, MultipartFormDataContent compareValue,
        ReminderRule reminderRule, ReminderRuleJob reminderRuleJob, long sourceTableControlValueId,
        long sourceTableCalculateValueId, long id = 0)
    {
        throw new NotImplementedException();
    }
}