using FinanceCheckUp.Application.Contexts.Concretes.Databases;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Framework.Data;
using FinanceCheckUp.Framework.Data.MsSql.Repositories;

namespace FinanceCheckUp.Application.Managers.SqlQueryManager;

public interface IDashLikiditeManager : IGenericDapperRepository
{
    List<DashBilancoView> Get_MainList(int _year, long _compID);
    List<DashBilancoView> Get_LikiditeORANT(int _year, long _compID);
}

public class DashLikiditeManager(FinanceCheckUpDbContext _dbContext) : GenericDapperRepositoryBase(_dbContext), IDashLikiditeManager
{
    public List<DashBilancoView> Get_MainList(int _year, long _compID)
    {
        return Query<DashBilancoView>("Select * from TBLLikidite  where CompanyID=@companyID and Year= @nyear ", new { nyear = _year, companyID = _compID }).ToList();// 101  LikiditeKVadeBorc 'Kısa Vadeli Borçlanmalar'
    }

    public List<DashBilancoView> Get_LikiditeORANT(int _year, long _compID)
    {
        return StaticQuery<DashBilancoView>("EXEC [SP_RasyoLikiditeOran] @companyID, @nyear", new { nyear = _year, companyID = _compID }).ToList();
    }
}
