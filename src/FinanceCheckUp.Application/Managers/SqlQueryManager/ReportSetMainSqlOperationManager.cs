using FinanceCheckUp.Application.Contexts.Concretes.Databases;
using FinanceCheckUp.Application.Models.ViewModel;
using FinanceCheckUp.Application.Models.ViewModel.Reports;
using FinanceCheckUp.Framework.Data;
using FinanceCheckUp.Framework.Data.MsSql.Repositories;

namespace FinanceCheckUp.Application.Managers.SqlQueryManager;

public interface IReportSetMainSqlOperationManager : IGenericDapperRepository
{
    int Set_ReportSetMain(int _year, long _compID);
    int Set_ReportSetMulti(int _year, long _compID);
    int Set_ReportSet(int _year, long _compID);
    int Set_ReportSetKon(int _year, long _compID);
    int Set_ReportSetKonM(int _year, long _compID);
    List<YearlyErrorResult> Get_StatbyCompany(long _compID);
    List<YearlyErrorResult> Get_StatbyCompanyConsole(long _compID);
    List<YearlyErrorResult> Get_StatbyCompanyConsoleM(long _compID);
    List<YearlyErrorResult> Get_StatbyCompanyAktarmaMizan(long _compID);
    List<YearlyErrorResult> Get_StatbyCompanyAktarma(long _compID);
    List<DashAktarma> Get_CompanyAktarmaResult(int _year, long _compID);
    List<YearlyErrorResult> StartCompanyAktarma(int _year, long _compID);
    List<YearlyErrorResult> StartCompanyAktarmaMizan(int _year, long _compID);
    List<YearlyErrorResult> Get_StatbyCompanyAktarmaMZN(long _compID);
    List<YearlyErrorResult> Get_StatbyCompanyExcel(long _compID);
    List<YearlyErrorResult> Get_StatbyCompanyMain(long _compID);
    List<YearlyErrorResult> Get_StatbyCompanyMainQNB(long _compID);
    List<ReportSet> Get_ReportSetBilanco(int _year, long _compID);
    List<ReportSet> Get_ReportSetFiba(long _compID);
    List<ReportSet> Get_ReportSetBilancoMzn(int _year, long _compID);
    List<ReportSet> Get_ReportSetBilancoAkt(int _year, long _compID);
    List<ReportSet> Get_ReportSetBilancoAktJRNL(int _year, long _compID);
}


