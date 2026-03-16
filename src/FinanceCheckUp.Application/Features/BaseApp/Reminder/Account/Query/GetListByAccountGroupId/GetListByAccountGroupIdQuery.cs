using FinanceCheckUp.Domain.Dtos.BgServer.Accounts;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;

namespace FinanceCheckUp.Application.Features.BaseApp.Reminder.Account.Query.GetListByAccountGroupId;

public class GetListByAccountGroupIdQuery(long accountGroupId) : IRequest<GenericResult<List<ReminderAccountDto>>>
{
    public long AccountGroupId { get; set; } = accountGroupId;
}