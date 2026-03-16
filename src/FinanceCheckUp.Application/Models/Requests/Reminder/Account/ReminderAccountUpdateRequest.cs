using FinanceCheckUp.Application.Models.Responses.Reminder.Account;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;

namespace FinanceCheckUp.Application.Models.Requests.Reminder.Account;

public class ReminderAccountUpdateRequest : IRequest<GenericResult<ReminderAccountUpdateResponse>>
{
    public required long Id { get; set; }
    public required string Name { get; set; }

    public int StartValue { get; set; }

    public int FinishValue { get; set; }

    public int AccountGroupId { get; set; }

    public int AccountType { get; set; }
}