using FinanceCheckUp.Application.Contexts.Concretes.Databases;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Framework.Data;
using FinanceCheckUp.Framework.Data.MsSql.Repositories;

namespace FinanceCheckUp.Application.Managers.SqlQueryManager;
public interface IDashOzetMaliMizanManager : IGenericDapperRepository
{
    public long getPasifMizan(int _year, long _compID);
    public long getOzkaynak(int _year, long _compID);
    public List<DashYearlyResultMizan> OzetMali8(int _year, long _compID);
    public List<DashYearlyResultMizan> OzetMaliFinal(long _compID);
    public long SetErrored(int _year, long _compID, int _monthID);
    public List<DashYearlyResultMizan> OzetMali8Byn(int _year, long _compID);
    public long getKArzarar(int _year, long _compID);
    public int SetJournnal(int _year, long _compID);
    public int  ClearFibaPr(long _compID);
}



public class DashOzetMaliMizanManager(FinanceCheckUpDbContext _dbContext) : GenericDapperRepositoryBase(_dbContext), IDashOzetMaliMizanManager
{
    public long getPasifMizan(int _year, long _compID)
    {
        string sql = @"SELECT SUM(Amount)  FROM [EDEFTERDB].[dbo].[TBLMSampleBlncoMzn] where  CompanyID=@companyID and Year=@nyear and TypeID in (444,333,3333)";
        return Query<long>(sql, new { nyear = _year, companyID = _compID }).FirstOrDefault();
    }
    public long getOzkaynak(int _year, long _compID)
    {
        string sql = @"SELECT SUM(Amount)  FROM [EDEFTERDB].[dbo].[TBLMSampleBlncoMzn] where  CompanyID=@companyID and Year=@nyear and TypeID in (3333)";
        return Query<long>(sql, new { nyear = _year, companyID = _compID }).FirstOrDefault();
    }
    public List<DashYearlyResultMizan> OzetMali8(int _year, long _compID)
    {
        Query<int>("DELETE FROM [EDEFTERDB].[dbo].[TBLMSampleBlncoShrt] where  CompanyID=@companyID", new { companyID = _compID });
        Query<int>("EXEC SPO_MIZANACT @companyID,@nyear", new { companyID = _compID, nyear = _year });
        //string sqle = @"EXEC SPO_MIZANACT @companyID,@nyear";
        //StaticQuery<int>(sqle, new { companyID = _compID,  nyear = _year},commandType: System.Data.CommandType.StoredProcedure).FirstOrDefault();
        float totalKArzarare = getKArzarar(_year, _compID);
        long totalP590 = Get_P590(_year, _compID);
        if (totalP590 == 0 && totalKArzarare > 0)
        {

            //   string sqle1 = @"UPDATE  [dbo].[TBLMSampleBlncoMzn] set [Amount]=@bakiye+[Amount]      where   CompanyID=@companyID and [Year]=@nyear  and AccountMainID ='2223'";
            //StaticQuery<int>(sqle1, new { nyear = _year, companyID = _compID, bakiye = totalKArzarare }); 
        }
        else
        {
            //string sql = @"UPDATE [EDEFTERDB].[dbo].[TBLMSampleBlncoMzn] set Amount=(select SUM(Amount)  FROM [EDEFTERDB].[dbo].[TBLMSampleBlncoMzn] where  CompanyID=@companyID and Year=@nyear and TypeID in (444,333,3333)) where CompanyID=@companyID and Year=@nyear and TypeID in (2223)";StaticQuery<int>("UPDATE   TBLMSampleBlncoMzn set AmountBakiye=AmountBakiye*-1 where  CompanyID=@companyID and [Year]=@nyear and AccountMainID in('590')", new { nyear = _year, companyID = _compID }).FirstOrDefault();
            //StaticQuery<int>(sql, new { nyear = _year, companyID = _compID });
        }

        //

        return Query<DashYearlyResultMizan>("EXEC TTZDashBoardOzetMaliSPMMZN @companyID, @nyear", new { nyear = _year, companyID = _compID }).ToList();
    }

