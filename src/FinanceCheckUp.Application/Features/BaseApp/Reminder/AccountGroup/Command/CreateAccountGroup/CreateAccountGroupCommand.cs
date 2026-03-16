using FinanceCheckUp.Application.Dtos.BgServer.AccountGroups;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using Swashbuckle.AspNetCore.Filters;

namespace FinanceCheckUp.Application.Features.BaseApp.Reminder.AccountGroup.Command.CreateAccountGroup;

public class CreateAccountGroupCommand : IRequest<GenericResult<ReminderAccountGroupDto>>
{
    public string Name { get; set; }
}

public class CreateAccountGroupCommandExample : IExamplesProvider<CreateAccountGroupCommand>
{
    public CreateAccountGroupCommand GetExamples()
    {
        return new CreateAccountGroupCommand
        {
            Name = "Name"
        };
    }
}