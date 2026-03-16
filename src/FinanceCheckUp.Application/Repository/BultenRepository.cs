using FinanceCheckUp.Application.Contexts.Concretes.Databases;
using FinanceCheckUp.Domain.Entities;
using FinanceCheckUp.Framework.Data.MsSql.Repositories;
using FinanceCheckUp.Infrastructure.Repository;

namespace FinanceCheckUp.Application.Repository;


public class BultenRepository(FinanceCheckUpDbContext dbContext) : GenericBaseRepository<Bulten, int>(dbContext), IBultenRepository;
