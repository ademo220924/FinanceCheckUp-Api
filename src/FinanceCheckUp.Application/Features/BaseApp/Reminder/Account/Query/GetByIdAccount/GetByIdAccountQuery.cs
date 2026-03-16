using FinanceCheckUp.Domain.Dtos.BgServer.Accounts;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;

namespace FinanceCheckUp.Application.Features.BaseApp.Reminder.Account.Query.GetByIdAccount;

public class GetByIdAccountQuery(long id) : IRequest<GenericResult<ReminderAccountDto>>
{
    public long Id { get; set; } = id;
}