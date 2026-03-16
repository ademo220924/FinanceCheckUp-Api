using FinanceCheckUp.Application.Contexts.Concretes.Databases;
using FinanceCheckUp.Domain.Entities;
using FinanceCheckUp.Framework.Data;
using FinanceCheckUp.Framework.Data.MsSql.Repositories;


namespace FinanceCheckUp.Application.Managers.SqlQueryManager;
public interface ITBLMizanManager : IGenericDapperRepository
{
    public IEnumerable<Tblmizan> Get_TBLMizan();
    public int GetComapnyIDByMonth(long compide, int monide, int yearide);
    public int GetComapnyCountMizanByn(long compide, int yearide);
    public int DeleteComapnyCountMizanByn(long compide, int yearide);
    public IEnumerable<Tblmizan> Get_TBLMizanCompany(string ide);
    public Tblmizan GetRow_TBLMizan(string ide);
    public int GetYearByComapnyID(long ide);
    public int Save_TBLMizan(Tblmizan tblmizan);
    public bool Update_TBLMizan(Tblmizan tblmizan);
}




public class TBLMizanManager(FinanceCheckUpDbContext _dbContext) : GenericDapperRepositoryBase(_dbContext), ITBLMizanManager
{
    public IEnumerable<Tblmizan> Get_TBLMizan()
    {
        return StaticQuery<Tblmizan>("Select * From [TBLMizan]");
    }
    public int GetComapnyIDByMonth(long compide, int monide, int yearide)
    {
        return StaticQuery<int>("Select ID From [TBLMizan] where CompanyID=@ID and Year=@year and MONTH(DocumentDate)=@mon", new { ID = compide, year = yearide, mon = monide }).FirstOrDefault();
    }
    public int GetComapnyCountMizanByn(long compide, int yearide)
    {
        return StaticQuery<int>("SELECT  COUNT(*) FROM [EDEFTERDB].[dbo].[TBLXMLSourceOne] where  [Year]=@year and CompanyID=@ID and (AccountMainID>'599' and AccountMainID<'699' ) and Amount>0", new { ID = compide, year = yearide }).FirstOrDefault();
    }
    public int DeleteComapnyCountMizanByn(long compide, int yearide)
    {
        return StaticQuery<int>("DELETE FROM [EDEFTERDB].[dbo].[TBLXMLSourceOne] where  [Year]=@year and CompanyID=@ID and  AccountMainID>'599'  ", new { ID = compide, year = yearide }).FirstOrDefault();
    }
    public IEnumerable<Tblmizan> Get_TBLMizanCompany(string ide)
    {
        return StaticQuery<Tblmizan>("Select * From [TBLMizan] where CompanyID=@ID ", new { ID = ide });
    }
    public Tblmizan GetRow_TBLMizan(string ide)
    {
        return StaticQuery<Tblmizan>("Select * From [TBLMizan] where ID=@ID ", new { ID = ide }).FirstOrDefault();
    }
    public int GetYearByComapnyID(long ide)
    {
        return StaticQuery<int>("Select COUNT(DISTINCT(Year)) From [TBLMizan] where CompanyID=@ID ", new { ID = ide }).FirstOrDefault();
    }


    public int Save_TBLMizan(Tblmizan tblmizan)
    {
        string sql = @"  INSERT INTO [TBLMizan]
          (  
        [CsvName] ,
        [CompanyID] ,
        [CreatedDate] ,
DocumentDate ,MainMonth,[Year]
          ) 
           VALUES 
         (  
        @CsvName ,
        @CompanyID ,
        getdate() ,
@DocumentDate ,@MainMonth,@Year
         )  ;select  Cast(SCOPE_IDENTITY() as Int)";
        tblmizan.Id = StaticQuery<int>(sql, tblmizan).FirstOrDefault();
        return (int)tblmizan.Id;
    }

    public bool Update_TBLMizan(Tblmizan tblmizan)
    {
        try
        {
            string sql = "UPDATE   [TBLMizan] SET     [CsvName]=@CsvName , [CompanyID]=@CompanyID , [CreatedDate]=@CreatedDate,DocumentDate=@DocumentDate, [Year]=@Year ,MainMonth=@MainMonth WHERE [ID]=@ID";
            Execute(sql, tblmizan);
            return true;
        }
        catch
        {
            throw;
        }
    }
}
