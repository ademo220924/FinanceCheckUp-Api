using FinanceCheckUp.Application.Contexts.Concretes.Databases;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Application.Models.ViewModel.Reports;
using FinanceCheckUp.Framework.Data;
using FinanceCheckUp.Framework.Data.MsSql.Repositories;

namespace FinanceCheckUp.Application.Managers.SqlQueryManager;


public interface IDashGelirTablosuManager : IGenericDapperRepository
{
    public List<DashBilancoViewMznShort> Get_MAINBilancoMznSmm(int _year, long _compID);
    public List<DashBilancoViewMznShort> Get_MAINRevenueMznSmm(int _year, long _compID);
    public List<DashBilancoViewMznShort> Get_MAINRevenueMznAkt(int _year, long _compID);
    public List<DashBilancoViewMznShort> Get_MAINBilancoMznAkt(int _year, long _compID);
    public List<DashBilancoViewMznShort> Get_MAINBilancoMznAktMulti(long _compID);
    public List<DashBilancoViewMznShort> Get_MAINBilancoMznAktCompare(long _compID, long _yearD, long _monID);
    public List<DashBilancoViewMznShort> Get_MAINBilancoMznAktMultiKon(long _compID);
    public List<DashBilancoViewMznShort> Get_MAINBilancoMznAktMultiJRNL(long _compID);
    public List<DashBilancoViewMznShort> Get_MAINRevenueMznAktMultiJRNL(long _compID);
    public List<DashBilancoViewMznShort> Get_MAINRevenueMznAktMultiKon(long _compID);
    public List<DashBilancoViewMznShort> Get_MAINRevenueMznAktMulti(long _compID);
    public List<DashBilancoViewMznShort> Get_MAINRevenueMznAktMultiSmm(long _compID);
    public List<DashBilancoViewMznShort> Get_MAINBilancoMznAktMultiSmm(long _compID);
    public List<DashBilancoView> Get_MAINRESULT(int _year, long _compID);
    public List<DashBilancoViewMulti> Get_MAINRESULTMulti(int[] _year, long _compID);

    public List<CashflowView> Get_MAINRESULTMultiCashFlow(long _compID);
    public List<DashBilancoViewMulti> Get_MAINRESULTMultiMain(long _compID);
    public List<DashPivotView> Get_MAINRESULTMultiMainPIVOT(long _compID);
    public int Get_MAINRESULTMultiMainPIVOTCheckFiba(long _compID);
    public int Get_MAINRESULTMultiMainPIVOTCheckFibaPr(long _compID);
    public int Get_MAINRESULTMultiMainPIVOTCheck(long _compID);
    public List<DashShortView> Get_MAINRESULTMultiMainPIVOTANeo(long _compID);
    public List<DashPivotView> Get_MAINRESULTMultiMainPIVOTA(long _compID);
    public List<DashPivotView> Get_MAINRESULTMultiMainPIVOTB(long _compID);
    public List<DashPivotView> Get_MAINRESULTMultiMainPIVOTAMIFIBA(long _compID);
    public List<DashPivotView> Get_MAINRESULTMultiMainPIVOTBMIFIBA(long _compID);
    public List<DashPivotView> Get_MAINRESULTMultiMainPIVOTAMI(long _compID);
    public List<DashPivotView> Get_MAINRESULTMultiMainPIVOTBMI(long _compID);
    public List<DashBilancoViewMulti> Get_MAINRESULTMultiRVNMain(long _compID);
    public List<DashBilancoViewMulti> Get_MAINRESULTMultiRVN(int[] _year, long _compID);
    public List<DashBilancoView> Get_MAINTAXCheck(int _year, long _compID);
    public List<DashBilancoView> Get_MaliBorcT(int _year, long _compID);

    public List<DashBilancoView> Get_TicBorcT(int _year, long _compID);

    public List<DashBilancoView> Get_DigerBorcT(int _year, long _compID);

    public List<DashBilancoView> Get_AlinanAvansT(int _year, long _compID);

    public List<DashBilancoView> Get_InsaatOnarimHakedisT(int _year, long _compID);

    public List<DashBilancoView> Get_VergiYukT(int _year, long _compID);
    public List<DashBilancoView> Get_BorcKarslkT(int _year, long _compID);

    public List<DashBilancoView> Get_KTahakkukT(int _year, long _compID);