    public List<DashYearlyResultMizan> OzetMaliFinal(long _compID)
    {
        return Query<DashYearlyResultMizan>("Select * from  [TTZDashBoardOzetMaliMzn] where [CompanyID]=@companyID    ", new { companyID = _compID }).ToList();
    }

    public long SetErrored(int _year, long _compID, int _monthID)
    {
        return Execute("EXEC SPGRO_TBLDataErrored @companyID, @nyear, @nmonth", new { nyear = _year, companyID = _compID, nmonth = _monthID });
    }

    public List<DashYearlyResultMizan> OzetMali8Byn(int _year, long _compID)
    {
        Execute("DELETE FROM [EDEFTERDB].[dbo].[TBLMSampleBlncoShrt] where  CompanyID=@companyID", new { companyID = _compID });
        //StaticQuery<int>("EXEC SPO_MIZANACT @companyID,@nyear", new { companyID = _compID, nyear = _year }).FirstOrDefault();
        //string sqle = @"EXEC SPO_MIZANACT @companyID,@nyear";
        //StaticQuery<int>(sqle, new { companyID = _compID,  nyear = _year},commandType: System.Data.CommandType.StoredProcedure).FirstOrDefault();
        float totalKArzarare = getKArzarar(_year, _compID);
        long totalP590 = Get_P590(_year, _compID);
        if (totalP590 == 0 && totalKArzarare > 0)
        {

            //   string sqle1 = @"UPDATE  [dbo].[TBLMSampleBlncoMzn] set [Amount]=@bakiye+[Amount]      where   CompanyID=@companyID and [Year]=@nyear  and AccountMainID ='2223'";
            //StaticQuery<int>(sqle1, new { nyear = _year, companyID = _compID, bakiye = totalKArzarare }); 
        }
        else
        {
            //string sql = @"UPDATE [EDEFTERDB].[dbo].[TBLMSampleBlncoMzn] set Amount=(select SUM(Amount)  FROM [EDEFTERDB].[dbo].[TBLMSampleBlncoMzn] where  CompanyID=@companyID and Year=@nyear and TypeID in (444,333,3333)) where CompanyID=@companyID and Year=@nyear and TypeID in (2223)";StaticQuery<int>("UPDATE   TBLMSampleBlncoMzn set AmountBakiye=AmountBakiye*-1 where  CompanyID=@companyID and [Year]=@nyear and AccountMainID in('590')", new { nyear = _year, companyID = _compID }).FirstOrDefault();
            //StaticQuery<int>(sql, new { nyear = _year, companyID = _compID });
        }

        //

        return Query<DashYearlyResultMizan>("EXEC TTZDashBoardOzetMaliSPMMZN @companyID, @nyear", new { nyear = _year, companyID = _compID }).ToList();
    }

    public long getKArzarar(int _year, long _compID)
    {
        string sql = @"SELECT SUM(Amount)  FROM [EDEFTERDB].[dbo].[TBLMRevenueMzn] where  CompanyID=@companyID and Year=@nyear and TypeID in (9995)";
        return Query<long>(sql, new { nyear = _year, companyID = _compID }).FirstOrDefault();
    }

    private long Get_P590(int _year, long _compID)
    {
        return Query<int>("SELECT  ISNULL(ABS(Cast(SUM([AmountBakiye]) as bigint)),0) as Amount FROM [dbo].[TBLXMLSourceOne] where   CompanyID=@companyID and [Year]=@nyear  and AccountMainID ='590'", new { nyear = _year, companyID = _compID }).FirstOrDefault();
    }
    
    public   int SetJournnal(int _year, long _compID)
    {
    
        StaticQuery<int>("EXEC [SPP_SMMMZNBLNCAKTJRNLA] @companyID,@nyear", new { companyID = _compID,nyear = _year, }).FirstOrDefault();
 
        return 0;
    }
    
    public   int  ClearFibaPr(long _compID)
    { 
        StaticQuery<int>("DELETE FROM [EDEFTERDB].[dbo].[TBLMSampleBlncoShrtCustomPr] where  CompanyID=@companyID", new { companyID = _compID }).FirstOrDefault();
          
        return 0;
    }
}