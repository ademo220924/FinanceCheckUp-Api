using FinanceCheckUp.Framework.Data.MsSql.Repositories;
namespace FinanceCheckUp.Application.Managers.SqlQueryManager;

using FinanceCheckUp.Application.Contexts.Concretes.Databases;
using FinanceCheckUp.Application.Models.ViewModel;
using FinanceCheckUp.Framework.Data;

public interface IDashBilancoSetQnbGelirGManager : IGenericDapperRepository
{
    List<DashBilancoViewQnb> Get_1(int _year, long _compID);
    List<DashBilancoViewQnb> Get_3(int _year, long _compID);
    List<DashBilancoViewQnb> Get_5(int _year, long _compID);
    List<DashBilancoViewQnb> Get_7(int _year, long _compID);


}

public class DashBilancoSetQnbGelirGManager(FinanceCheckUpDbContext _dbContext) : GenericDapperRepositoryBase(_dbContext), IDashBilancoSetQnbGelirGManager
{
    public List<DashBilancoViewQnb> Get_1(int _year, long _compID)
    {
        return Query<DashBilancoViewQnb>("EXEC [SP_Main_Grow_HeaderQnbSubTypeOlaganDisi] @companyID, @nyear,127", new { nyear = _year, companyID = _compID }).ToList();
    }
    public List<DashBilancoViewQnb> Get_3(int _year, long _compID)
    {
        return Query<DashBilancoViewQnb>("EXEC [SP_Main_Grow_HeaderQnb] @companyID, @nyear,129", new { nyear = _year, companyID = _compID }).ToList();
    }
    public List<DashBilancoViewQnb> Get_5(int _year, long _compID)
    {
        return Query<DashBilancoViewQnb>("EXEC [SP_Main_Grow_HeaderQnb] @companyID, @nyear,131", new { nyear = _year, companyID = _compID }).ToList();
    }
    public List<DashBilancoViewQnb> Get_7(int _year, long _compID)
    {
        return Query<DashBilancoViewQnb>("EXEC [SP_Main_Grow_HeaderQnb] @companyID, @nyear,132", new { nyear = _year, companyID = _compID }).ToList();
    }
}