    public List<DashBilancoView> Get_YabKaynakT(int _year, long _compID);

    public List<DashBilancoView> Get_TOPLAMT(int _year, long _compID);
    public List<DashBilancoView> Get_TOPLAMTU(int _year, long _compID);
    public List<DashBilancoView> Get_MaliBorcUT(int _year, long _compID);

    public List<DashBilancoView> Get_TicBorcUT(int _year, long _compID);

    public List<DashBilancoView> Get_DigerBorcUT(int _year, long _compID);

    public List<DashBilancoView> Get_AlinanAvansUT(int _year, long _compID);

    public List<DashBilancoView> Get_BorcKarslkUT(int _year, long _compID);

    public List<DashBilancoView> Get_TahakkukUT(int _year, long _compID);

    public List<DashBilancoView> Get_YabKaynakUT(int _year, long _compID);
    public List<DashPivotView> Get_MAINRESULTMultiMainPIVOTBMIFIBAPR(long _compID);
    public List<DashPivotView> Get_MAINRESULTMultiMainPIVOTAMIFIBAPR(long _compID);
}

public class DashGelirTablosuManager(FinanceCheckUpDbContext _dbContext) : GenericDapperRepositoryBase(_dbContext), IDashGelirTablosuManager
{
    public List<DashBilancoViewMznShort> Get_MAINBilancoMznSmm(int _year, long _compID)
    {
        string sql = @"EXEC SPP_SMMMZNBLNC @companyID,@nyear";

        return Query<DashBilancoViewMznShort>(sql, new { nyear = _year, companyID = _compID }).ToList();
    }



