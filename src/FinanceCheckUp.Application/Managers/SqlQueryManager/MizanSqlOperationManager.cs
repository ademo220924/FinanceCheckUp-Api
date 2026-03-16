using FinanceCheckUp.Application.Contexts.Concretes.Databases;
using FinanceCheckUp.Application.Models.ViewModel.Mizan;
using FinanceCheckUp.Framework.Data;
using FinanceCheckUp.Framework.Data.MsSql.Repositories;

namespace FinanceCheckUp.Application.Managers.SqlQueryManager;

public interface IMizanSqlOperationManager : IGenericDapperRepository
{
    int Set_ReportSetResetMizanKayit(int year, long compId);
    int Set_ReportSetResetMizanKayitMOnth(int nYear, long compId, byte nmonth);
    IEnumerable<TBLXMLSCheckpdfMizan> Get_TBLXMLSCheckpdfMizan();
    public List<TBLXMLSCheckpdfMizan> Get_TBLXMLSCheckpdfMizanLast(long _ID, int nyear_);
    List<TBLXMLSCheckpdfMizan> Get_TBLXMLSCheckpdfMizanCount(long _ID, int nyear_, byte nmonth_);
    List<TBLXMLSCheckpdfMizan> LastRepByCompanyIDn(int nyear_, long _ID, int nmonth_, byte typeIDe);
    List<TBLXMLSCheckpdfMizan> GetMizanBeyanSame(long _ID);
    TBLXMLSCheckpdfMizan GetRow_TBLXMLSCheckpdfMizan(long _ID);
    int DeleteByCompanyIDn(long _ID, int nyear_, int nmonth_);
    int Save_TBLXMLSCheckpdfMizan(TBLXMLSCheckpdfMizan tBLXMLSCheckpdfMizan);
    bool Update_TBLXMLSCheckpdfMizan(TBLXMLSCheckpdfMizan tBLXMLSCheckpdfMizan);
}


public class MizanSqlOperationManager(FinanceCheckUpDbContext _dbContext) : GenericDapperRepositoryBase(_dbContext), IMizanSqlOperationManager
{
    public int Set_ReportSetResetMizanKayit(int year, long compId)
    {
        Execute("Delete FROM [SPO_TBMLAKTARMA] where [CompanyID]=@companyID and [YEAR]=@nyear ", new { nyear = year, companyID = compId });
        Execute("Delete FROM [TBLXMLSourceOne] where CompanyID=@companyID and Year=@nyear ", new { nyear = year, companyID = compId });
        Execute("Delete FROM [TBLXMLSourceOneT] where CompanyID=@companyID and Year=@nyear ", new { nyear = year, companyID = compId });
        return 1;
    }

    public int Set_ReportSetResetMizanKayitMOnth(int year, long companyId, byte month)
    {
        Execute("Delete FROM [TBLXMLSourceOneBck] where CompanyID=@companyID and Year=@nyear and IsBeyan=0 and MainMonth=@nmonth", new { nyear = year, companyID = companyId, nmonth = month });
        return 1;
    }

