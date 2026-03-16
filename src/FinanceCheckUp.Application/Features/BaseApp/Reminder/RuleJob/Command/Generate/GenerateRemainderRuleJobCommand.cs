using FinanceCheckUp.Application.Dtos.BgServer.RuleJobs;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;

namespace FinanceCheckUp.Application.Features.BaseApp.Reminder.RuleJob.Command.Generate;

public class GenerateRemainderRuleJobCommand : IRequest<GenericResult<List<ReminderRuleJobDto>>>
{ }