    public List<DashBilancoViewMznShort> Get_MAINRevenueMznSmm(int _year, long _compID)
    {
        string sql = @"EXEC SPP_SMMMZNRVN @companyID,@nyear";

        return Query<DashBilancoViewMznShort>(sql, new { nyear = _year, companyID = _compID }).ToList();
    }
    public List<DashBilancoViewMznShort> Get_MAINRevenueMznAkt(int _year, long _compID)
    {
        string sql = @"EXEC SPP_SMMMZNRVNAKT @companyID,@nyear";

        return Query<DashBilancoViewMznShort>(sql, new { nyear = _year, companyID = _compID }).ToList();
    }
    public List<DashBilancoViewMznShort> Get_MAINBilancoMznAkt(int _year, long _compID)
    {
        string sql = @"EXEC [SPP_SMMMZNBLNCAKT] @companyID,@nyear";

        return Query<DashBilancoViewMznShort>(sql, new { nyear = _year, companyID = _compID }).ToList();
    }
    public List<DashBilancoViewMznShort> Get_MAINBilancoMznAktMulti(long _compID)
    {
        List<DashBilancoViewMznShort> nlist = new List<DashBilancoViewMznShort>();
        long _compIDz = _compID * -1000000;
        string sql1 = @"Select DISTINCT(Year) from [TBLMSampleBlncoMzn] where CompanyID=@companyID";
        List<int> nlistint = Query<int>(sql1, new { companyID = _compIDz }).ToList();

        foreach (var item in nlistint)
        {
            string sql = @"EXEC SPP_SMMMZNBLNCAKT @companyID,@nyear";

            List<DashBilancoViewMznShort> tlist = Query<DashBilancoViewMznShort>(sql, new { nyear = item, companyID = _compID }).ToList();
            nlist.AddRange(tlist);
        }

        return nlist;

    }
    public List<DashBilancoViewMznShort> Get_MAINBilancoMznAktCompare(long _compID, long _yearD, long _monID)
    {


        string sql = @"EXEC SPP_SMMMZZCOMPR @companyID,@nyear,@mmonth";

        List<DashBilancoViewMznShort> tlist = Query<DashBilancoViewMznShort>(sql, new { companyID = _compID, nyear = _yearD, mmonth = _monID }).ToList();


        return tlist;

    }
    public List<DashBilancoViewMznShort> Get_MAINBilancoMznAktMultiKon(long _compID)
    {
        List<DashBilancoViewMznShort> nlist = new List<DashBilancoViewMznShort>();
        long _compIDz = _compID * -1000000;
        string sql1 = @"Select DISTINCT(Year) from [TBLMSampleBlncoRasTKon] where CompanyID=@companyID";
        List<int> nlistint = Query<int>(sql1, new { companyID = _compIDz }).ToList();

        foreach (var item in nlistint)
        {
            string sql = @"EXEC SPP_SMMMZNBLNCAKTKON @companyID,@nyear";

            List<DashBilancoViewMznShort> tlist = Query<DashBilancoViewMznShort>(sql, new { nyear = item, companyID = _compID }).ToList();
            nlist.AddRange(tlist);
        }

        return nlist;

    }
    //SPP_SMMMZNRVNAKTJRNL
    public List<DashBilancoViewMznShort> Get_MAINBilancoMznAktMultiJRNL(long _compID)
    {
        List<DashBilancoViewMznShort> nlist = new List<DashBilancoViewMznShort>();
        long _compIDz = _compID * -1000000;
        string sql1 = @"Select DISTINCT(Year) from [TBLMSampleBlncoMzn] where CompanyID=@companyID";
        List<int> nlistint = Query<int>(sql1, new { companyID = _compIDz }).ToList();

        foreach (var item in nlistint)
        {

            string sql = @"EXEC SPP_SMMMZNBLNCAKTJRNL @companyID,@nyear";

            List<DashBilancoViewMznShort> tlist = Query<DashBilancoViewMznShort>(sql, new { nyear = item, companyID = _compID }).ToList();
            nlist.AddRange(tlist);
        }

        return nlist;

    }
    public List<DashBilancoViewMznShort> Get_MAINRevenueMznAktMultiJRNL(long _compID)
    {
        List<DashBilancoViewMznShort> nlist = new List<DashBilancoViewMznShort>();
        long _compIDz = _compID * -1000000;
        string sql1 = @"Select DISTINCT(Year) from [TBLMRevenueMzn] where CompanyID=@companyID";
        List<int> nlistint = Query<int>(sql1, new { companyID = _compIDz }).ToList();

        foreach (var item in nlistint)
        {
            string sql = @"EXEC SPP_SMMMZNRVNAKTJRNL @companyID,@nyear";

            List<DashBilancoViewMznShort> tlist = Query<DashBilancoViewMznShort>(sql, new { nyear = item, companyID = _compID }).ToList();
            nlist.AddRange(tlist);
        }

        return nlist;
    }
    public List<DashBilancoViewMznShort> Get_MAINRevenueMznAktMultiKon(long _compID)
    {
        List<DashBilancoViewMznShort> nlist = new List<DashBilancoViewMznShort>();
        long _compIDz = _compID * -1000000;
        string sql1 = @"Select DISTINCT(Year) from [TBLMRevenueRasTKon] where CompanyID=@companyID";
        List<int> nlistint = Query<int>(sql1, new { companyID = _compIDz }).ToList();

        foreach (var item in nlistint)
        {
            string sql = @"EXEC SPP_SMMMZNRVNAKTKon @companyID,@nyear";

            List<DashBilancoViewMznShort> tlist = Query<DashBilancoViewMznShort>(sql, new { nyear = item, companyID = _compID }).ToList();
            nlist.AddRange(tlist);
        }

        return nlist;
    }
    public List<DashBilancoViewMznShort> Get_MAINRevenueMznAktMulti(long _compID)
    {
        List<DashBilancoViewMznShort> nlist = new List<DashBilancoViewMznShort>();
        long _compIDz = _compID * -1000000;
        string sql1 = @"Select DISTINCT(Year) from [TBLMRevenueMzn] where CompanyID=@companyID";
        List<int> nlistint = Query<int>(sql1, new { companyID = _compIDz }).ToList();

        foreach (var item in nlistint)
        {
            string sql = @"EXEC SPP_SMMMZNRVNAKT @companyID,@nyear";

            List<DashBilancoViewMznShort> tlist = Query<DashBilancoViewMznShort>(sql, new { nyear = item, companyID = _compID }).ToList();
            nlist.AddRange(tlist);
        }

        return nlist;
    }
    public List<DashBilancoViewMznShort> Get_MAINRevenueMznAktMultiSmm(long _compID)
    {
        List<DashBilancoViewMznShort> nlist = new List<DashBilancoViewMznShort>();
        long _compIDz = _compID * -1;
        string sql1 = @"Select DISTINCT(Year) from [TBLMRevenueMzn] where CompanyID=@companyID";
        List<int> nlistint = Query<int>(sql1, new { companyID = _compIDz }).ToList();

        foreach (var item in nlistint)
        {
            string sql = @"EXEC SPP_SMMMZNRVN @companyID,@nyear";

            List<DashBilancoViewMznShort> tlist = Query<DashBilancoViewMznShort>(sql, new { nyear = item, companyID = _compID }).ToList();
            nlist.AddRange(tlist);
        }

        return nlist;
    }
    public List<DashBilancoViewMznShort> Get_MAINBilancoMznAktMultiSmm(long _compID)
    {
        List<DashBilancoViewMznShort> nlist = new List<DashBilancoViewMznShort>();
        long _compIDz = _compID * -1;
        string sql1 = @"Select DISTINCT(Year) from [TBLMSampleBlncoMzn] where CompanyID=@companyID";
        List<int> nlistint = Query<int>(sql1, new { companyID = _compIDz }).ToList();

        foreach (var item in nlistint)
        {
            string sql = @"EXEC SPP_SMMMZNBLNC @companyID,@nyear";

            List<DashBilancoViewMznShort> tlist = Query<DashBilancoViewMznShort>(sql, new { nyear = item, companyID = _compID }).ToList();
            nlist.AddRange(tlist);
        }

        return nlist;

    }
    public List<DashBilancoView> Get_MAINRESULT(int _year, long _compID)
    {
        return Query<DashBilancoView>("Select * from  TBLMSampleBlnco WITH (NOLOCK) Where CompanyID=@companyID and [Year]=@nyear", new { nyear = _year, companyID = _compID }).ToList();
    }
    public List<DashBilancoViewMulti> Get_MAINRESULTMulti(int[] _year, long _compID)
    {
        return Query<DashBilancoViewMulti>("Select * from  TBLMSampleBlncoMzn WITH (NOLOCK) Where CompanyID=@companyID and [Year] in @nyear ", new { nyear = _year, companyID = _compID }).ToList();
    }

