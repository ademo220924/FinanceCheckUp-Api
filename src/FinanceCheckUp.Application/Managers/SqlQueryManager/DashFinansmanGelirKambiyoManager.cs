using FinanceCheckUp.Application.Contexts.Concretes.Databases;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Framework.Data;
using FinanceCheckUp.Framework.Data.MsSql.Repositories;

namespace FinanceCheckUp.Application.Managers.SqlQueryManager;



public interface IDashFinansmanGelirKambiyoManager : IGenericDapperRepository
{
    public IEnumerable<DashFinansmanGelirKambiyo> Get_List(int id = 1);
}

public class DashFinansmanGelirKambiyoManager(FinanceCheckUpDbContext _dbContext) : GenericDapperRepositoryBase(_dbContext), IDashFinansmanGelirKambiyoManager
{
    public IEnumerable<DashFinansmanGelirKambiyo> Get_List(int id = 1)
    {
        string sql = @"EXEC SPFinansmanGelirKambiyo @compid";
        return Query<DashFinansmanGelirKambiyo>(sql, new { compid = id });
    }
}
