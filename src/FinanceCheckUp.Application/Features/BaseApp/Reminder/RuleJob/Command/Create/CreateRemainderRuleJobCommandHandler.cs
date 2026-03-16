using FinanceCheckUp.Application.Dtos.BgServer.RuleJobs;
using FinanceCheckUp.Domain.Entities.BgServer;
using FinanceCheckUp.Framework.Core.Models;
using FinanceCheckUp.Framework.Data;
using FinanceCheckUp.Infrastructure.Repository;
using MediatR;

namespace FinanceCheckUp.Application.Features.BaseApp.Reminder.RuleJob.Command.Create;

public class CreateRemainderRuleJobCommandHandle(
    IGenericRepository<ReminderRule, long> reminderRuleRepository,
    IGenericRepository<ReminderRuleJob, long> reminderRuleJobRepository,
    IReminderRuleJobHistoryRepository reminderRuleJobHistoryRepository,
    ICompanyRepository companyRepository) : IRequestHandler<CreateRemainderRuleJobCommand, GenericResult<List<ReminderRuleJobDto>>>
{

    private readonly IGenericRepository<ReminderRule, long> _reminderRuleRepository = reminderRuleRepository ?? throw new ArgumentNullException(nameof(reminderRuleRepository));
    private readonly IGenericRepository<ReminderRuleJob, long> _reminderRuleJobRepository = reminderRuleJobRepository ?? throw new ArgumentNullException(nameof(reminderRuleJobRepository));
    private readonly IReminderRuleJobHistoryRepository _reminderRuleJobHistoryRepository = reminderRuleJobHistoryRepository ?? throw new ArgumentNullException(nameof(reminderRuleJobHistoryRepository));
    private readonly ICompanyRepository _companyRepository = companyRepository ?? throw new ArgumentNullException(nameof(companyRepository));



    public Task<GenericResult<List<ReminderRuleJobDto>>> Handle(CreateRemainderRuleJobCommand request, CancellationToken cancellationToken)
    {
        return Task.FromResult(GenericResult<List<ReminderRuleJobDto>>.Success([]));
    }
}