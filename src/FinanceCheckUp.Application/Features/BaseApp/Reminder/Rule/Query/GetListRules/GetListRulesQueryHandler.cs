using AutoMapper;
using FinanceCheckUp.Application.Dtos.BgServer.Rules;
using FinanceCheckUp.Domain.Common.Enums;
using FinanceCheckUp.Domain.Common.Utilities;
using FinanceCheckUp.Domain.Entities.BgServer;
using FinanceCheckUp.Framework.Core.Exceptions;
using FinanceCheckUp.Framework.Core.Models;
using FinanceCheckUp.Framework.Data;
using MediatR;

namespace FinanceCheckUp.Application.Features.BaseApp.Reminder.Rule.Query.GetListRules;

public class GetListRulesQueryHandle(
    IGenericRepository<ReminderRule, long> reminderRuleRepository,
    IMapper mapper,
    IGenericRepository<ReminderAccount, long> accountRepository) : IRequestHandler<GetListRuleQuery, GenericResult<List<RemainderRuleDto>>>
{
    private readonly IGenericRepository<ReminderRule, long> _reminderRuleRepository = reminderRuleRepository ?? throw new ArgumentNullException(nameof(reminderRuleRepository));
    private readonly IMapper _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    private readonly IGenericRepository<ReminderAccount, long> _accountRepository = accountRepository ?? throw new ArgumentNullException(nameof(accountRepository));


    public async Task<GenericResult<List<RemainderRuleDto>>> Handle(GetListRuleQuery request, CancellationToken cancellationToken)
    {
        var list = await _reminderRuleRepository.GetListAsync(cancellationToken: cancellationToken);
        if (list.Count == 0)
            return GenericResult<List<RemainderRuleDto>>.Success([]);

        var dto = _mapper.Map<List<RemainderRuleDto>>(list);
        var mainAccounts = await _accountRepository.GetListAsync(cancellationToken: cancellationToken);
        if (mainAccounts == null || mainAccounts.Count == 0)
            throw new NotFoundException(nameof(ReminderAccount));


        dto.ForEach(d =>
        {
            var account = mainAccounts.First(c => c.Id == d.AccountId);
            d.AccountName = account.Name;
            d.AccountType = (AccountType)account.AccountType;
            d.StartValue = account.StartValue;
            d.FinishValue = account.FinishValue;
            d.AccountTypeText = ((AccountType)account.AccountType).GetDescription();
        });

        return GenericResult<List<RemainderRuleDto>>.Success(dto);
    }
}