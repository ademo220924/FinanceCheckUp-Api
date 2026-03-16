using FinanceCheckUp.Application.Contexts.Concretes.Databases;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Framework.Data;
using FinanceCheckUp.Framework.Data.MsSql.Repositories;

namespace FinanceCheckUp.Application.Managers.SqlQueryManager;
public interface IReportDashMizanManager : IGenericDapperRepository
{
    public IEnumerable<YearlyReportDashMizan> Get_Data_GrossProfit(long _compID);
    public IEnumerable<YearlyReportDashMizan> Get_Data_Revenue(long _compID);
    public IEnumerable<YearlyReportDashMizanGrap> Get_Data_GrossProfitGraphic(long _compID);
    public IEnumerable<YearlyReportDashMizan> Get_Data_DonemselKarzarar(long _compID);
    public IEnumerable<YearlyReportDashMizan> Get_Data_WorkingCapital(long _compID);
    public int Get_LastMonthYear(int _year, long _compID);
    public IEnumerable<YearlyReportDashMizan> Get_Data_BLNC(int _year, long _compID);
    public IEnumerable<YearlyReportDashMizan> Get_Data_CRORN(int _year, long _compID);
    public IEnumerable<YearlyReportDashMizan> Get_Data_NKTORN(int _year, long _compID);
    public IEnumerable<YearlyReportDashMizan> Get_Data_EbitMarjin(long _compID);
}


public class ReportDashMizanManager(FinanceCheckUpDbContext _dbContext) : GenericDapperRepositoryBase(_dbContext), IReportDashMizanManager
{
    public IEnumerable<YearlyReportDashMizan> Get_Data_GrossProfit(long _compID)
    {
        IEnumerable<YearlyReportDashMizan> nval = StaticQuery<YearlyReportDashMizan>("Select * from  TBLWcapBrutKarZararMizan where CompanyID=@companyID", new { companyID = _compID });
        if (nval == null || nval.Count() < 1)
        {
            nval = new List<YearlyReportDashMizan>();
        }
        return nval;
    }
    public IEnumerable<YearlyReportDashMizan> Get_Data_Revenue(long _compID)
    {
        IEnumerable<YearlyReportDashMizan> nval = StaticQuery<YearlyReportDashMizan>("Select * from  TBLWcapNetSatisMizan where CompanyID=@companyID  ", new { companyID = _compID });
        if (nval == null || nval.Count() < 1)
        {
            nval = new List<YearlyReportDashMizan>();
        }
        return nval;
    }
    public IEnumerable<YearlyReportDashMizanGrap> Get_Data_GrossProfitGraphic(long _compID)
    {
        IEnumerable<YearlyReportDashMizanGrap> nval = Query<YearlyReportDashMizanGrap>("EXEC SP_BRUTKARZBYMONTHV1Mizan  @companyID", new { companyID = _compID });
        if (nval == null || nval.Count() < 1)
        {
            nval = new List<YearlyReportDashMizanGrap>();
        }
        return nval;
    }

    public IEnumerable<YearlyReportDashMizan> Get_Data_DonemselKarzarar(long _compID)
    {
        IEnumerable<YearlyReportDashMizan> nval = Query<YearlyReportDashMizan>("Select * from   TBLWcapDonemKarZararMizan where CompanyID=@companyID  ", new { companyID = _compID });

        if (nval == null || nval.Count() < 1)
        {
            nval = new List<YearlyReportDashMizan>();
        }
        return nval;
    }
    public IEnumerable<YearlyReportDashMizan> Get_Data_WorkingCapital(long _compID)
    {
        IEnumerable<YearlyReportDashMizan> nval = Query<YearlyReportDashMizan>("EXEC SP_WCAPITALBYMONTHV21Mizan @companyID ", new { companyID = _compID });



        if (nval == null || nval.Count() < 1)
        {
            nval = new List<YearlyReportDashMizan>();
        }
        return nval;
    }
    public int Get_LastMonthYear(int _year, long _compID)
    {
        return Query<int>("Select TOP 1  MONTH(DocumentDate) from TBLXml where CompanyID=@companyID and Year=@nyear order by DocumentDate Desc", new { nyear = _year, companyID = _compID }).FirstOrDefault();
    }
    public IEnumerable<YearlyReportDashMizan> Get_Data_BLNC(int _year, long _compID)
    {
        return Query<YearlyReportDashMizan>("EXEC SP_WCAPITALBYMONTBLNC @nyear,@companyID", new { nyear = _year, companyID = _compID });
    }
    public IEnumerable<YearlyReportDashMizan> Get_Data_CRORN(int _year, long _compID)
    {
        return Query<YearlyReportDashMizan>("EXEC SP_WCAPITALBYMONTCRORN @nyear,@companyID", new { nyear = _year, companyID = _compID });
    }
    public IEnumerable<YearlyReportDashMizan> Get_Data_NKTORN(int _year, long _compID)
    {
        return Query<YearlyReportDashMizan>("EXEC SP_WCAPITALBYMONTNKTORN @nyear,@companyID", new { nyear = _year, companyID = _compID });
    }
    public IEnumerable<YearlyReportDashMizan> Get_Data_EbitMarjin(long _compID)
    {
        IEnumerable<YearlyReportDashMizan> nval = Query<YearlyReportDashMizan>("Select * from  TBLWcapEsasMaliyetKarZararMizan where CompanyID=@companyID  ", new { companyID = _compID });


        if (nval == null || nval.Count() < 1)
        {
            nval = new List<YearlyReportDashMizan>();
        }
        return nval;
    }
}