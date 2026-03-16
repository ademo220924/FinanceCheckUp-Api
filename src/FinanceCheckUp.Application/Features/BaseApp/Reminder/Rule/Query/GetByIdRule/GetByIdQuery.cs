using FinanceCheckUp.Application.Dtos.BgServer.Rules;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;

namespace FinanceCheckUp.Application.Features.BaseApp.Reminder.Rule.Query.GetByIdRule;

public class GetByIdQuery : IRequest<GenericResult<RemainderRuleDto>>
{
    public GetByIdQuery(long id)
    {
        ID = id;
    }

    public long ID { get; set; }
}