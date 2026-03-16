using FinanceCheckUp.Application.Dtos.BgServer.AccountGroups;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;

namespace FinanceCheckUp.Application.Features.BaseApp.Reminder.AccountGroup.Query.GetListAccountGroup;

public class GetListAccountGroupQuery : IRequest<GenericResult<List<ReminderAccountGroupDto>>>
{
}