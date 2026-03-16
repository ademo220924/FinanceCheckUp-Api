using FinanceCheckUp.Application.Contexts.Concretes.Databases;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Framework.Data;
using FinanceCheckUp.Framework.Data.MsSql.Repositories;

namespace FinanceCheckUp.Application.Managers.SqlQueryManager;
public interface IBeyannameChkManager : IGenericDapperRepository
{
    public List<BeyannameChk> Get_BeyannameResult(long companyid_, int year_);
    public int Get_BeyannameCountChk(long companyid_, int year_);
    public List<BeyannameChk> Get_BeyannameResultLst(long companyid_, int year_);
    public List<BeyannameChk> Get_BeyannameResultLstChk(long companyid_, int year_);
    public int LastSet(long ide_);
    public int LastSetChk(long ide_);
    public int LastFinished(long companyid_, int year_, int nmonth_);
    public int LastFinishedChk(long companyid_, int year_, int nmonth_);
    public int Delete(long companyid_, int year_);
    public int DeleteChk(long companyid_, int year_);
    public int DeleteLast(long companyid_, int year_);
    public int DeleteLastChk(long companyid_, int year_);
    public int Save_BeyannameChk(BeyannameChk btnchk);
    public int Save_Beyanname(BeyannameChk btnchk);
}


