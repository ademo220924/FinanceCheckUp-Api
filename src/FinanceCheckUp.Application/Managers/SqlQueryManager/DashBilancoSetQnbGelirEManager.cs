using FinanceCheckUp.Application.Contexts.Concretes.Databases;
using FinanceCheckUp.Application.Models.ViewModel;
using FinanceCheckUp.Framework.Data;
using FinanceCheckUp.Framework.Data.MsSql.Repositories;

namespace FinanceCheckUp.Application.Managers.SqlQueryManager;
public interface IDashBilancoSetQnbGelirEManager : IGenericDapperRepository
{

    List<DashBilancoViewQnb> Get_1(int _year, long _compID);
    List<DashBilancoViewQnb> Get_3(int _year, long _compID);
    List<DashBilancoViewQnb> Get_5(int _year, long _compID);

}

public class DashBilancoSetQnbGelirEManager(FinanceCheckUpDbContext _dbContext) : GenericDapperRepositoryBase(_dbContext), IDashBilancoSetQnbGelirEManager
{
    public List<DashBilancoViewQnb> Get_1(int _year, long _compID)
    {
        return Query<DashBilancoViewQnb>("EXEC [SP_Main_Grow_HeaderQnbSubTypeDigerFaaliyet] @companyID, @nyear,119", new { nyear = _year, companyID = _compID }).ToList();
    }
    public List<DashBilancoViewQnb> Get_3(int _year, long _compID)
    {
        return Query<DashBilancoViewQnb>("EXEC [SP_Main_Grow_HeaderQnb] @companyID, @nyear,121", new { nyear = _year, companyID = _compID }).ToList();
    }
    public List<DashBilancoViewQnb> Get_5(int _year, long _compID)
    {
        return Query<DashBilancoViewQnb>("EXEC [SP_Main_Grow_HeaderQnb] @companyID, @nyear,123", new { nyear = _year, companyID = _compID }).ToList();
    }
}