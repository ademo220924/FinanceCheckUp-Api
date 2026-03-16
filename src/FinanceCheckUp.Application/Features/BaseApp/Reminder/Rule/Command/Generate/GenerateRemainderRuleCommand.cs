using FinanceCheckUp.Application.Dtos.BgServer.Rules;
using FinanceCheckUp.Domain.Entities.BgServer;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;

namespace FinanceCheckUp.Application.Features.BaseApp.Reminder.Rule.Command.Generate;

public class GenerateRemainderRuleCommand : IRequest<GenericResult<List<RemainderRuleDto>>>
{
    public List<ReminderRule> ReminderRules { get; set; }
}