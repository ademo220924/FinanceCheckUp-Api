using FinanceCheckUp.Application.Contexts.Concretes.Databases;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Framework.Data;
using FinanceCheckUp.Framework.Data.MsSql.Repositories;

namespace FinanceCheckUp.Application.Managers.SqlQueryManager;

public interface IAppLogsManager : IGenericDapperRepository
{
    IEnumerable<AppLogs> Get_AppLogs();
    AppLogs GetRow_AppLogs(int _ID);
    int Save_AppLogs(AppLogs appLogs);
}

public class AppLogsManager(FinanceCheckUpDbContext _dbContext) : GenericDapperRepositoryBase(_dbContext), IAppLogsManager
{
    public IEnumerable<AppLogs> Get_AppLogs()
    {
        return Query<AppLogs>("Select * From [AppLogs]");
    }
    public AppLogs GetRow_AppLogs(int _ID)
    {
        return StaticQuery<AppLogs>("Select * From [AppLogs] where ID=@ID ", new { ID = _ID }).FirstOrDefault();
    }

    public int Save_AppLogs(AppLogs appLogs)
    {
        string sql = @"  INSERT INTO [AppLogs]
          ( 
        [UserID] ,
LogTypeID,
        [ActionDate] ,
        [Detail] 
          ) 
           VALUES 
         ( 
        @UserID ,
@LogTypeID,
        @ActionDate ,
        @Detail 
         )  ;select  Cast(SCOPE_IDENTITY() as Int)";
        appLogs.ID = Query<int>(sql, appLogs).FirstOrDefault();
        return appLogs.ID;
    }
}
