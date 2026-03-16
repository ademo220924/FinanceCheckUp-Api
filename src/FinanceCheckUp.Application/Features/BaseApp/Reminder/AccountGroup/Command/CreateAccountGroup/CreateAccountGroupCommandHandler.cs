using AutoMapper;
using FinanceCheckUp.Application.Dtos.BgServer.AccountGroups;
using FinanceCheckUp.Domain.Entities.BgServer;
using FinanceCheckUp.Framework.Core.Exceptions;
using FinanceCheckUp.Framework.Core.Models;
using FinanceCheckUp.Framework.Data;
using MediatR;

namespace FinanceCheckUp.Application.Features.BaseApp.Reminder.AccountGroup.Command.CreateAccountGroup;

public class CreateAccountGroupCommandHandle(
    IGenericRepository<ReminderAccountGroup, long> reminderAccountGroupRepository,
    IMapper mapper)
    : IRequestHandler<CreateAccountGroupCommand, GenericResult<ReminderAccountGroupDto>>
{
    public async Task<GenericResult<ReminderAccountGroupDto>> Handle(CreateAccountGroupCommand request, CancellationToken cancellationToken)
    {
        var entity = mapper.Map<ReminderAccountGroup>(request);
        var created = await reminderAccountGroupRepository.AddAsync(entity, cancellationToken);
        if (!created)
            throw new CreateOperationException(nameof(ReminderAccountGroup), request);
        var dto = mapper.Map<ReminderAccountGroupDto>(entity);
        return GenericResult<ReminderAccountGroupDto>.Success(dto);
    }
}