using FinanceCheckUp.Application.Dtos.BgServer.AccountGroups;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using Swashbuckle.AspNetCore.Filters;

namespace FinanceCheckUp.Application.Features.BaseApp.Reminder.AccountGroup.Command.UpdateAccountGroup;

public class UpdateAccountGroupCommand : IRequest<GenericResult<ReminderAccountGroupDto>>
{
    public string Name { get; set; }
    public long Id { get; set; }
}

public class UpdateAccountGroupCommandExample : IExamplesProvider<UpdateAccountGroupCommand>
{
    public UpdateAccountGroupCommand GetExamples()
    {
        return new UpdateAccountGroupCommand
        {
            Id = 3,
            Name = "Name"
        };
    }
}