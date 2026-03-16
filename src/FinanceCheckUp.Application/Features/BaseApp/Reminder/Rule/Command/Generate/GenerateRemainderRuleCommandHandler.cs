using AutoMapper;
using FinanceCheckUp.Application.Dtos.BgServer.Rules;
using FinanceCheckUp.Domain.Entities.BgServer;
using FinanceCheckUp.Framework.Core.Exceptions;
using FinanceCheckUp.Framework.Core.Models;
using FinanceCheckUp.Framework.Data;
using MediatR;

namespace FinanceCheckUp.Application.Features.BaseApp.Reminder.Rule.Command.Generate;

public class GenerateRemainderRuleCommandHandle(
    IGenericRepository<ReminderRule, long> reminderRuleRepo,
    IMapper mapper)
    : IRequestHandler<GenerateRemainderRuleCommand, GenericResult<List<RemainderRuleDto>>>
{
    private readonly IGenericRepository<ReminderRule, long> _reminderRuleRepo = reminderRuleRepo ?? throw new ArgumentNullException(nameof(reminderRuleRepo));
    private readonly IMapper _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));


    public async Task<GenericResult<List<RemainderRuleDto>>> Handle(GenerateRemainderRuleCommand command, CancellationToken cancellationToken)
    {
        var entity = _mapper.Map<List<ReminderRule>>(command.ReminderRules);
        var created = await _reminderRuleRepo.AddRangeAsync(entity, cancellationToken);
        if (!created)
            throw new CreateOperationException(nameof(ReminderRule), entity);

        var dto = _mapper.Map<List<RemainderRuleDto>>(entity);
        return GenericResult<List<RemainderRuleDto>>.Success(dto);
    }
}