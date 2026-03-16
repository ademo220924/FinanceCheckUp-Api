using FinanceCheckUp.Application.Dtos.BgServer.Rules;
using FinanceCheckUp.Application.Models.Requests.Reminder;
using FinanceCheckUp.Domain.Common.Enums;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;

namespace FinanceCheckUp.Application.Features.BaseApp.Reminder.Rule.Command.CreateRemainderRule;

public class CreateRemainderRuleCommand : IRequest<GenericResult<RemainderRuleDto>>
{
    public CreateRemainderRuleRequest Model { get; set; }
}