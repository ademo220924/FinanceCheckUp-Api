using AutoMapper;
using FinanceCheckUp.Domain.Dtos.BgServer.Accounts;
using FinanceCheckUp.Domain.Entities.BgServer;
using FinanceCheckUp.Framework.Core.Models;
using FinanceCheckUp.Framework.Data;
using MediatR;

namespace FinanceCheckUp.Application.Features.BaseApp.Reminder.Account.Query.GetListByAccountType;

public class GetListByAccountTypeQueryHandle(
    IGenericRepository<ReminderAccount, long> reminderAccountRepository,
    IGenericRepository<ReminderAccountGroup, long> reminderAccountGroupRepository,
    IMapper mapper)
    : IRequestHandler<GetListByAccountTypeQuery, GenericResult<List<ReminderAccountDto>>>
{
    private readonly IGenericRepository<ReminderAccount, long> _reminderAccountRepository = reminderAccountRepository ?? throw new ArgumentNullException(nameof(reminderAccountRepository));
    private readonly IGenericRepository<ReminderAccountGroup, long> _reminderAccountGroupRepository = reminderAccountGroupRepository ?? throw new ArgumentNullException(nameof(reminderAccountGroupRepository));
    private readonly IMapper _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));

    public async Task<GenericResult<List<ReminderAccountDto>>> Handle(GetListByAccountTypeQuery request,
        CancellationToken cancellationToken)
    {
        var accounts = await _reminderAccountRepository.GetListAsync(c => c.AccountType.Equals(request.AccountType), cancellationToken);
        var accountGroups = await _reminderAccountGroupRepository.GetListAsync(cancellationToken: cancellationToken);
        var dtoList = _mapper.Map<List<ReminderAccountDto>>(accounts);
        dtoList.ForEach(ac => ac.AccountGroupName = accountGroups.FirstOrDefault(acg => acg.Id.Equals(ac.AccountGroupId))?.Name);
        return GenericResult<List<ReminderAccountDto>>.Success(dtoList);
    }
}