using FinanceCheckUp.Application.Contexts.Concretes.Databases;
using FinanceCheckUp.Domain.Entities;
using FinanceCheckUp.Framework.Data.MsSql.Repositories;

namespace FinanceCheckUp.Infrastructure.Repository;

public class TblwzoneRepository(FinanceCheckUpDbContext dbContext) : GenericBaseRepository<Tblwzone, int>(dbContext), ITblwzoneRepository;
