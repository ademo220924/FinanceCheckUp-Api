using FinanceCheckUp.Application.Contexts.Concretes.Databases;
using FinanceCheckUp.Domain.Entities;
using FinanceCheckUp.Framework.Data;
using FinanceCheckUp.Framework.Data.MsSql.Repositories;

namespace FinanceCheckUp.Application.Managers.SqlQueryManager;
public interface ITBLAAQnbSignLogManager : IGenericDapperRepository
{
    public TblaaqnbSignLog Get_TBLAAQnbSignLogRow(long Id);
    public IEnumerable<TblaaqnbSignLog> Get_TBLAAQnbSignLog(long companyID);
    public IEnumerable<TblaaqnbSignLog> Get_All();
    public int Save_TBLAAQnbSignLog(TblaaqnbSignLog tBLAAQnbSignLog);
    public int Update_TBLAAQnbSignLog(TblaaqnbSignLog tBLAAQnbSignLog);

}


public class TBLAAQnbSignLogManager(FinanceCheckUpDbContext _dbContext) : GenericDapperRepositoryBase(_dbContext), ITBLAAQnbSignLogManager
{
    public TblaaqnbSignLog Get_TBLAAQnbSignLogRow(long Id)
    {
        return StaticQuery<TblaaqnbSignLog>("Select * From [TBLAAQnbSignLog] where ID=@ID ", new { ID = Id }).FirstOrDefault();
    }
    public IEnumerable<TblaaqnbSignLog> Get_TBLAAQnbSignLog(long companyID)
    {
        return StaticQuery<TblaaqnbSignLog>("Select * From [TBLAAQnbSignLog] where CompanyID=@ID ", new { ID = companyID });
    }
    public IEnumerable<TblaaqnbSignLog> Get_All()
    {
        string sql = @"SELECT TOP (1000) t.*
,y.CompanyName as EntegratorCompanyName 
            FROM[EDEFTERDB].[dbo].[TBLAAQnbSignLog] t LEFT JOIN CompanyEntegrator y on t.CompanyEntegratorID = y.ID";


        return StaticQuery<TblaaqnbSignLog>(sql);
    }
    public int Save_TBLAAQnbSignLog(TblaaqnbSignLog tBLAAQnbSignLog)
    {
        string sql = @" 
IF NOT EXISTS
(
  SELECT
    *
  FROM
   [TBLAAQnbSignLog]
  WHERE
    CompanyID = @CompanyID AND
    CompanyEntegratorID =@CompanyEntegratorID
)
BEGIN 
INSERT INTO [TBLAAQnbSignLog]
        (UserID,CompanyID,CompanyEntegratorID,StartDate,EndDate) 
           VALUES 
         (@UserID,@CompanyID,@CompanyEntegratorID,@StartDate,@EndDate)  ;select  Cast(SCOPE_IDENTITY() as Bigint) END ELSE  BEGIN  UPDATE [TBLAAQnbSignLog] SET 
         StartDate=@StartDate,EndDate=@EndDate    WHERE CompanyID = @CompanyID AND
    CompanyEntegratorID =@CompanyEntegratorID END";

        return Query<int>(sql, this).FirstOrDefault();
    }
    public int Update_TBLAAQnbSignLog(TblaaqnbSignLog tBLAAQnbSignLog)
    {
        string sql = @"UPDATE [TBLAAQnbSignLog] SET 
         StartDate=@StartDate,EndDate=@EndDate,IsDeclined=@IsDeclined,DeclinedDate=@DeclinedDate,DeclinedUserID=@DeclinedUserID  ,DeclinedDateBank=@DeclinedDateBank,IsDeclinedBank=@IsDeclinedBank,DeclinedUserIDBank=@DeclinedUserIDBank ,IsForBankToo=@IsForBankToo WHERE [ID]=@ID";

        return Query<int>(sql, tBLAAQnbSignLog).FirstOrDefault();
    }
}