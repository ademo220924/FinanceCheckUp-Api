using AutoMapper;
using FinanceCheckUp.Application.Dtos.BgServer.Rules;
using FinanceCheckUp.Domain.Entities.BgServer;
using FinanceCheckUp.Framework.Core.Exceptions;
using FinanceCheckUp.Framework.Core.Models;
using FinanceCheckUp.Framework.Data;
using FinanceCheckUp.Infrastructure.Repository;
using MediatR;

namespace FinanceCheckUp.Application.Features.BaseApp.Reminder.Rule.Command.CreateRemainderRule;

public class CreateRemainderRuleCommandHandle(
    IReminderRuleRepository  reminderRuleRepo, 
    IMapper mapper): IRequestHandler<CreateRemainderRuleCommand, GenericResult<RemainderRuleDto>>
{
    public async Task<GenericResult<RemainderRuleDto>> Handle(CreateRemainderRuleCommand command, CancellationToken cancellationToken)
    {
        var entity = mapper.Map<ReminderRule>(command);
        var created = await reminderRuleRepo.AddAsync(entity, cancellationToken);
        if (!created)
            if (!created)
                throw new CreateOperationException(nameof(ReminderRule), command);

        var dto = mapper.Map<RemainderRuleDto>(entity);
        return GenericResult<RemainderRuleDto>.Success(dto); ;
    }
}