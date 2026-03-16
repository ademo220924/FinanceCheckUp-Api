using FinanceCheckUp.Application.Dtos.BgServer.RuleJobs;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;

namespace FinanceCheckUp.Application.Features.BaseApp.Reminder.RuleJob.Command.Create;

public class CreateRemainderRuleJobCommand : IRequest<GenericResult<List<ReminderRuleJobDto>>>
{
    public long RuleId { get; set; }
}