using FinanceCheckUp.Application.Contexts.Concretes.Databases;
using FinanceCheckUp.Domain.Entities.BgServer;
using FinanceCheckUp.Framework.Data;
using FinanceCheckUp.Framework.Data.MsSql.Repositories;

namespace FinanceCheckUp.Application.Managers.SqlQueryManager
{
    public interface IReminderRuleJobHistoryManager : IGenericDapperRepository
    {
        IEnumerable<ReminderRuleJobHistory> Get_ReminderRuleJobHistory();
        ReminderRuleJobHistory GetRow_ReminderRuleJobHistory(long _ID);
        long Save_ReminderRuleJobHistory(ReminderRuleJobHistory reminderRuleJobHistory);
        bool Update_ReminderRuleJobHistory(ReminderRuleJobHistory reminderRuleJobHistory);
    }

    public class ReminderRuleJobHistoryManager(FinanceCheckUpDbContext _dbContext) : GenericDapperRepositoryBase(_dbContext), IReminderRuleJobHistoryManager
    {
        public IEnumerable<ReminderRuleJobHistory> Get_ReminderRuleJobHistory()
        {
            return StaticQuery<ReminderRuleJobHistory>("Select * From [ReminderRuleJobHistory]");
        }
        public ReminderRuleJobHistory GetRow_ReminderRuleJobHistory(long _ID)
        {
            return StaticQuery<ReminderRuleJobHistory>("Select * From [ReminderRuleJobHistory] where ID=@ID ", new { ID = _ID }).FirstOrDefault();
        }

        public long Save_ReminderRuleJobHistory(ReminderRuleJobHistory reminderRuleJobHistory)
        {
            string sql = @"  INSERT INTO [ReminderRuleJobHistory]
          ( 
        [ReminderRuleJobId] ,
        [ControlValue] ,
        [CalculateValue] ,
        [DifferentValue] ,
        [DifferentPercentage] ,
        [Explanation] ,
        [IsNotify] ,
        [CreatedDate] ,
        [UpdatedDate] ,
        [SourceTableControlValueId] ,
        [SourceTableCalculateValueId] 
          ) 
           VALUES 
         ( 
        @ReminderRuleJobId ,
        @ControlValue ,
        @CalculateValue ,
        @DifferentValue ,
        @DifferentPercentage ,
        @Explanation ,
        @IsNotify ,
        @CreatedDate ,
        @UpdatedDate ,
        @SourceTableControlValueId ,
        @SourceTableCalculateValueId 
         )  ;select  Cast(SCOPE_IDENTITY() as Int)";

            reminderRuleJobHistory.Id = Query<int>(sql, reminderRuleJobHistory).FirstOrDefault();
            return reminderRuleJobHistory.Id;
        }

        public bool Update_ReminderRuleJobHistory(ReminderRuleJobHistory reminderRuleJobHistory)
        {
            try
            {
                string sql = "UPDATE   [ReminderRuleJobHistory] SET  [ReminderRuleJobId]=@ReminderRuleJobId , [ControlValue]=@ControlValue , [CalculateValue]=@CalculateValue , [DifferentValue]=@DifferentValue , [DifferentPercentage]=@DifferentPercentage , [Explanation]=@Explanation , [IsNotify]=@IsNotify , [CreatedDate]=@CreatedDate , [UpdatedDate]=@UpdatedDate , [SourceTableControlValueId]=@SourceTableControlValueId , [SourceTableCalculateValueId]=@SourceTableCalculateValueId  WHERE [ID]=@ID";
                Execute(sql, reminderRuleJobHistory);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
