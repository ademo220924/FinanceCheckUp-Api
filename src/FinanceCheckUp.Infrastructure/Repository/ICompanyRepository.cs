using FinanceCheckUp.Domain.Dtos.BaseApp;
using FinanceCheckUp.Domain.Entities;
using FinanceCheckUp.Framework.Data;

namespace FinanceCheckUp.Infrastructure.Repository;

public interface ICompanyRepository : IGenericRepository<Company, long>
{}