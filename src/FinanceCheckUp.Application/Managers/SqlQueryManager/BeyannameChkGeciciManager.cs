using FinanceCheckUp.Application.Contexts.Concretes.Databases;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Framework.Data;
using FinanceCheckUp.Framework.Data.MsSql.Repositories;

namespace FinanceCheckUp.Application.Managers.SqlQueryManager;
public interface IBeyannameChkGeciciManager : IGenericDapperRepository
{
    List<BeyannameChkGecici> Get_BeyannameResult(long companyid_, int year_);
    List<BeyannameGeciciView> Get_BeyannameResultMulti(long companyid_, int year_);
    List<BeyannameChkGecici> Get_BeyannameResultLst(long companyid_, int year_);
    int LastSet(long ide_);
    int LastFinished(long companyid_, int year_, int nmonth_);
    int Delete(long companyid_, int year_);
    int DeleteLast(long companyid_, int year_);
    int Save_Beyanname(BeyannameChkGecici beyannameChkGecici);
}


public class BeyannameChkGeciciManager(FinanceCheckUpDbContext _dbContext) : GenericDapperRepositoryBase(_dbContext), IBeyannameChkGeciciManager
{
    public List<BeyannameChkGecici> Get_BeyannameResult(long companyid_, int year_)
    {
        return StaticQuery<BeyannameChkGecici>("SELECT * FROM [dbo].[TBLXMLSourceByn]  where CompanyID=@compID and Year=@nyear", new { compID = companyid_, nyear = year_ }).ToList();
    }
    public List<BeyannameGeciciView> Get_BeyannameResultMulti(long companyid_, int year_)
    {
        return StaticQuery<BeyannameGeciciView>("SELECT * FROM [dbo].[TBLXMLSourceByn]  where CompanyID=@compID and Year=@nyear", new { compID = companyid_, nyear = year_ }).ToList();
    }
    public List<BeyannameChkGecici> Get_BeyannameResultLst(long companyid_, int year_)
    {
        return StaticQuery<BeyannameChkGecici>("SELECT * FROM [EDEFTERDB].[dbo].[TBLXMLSourceByn] where SubID not in (Select DISTINCT(SubID) from [TBLBeyanname])  and CompanyID=@compID and Year=@nyear", new { compID = companyid_, nyear = year_ }).ToList();
    }
    public int LastSet(long ide_)
    {
        return Query<int>("UPDATE   [EDEFTERDB].[dbo].[TBLXMLSourceByn] set  SubID=(SELECT SubID FROM [EDEFTERDB].[dbo].[TBLXMLSourceByn] where  ID = (select top 1 ID from [TBLXMLSourceByn] Where ID<@ide order by ID desc)) where ID=@ide", new { ide = ide_ }).FirstOrDefault();
    }
    public int LastFinished(long companyid_, int year_, int nmonth_)
    {
        return Query<int>("EXEC [SampleMizanBynLst] @compID,@nyear,@nmonth", new { compID = companyid_, nyear = year_, nmonth = nmonth_ }).FirstOrDefault();
    }
    public int Delete(long companyid_, int year_)
    {
        return Query<int>("Delete from TBLXMLSourceByn where CompanyID=@compID and Year=@nyear;", new { compID = companyid_, nyear = year_ }).FirstOrDefault();
    }
    public int DeleteLast(long companyid_, int year_)
    {
        StaticQuery<int>("Delete FROM [EDEFTERDB].[dbo].[TBLXMLSourceByn] where [AccountMainDescription]='' and CompanyID=@compID and Year=@nyear;", new { compID = companyid_, nyear = year_ });
        return StaticQuery<int>("Delete FROM [EDEFTERDB].[dbo].[TBLXMLSourceByn] where [Amount]=0 and [AmountBefore]=0 and CompanyID=@compID and Year=@nyear;", new { compID = companyid_, nyear = year_ }).FirstOrDefault();
    }
    public int Save_Beyanname(BeyannameChkGecici beyannameChkGecici)
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
        return Query<int>(sql, beyannameChkGecici).FirstOrDefault();
    }
}