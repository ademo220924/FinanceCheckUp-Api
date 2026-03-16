using AutoMapper;
using FinanceCheckUp.Domain.Dtos.BgServer.Accounts;
using FinanceCheckUp.Domain.Entities.BgServer;
using FinanceCheckUp.Framework.Core.Exceptions;
using FinanceCheckUp.Framework.Core.Models;
using FinanceCheckUp.Framework.Data;
using MediatR;

namespace FinanceCheckUp.Application.Features.BaseApp.Reminder.Account.Command.UpdateAccount;

public class UpdateAccountCommandHandle(
    IGenericRepository<ReminderAccount, long> reminderAccountRepository,
    IMapper mapper)
    : IRequestHandler<UpdateAccountCommand, GenericResult<ReminderAccountDto>>
{
    private readonly IGenericRepository<ReminderAccount, long> _reminderAccountRepository = reminderAccountRepository ?? throw new ArgumentNullException(nameof(reminderAccountRepository));
    private readonly IMapper _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));

    public async Task<GenericResult<ReminderAccountDto>> Handle(UpdateAccountCommand request, CancellationToken cancellationToken)
    {
        var entity = _mapper.Map<ReminderAccount>(request);
        var mainAccount = await _reminderAccountRepository.GetByIdAsync(request.Model.Id.ToString(), cancellationToken);
        if (mainAccount == null)
            throw new NotFoundException(request.Model.Id.ToString(), nameof(Account));

        var updated = await _reminderAccountRepository.UpdateAsync(entity, cancellationToken);
        if (!updated)
            throw new UpdateOperationException(nameof(ReminderAccount), request);

        var dto = _mapper.Map<ReminderAccountDto>(entity);
        return GenericResult<ReminderAccountDto>.Success(dto);
    }
}