public class BeyannameChkManager(FinanceCheckUpDbContext _dbContext) : GenericDapperRepositoryBase(_dbContext), IBeyannameChkManager
{
    public List<BeyannameChk> Get_BeyannameResult(long companyid_, int year_)
    {
        return StaticQuery<BeyannameChk>("SELECT * FROM [dbo].[TBLXMLSourceByn]  where CompanyID=@compID and Year=@nyear", new { compID = companyid_, nyear = year_ }).ToList();
    }
    public int Get_BeyannameCountChk(long companyid_, int year_)
    {
        return StaticQuery<int>("SELECT COUNT(ID) FROM [dbo].[TBLXMLSourceBynChk]  where CompanyID=@compID and Year=@nyear", new { compID = companyid_, nyear = year_ }).FirstOrDefault();
    }
    public List<BeyannameChk> Get_BeyannameResultLst(long companyid_, int year_)
    {
        return StaticQuery<BeyannameChk>("SELECT * FROM [EDEFTERDB].[dbo].[TBLXMLSourceByn] where SubID not in (Select DISTINCT(SubID) from [TBLBeyanname])  and CompanyID=@compID and Year=@nyear", new { compID = companyid_, nyear = year_ }).ToList();
    }
    public List<BeyannameChk> Get_BeyannameResultLstChk(long companyid_, int year_)
    {
        return StaticQuery<BeyannameChk>("SELECT * FROM [EDEFTERDB].[dbo].[TBLXMLSourceBynChk] where SubID not in (Select DISTINCT(SubID) from [TBLBeyanname])  and CompanyID=@compID and Year=@nyear", new { compID = companyid_, nyear = year_ }).ToList();
    }
    public int LastSet(long ide_)
    {
        return StaticQuery<int>("UPDATE   [EDEFTERDB].[dbo].[TBLXMLSourceByn] set  SubID=(SELECT SubID FROM [EDEFTERDB].[dbo].[TBLXMLSourceByn] where  ID = (select top 1 ID from [TBLXMLSourceByn] Where ID<@ide order by ID desc)) where ID=@ide", new { ide = ide_ }).FirstOrDefault();
    }
    public int LastSetChk(long ide_)
    {
        return StaticQuery<int>("UPDATE   [EDEFTERDB].[dbo].[TBLXMLSourceBynChk] set  SubID=(SELECT SubID FROM [EDEFTERDB].[dbo].[TBLXMLSourceBynChk] where  ID = (select top 1 ID from [TBLXMLSourceByn] Where ID<@ide order by ID desc)) where ID=@ide", new { ide = ide_ }).FirstOrDefault();
    }
    public int LastFinished(long companyid_, int year_, int nmonth_)
    {
        return StaticQuery("EXEC [SampleMizanBynLst] @compID,@nyear,@nmonth", new { compID = companyid_, nyear = year_, nmonth = nmonth_ }).FirstOrDefault();
    }
    public int LastFinishedChk(long companyid_, int year_, int nmonth_)
    {
        return StaticQuery("EXEC [SampleMizanBynLstChk] @compID,@nyear,@nmonth", new { compID = companyid_, nyear = year_, nmonth = nmonth_ }).FirstOrDefault();
    }
    public int Delete(long companyid_, int year_)
    {
        return StaticQuery<int>("Delete from TBLXMLSourceByn where CompanyID=@compID and Year=@nyear;", new { compID = companyid_, nyear = year_ }).FirstOrDefault();
    }
    public int DeleteChk(long companyid_, int year_)
    {
        return StaticQuery<int>("Delete from TBLXMLSourceBynChk where CompanyID=@compID and Year=@nyear;", new { compID = companyid_, nyear = year_ }).FirstOrDefault();
    }
    public int DeleteLast(long companyid_, int year_)
    {
        StaticQuery<int>("Delete FROM [EDEFTERDB].[dbo].[TBLXMLSourceByn] where [AccountMainDescription]='' and CompanyID=@compID and Year=@nyear;", new { compID = companyid_, nyear = year_ });
        return StaticQuery<int>("Delete FROM [EDEFTERDB].[dbo].[TBLXMLSourceByn] where [Amount]=0 and [AmountBefore]=0 and CompanyID=@compID and Year=@nyear;", new { compID = companyid_, nyear = year_ }).FirstOrDefault();
    }
    public int DeleteLastChk(long companyid_, int year_)
    {
        StaticQuery<int>("Delete FROM [EDEFTERDB].[dbo].[TBLXMLSourceBynChk] where [AccountMainDescription]='' and CompanyID=@compID and Year=@nyear;", new { compID = companyid_, nyear = year_ });
        return StaticQuery<int>("Delete FROM [EDEFTERDB].[dbo].[TBLXMLSourceBynChk] where [Amount]=0 and [AmountBefore]=0 and CompanyID=@compID and Year=@nyear;", new { compID = companyid_, nyear = year_ }).FirstOrDefault();
    }
    public int Save_BeyannameChk(BeyannameChk btnchk)
    {
        try
        {
            string sql = @" 

INSERT INTO [TBLXMLSourceBynChk]
          (  
        [AccountMainID] ,
        [AccountMainDescription] ,
        [Amount] ,
AmountBefore,
        [CompanyID] ,
        [Year]  ,IsRevenue,SubID,MainID
          ) 
           VALUES 
         (  
       @AccountMainID  ,
       @AccountMainDescription ,
       @Amount  ,
@AmountBefore,
       @CompanyID ,
       @Year  ,@IsRevenue,@SubID,@MainID

         )  ;select  Cast(SCOPE_IDENTITY() as Int)";
            return StaticQuery<int>(sql, btnchk).FirstOrDefault();
        }
        catch (Exception ex)
        {
            var chk = ex;
            throw;
        }

    }
    public int Save_Beyanname(BeyannameChk btnchk)
    {
        try
        {
            string sql = @" 

INSERT INTO [TBLXMLSourceByn]
          (  
        [AccountMainID] ,
        [AccountMainDescription] ,
        [Amount] ,
AmountBefore,
        [CompanyID] ,
        [Year]  ,IsRevenue,SubID,MainID
          ) 
           VALUES 
         (  
       @AccountMainID  ,
       @AccountMainDescription ,
       @Amount  ,
@AmountBefore,
       @CompanyID ,
       @Year  ,@IsRevenue,@SubID,@MainID

         )  ;select  Cast(SCOPE_IDENTITY() as Int)";
            return StaticQuery<int>(sql, btnchk).FirstOrDefault();
        }
        catch (Exception ex)
        {
            var chk = ex;
            throw;
        }

    }

}