public class ReportSetMainSqlOperationManager(FinanceCheckUpDbContext _dbContext) : GenericDapperRepositoryBase(_dbContext), IReportSetMainSqlOperationManager
{
    public int Set_ReportSetMain(int _year, long _compID)
    {
        try
        {
            return Query<int>("EXEC SPO_REPOR00GENERALTOTAL @companyID, @nyear,1", new { nyear = _year, companyID = _compID }).FirstOrDefault();
        }
        catch (Exception ex)
        {
            var chk = ex;
            throw;
        }

        //SPO_COMPANYMIZANERR  SPO_DONUKCHK
    }
    public int Set_ReportSetMulti(int _year, long _compID)
    {

        Query<int>("EXEC [dbo].[SP_TBLXMLSourceRepV3] @companyID, @nyear", new { nyear = _year, companyID = _compID }).FirstOrDefault();
        Query<int>("EXEC [dbo].[SPO_COMPANYMIZANERR] @companyID, @nyear", new { nyear = _year, companyID = _compID }).FirstOrDefault();
        return Query<int>("EXEC [dbo].[SPO_DONUKCHK] @companyID, @nyear,3", new { nyear = _year, companyID = _compID }).FirstOrDefault();
        //SPO_COMPANYMIZANERR  SPO_DONUKCHK  SPO_COMPANYMIZANERRMZN
    }
    public int Set_ReportSet(int _year, long _compID)
    {

        Query<int>("EXEC [dbo].[SP_TBLXMLSourceRep] @companyID, @nyear", new { nyear = _year, companyID = _compID });
        Query<int>("EXEC [dbo].[SPO_COMPANYMIZANERR] @companyID, @nyear", new { nyear = _year, companyID = _compID });

        return Query<int>("EXEC [dbo].[SPO_DONUKCHK] @companyID, @nyear,1", new { nyear = _year, companyID = _compID }).FirstOrDefault();
        //SPO_COMPANYMIZANERR  SPO_DONUKCHK  SPO_COMPANYMIZANERRMZN
    }
    public int Set_ReportSetKon(int _year, long _compID)
    {


        return Query<int>("EXEC [dbo].[SPAKT_KONSOL_ALL] @companyID, @nyear", new { nyear = _year, companyID = _compID }).FirstOrDefault();
        //SPO_COMPANYMIZANERR  SPO_DONUKCHK  SPO_COMPANYMIZANERRMZN
    }
    public int Set_ReportSetKonM(int _year, long _compID)
    {


        return Query<int>("EXEC [dbo].[SPAKT_KONSOL_ALLM] @companyID, @nyear", new { nyear = _year, companyID = _compID }).FirstOrDefault();
        //SPO_COMPANYMIZANERR  SPO_DONUKCHK  SPO_COMPANYMIZANERRMZN
    }
    public List<YearlyErrorResult> Get_StatbyCompany(long _compID)
    {
        return Query<YearlyErrorResult>("EXEC SPOT_MIZANREPORTCOUNT @companyID", new { companyID = _compID }).ToList();
    }
    public List<YearlyErrorResult> Get_StatbyCompanyConsole(long _compID)
    {
        return Query<YearlyErrorResult>("EXEC SPOT_MAINKONSOLCOUNT @companyID", new { companyID = _compID }).ToList();
    }
    public List<YearlyErrorResult> Get_StatbyCompanyConsoleM(long _compID)
    {
        return Query<YearlyErrorResult>("EXEC SPOT_MAINKONSOLCOUNTM @companyID", new { companyID = _compID }).ToList();
    }
    public List<YearlyErrorResult> Get_StatbyCompanyAktarmaMizan(long _compID)
    {
        return Query<YearlyErrorResult>("EXEC  SPOT_MAINREPORTCOUNTAKTRMMIZAN @companyID", new { companyID = _compID }).ToList();
    }
    public List<YearlyErrorResult> Get_StatbyCompanyAktarma(long _compID)
    {
        return Query<YearlyErrorResult>("EXEC  SPOT_MAINREPORTCOUNTAKTRM @companyID", new { companyID = _compID }).ToList();
    }
    public List<DashAktarma> Get_CompanyAktarmaResult(int _year, long _compID)
    {
        return StaticQuery<DashAktarma>("Select * from [SPO_TBMLAKTARMA] where CompanyID=@companyID and [YEAR]=@nyear", new { nyear = _year, companyID = _compID }).ToList();
    }
    public List<YearlyErrorResult> StartCompanyAktarma(int _year, long _compID)
    {
        return Query<YearlyErrorResult>("EXEC  SPAKT_PROCALL @companyID, @nyear,1", new { nyear = _year, companyID = _compID }).ToList();
    }
    public List<YearlyErrorResult> StartCompanyAktarmaMizan(int _year, long _compID)
    {
        return Query<YearlyErrorResult>("EXEC  SPAKT_PROCALL @companyID, @nyear,3", new { nyear = _year, companyID = _compID }).ToList();
    }
    public List<YearlyErrorResult> Get_StatbyCompanyAktarmaMZN(long _compID)
    {
        return Query<YearlyErrorResult>("EXEC  SPOT_MIZANREPORTCOUNTAKTRMExcel @companyID", new { companyID = _compID }).ToList();
    }
    public List<YearlyErrorResult> Get_StatbyCompanyExcel(long _compID)
    {
        return Query<YearlyErrorResult>("EXEC SPOT_MIZANREPORTCOUNTExcel @companyID", new { companyID = _compID }).ToList();
    }
    public List<YearlyErrorResult> Get_StatbyCompanyMain(long _compID)
    {
        return Query<YearlyErrorResult>("EXEC SPOT_MAINREPORTCOUNT @companyID", new { companyID = _compID }).ToList();
    }
    public List<YearlyErrorResult> Get_StatbyCompanyMainQNB(long _compID)
    {
        return Query<YearlyErrorResult>("EXEC SPOT_MAINREPORTCOUNTQnb @companyID", new { companyID = _compID }).ToList();
    }
    public List<ReportSet> Get_ReportSetBilanco(int _year, long _compID)
    {
        string sql = @"SELECT  
       [TypeID]
      ,[AccountMainID]
      ,[AccountMainDescription]
      ,[AccountMainEng]
      ,Cast([Amount] as bigint) as  Amount
      ,[DebitCreditCode] 
	  ,Cast([AmountBakiye] as bigint)  'AmountBakiye'
      ,CASE when [DebitCreditCode]='D'  and AccountMainID<>'692' THEN Cast([AmountBakiye] as bigint)
            when [DebitCreditCode]='C'  and Cast([AmountBakiye] as bigint)>0 THEN Cast([AmountBakiye] as bigint)ELSE 0 END as  BorcBakiye 
	  ,CASE when [DebitCreditCode]='C'  and AccountMainID<>'692'  and Cast([AmountBakiye] as bigint)<0  THEN Cast([AmountBakiye] as bigint) 
            when [DebitCreditCode]='D'  and AccountMainID ='692' THEN Cast([Credit] as bigint) 
            when [DebitCreditCode]='D'  and Cast([AmountBakiye] as bigint)=0 THEN 0 ELSE 0 END as  AlacakBakiye 
      ,[SubTypeID]
      ,[MainTypeID] 
      ,[IsErrored]
      ,Cast([MainAmountTotal] as bigint) as  MainAmountTotal,Cast([Debit] as bigint) as Debit ,Cast([Credit] as bigint) as Credit
  FROM [dbo].[TBLXMLSourceOne] where CompanyID=@companyID and  [Year]=@nyear and AccountMainID<800  order by AccountMainID";

        return StaticQuery<ReportSet>(sql, new { nyear = _year, companyID = _compID }).ToList();
    }
    public List<ReportSet> Get_ReportSetFiba(long _compID)
    {
        string sql = @"EXEC [dbo].[SP_A_MIZANHEADERChk] @comp";

        return Query<ReportSet>(sql, new { comp = _compID }).ToList();
    }
    public List<ReportSet> Get_ReportSetBilancoMzn(int _year, long _compID)
    {
        string sql = @"EXEC [SPP_SMMMZN] @companyID,@nyear";

        return Query<ReportSet>(sql, new { nyear = _year, companyID = _compID }).ToList();
    }
    public List<ReportSet> Get_ReportSetBilancoAkt(int _year, long _compID)
    {
        string sql = @"EXEC [SPP_SMMMZNAKT] @companyID,@nyear";

        return Query<ReportSet>(sql, new { nyear = _year, companyID = _compID }).ToList();
    }
    public List<ReportSet> Get_ReportSetBilancoAktJRNL(int _year, long _compID)
    {
        string sql = @"EXEC [SPP_SMMMZNAKTJRNL] @companyID,@nyear";

        return Query<ReportSet>(sql, new { nyear = _year, companyID = _compID }).ToList();
    }
}



