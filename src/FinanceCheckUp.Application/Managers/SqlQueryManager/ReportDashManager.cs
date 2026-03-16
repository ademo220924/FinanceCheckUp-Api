using FinanceCheckUp.Application.Contexts.Concretes.Databases;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Application.Models.ViewModel;
using FinanceCheckUp.Framework.Data;
using FinanceCheckUp.Framework.Data.MsSql.Repositories;

namespace FinanceCheckUp.Application.Managers.SqlQueryManager;

public interface IReportDashManager : IGenericDapperRepository
{
    public IEnumerable<YearlyReportDash> Get_Data_GrossProfitMIZAN(long _compID);
    public IEnumerable<YearlyReportDash> Get_Data_BrutKarZararMIZAN(long _compID);
    public IEnumerable<YearlyReportDash> Get_Data_FinancialDebitMIZAN(long _compID);
    public IEnumerable<YearlyReportDash> Get_Data_FinancialDebitMultiMIZAN(long _compID);
    public IEnumerable<YearlyReportDash> Get_Data_FinancialCariOrANMIZAN(long _compID);
    public IEnumerable<YearlyReportDash> Get_Data_WorkingCapitalMIZAN(long _compID);
    public IEnumerable<ReportMainItem> DataReportMainKapakMIZAN(long _compID);
    public IEnumerable<DashBilancoViewMarj> Get_Data_FinancialOzkaynakAktifMIZAN(long _compID);
    public IEnumerable<YearlyReportDash> Get_Data_RevenueMizan(long _compID);
    public IEnumerable<YearlyReportDash> Get_Data_DonemselKarzararMIZAN(long _compID);
    public IEnumerable<YearlyReportDash> Get_Data_EbitMarjinMIZAN(long _compID);
    public IEnumerable<YearlyReportDash> Get_Data_GrossProfit(int _year, long _compID);
    public IEnumerable<YearlyReportDash> Get_Data_FinancialDebit(int _year, long _compID);
    public IEnumerable<YearlyReportDash> Get_Data_FinancialDebitMulti(int _year, long _compID);
    public IEnumerable<ReportMainItem> DataReportMainKapak(int _year, long _compID);
    public DashBilancoViewMarj Get_Data_FinancialCariOrAN(int _year, long _compID);
    public IEnumerable<DashBilancoViewMarj> Get_Data_FinancialOzkaynakAktif(int _year, long _compID);
    public IEnumerable<YearlyReportDash> Get_Data_Revenue(int _year, long _compID);
    public IEnumerable<YearlyReportDashGraphic> Get_Data_GrossProfitGraphic(int _year, long _compID);
    public IEnumerable<YearlyReportDash> Get_Data_DonemselKarzarar(int _year, long _compID);
    public DashYearlyResultWorkingCapital Get_Data_WorkingCapital(int _year, long _compID);
    public int Get_LastMonthYear(int _year, long _compID);
    public IEnumerable<YearlyReportDash> Get_Data_BLNC(int _year, long _compID);
    public IEnumerable<YearlyReportDash> Get_Data_CRORN(int _year, long _compID);
    public IEnumerable<YearlyReportDash> Get_Data_NKTORN(int _year, long _compID);
    public IEnumerable<YearlyReportDash> Get_Data_EbitMarjin(int _year, long _compID);
}

public class ReportDashManager(FinanceCheckUpDbContext _dbContext) : GenericDapperRepositoryBase(_dbContext), IReportDashManager
{
    public IEnumerable<YearlyReportDash> Get_Data_GrossProfitMIZAN(long _compID)
    {
        return StaticQuery<YearlyReportDash>("SELECT   SUM([Amount])  as 'Amount'    ,[CompanyID] ,[Year] as MainYear FROM[EDEFTERDB].[dbo].[TBLMRevenueMzn] where CompanyID =@companyID and AccountMainID in ('600','601','602') group by [Year],[CompanyID]", new { companyID = _compID });
    }
    public IEnumerable<YearlyReportDash> Get_Data_BrutKarZararMIZAN(long _compID)
    {
        return StaticQuery<YearlyReportDash>("SELECT   SUM([Amount])  as 'Amount'    ,[CompanyID] ,[Year] as MainYear FROM[EDEFTERDB].[dbo].[TBLMRevenueMzn] where CompanyID =@companyID and TypeID in ('222') group by [Year],[CompanyID]", new { companyID = _compID });
    }
    public IEnumerable<YearlyReportDash> Get_Data_FinancialDebitMIZAN(long _compID)
    {
        return StaticQuery<YearlyReportDash>("SELECT   SUM([Amount])  as 'Amount'    ,[CompanyID] ,[Year] as MainYear FROM[EDEFTERDB].[dbo].[TBLMRevenueMzn] where CompanyID =@companyID and AccountMainID in ('300','400')  group by [Year],[CompanyID]", new { companyID = _compID });
    }
    public IEnumerable<YearlyReportDash> Get_Data_FinancialDebitMultiMIZAN(long _compID)
    {
        return Query<YearlyReportDash>("EXEC SP_BFINANCEDeptMONTHMIZAN @companyID", new { companyID = _compID });
    }

