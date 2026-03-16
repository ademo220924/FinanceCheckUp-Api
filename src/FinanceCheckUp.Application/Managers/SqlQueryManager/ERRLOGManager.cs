using FinanceCheckUp.Application.Contexts.Concretes.Databases;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Framework.Data;
using FinanceCheckUp.Framework.Data.MsSql.Repositories;

namespace FinanceCheckUp.Application.Managers.SqlQueryManager;

public interface IERRLOGManager : IGenericDapperRepository
{
    public IEnumerable<ERRLOG> Get_AppLogs();
    public int Save_AppLogs(ERRLOG eRRLOG);

}

public class ERRLOGManager(FinanceCheckUpDbContext _dbContext) : GenericDapperRepositoryBase(_dbContext), IERRLOGManager
{
    public IEnumerable<ERRLOG> Get_AppLogs()
    {
        return Query<ERRLOG>("Select * From [LOGGER]");
    }


    public int Save_AppLogs(ERRLOG eRRLOG)
    {
        string sql = @"  INSERT INTO [LOGGER]
          ( 
        [ERLOG] ,
         CsvID,
        [CompanyID]  
          ) 
           VALUES 
         ( 
        @ERLOG ,
         @CsvID,
        @CompanyID 
         )  ;select  Cast(SCOPE_IDENTITY() as Int)";
        return Query<int>(sql, eRRLOG).FirstOrDefault();
    }
}
