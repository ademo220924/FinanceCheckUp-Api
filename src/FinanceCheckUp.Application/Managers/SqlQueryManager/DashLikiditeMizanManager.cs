using FinanceCheckUp.Application.Contexts.Concretes.Databases;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Framework.Data;
using FinanceCheckUp.Framework.Data.MsSql.Repositories;


namespace FinanceCheckUp.Application.Managers.SqlQueryManager;
public interface IDashLikiditeMizanManager : IGenericDapperRepository
{
    public List<DashBilancoViewMizan> Get_MAINRESULTMultiMain(long _compID);
    public List<DashBilancoViewMizan> Get_MainList(long _compID);
    public List<DashYearlyResultMizan> Get_LikiditeORANT(long _compID);

}


public class DashLikiditeMizanManager(FinanceCheckUpDbContext _dbContext) : GenericDapperRepositoryBase(_dbContext), IDashLikiditeMizanManager
{
    public List<DashBilancoViewMizan> Get_MAINRESULTMultiMain(long _compID)
    {
        return Query<DashBilancoViewMizan>("Select * from  TBLMSampleBlncoMzn WITH (NOLOCK) Where CompanyID=@companyID  ", new { companyID = _compID }).ToList();
    }

    public List<DashBilancoViewMizan> Get_MainList(long _compID)
    {
        return Query<DashBilancoViewMizan>("Select * from TBLLikiditeMZN where CompanyID=@companyID ", new { companyID = _compID }).ToList();// 101  LikiditeKVadeBorc 'Kısa Vadeli Borçlanmalar'
    }

    public List<DashYearlyResultMizan> Get_LikiditeORANT(long _compID)
    {
        return Query<DashYearlyResultMizan>("Select * from  TTZDashBoardOranMzn where CompanyID=@companyID and Description='Likidite Oranı'", new { companyID = _compID }).ToList();
    }
}