    //SP_BFINANCEDeptMONTHMIZAN
    public IEnumerable<YearlyReportDash> Get_Data_FinancialCariOrANMIZAN(long _compID)
    {
        return StaticQuery<YearlyReportDash>(" SELECT * FROM [EDEFTERDB].[dbo].TTZDashBoardOranMzn  where  CompanyID=@companyID  and TypeID=2  and Description='Cari Oran' ", new { companyID = _compID });
    }

    //SP_WCAPITALBYMONTHV21Mizan
    public IEnumerable<YearlyReportDash> Get_Data_WorkingCapitalMIZAN(long _compID)
    {
        return Query<YearlyReportDash>("EXEC SP_WCAPITALBYMONTHV21Mizan @companyID ", new { companyID = _compID });
    }
    public IEnumerable<ReportMainItem> DataReportMainKapakMIZAN(long _compID)
    {
        List<ReportMainItem> nget = new List<ReportMainItem>();
        string sql = @"Select * from [dbo].[TBMLREPOR01MZN] where   CompanyID=@companyID ";

        return StaticQuery<ReportMainItem>(sql, new { companyID = _compID });

    }
    public IEnumerable<DashBilancoViewMarj> Get_Data_FinancialOzkaynakAktifMIZAN(long _compID)
    {
        List<DashBilancoViewMarj> nmarJ = StaticQuery<DashBilancoViewMarj>("SELECT top 1 * FROM [EDEFTERDB].[dbo].[TBLMSampleBlncoMzn]  where  CompanyID=@companyID  and TypeID in ('2221')  order by Year desc ", new { companyID = _compID }).ToList();
        List<DashBilancoViewMarj> nmarJ1 = StaticQuery<DashBilancoViewMarj>("SELECT top 1 * FROM [EDEFTERDB].[dbo].[TBLMSampleBlncoMzn]  where  CompanyID=@companyID  and TypeID in ('3333')  order by Year desc   ", new { companyID = _compID }).ToList();
        nmarJ.AddRange(nmarJ1);

        return nmarJ;
    }
    public IEnumerable<YearlyReportDash> Get_Data_RevenueMizan(long _compID)
    {
        return StaticQuery<YearlyReportDash>("SELECT [Amount] ,[CompanyID]  ,[Year] FROM [EDEFTERDB].[dbo].[TBLWcapNetSatisMizan] where CompanyID=@companyID ", new { companyID = _compID });
    }
    public IEnumerable<YearlyReportDash> Get_Data_DonemselKarzararMIZAN(long _compID)
    {
        return StaticQuery<YearlyReportDash>("Select * from  [TBLWcapBrutKarZararMizan]  where   CompanyID=@companyID  ", new { companyID = _compID });
    }
    public IEnumerable<YearlyReportDash> Get_Data_EbitMarjinMIZAN(long _compID)
    {
        return StaticQuery<YearlyReportDash>("Select * from  [TBLWcapEsasMaliyetKarZararMizan]  where   CompanyID=@companyID ", new { companyID = _compID });
    }
    public IEnumerable<YearlyReportDash> Get_Data_GrossProfit(int _year, long _compID)
    {
        return Query<YearlyReportDash>("EXEC SP_BRUTKARZBYMONTHV3 @nyear,@companyID", new { nyear = _year, companyID = _compID });
    }
    //SELECT   SUM([Amount])   ,[CompanyID] ,[Year]  FROM [EDEFTERDB].[dbo].TBLMSampleBlncoMzn where CompanyID =9  and AccountMainID in ('300','400' ) group by [Year],[CompanyID] 
    public IEnumerable<YearlyReportDash> Get_Data_FinancialDebit(int _year, long _compID)
    {
        return Query<YearlyReportDash>("EXEC SP_BFINANCEMONTH @nyear,@companyID", new { nyear = _year, companyID = _compID });
    }
    public IEnumerable<YearlyReportDash> Get_Data_FinancialDebitMulti(int _year, long _compID)
    {
        return Query<YearlyReportDash>("EXEC SP_BFINANCEDeptMONTH @nyear,@companyID", new { nyear = _year, companyID = _compID });
    }