    public List<CashflowView> Get_MAINRESULTMultiCashFlow(long _compID)
    {
        return Query<CashflowView>("Select * from [dbo].[TBLMNKTAKIS] where CompanyID=@companyID  order by TypeID asc", new { companyID = _compID }).ToList();
    }
    public List<DashBilancoViewMulti> Get_MAINRESULTMultiMain(long _compID)
    {
        string sqll = @"Select  [AccountMainID]
      ,[AccountMainDescription]
      ,[DebitCreditCode]
        , CASE WHEN(([AccountMainID] > '299' and [AccountMainID] < '550') and [AccountMainID] not in ('300','400','303','309'))  or (TypeID in (333, 444) and Amount<0) THEN Amount*-1 ELSE Amount END as 'Amount'
      ,[CompanyID]
      ,[Year]
      ,[GroupName]
      ,[CounterZone]
      ,[TypeID]
      ,[IsHidden]
      ,[ID]
      ,[CreatedDate]from  TBLMSampleBlncoMzn WITH (NOLOCK) Where CompanyID=@companyID ";


        return Query<DashBilancoViewMulti>(sqll, new { companyID = _compID }).ToList();
    }
    public List<DashPivotView> Get_MAINRESULTMultiMainPIVOT(long _compID)
    {
        string sqll = @"Select    [ID]
      ,[AccountMainID]
      ,[AccountMainDescription] 
      ,CAST([Amount] AS DECIMAL(25, 2))   as 'Amount' 
      ,case when CAST([Diff] AS DECIMAL(25, 2))>CAST('-0.01' AS DECIMAL(25, 2)) and CAST([Diff] AS DECIMAL(25, 2))<CAST('0.01' AS DECIMAL(25, 2)) THEN '-' ELSE '% '+ CAST(CAST([Diff] AS DECIMAL(25, 2)) as nvarchar(25))   END as 'DiffZone'
      ,[DiffVal]
      ,[CompanyID]
      ,[Year]
      ,[GroupName]
      ,[CounterZone]
      ,[TypeID]
      ,[IsHidden] from  TBLMSampleBlncoShrt WITH (NOLOCK) Where CompanyID=@companyID ";


        return Query<DashPivotView>(sqll, new { companyID = _compID }).ToList();
    }
    public int Get_MAINRESULTMultiMainPIVOTCheckFiba(long _compID)
    {
        string sqll = @"IF(NOT EXISTS(SELECT* FROM TBLMSampleBlncoShrtCustom WHERE CompanyID = @compID) )
        BEGIN
            EXEC SP_CUSTSPCE @compID; 
        END";


        return Query<int>(sqll, new { compID = _compID }).FirstOrDefault();
    }
    