    public IEnumerable<TBLXMLSCheckpdfMizan> Get_TBLXMLSCheckpdfMizan()
    {
        return StaticQuery<TBLXMLSCheckpdfMizan>("Select * From [TBLXMLSCheckpdfMizan]");
    }
    public List<TBLXMLSCheckpdfMizan> Get_TBLXMLSCheckpdfMizanLast(long _ID, int nyear_)
    {
        return StaticQuery<TBLXMLSCheckpdfMizan>("Select * from  [EDEFTERDB].[dbo].[TBLXMLSCheckpdfMizan]   where CompanyID=@ID and Year=@nyear   and [Amount1Diff]=0 and [Amount2Diff]=0", new { ID = _ID, nyear = nyear_ }).ToList();
    }
    public List<TBLXMLSCheckpdfMizan> Get_TBLXMLSCheckpdfMizanCount(long _ID, int nyear_, byte nmonth_)
    {
        Execute("delete from [EDEFTERDB].[dbo].[TBLXMLSCheckpdfMizan]   where (Amount1=0 and Amount2=0 and Amount3=0)  and CompanyID=@ID and Year=@nyear and MainMonth=@nmon", new { ID = _ID, nyear = nyear_, nmon = nmonth_ });
        return StaticQuery<TBLXMLSCheckpdfMizan>("Select * from  [EDEFTERDB].[dbo].[TBLXMLSCheckpdfMizan]   where CompanyID=@ID and Year=@nyear and MainMonth=@nmon", new { ID = _ID, nyear = nyear_, nmon = nmonth_ }).ToList();
    }
    public List<TBLXMLSCheckpdfMizan> LastRepByCompanyIDn(int nyear_, long _ID, int nmonth_, byte typeIDe)
    {
        return StaticQuery<TBLXMLSCheckpdfMizan>("EXEC Sa_PRoMznPdfIN @nyear,@compdID,@nmon,@typeID", new { nyear = nyear_, compdID = _ID, nmon = nmonth_, typeID = typeIDe }).ToList();
    }
    public List<TBLXMLSCheckpdfMizan> GetMizanBeyanSame(long _ID)
    {
        return StaticQuery<TBLXMLSCheckpdfMizan>("Select[Year],CompanyID,MainMonth FROM[EDEFTERDB].[dbo].[TBLXMLSourceOneBck] where CompanyID = @compdID and IsBeyan = 0 and Cast([Year] as nvarchar(4))+Cast(CompanyID  as nvarchar(24))+Cast(MainMonth as nvarchar(24)) in (Select Cast([Year] as nvarchar(4))+Cast(CompanyID  as nvarchar(24))+Cast(MainMonth as nvarchar(24))   FROM[EDEFTERDB].[dbo].[TBLXMLSourceOneBck] where CompanyID =@compdID and IsBeyan = 1) group by CompanyID,MainMonth ,[Year]", new { compdID = _ID }).ToList();
    }
    public TBLXMLSCheckpdfMizan GetRow_TBLXMLSCheckpdfMizan(long _ID)
    {
        return StaticQuery<TBLXMLSCheckpdfMizan>("Select * From [TBLXMLSCheckpdfMizan] where ID=@ID ", new { ID = _ID }).FirstOrDefault();
    }
    public int DeleteByCompanyIDn(long _ID, int nyear_, int nmonth_)
    {
        return Execute("DELETE From [TBLXMLSCheckpdfMizan] where CompanyID=@ID and [Year]=@nyear  and MainMonth=@monthide ", new { ID = _ID, nyear = nyear_, monthide = nmonth_ });
    }
    public int Save_TBLXMLSCheckpdfMizan(TBLXMLSCheckpdfMizan tBLXMLSCheckpdfMizan)
    {
        string sql = @"  INSERT INTO [TBLXMLSCheckpdfMizan]
          ( 
        [AccountMainID] ,
        [AccountMainDescription] ,
        [Amount1] ,
        [Amount1Diff] ,
        [Amount2] ,
        [Amount2Diff] ,
        [Amount3] ,
        [Amount3Diff] ,
        [Amount4] ,
        [Amount4Diff] ,
        [CompanyID] ,
        [Year] ,MainMonth,PageID
          ) 
           VALUES 
         ( 
        @AccountMainID ,
        @AccountMainDescription ,
        @Amount1 ,
        @Amount1Diff ,
        @Amount2 ,
        @Amount2Diff ,
        @Amount3 ,
        @Amount3Diff ,
        @Amount4 ,
        @Amount4Diff ,
        @CompanyID ,
        @Year ,@MainMonth,@PageID
         )  ;

         select  Cast(SCOPE_IDENTITY() as Int)";
        return Execute(sql, tBLXMLSCheckpdfMizan);
    }
    public bool Update_TBLXMLSCheckpdfMizan(TBLXMLSCheckpdfMizan tBLXMLSCheckpdfMizan)
    {
        try
        {
            string sql = "UPDATE   [TBLXMLSCheckpdfMizan] SET  [AccountMainID]=@AccountMainID , [AccountMainDescription]=@AccountMainDescription , [Amount1]=@Amount1 , [Amount1Diff]=@Amount1Diff , [Amount2]=@Amount2 , [Amount2Diff]=@Amount2Diff , [Amount3]=@Amount3 , [Amount3Diff]=@Amount3Diff , [Amount4]=@Amount4 , [Amount4Diff]=@Amount4Diff , [CompanyID]=@CompanyID , [Year]=@Year   WHERE [ID]=@ID";
            Execute(sql, tBLXMLSCheckpdfMizan);
            return true;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

}