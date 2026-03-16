using AutoMapper;
using FinanceCheckUp.Application.Dtos.BgServer.AccountGroups;
using FinanceCheckUp.Domain.Entities.BgServer;
using FinanceCheckUp.Framework.Core.Exceptions;
using FinanceCheckUp.Framework.Core.Models;
using FinanceCheckUp.Framework.Data;
using MediatR;

namespace FinanceCheckUp.Application.Features.BaseApp.Reminder.AccountGroup.Query.GetByIdAccountGroup;

public class GetByIdAccountGroupQueryHandle(
    IGenericRepository<ReminderAccountGroup, long> reminderAccountGroupRepository,
    IMapper mapper) : IRequestHandler<GetByIdAccountGroupQuery, GenericResult<ReminderAccountGroupDto>>
{
    private readonly IGenericRepository<ReminderAccountGroup, long> _reminderAccountGroupRepository = reminderAccountGroupRepository ?? throw new ArgumentNullException(nameof(reminderAccountGroupRepository));
    private readonly IMapper _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));


    public async Task<GenericResult<ReminderAccountGroupDto>> Handle(GetByIdAccountGroupQuery request, CancellationToken cancellationToken)
    {
        var accountGroup = await _reminderAccountGroupRepository.GetAsync(c => c.Id.Equals(request.Id), cancellationToken);
        if (accountGroup == null)
            throw new NotFoundException(request.Id.ToString(), nameof(AccountGroup));


        var dto = _mapper.Map<ReminderAccountGroupDto>(accountGroup);
        return GenericResult<ReminderAccountGroupDto>.Success(dto);
    }
}