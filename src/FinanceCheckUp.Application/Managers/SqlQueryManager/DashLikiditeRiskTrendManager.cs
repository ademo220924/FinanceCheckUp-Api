using FinanceCheckUp.Application.Contexts.Concretes.Databases;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Framework.Data;
using FinanceCheckUp.Framework.Data.MsSql.Repositories;

namespace FinanceCheckUp.Application.Managers.SqlQueryManager;


public interface IDashLikiditeRiskTrendManager : IGenericDapperRepository
{
    public List<DashYearlyResult> LikiditeRiskTrend21(int _year, long _compID);
    public List<DashYearlyResult> LikiditeRiskTrend21Final(int _year, long _compID);
}

public class DashLikiditeRiskTrendManager(FinanceCheckUpDbContext _dbContext) : GenericDapperRepositoryBase(_dbContext), IDashLikiditeRiskTrendManager
{
    public List<DashYearlyResult> LikiditeRiskTrend21(int _year, long _compID)
    {
        return Query<DashYearlyResult>("EXEC TTZDashBoardOzetLikiditeSPM @companyID, @nyear", new { nyear = _year, companyID = _compID }).ToList();
    }
    public List<DashYearlyResult> LikiditeRiskTrend21Final(int _year, long _compID)
    {
        return Query<DashYearlyResult>("Select *  FROM [TTZDashBoardOzetLikidite] where [CompanyID]=@companyID and [Year]=@nyear   ", new { nyear = _year, companyID = _compID }).ToList();
    }
}
