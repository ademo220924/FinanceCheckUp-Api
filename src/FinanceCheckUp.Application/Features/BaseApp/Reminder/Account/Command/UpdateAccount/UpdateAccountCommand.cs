using FinanceCheckUp.Application.Models.Requests.Reminder.Account;
using FinanceCheckUp.Domain.Common.Enums;
using FinanceCheckUp.Domain.Dtos.BgServer.Accounts;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using Swashbuckle.AspNetCore.Filters;

namespace FinanceCheckUp.Application.Features.BaseApp.Reminder.Account.Command.UpdateAccount;

public class UpdateAccountCommand : IRequest<GenericResult<ReminderAccountDto>>
{
    public ReminderAccountUpdateRequest Model { get; set; }
}

public class UpdateMainAccountCommandExample : IExamplesProvider<UpdateAccountCommand>
{
    public UpdateAccountCommand GetExamples()
    {
        return new UpdateAccountCommand
        {
            Model = new ReminderAccountUpdateRequest
            {
                Id = 3,
                Name = "Arazi ve Arsalar",
                StartValue = 250,
                FinishValue = 250,
                AccountGroupId = 1,
                AccountType = (int)AccountType.BalanceMainAccount
            }

        };
    }
}
