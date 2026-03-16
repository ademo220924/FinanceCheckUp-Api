using FinanceCheckUp.Application.Common.Utilities;
using FinanceCheckUp.Application.Dtos.BgServer.RuleJobs;
using FinanceCheckUp.Domain.Entities.BgServer;
using FinanceCheckUp.Framework.Core.Models;
using FinanceCheckUp.Framework.Data;
using FinanceCheckUp.Infrastructure.Repository;
using MediatR;

namespace FinanceCheckUp.Application.Features.BaseApp.Reminder.RuleJob.Query.GetListByCompanyId;

public class GetListByCompanyIdQueryHandle(
    IGenericRepository<ReminderRule, long> reminderRuleRepository,
    IReminderRuleJobRepository reminderRuleJobRepository,
    ICompanyRepository companyRepository,
    IGenericRepository<ReminderAccount, long> reminderAccountRepository,
    IGenericRepository<ReminderAccountGroup, long> reminderAccountGroupRepository)
    : IRequestHandler<GetListByCompanyIdQuery, GenericResult<List<ReminderRuleJobDto>>>
{
    private readonly IGenericRepository<ReminderRule, long> _reminderRuleRepository = reminderRuleRepository ?? throw new ArgumentNullException(nameof(reminderRuleRepository));
    private readonly IReminderRuleJobRepository _reminderRuleJobRepository = reminderRuleJobRepository ?? throw new ArgumentNullException(nameof(reminderRuleJobRepository));
    private readonly ICompanyRepository _companyRepository = companyRepository ?? throw new ArgumentNullException(nameof(companyRepository));
    private readonly IGenericRepository<ReminderAccount, long> _reminderAccountRepository = reminderAccountRepository ?? throw new ArgumentNullException(nameof(reminderAccountRepository));
    private readonly IGenericRepository<ReminderAccountGroup, long> _reminderAccountGroupRepository = reminderAccountGroupRepository ?? throw new ArgumentNullException(nameof(reminderAccountGroupRepository));


    public async Task<GenericResult<List<ReminderRuleJobDto>>> Handle(GetListByCompanyIdQuery request, CancellationToken cancellationToken)
    {
        var mappingModel = ManuelMappingUtilities.SetMapping(new List<ReminderRuleJob>
            {
                await _reminderRuleJobRepository.GetAsync(c => c.CompanyId.Equals(request.CompanyId), cancellationToken)
            },
            await _companyRepository.GetListAsync(cancellationToken: cancellationToken),
            await _reminderRuleRepository.GetListAsync(cancellationToken: cancellationToken),
            await _reminderAccountRepository.GetListAsync(cancellationToken: cancellationToken),
            await _reminderAccountGroupRepository.GetListAsync(cancellationToken: cancellationToken));

        return GenericResult<List<ReminderRuleJobDto>>.Success(mappingModel);
    }
}