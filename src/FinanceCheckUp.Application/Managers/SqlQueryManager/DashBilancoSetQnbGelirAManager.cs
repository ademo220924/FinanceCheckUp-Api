using FinanceCheckUp.Application.Contexts.Concretes.Databases;
using FinanceCheckUp.Application.Models.ViewModel;
using FinanceCheckUp.Framework.Data;
using FinanceCheckUp.Framework.Data.MsSql.Repositories;

namespace FinanceCheckUp.Application.Managers.SqlQueryManager;
public interface IDashBilancoSetQnbGelirAManager : IGenericDapperRepository
{
    List<DashBilancoViewQnb> Get_1(int _year, long _compID);
}


public class DashBilancoSetQnbGelirAManager(FinanceCheckUpDbContext _dbContext) : GenericDapperRepositoryBase(_dbContext), IDashBilancoSetQnbGelirAManager
{
    public List<DashBilancoViewQnb> Get_1(int _year, long _compID)
    {
        return StaticQuery<DashBilancoViewQnb>("EXEC [SP_Main_Grow_HeaderQnbSubTypeBrut] @companyID, @nyear,109", new { nyear = _year, companyID = _compID }).ToList();
    }
}