    public   int Get_MAINRESULTMultiMainPIVOTCheckFibaPr(long _compID)
    {
        string sqll = @"IF(NOT EXISTS(SELECT* FROM TBLMSampleBlncoShrtCustomPr WHERE CompanyID = @compID) )
        BEGIN
            EXEC SP_CUSTSPCEPR @compID; 
        END";


        return StaticQuery<int>(sqll, new { compID = _compID }).FirstOrDefault();
    }
    
    public int Get_MAINRESULTMultiMainPIVOTCheck(long _compID)
    {
        string sqll = @"IF(NOT EXISTS(SELECT* FROM TBLMSampleBlncoShrt WHERE CompanyID = @compID) )
        BEGIN
            EXEC [SP_Main_CompanyViewBilancoShrtMIZAN] @compID;
        EXEC SP_Main_Grow_ViewBiloncoScoreListMIZAN @compID;
        END";


        return Query<int>(sqll, new { compID = _compID }).FirstOrDefault();
    }
    public List<DashShortView> Get_MAINRESULTMultiMainPIVOTANeo(long _compID)
    {
        string sqll = @"EXEC ShortBilancoView @companyID ";


        return Query<DashShortView>(sqll, new { companyID = _compID }).ToList();
    }
    public List<DashPivotView> Get_MAINRESULTMultiMainPIVOTA(long _compID)
    {
        string sqll = @"Select    [ID]
      ,[AccountMainID]
      ,[AccountMainDescription] 
      ,CAST([Amount] AS DECIMAL(25, 2))   as 'Amount'
      ,case when CAST([Diff] AS DECIMAL(25, 2))>CAST('-0.01' AS DECIMAL(25, 2)) and CAST([Diff] AS DECIMAL(25, 2))<CAST('0.01' AS DECIMAL(25, 2)) THEN '-' ELSE '% '+ CAST(CAST([Diff] AS DECIMAL(25, 2)) as nvarchar(25))   END as 'DiffZone'
       , CAST([Diff] AS DECIMAL(25, 2)) as 'Diff'
      ,[DiffVal]
      ,[CompanyID]
      ,[Year]
      ,[GroupName]
      ,[CounterZone]
      ,[TypeID]
      ,[IsHidden] from  TBLMSampleBlncoShrt where ((AccountMainID between 99 and 299) or TypeID in (111,222,2121)) and CompanyID=@companyID ";


        return Query<DashPivotView>(sqll, new { companyID = _compID }).ToList();
    }
    public List<DashPivotView> Get_MAINRESULTMultiMainPIVOTB(long _compID)
    {
        string sqll = @"Select    [ID]
      ,[AccountMainID]
      ,[AccountMainDescription] 
      ,CASE WHEN TypeID=4141 THEN CAST(ABS([Amount]) AS DECIMAL(25, 2)) ELSE CAST([Amount] AS DECIMAL(25, 2)) END  as 'Amount'
      ,case when CAST([Diff] AS DECIMAL(25, 2))>CAST('-0.01' AS DECIMAL(25, 2)) and CAST([Diff] AS DECIMAL(25, 2))<CAST('0.01' AS DECIMAL(25, 2)) THEN '-' ELSE '% '+ CAST(CAST([Diff] AS DECIMAL(25, 2)) as nvarchar(25))   END as 'DiffZone'
      ,[DiffVal]   ,CASE WHEN [Amount]<-1 and TypeID<>4141 THEN  CAST(ABS([Diff]) AS DECIMAL(25, 2))*-1 ELSE  CAST(ABS([Diff]) AS DECIMAL(25, 2))  END as 'Diff'
      ,[CompanyID]
      ,[Year]
      ,[GroupName]
      ,[CounterZone]
      ,[TypeID]
      ,[IsHidden] from  TBLMSampleBlncoShrt where ((AccountMainID between 299 and 599) or TypeID in (333,444,4141,3333)) and CompanyID=@companyID ";


        return Query<DashPivotView>(sqll, new { companyID = _compID }).ToList();
    }
    public List<DashPivotView> Get_MAINRESULTMultiMainPIVOTAMIFIBA(long _compID)
    {
        string sqll = @"Select    [ID]
      ,[AccountMainID]
      ,[AccountMainDescription] 
      ,CAST([Amount] AS DECIMAL(25, 2))   as 'Amount'
      ,case when CAST([Diff] AS DECIMAL(25, 2))>CAST('-0.01' AS DECIMAL(25, 2)) and CAST([Diff] AS DECIMAL(25, 2))<CAST('0.01' AS DECIMAL(25, 2)) THEN '-' ELSE '% '+ CAST(CAST([Diff] AS DECIMAL(25, 2)) as nvarchar(25))   END as 'DiffZone'
       , CAST([Diff] AS DECIMAL(25, 2)) as 'Diff'
      ,[DiffVal]
      ,[CompanyID]
      ,[Year]
      ,[GroupName]
      ,[CounterZone]
      ,[TypeID]
      ,[IsHidden] ,YearTx from  TBLMSampleBlncoShrtCustom where  CounterZone <63    and CompanyID=@companyID order by CounterZone";


        return Query<DashPivotView>(sqll, new { companyID = _compID }).ToList();
    }
    public List<DashPivotView> Get_MAINRESULTMultiMainPIVOTBMIFIBA(long _compID)
    {
        string sqll = @"Select    [ID]
      ,[AccountMainID]
      ,[AccountMainDescription] 
      ,CASE WHEN TypeID=4141 THEN CAST(ABS([Amount]) AS DECIMAL(25, 2)) ELSE CAST([Amount] AS DECIMAL(25, 2)) END  as 'Amount'
      ,[Diff]   as 'DiffZone'
      ,[DiffVal]  as 'Diff'
      ,[CompanyID]
      ,[Year]
      ,[GroupName]
      ,[CounterZone]
      ,[TypeID]
      ,[IsHidden],YearTx from  TBLMSampleBlncoShrtCustom where  CounterZone >62     and CompanyID=@companyID order by CounterZone";


        return Query<DashPivotView>(sqll, new { companyID = _compID }).ToList();
    }
    public List<DashPivotView> Get_MAINRESULTMultiMainPIVOTAMI(long _compID)
    {
        string sqll = @"Select    [ID]
      ,[AccountMainID]
      ,[AccountMainDescription] 
      ,CAST(ABS([Amount]) AS DECIMAL(25, 2))   as 'Amount'
      ,case when CAST([Diff] AS DECIMAL(25, 2))>CAST('-0.01' AS DECIMAL(25, 2)) and CAST([Diff] AS DECIMAL(25, 2))<CAST('0.01' AS DECIMAL(25, 2)) THEN '-' ELSE '% '+ CAST(CAST([Diff] AS DECIMAL(25, 2)) as nvarchar(25))   END as 'DiffZone'
       , CAST([Diff] AS DECIMAL(25, 2)) as 'Diff'
      ,[DiffVal]
      ,[CompanyID]
      ,[Year]
      ,[GroupName]
      ,[CounterZone]
      ,[TypeID]
      ,[IsHidden] from  TBLMSampleBlncoShrt where ((AccountMainID between 99 and 299) or TypeID in (111,222,2221)) and CompanyID=@companyID ";


        return Query<DashPivotView>(sqll, new { companyID = _compID }).ToList();
    }
    public List<DashPivotView> Get_MAINRESULTMultiMainPIVOTBMI(long _compID)
    {
        string sqll = @"Select    [ID]
      ,[AccountMainID]
      ,[AccountMainDescription] 
      ,CASE WHEN TypeID=4141 THEN CAST(ABS([Amount]) AS DECIMAL(25, 2)) ELSE CAST(ABS([Amount]) AS DECIMAL(25, 2)) END  as 'Amount'
      ,case when CAST([Diff] AS DECIMAL(25, 2))>CAST('-0.01' AS DECIMAL(25, 2)) and CAST([Diff] AS DECIMAL(25, 2))<CAST('0.01' AS DECIMAL(25, 2)) THEN '-' ELSE '% '+ CAST(CAST([Diff] AS DECIMAL(25, 2)) as nvarchar(25))   END as 'DiffZone'
      ,[DiffVal]   ,CASE WHEN [Amount]<-1 and TypeID<>4141 THEN  CAST(ABS([Diff]) AS DECIMAL(25, 2))*-1 ELSE  CAST(ABS([Diff]) AS DECIMAL(25, 2))  END as 'Diff'
      ,[CompanyID]
      ,[Year]
      ,[GroupName]
      ,[CounterZone]
      ,[TypeID]
      ,[IsHidden] from  TBLMSampleBlncoShrt where ((AccountMainID between 299 and 599) or TypeID in (333,444,2223,3333)) and CompanyID=@companyID ";


        return Query<DashPivotView>(sqll, new { companyID = _compID }).ToList();
    }
    public List<DashBilancoViewMulti> Get_MAINRESULTMultiRVNMain(long _compID)
    {
        return Query<DashBilancoViewMulti>("Select * from  TBLMRevenueMzn WITH (NOLOCK) Where CompanyID=@companyID   ", new { companyID = _compID }).ToList();
    }
    public List<DashBilancoViewMulti> Get_MAINRESULTMultiRVN(int[] _year, long _compID)
    {
        return Query<DashBilancoViewMulti>("Select * from  TBLMRevenueMzn WITH (NOLOCK) Where CompanyID=@companyID and [Year] in @nyear ", new { nyear = _year, companyID = _compID }).ToList();
    }
    public List<DashBilancoView> Get_MAINTAXCheck(int _year, long _compID)
    {
        return Query<DashBilancoView>("Select * from   [dbo].[TBLZoneCheck] WITH (NOLOCK) Where CompanyID=@companyID and [Year]=@nyear", new { nyear = _year, companyID = _compID }).ToList();
    }
    public List<DashBilancoView> Get_MaliBorcT(int _year, long _compID)
    {
        return Query<DashBilancoView>("EXEC SP_Main_Grow_Header @companyID, @nyear,30", new { nyear = _year, companyID = _compID }).ToList();
    }

