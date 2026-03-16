using FinanceCheckUp.Application.Contexts.Concretes.Databases;
using FinanceCheckUp.Application.Models.ViewModel;
using FinanceCheckUp.Framework.Data;
using FinanceCheckUp.Framework.Data.MsSql.Repositories;
namespace FinanceCheckUp.Application.Managers.SqlQueryManager;

public interface IDashBilancoSetQnbGelirHManager : IGenericDapperRepository
{
    List<DashBilancoViewQnb> Get_1(int _year, long _compID);
}

public class DashBilancoSetQnbGelirHManager(FinanceCheckUpDbContext _dbContext) : GenericDapperRepositoryBase(_dbContext), IDashBilancoSetQnbGelirHManager
{
    public List<DashBilancoViewQnb> Get_1(int _year, long _compID)
    {
        return Query<DashBilancoViewQnb>("EXEC [SP_Main_Grow_HeaderQnbSubTypeDonemKar] @companyID, @nyear,133", new { nyear = _year, companyID = _compID }).ToList();
    }
}