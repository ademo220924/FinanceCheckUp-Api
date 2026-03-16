using FinanceCheckUp.Application.Contexts.Concretes.Databases;
using FinanceCheckUp.Domain.Entities.BgServer;
using FinanceCheckUp.Framework.Data;
using FinanceCheckUp.Framework.Data.MsSql.Repositories;

namespace FinanceCheckUp.Application.Managers.SqlQueryManager
{
    public interface IReminderRuleManager : IGenericDapperRepository
    {
        IEnumerable<ReminderRule> Get_ReminderRule();
        ReminderRule GetRow_ReminderRule(long _ID);
        long Save_ReminderRule(ReminderRule reminderRule);
        bool Update_ReminderRule(ReminderRule reminderRule);
    }


    public class ReminderRuleManager(FinanceCheckUpDbContext _dbContext) : GenericDapperRepositoryBase(_dbContext), IReminderRuleManager
    {
        public IEnumerable<ReminderRule> Get_ReminderRule()
        {
            return StaticQuery<ReminderRule>("Select * From [ReminderRule]");
        }
        public ReminderRule GetRow_ReminderRule(long _ID)
        {
            return StaticQuery<ReminderRule>("Select * From [ReminderRule] where ID=@ID ", new { ID = _ID }).FirstOrDefault();
        }

        public long Save_ReminderRule(ReminderRule reminderRule)
        {
            string sql = @"  INSERT INTO [ReminderRule]
          ( 
        [AccountId] ,
        [PeriodType] ,
        [ControlValue] ,
        [ControlValueType] ,
        [LastGenerateDate] 
          ) 
           VALUES 
         ( 
        @AccountId ,
        @PeriodType ,
        @ControlValue ,
        @ControlValueType ,
        @LastGenerateDate 
         )  ;select  Cast(SCOPE_IDENTITY() as Int)";

            if (reminderRule.Id > 0)
            {
                sql = "UPDATE   [ReminderRule] SET  [AccountId]=@AccountId , [PeriodType]=@PeriodType , [ControlValue]=@ControlValue , [ControlValueType]=@ControlValueType , [LastGenerateDate]=@LastGenerateDate  WHERE [ID]=@ID";
            }
            reminderRule.Id = Query<int>(sql, reminderRule).FirstOrDefault();
            return reminderRule.Id;
        }

        public bool Update_ReminderRule(ReminderRule reminderRule)
        {
            try
            {
                string sql = "UPDATE   [ReminderRule] SET  [AccountId]=@AccountId , [PeriodType]=@PeriodType , [ControlValue]=@ControlValue , [ControlValueType]=@ControlValueType , [LastGenerateDate]=@LastGenerateDate  WHERE [ID]=@ID";
                Execute(sql, reminderRule);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