    public List<DashBilancoView> Get_TicBorcT(int _year, long _compID)
    {
        return Query<DashBilancoView>("EXEC SP_Main_Grow_Header @companyID, @nyear,32", new { nyear = _year, companyID = _compID }).ToList();
    }

    public List<DashBilancoView> Get_DigerBorcT(int _year, long _compID)
    {
        return Query<DashBilancoView>("EXEC SP_Main_Grow_Header @companyID, @nyear,33", new { nyear = _year, companyID = _compID }).ToList();
    }

    public List<DashBilancoView> Get_AlinanAvansT(int _year, long _compID)
    {
        return Query<DashBilancoView>("EXEC SP_Main_Grow_Header @companyID, @nyear,34", new { nyear = _year, companyID = _compID }).ToList();
    }

    public List<DashBilancoView> Get_InsaatOnarimHakedisT(int _year, long _compID)
    {
        return Query<DashBilancoView>("EXEC SP_Main_Grow_Header @companyID, @nyear,35", new { nyear = _year, companyID = _compID }).ToList();
    }

    public List<DashBilancoView> Get_VergiYukT(int _year, long _compID)
    {
        return Query<DashBilancoView>("EXEC SP_Main_Grow_Header @companyID, @nyear,36", new { nyear = _year, companyID = _compID }).ToList();
    }

