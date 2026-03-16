using AutoMapper;
using FinanceCheckUp.Application.Dtos.BgServer.Rules;
using FinanceCheckUp.Domain.Common.Enums;
using FinanceCheckUp.Domain.Common.Utilities;
using FinanceCheckUp.Domain.Entities.BgServer;
using FinanceCheckUp.Framework.Core.Exceptions;
using FinanceCheckUp.Framework.Core.Models;
using FinanceCheckUp.Framework.Data;
using MediatR;

namespace FinanceCheckUp.Application.Features.BaseApp.Reminder.Rule.Query.GetByIdRule;

public class GetByIdQueryHandle(
    IGenericRepository<ReminderRule, long> reminderRuleRepository,
    IMapper mapper,
    IGenericRepository<ReminderAccount, long> accountRepository)
    : IRequestHandler<GetByIdQuery, GenericResult<RemainderRuleDto>>
{
    private readonly IGenericRepository<ReminderRule, long> _reminderRuleRepository = reminderRuleRepository ?? throw new ArgumentNullException(nameof(reminderRuleRepository));
    private readonly IMapper _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    private readonly IGenericRepository<ReminderAccount, long> _accountRepository = accountRepository ?? throw new ArgumentNullException(nameof(accountRepository));


    public async Task<GenericResult<RemainderRuleDto>> Handle(GetByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _reminderRuleRepository.GetAsync(c => c.Id.Equals(request.ID), cancellationToken);
        if (entity == null)
            return GenericResult<RemainderRuleDto>.Success(default!);

        var dto = _mapper.Map<RemainderRuleDto>(entity);
        var accountInfo = await _accountRepository.GetAsync(c => c.Id.Equals(dto.AccountId), cancellationToken);
        if (accountInfo == null)
            throw new NotFoundException(nameof(ReminderAccount), request.ID.ToString());

        dto.AccountName = accountInfo.Name;
        dto.AccountType = (AccountType)accountInfo.AccountType;
        dto.StartValue = accountInfo.StartValue;
        dto.FinishValue = accountInfo.FinishValue;
        dto.AccountTypeText = ((AccountType)accountInfo.AccountType).GetDescription();

        return GenericResult<RemainderRuleDto>.Success(dto);
    }
}