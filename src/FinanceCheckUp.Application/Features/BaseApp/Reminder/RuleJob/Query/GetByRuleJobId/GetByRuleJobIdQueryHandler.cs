using FinanceCheckUp.Application.Common.Utilities;
using FinanceCheckUp.Application.Dtos.BgServer.RuleJobs;
using FinanceCheckUp.Domain.Entities.BgServer;
using FinanceCheckUp.Framework.Core.Models;
using FinanceCheckUp.Framework.Data;
using FinanceCheckUp.Infrastructure.Repository;
using MediatR;

namespace FinanceCheckUp.Application.Features.BaseApp.Reminder.RuleJob.Query.GetByRuleJobId;

public class GetByRuleJobIdQueryHandle(
    IGenericRepository<ReminderRule, long> reminderRuleRepository,
    IGenericRepository<ReminderRuleJob, long> reminderRuleJobRepository,
    ICompanyRepository companyRepository,
    IGenericRepository<ReminderAccount, long> reminderAccountRepository,
    IGenericRepository<ReminderAccountGroup, long> reminderAccountGroupRepository) : IRequestHandler<GetByRuleJobIdQuery, GenericResult<ReminderRuleJobDto>>
{
    private readonly IGenericRepository<ReminderRule, long> _reminderRuleRepository = reminderRuleRepository ?? throw new ArgumentNullException(nameof(reminderRuleRepository));
    private readonly IGenericRepository<ReminderRuleJob, long> _reminderRuleJobRepository = reminderRuleJobRepository ?? throw new ArgumentNullException(nameof(reminderRuleJobRepository));
    private readonly ICompanyRepository _companyRepository = companyRepository ?? throw new ArgumentNullException(nameof(companyRepository));
    private readonly IGenericRepository<ReminderAccount, long> _reminderAccountRepository = reminderAccountRepository ?? throw new ArgumentNullException(nameof(reminderAccountRepository));
    private readonly IGenericRepository<ReminderAccountGroup, long> _reminderAccountGroupRepository = reminderAccountGroupRepository ?? throw new ArgumentNullException(nameof(reminderAccountGroupRepository));


    public async Task<GenericResult<ReminderRuleJobDto>> Handle(GetByRuleJobIdQuery request, CancellationToken cancellationToken)
    {
        var data = await _reminderRuleJobRepository.GetAsync(c => c.Id.Equals(request.Id), cancellationToken);
        if (data == null)
            return GenericResult<ReminderRuleJobDto>.Success(new ReminderRuleJobDto());

        var resultMap = ManuelMappingUtilities.SetMapping(new List<ReminderRuleJob> { data },
                                                                                await _companyRepository.GetListAsync(cancellationToken: cancellationToken),
                                                                                await _reminderRuleRepository.GetListAsync(cancellationToken: cancellationToken),
                                                                                await _reminderAccountRepository.GetListAsync(cancellationToken: cancellationToken),
                                                                                await _reminderAccountGroupRepository.GetListAsync(cancellationToken: cancellationToken));
        return GenericResult<ReminderRuleJobDto>.Success(resultMap.FirstOrDefault() ?? new ReminderRuleJobDto()); ;
    }
}