    public List<DashBilancoView> Get_BorcKarslkT(int _year, long _compID)
    {
        return Query<DashBilancoView>("EXEC SP_Main_Grow_Header @companyID, @nyear,37", new { nyear = _year, companyID = _compID }).ToList();
    }

    public List<DashBilancoView> Get_KTahakkukT(int _year, long _compID)
    {
        return Query<DashBilancoView>("EXEC SP_Main_Grow_Header @companyID, @nyear,38", new { nyear = _year, companyID = _compID }).ToList();
    }

    public List<DashBilancoView> Get_YabKaynakT(int _year, long _compID)
    {
        return Query<DashBilancoView>("EXEC SP_Main_Grow_Header @companyID, @nyear,39", new { nyear = _year, companyID = _compID }).ToList();
    }

    public List<DashBilancoView> Get_TOPLAMT(int _year, long _compID)
    {
        return Query<DashBilancoView>("EXEC SP_Main_Grow_HeaderMainV1 @companyID, @nyear,3", new { nyear = _year, companyID = _compID }).ToList();
    }
    public List<DashBilancoView> Get_TOPLAMTU(int _year, long _compID)
    {
        return Query<DashBilancoView>("EXEC SP_Main_Grow_HeaderMainV1 @companyID, @nyear,4", new { nyear = _year, companyID = _compID }).ToList();
    }
    public List<DashBilancoView> Get_MaliBorcUT(int _year, long _compID)
    {
        return Query<DashBilancoView>("EXEC SP_Main_Grow_Header @companyID, @nyear,40", new { nyear = _year, companyID = _compID }).ToList();
    }

