using FinanceCheckUp.Application.Dtos.BgServer.RuleJobs;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;

namespace FinanceCheckUp.Application.Features.BaseApp.Reminder.RuleJob.Query.GetListByCompanyId;

public class GetListByCompanyIdQuery : IRequest<GenericResult<List<ReminderRuleJobDto>>>
{
    public GetListByCompanyIdQuery(long companyId)
    {
        CompanyId = companyId;
    }
    public long CompanyId { get; set; }
}