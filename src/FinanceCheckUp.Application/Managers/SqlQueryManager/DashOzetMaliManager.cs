using FinanceCheckUp.Application.Contexts.Concretes.Databases;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Framework.Data;
using FinanceCheckUp.Framework.Data.MsSql.Repositories;

namespace FinanceCheckUp.Application.Managers.SqlQueryManager;


public interface IDashOzetMaliManager : IGenericDapperRepository
{
    public List<DashYearlyResult> OzetMali8(int _year, long _compID);

    public List<DashYearlyResult> OzetMaliFinal(int _year, long _compID);

    public int SetErrored(int _year, long _compID, int _monthID);
}

public class DashOzetMaliManager(FinanceCheckUpDbContext _dbContext) : GenericDapperRepositoryBase(_dbContext), IDashOzetMaliManager
{
    public List<DashYearlyResult> OzetMali8(int _year, long _compID)
    {

        return Query<DashYearlyResult>("EXEC TTZDashBoardOzetMaliSPM @companyID, @nyear", new { nyear = _year, companyID = _compID }).ToList();
    }

    public List<DashYearlyResult> OzetMaliFinal(int _year, long _compID)
    {
        return Query<DashYearlyResult>("Select * from  [TTZDashBoardOzetMali] where [CompanyID]=@companyID and [Year]=@nyear   ", new { nyear = _year, companyID = _compID }).ToList();
    }

    public int SetErrored(int _year, long _compID, int _monthID)
    {
        return Execute("EXEC SPGRO_TBLDataErrored @companyID, @nyear, @nmonth", new { nyear = _year, companyID = _compID, nmonth = _monthID });
    }
}
