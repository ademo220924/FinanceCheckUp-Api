using FinanceCheckUp.Application.Contexts.Concretes.Databases;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Framework.Data;
using FinanceCheckUp.Framework.Data.MsSql.Repositories;

namespace FinanceCheckUp.Application.Managers.SqlQueryManager;

public interface IEmailTemplatesManager : IGenericDapperRepository
{
    public IEnumerable<EmailTemplates> Get_All();
}

public class EmailTemplatesManager(FinanceCheckUpDbContext _dbContext) : GenericDapperRepositoryBase(_dbContext), IEmailTemplatesManager
{
    public IEnumerable<EmailTemplates> Get_All()
    {
        return Query<EmailTemplates>("Select * From [EmailTemplates]");
    }
}
