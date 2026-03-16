using FinanceCheckUp.Application.Contexts.Concretes.Databases;
using FinanceCheckUp.Domain.Dtos.BaseApp;
using FinanceCheckUp.Domain.Entities;
using FinanceCheckUp.Framework.Data.MsSql.Repositories;
using FinanceCheckUp.Infrastructure.Repository;

namespace FinanceCheckUp.Application.Repository;

public class CompanyRepository(FinanceCheckUpDbContext dbContext) : GenericBaseRepository<Company, long>(dbContext), ICompanyRepository
{ }