using FinanceCheckUp.Application.Dtos.BgServer.RuleJobs;
using FinanceCheckUp.Application.Models.Requests.Reminder;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;

namespace FinanceCheckUp.Application.Features.BaseApp.Reminder.RuleJob.Query.GetListByCompanyAndAccountId;

public class GetListByCompanyAndAccountIdQuery : IRequest<GenericResult<List<ReminderRuleJobDto>>>
{
    public GetListByCompanyAndMainAccountIdRequest Model { get; set; }
}