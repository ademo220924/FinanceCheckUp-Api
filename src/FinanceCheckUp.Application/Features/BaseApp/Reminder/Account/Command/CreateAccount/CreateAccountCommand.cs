using FinanceCheckUp.Application.Models.Requests.Reminder.Account;
using FinanceCheckUp.Domain.Common.Enums;
using FinanceCheckUp.Domain.Dtos.BgServer.Accounts;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using Swashbuckle.AspNetCore.Filters;

namespace FinanceCheckUp.Application.Features.BaseApp.Reminder.Account.Command.CreateAccount;

public class CreateAccountCommand : IRequest<GenericResult<ReminderAccountDto>>
{
    public ReminderAccountCreateRequest Model { get; set; }
}

public class CreateMainAccountCommandExample : IExamplesProvider<CreateAccountCommand>
{
    public CreateAccountCommand GetExamples()
    {
        return new CreateAccountCommand
        {
            Model = new ReminderAccountCreateRequest
            {
                Name = "Arazi ve Arsalar",
                StartValue = 250,
                FinishValue = 250,
                AccountGroupId = 1,
                AccountType = (int)AccountType.BalanceMainAccount
            }
        };
    }
}