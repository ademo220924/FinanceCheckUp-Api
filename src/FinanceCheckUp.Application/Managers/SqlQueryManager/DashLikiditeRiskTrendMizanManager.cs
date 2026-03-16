using FinanceCheckUp.Application.Contexts.Concretes.Databases;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Framework.Data;
using FinanceCheckUp.Framework.Data.MsSql.Repositories;


namespace FinanceCheckUp.Application.Managers.SqlQueryManager;
public interface IDashLikiditeRiskTrendMizanManager : IGenericDapperRepository
{
    public List<DashYearlyResultMizan> LikiditeRiskTrend21(int _year, long _compID);
    public List<DashYearlyResultMizan> LikiditeRiskTrend21Final(long _compID);
}


public class DashLikiditeRiskTrendMizanManager(FinanceCheckUpDbContext _dbContext) : GenericDapperRepositoryBase(_dbContext), IDashLikiditeRiskTrendMizanManager
{
    public List<DashYearlyResultMizan> LikiditeRiskTrend21(int _year, long _compID)
    {
        return Query<DashYearlyResultMizan>("EXEC TTZDashBoardOzetLikiditeSPMMZN @companyID, @nyear", new { nyear = _year, companyID = _compID }).ToList();
    }
    public List<DashYearlyResultMizan> LikiditeRiskTrend21Final(long _compID)
    {
        return Query<DashYearlyResultMizan>("Select *  FROM [TTZDashBoardOzetLikiditeMzn] where [CompanyID]=@companyID  ", new { companyID = _compID }).ToList();
    }
}