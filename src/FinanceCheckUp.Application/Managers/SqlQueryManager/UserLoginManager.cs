using FinanceCheckUp.Application.Contexts.Concretes.Databases;
using FinanceCheckUp.Domain.Entities;
using FinanceCheckUp.Framework.Data;
using FinanceCheckUp.Framework.Data.MsSql.Repositories;

namespace FinanceCheckUp.Application.Managers.SqlQueryManager;


public interface IUserLoginManager : IGenericDapperRepository
{
    public long Save_User(UserLogin userLogin);
}

public class UserLoginManager(FinanceCheckUpDbContext _dbContext) : GenericDapperRepositoryBase(_dbContext), IUserLoginManager
{
    public long Save_User(UserLogin userLogin)
    {
        string sql = @"  INSERT INTO [UserLogin]
          ( 
        [UserID] ,
        [UserIP] , 
        [UserBrowser]   ,CreatedDate
          ) 
           VALUES 
         ( 
        @UserID ,
        @UserIP , 
        @UserBrowser ,getdate() 
         )  ;select  Cast(SCOPE_IDENTITY() as Int)";

        userLogin.Id = Query<long>(sql, userLogin).FirstOrDefault();
        return userLogin.Id;
    }
}
