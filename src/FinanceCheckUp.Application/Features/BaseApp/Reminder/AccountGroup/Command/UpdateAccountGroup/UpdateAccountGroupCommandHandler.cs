using AutoMapper;
using FinanceCheckUp.Application.Dtos.BgServer.AccountGroups;
using FinanceCheckUp.Domain.Entities.BgServer;
using FinanceCheckUp.Framework.Core.Exceptions;
using FinanceCheckUp.Framework.Core.Models;
using FinanceCheckUp.Framework.Data;
using MediatR;

namespace FinanceCheckUp.Application.Features.BaseApp.Reminder.AccountGroup.Command.UpdateAccountGroup;

public class UpdateAccountGroupCommandHandle(
    IGenericRepository<ReminderAccountGroup, long> reminderAccountGroupRepository,
    IMapper mapper) : IRequestHandler<UpdateAccountGroupCommand, GenericResult<ReminderAccountGroupDto>>
{
    private readonly IGenericRepository<ReminderAccountGroup, long> _reminderAccountGroupRepository = reminderAccountGroupRepository ?? throw new ArgumentNullException(nameof(reminderAccountGroupRepository));
    private readonly IMapper _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));


    public async Task<GenericResult<ReminderAccountGroupDto>> Handle(UpdateAccountGroupCommand request, CancellationToken cancellationToken)
    {
        var entity = _mapper.Map<ReminderAccountGroup>(request);
        var accountGroup = await _reminderAccountGroupRepository.GetAsync(c => c.Id.Equals(request.Id), cancellationToken);
        if (accountGroup == null)
            throw new NotFoundException(request.Id.ToString(), nameof(accountGroup));

        var updated = await _reminderAccountGroupRepository.UpdateAsync(entity, cancellationToken);
        if (!updated)
            throw new UpdateOperationException(nameof(ReminderAccount), request);

        var dto = _mapper.Map<ReminderAccountGroupDto>(entity);
        return GenericResult<ReminderAccountGroupDto>.Success(dto);
    }
}