using FinanceCheckUp.Application.Contexts.Concretes.Databases;
using FinanceCheckUp.Application.Models.ViewModel;
using FinanceCheckUp.Framework.Data;
using FinanceCheckUp.Framework.Data.MsSql.Repositories;

namespace FinanceCheckUp.Application.Managers.SqlQueryManager;
public interface IDashBilancoSetQnbGelirBManager : IGenericDapperRepository
{
    List<DashBilancoViewQnb> Get_1(int _year, long _compID);
    List<DashBilancoViewQnb> Get_3(int _year, long _compID);
}


public class DashBilancoSetQnbGelirBManager(FinanceCheckUpDbContext _dbContext) : GenericDapperRepositoryBase(_dbContext), IDashBilancoSetQnbGelirBManager
{
    public List<DashBilancoViewQnb> Get_1(int _year, long _compID)
    {
        return Query<DashBilancoViewQnb>("EXEC [SP_Main_Grow_HeaderQnbFaaliyet] @companyID, @nyear,111", new { nyear = _year, companyID = _compID }).ToList();

    }
    public List<DashBilancoViewQnb> Get_3(int _year, long _compID)
    {
        return Query<DashBilancoViewQnb>("EXEC [SP_Main_Grow_HeaderQnbSubTypEsasFaaliyet] @companyID, @nyear,113", new { nyear = _year, companyID = _compID }).ToList();
    }
}