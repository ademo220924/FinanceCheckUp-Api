using AutoMapper;
using FinanceCheckUp.Domain.Dtos.BgServer.Accounts;
using FinanceCheckUp.Domain.Entities.BgServer;
using FinanceCheckUp.Framework.Core.Exceptions;
using FinanceCheckUp.Framework.Core.Models;
using FinanceCheckUp.Framework.Data;
using MediatR;

namespace FinanceCheckUp.Application.Features.BaseApp.Reminder.Account.Command.CreateAccount;

public class CreateAccountCommandHandle(
    IGenericRepository<ReminderAccount, long> reminderAccountRepository,
    IMapper mapper)
    : IRequestHandler<CreateAccountCommand, GenericResult<ReminderAccountDto>>
{
    private readonly IGenericRepository<ReminderAccount, long> _reminderAccountRepository = reminderAccountRepository ?? throw new ArgumentNullException(nameof(reminderAccountRepository));
    private readonly IMapper _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));

    public async Task<GenericResult<ReminderAccountDto>> Handle(CreateAccountCommand request, CancellationToken cancellationToken)
    {
        var entity = _mapper.Map<ReminderAccount>(request);
        var created = await _reminderAccountRepository.AddAsync(entity, cancellationToken);
        if (!created)
            throw new CreateOperationException(nameof(ReminderAccount), request);

        var model = _reminderAccountRepository.GetAsync(c => c.Name == request.Model.Name, cancellationToken);
        if (model == null)
            throw new NotFoundException(nameof(ReminderAccount), request.Model.Name);

        var dto = _mapper.Map<ReminderAccountDto>(model);
        return GenericResult<ReminderAccountDto>.Success(dto);
    }
}