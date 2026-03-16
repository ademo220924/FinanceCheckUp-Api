using FinanceCheckUp.Application.Dtos.BgServer.Rules;
using FinanceCheckUp.Domain.Common.Enums;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;

namespace FinanceCheckUp.Application.Features.BaseApp.Reminder.Rule.Query.GetByPeriodTypeRules;

public class GetByPeriodTypeRuleQuery(PeriodType periodType) : IRequest<GenericResult<List<RemainderRuleDto>>>
{
    public PeriodType PeriodType { get; set; } = periodType;
}