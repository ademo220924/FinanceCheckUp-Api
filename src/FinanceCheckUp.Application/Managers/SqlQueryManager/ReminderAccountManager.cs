using FinanceCheckUp.Application.Contexts.Concretes.Databases;
using FinanceCheckUp.Domain.Entities.BgServer;
using FinanceCheckUp.Framework.Data;
using FinanceCheckUp.Framework.Data.MsSql.Repositories;

namespace FinanceCheckUp.Application.Managers.SqlQueryManager
{
    public interface IReminderAccountManager : IGenericDapperRepository
    {
        IEnumerable<ReminderAccount> Get_ReminderAccount();
        ReminderAccount GetRow_ReminderAccount(long _ID);
        long Save_ReminderAccount(ReminderAccount reminderAccount);
        bool Update_ReminderAccount(ReminderAccount reminderAccount);
    }

    public class ReminderAccountManager(FinanceCheckUpDbContext _dbContext) : GenericDapperRepositoryBase(_dbContext), IReminderAccountManager
    {
        public IEnumerable<ReminderAccount> Get_ReminderAccount()
        {
            return StaticQuery<ReminderAccount>("Select * From [ReminderAccount]");
        }
        public ReminderAccount GetRow_ReminderAccount(long _ID)
        {
            return StaticQuery<ReminderAccount>("Select * From [ReminderAccount] where ID=@ID ", new { ID = _ID }).FirstOrDefault();
        }

        public long Save_ReminderAccount(ReminderAccount reminderAccount)
        {
            string sql = @"  INSERT INTO [ReminderAccount]
          ( 
        [Name] ,
        [StartValue] ,
        [FinishValue] ,
        [AccountGroupId] ,
        [AccountType] 
          ) 
           VALUES 
         ( 
        @Name ,
        @StartValue ,
        @FinishValue ,
        @AccountGroupId ,
        @AccountType 
         )  ;select  Cast(SCOPE_IDENTITY() as Int)";

            if (reminderAccount.Id > 0)
            {
                sql = "UPDATE   [ReminderAccount] SET  [Name]=@Name , [StartValue]=@StartValue , [FinishValue]=@FinishValue , [AccountGroupId]=@AccountGroupId , [AccountType]=@AccountType  WHERE [ID]=@ID";
            }
            reminderAccount.Id = Query<int>(sql, reminderAccount).FirstOrDefault();
            return reminderAccount.Id;
        }

        public bool Update_ReminderAccount(ReminderAccount reminderAccount)
        {
            try
            {
                string sql = "UPDATE   [ReminderAccount] SET  [Name]=@Name , [StartValue]=@StartValue , [FinishValue]=@FinishValue , [AccountGroupId]=@AccountGroupId , [AccountType]=@AccountType  WHERE [ID]=@ID";
                Execute(sql, reminderAccount);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
