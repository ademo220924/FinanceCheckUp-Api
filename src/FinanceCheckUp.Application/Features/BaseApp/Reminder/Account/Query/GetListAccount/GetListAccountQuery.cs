using FinanceCheckUp.Domain.Dtos.BgServer.Accounts;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;

namespace FinanceCheckUp.Application.Features.BaseApp.Reminder.Account.Query.GetListAccount;

public class GetListAccountQuery : IRequest<GenericResult<List<ReminderAccountDto>>>
{
}