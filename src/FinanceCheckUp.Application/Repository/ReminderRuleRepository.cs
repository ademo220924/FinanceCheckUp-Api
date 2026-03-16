using FinanceCheckUp.Application.Contexts.Concretes.Databases;
using FinanceCheckUp.Domain.Entities.BgServer;
using FinanceCheckUp.Framework.Data.MsSql.Repositories;
using FinanceCheckUp.Infrastructure.Repository;

namespace FinanceCheckUp.Application.Repository;

public class ReminderRuleRepository(FinanceCheckUpDbContext dbContext) : GenericBaseRepository<ReminderRule, long>(dbContext), IReminderRuleRepository;
