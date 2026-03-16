using FinanceCheckUp.Domain.Common.Enums;
using FinanceCheckUp.Domain.Dtos.BgServer.Accounts;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;

namespace FinanceCheckUp.Application.Features.BaseApp.Reminder.Account.Query.GetListByAccountType;

public class GetListByAccountTypeQuery(AccountType accountType) : IRequest<GenericResult<List<ReminderAccountDto>>>
{
    public AccountType AccountType { get; set; } = accountType;
}