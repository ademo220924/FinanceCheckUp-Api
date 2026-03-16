using FinanceCheckUp.Application.Dtos.BgServer.AccountGroups;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;

namespace FinanceCheckUp.Application.Features.BaseApp.Reminder.AccountGroup.Query.GetByIdAccountGroup;

public class GetByIdAccountGroupQuery : IRequest<GenericResult<ReminderAccountGroupDto>>
{
    public GetByIdAccountGroupQuery(long id)
    {
        Id = id;
    }

    public long Id { get; set; }
}