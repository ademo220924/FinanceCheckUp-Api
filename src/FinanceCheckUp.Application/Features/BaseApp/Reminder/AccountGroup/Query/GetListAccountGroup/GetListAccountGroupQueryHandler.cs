using AutoMapper;
using FinanceCheckUp.Application.Dtos.BgServer.AccountGroups;
using FinanceCheckUp.Domain.Entities.BgServer;
using FinanceCheckUp.Framework.Core.Models;
using FinanceCheckUp.Framework.Data;
using MediatR;

namespace FinanceCheckUp.Application.Features.BaseApp.Reminder.AccountGroup.Query.GetListAccountGroup;

public class GetByIdAccountGroupQueryHandle(
    IGenericRepository<ReminderAccountGroup, long> reminderAccountGroupRepository,
    IMapper mapper) : IRequestHandler<GetListAccountGroupQuery, GenericResult<List<ReminderAccountGroupDto>>>
{
    private readonly IGenericRepository<ReminderAccountGroup, long> _reminderAccountGroupRepository = reminderAccountGroupRepository ?? throw new ArgumentNullException(nameof(reminderAccountGroupRepository));
    private readonly IMapper _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));


    public async Task<GenericResult<List<ReminderAccountGroupDto>>> Handle(GetListAccountGroupQuery request, CancellationToken cancellationToken)
    {
        var entities = await _reminderAccountGroupRepository.GetListAsync(cancellationToken: cancellationToken);
        var dto = _mapper.Map<List<ReminderAccountGroupDto>>(entities);
        return GenericResult<List<ReminderAccountGroupDto>>.Success(dto);
    }
}