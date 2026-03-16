using FinanceCheckUp.Application.Dtos.BgServer.RuleJobs;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;

namespace FinanceCheckUp.Application.Features.BaseApp.Reminder.RuleJob.Query.GetByRuleJobId;

public class GetByRuleJobIdQuery : IRequest<GenericResult<ReminderRuleJobDto>>
{
    public GetByRuleJobIdQuery(long id)
    {
        Id = id;
    }
    public long Id { get; set; }
}