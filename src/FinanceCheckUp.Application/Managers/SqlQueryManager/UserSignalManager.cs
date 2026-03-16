using FinanceCheckUp.Application.Contexts.Concretes.Databases;
using FinanceCheckUp.Domain.Entities;
using FinanceCheckUp.Framework.Data;
using FinanceCheckUp.Framework.Data.MsSql.Repositories;

namespace FinanceCheckUp.Application.Managers.SqlQueryManager;


public interface IUserSignalManager : IGenericDapperRepository
{
    public IEnumerable<UserSignal> Get_All();
    public bool Update_ToNonActive(UserSignal userSignal);
    public bool Update_ToActive(UserSignal userSignal);
    public int Save_(UserSignal userSignal);
}

public class UserSignalManager(FinanceCheckUpDbContext _dbContext) : GenericDapperRepositoryBase(_dbContext), IUserSignalManager
{
    public IEnumerable<UserSignal> Get_All()
    {
        return StaticQuery<UserSignal>("Select * From [UserSignal]");
    }
    public bool Update_ToNonActive(UserSignal userSignal)
    {
        try
        {
            string sql = "UPDATE   [UserSignal] SET  [IsActive]=0    WHERE [UserID]=@UserID";
            Execute(sql, userSignal);
            return true;
        }
        catch
        {
            throw;
        }
    }
    public bool Update_ToActive(UserSignal userSignal)
    {
        try
        {
            string sql = "UPDATE   [UserSignal] SET  [IsActive]=1    WHERE [UserID]=@UserID and UserSignalID=@UserSignalID";
            Execute(sql, userSignal);
            return true;
        }
        catch
        {
            throw;
        }
    }
    public int Save_(UserSignal userSignal)
    {



        var usr = Get_All().Where(x => x.UserSignalId.Trim() == userSignal.UserSignalId.Trim()).ToList();

        if (usr.Count() < 1)
        {
            Update_ToNonActive(userSignal);
            string sql = @"  INSERT INTO [UserSignal]
          ( 
        [UserID] ,
        [UserSignalID] ,
        [IsActive] 
          ) 
           VALUES 
         ( 
        @UserID ,
        @UserSignalID ,
        1 
         )  ;select  Cast(SCOPE_IDENTITY() as Int)";
            userSignal.Id = StaticQuery<int>(sql, userSignal).FirstOrDefault();
            return userSignal.Id;
        }
        else
        {
            Update_ToNonActive(userSignal);
            Update_ToActive(userSignal);
            return userSignal.Id;
        }



    }
}