    public IEnumerable<ReportMainItem> DataReportMainKapak(int _year, long _compID)
    {
        List<ReportMainItem> nget = new List<ReportMainItem>();
        string sql = @"Select * from [dbo].[TBMLREPOR01] where   CompanyID=@companyID and  [Year]=@nyear";

        return StaticQuery<ReportMainItem>(sql, new { nyear = _year, companyID = _compID });

    }
    public DashBilancoViewMarj Get_Data_FinancialCariOrAN(int _year, long _compID)
    {
        return StaticQuery<DashBilancoViewMarj>(" SELECT * FROM [EDEFTERDB].[dbo].TTZDashBoardOran  where  CompanyID=@companyID and  Year=@nyear and TypeID=2  and Description='Cari Oran' ", new { nyear = _year, companyID = _compID }).FirstOrDefault();
    }
    public IEnumerable<DashBilancoViewMarj> Get_Data_FinancialOzkaynakAktif(int _year, long _compID)
    {
        return StaticQuery<DashBilancoViewMarj>("SELECT * FROM [EDEFTERDB].[dbo].[TBLMSampleBlncoRasT]  where  CompanyID=@companyID and  Year=@nyear and TypeID in ('3333','2121')   ", new { nyear = _year, companyID = _compID });
    }
    public IEnumerable<YearlyReportDash> Get_Data_Revenue(int _year, long _compID)
    {
        return Query<YearlyReportDash>("EXEC SP_GELIRLERBYMONTHV1 @nyear,@companyID", new { nyear = _year, companyID = _compID });
    }
    public IEnumerable<YearlyReportDashGraphic> Get_Data_GrossProfitGraphic(int _year, long _compID)
    {
        return Query<YearlyReportDashGraphic>("EXEC SP_BRUTKARZBYMONTHV1 @nyear,@companyID", new { nyear = _year, companyID = _compID });
    }

    public IEnumerable<YearlyReportDash> Get_Data_DonemselKarzarar(int _year, long _compID)
    {
        return Query<YearlyReportDash>("EXEC SP_DONEMNTKARZBYMONTHV1 @nyear,@companyID", new { nyear = _year, companyID = _compID });
    }
    //SP_WCAPITALBYMONTHV21Mizan
    public DashYearlyResultWorkingCapital Get_Data_WorkingCapital(int _year, long _compID)
    {
        return Query<DashYearlyResultWorkingCapital>("EXEC SP_WCAPITALBYMONTHV21 @companyID,@nyear", new { nyear = _year, companyID = _compID }).FirstOrDefault();
    }
    public int Get_LastMonthYear(int _year, long _compID)
    {
        return Query<int>("Select TOP 1  MONTH(DocumentDate) from TBLXml where CompanyID=@companyID and Year=@nyear order by DocumentDate Desc", new { nyear = _year, companyID = _compID }).FirstOrDefault();
    }
    public IEnumerable<YearlyReportDash> Get_Data_BLNC(int _year, long _compID)
    {
        return Query<YearlyReportDash>("EXEC SP_WCAPITALBYMONTBLNC @nyear,@companyID", new { nyear = _year, companyID = _compID });
    }
    public IEnumerable<YearlyReportDash> Get_Data_CRORN(int _year, long _compID)
    {
        return Query<YearlyReportDash>("EXEC SP_WCAPITALBYMONTCRORN @nyear,@companyID", new { nyear = _year, companyID = _compID });
    }
    public IEnumerable<YearlyReportDash> Get_Data_NKTORN(int _year, long _compID)
    {
        return Query<YearlyReportDash>("EXEC SP_WCAPITALBYMONTNKTORN @nyear,@companyID", new { nyear = _year, companyID = _compID });
    }
    public IEnumerable<YearlyReportDash> Get_Data_EbitMarjin(int _year, long _compID)
    {
        return Query<YearlyReportDash>("EXEC SP_EBITMARGINBYMONTHV1 @nyear,@companyID", new { nyear = _year, companyID = _compID });
    }
}
