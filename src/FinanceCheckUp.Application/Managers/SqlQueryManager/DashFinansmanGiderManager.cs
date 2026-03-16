using FinanceCheckUp.Application.Contexts.Concretes.Databases;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Framework.Data;
using FinanceCheckUp.Framework.Data.MsSql.Repositories;

namespace FinanceCheckUp.Application.Managers.SqlQueryManager;

public interface IDashFinansmanGiderManager : IGenericDapperRepository
{
    public IEnumerable<DashFinansmanGider> Get_List(int id = 1);
}

public class DashFinansmanGiderManager(FinanceCheckUpDbContext _dbContext) : GenericDapperRepositoryBase(_dbContext), IDashFinansmanGiderManager
{
    public IEnumerable<DashFinansmanGider> Get_List(int id = 1)
    {
        string sql = @"EXEC SPFinansmanGiderKambiyo @compid";
        return Query<DashFinansmanGider>(sql, new { compid = id });
    }
}