    public List<DashBilancoView> Get_TicBorcUT(int _year, long _compID)
    {
        return Query<DashBilancoView>("EXEC SP_Main_Grow_Header @companyID, @nyear,42", new { nyear = _year, companyID = _compID }).ToList();
    }

    public List<DashBilancoView> Get_DigerBorcUT(int _year, long _compID)
    {
        return Query<DashBilancoView>("EXEC SP_Main_Grow_Header @companyID, @nyear,43", new { nyear = _year, companyID = _compID }).ToList();
    }

    public List<DashBilancoView> Get_AlinanAvansUT(int _year, long _compID)
    {
        return Query<DashBilancoView>("EXEC SP_Main_Grow_Header @companyID, @nyear,44", new { nyear = _year, companyID = _compID }).ToList();
    }

    public List<DashBilancoView> Get_BorcKarslkUT(int _year, long _compID)
    {
        return Query<DashBilancoView>("EXEC SP_Main_Grow_Header @companyID, @nyear,47", new { nyear = _year, companyID = _compID }).ToList();
    }

    public List<DashBilancoView> Get_TahakkukUT(int _year, long _compID)
    {
        return Query<DashBilancoView>("EXEC SP_Main_Grow_Header @companyID, @nyear,48", new { nyear = _year, companyID = _compID }).ToList();
    }

    public List<DashBilancoView> Get_YabKaynakUT(int _year, long _compID)
    {
        return Query<DashBilancoView>("EXEC SP_Main_Grow_Header @companyID, @nyear,49", new { nyear = _year, companyID = _compID }).ToList();
    }

    public   List<DashPivotView> Get_MAINRESULTMultiMainPIVOTBMIFIBAPR(long _compID)
    {
        string sqll = @"Select    [ID]
      ,[AccountMainID]
      ,[AccountMainDescription] 
      ,CASE WHEN TypeID=4141 THEN CAST(ABS([Amount]) AS DECIMAL(25, 2)) ELSE CAST([Amount] AS DECIMAL(25, 2)) END  as 'Amount'
      ,[Diff]   as 'DiffZone'
      ,[DiffVal]  as 'Diff'
      ,[CompanyID]
      ,[Year]
      ,[GroupName]
      ,[CounterZone]
      ,[TypeID]
      ,[IsHidden],YearTx  from  TBLMSampleBlncoShrtCustomPr where  CounterZone >62     and CompanyID=@companyID order by CounterZone";


        return StaticQuery<DashPivotView>(sqll, new { companyID = _compID }).ToList();
    }
    
    
    public   List<DashPivotView> Get_MAINRESULTMultiMainPIVOTAMIFIBAPR(long _compID)
    {
        string sqll = @"Select    [ID]
      ,[AccountMainID]
      ,[AccountMainDescription] 
      ,CAST([Amount] AS DECIMAL(25, 2))   as 'Amount'
      ,case when CAST([Diff] AS DECIMAL(25, 2))>CAST('-0.01' AS DECIMAL(25, 2)) and CAST([Diff] AS DECIMAL(25, 2))<CAST('0.01' AS DECIMAL(25, 2)) THEN '-' ELSE '% '+ CAST(CAST([Diff] AS DECIMAL(25, 2)) as nvarchar(25))   END as 'DiffZone'
       , CAST([Diff] AS DECIMAL(25, 2)) as 'Diff'
      ,[DiffVal]
      ,[CompanyID]
      ,[Year]
      ,[GroupName]
      ,[CounterZone]
      ,[TypeID]
      ,[IsHidden],YearTx  from  TBLMSampleBlncoShrtCustomPr where  CounterZone <63    and CompanyID=@companyID order by CounterZone";


        return StaticQuery<DashPivotView>(sqll, new { companyID = _compID }).ToList();
    }

    //public  List<DashBilancoView> Get_FinansmanGiderT(int _year, long _compID)
    //{//   ""SPO_WcapFinansmanGiderTpl
    //    return Query<DashBilancoView>("EXEC SPO_WcapFinansmanGiderTpl @companyID, @nyear", new { nyear = _year, companyID = _compID }).ToList();//--- +++('660','661')+++ TestMainOKynkFinansmanGider(TBLWcapFinansmanGider)
    //}



}
