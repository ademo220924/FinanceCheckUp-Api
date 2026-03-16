using AutoMapper;
using FinanceCheckUp.Domain.Dtos.BgServer.Accounts;
using FinanceCheckUp.Domain.Entities.BgServer;
using FinanceCheckUp.Framework.Core.Exceptions;
using FinanceCheckUp.Framework.Core.Models;
using FinanceCheckUp.Framework.Data;
using MediatR;

namespace FinanceCheckUp.Application.Features.BaseApp.Reminder.Account.Query.GetByIdAccount;

public class GetByIdAccountQueryHandle(
    IGenericRepository<ReminderAccount, long> reminderAccountRepository,
    IGenericRepository<ReminderAccountGroup, long> reminderAccountGroupRepository,
    IMapper mapper)
    : IRequestHandler<GetByIdAccountQuery, GenericResult<ReminderAccountDto>>
{
    private readonly IGenericRepository<ReminderAccount, long> _reminderAccountRepository = reminderAccountRepository ?? throw new ArgumentNullException(nameof(reminderAccountRepository));
    private readonly IGenericRepository<ReminderAccountGroup, long> _reminderAccountGroupRepository = reminderAccountGroupRepository ?? throw new ArgumentNullException(nameof(reminderAccountGroupRepository));
    private readonly IMapper _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));

    public async Task<GenericResult<ReminderAccountDto>> Handle(GetByIdAccountQuery request, CancellationToken cancellationToken)
    {
        var account = await _reminderAccountRepository.GetAsync(c => c.Id.Equals(request.Id), cancellationToken);
        if (account == null)
            throw new NotFoundException(request.Id.ToString(), nameof(Account));
        var accountDto = _mapper.Map<ReminderAccountDto>(account);

        var accountGroup = await _reminderAccountGroupRepository.GetAsync(c => c.Id == accountDto.AccountGroupId, cancellationToken);
        if (accountGroup == null)
            throw new NotFoundException(request.Id.ToString(), nameof(AccountGroup));


        accountGroup.Name = accountGroup.Name;
        return GenericResult<ReminderAccountDto>.Success(accountDto);
    }
}