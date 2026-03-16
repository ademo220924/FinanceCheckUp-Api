using FinanceCheckUp.Application.Dtos.BgServer.Rules;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;

namespace FinanceCheckUp.Application.Features.BaseApp.Reminder.Rule.Query.GetListRules;

public class GetListRuleQuery : IRequest<GenericResult<List<RemainderRuleDto>>>
{
}