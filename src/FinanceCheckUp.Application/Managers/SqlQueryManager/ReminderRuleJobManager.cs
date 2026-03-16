using FinanceCheckUp.Application.Contexts.Concretes.Databases;
using FinanceCheckUp.Domain.Entities.BgServer;
using FinanceCheckUp.Framework.Data;
using FinanceCheckUp.Framework.Data.MsSql.Repositories;

namespace FinanceCheckUp.Application.Managers.SqlQueryManager
{
    public interface IReminderRuleJobManager : IGenericDapperRepository
    {
        IEnumerable<ReminderRuleJob> Get_ReminderRuleJob();
        ReminderRuleJob GetRow_ReminderRuleJob(long _ID);
        long Save_ReminderRuleJob(ReminderRuleJob reminderRuleJob);
        bool Update_ReminderRuleJob(ReminderRuleJob reminderRuleJob);
    }

    public class ReminderRuleJobManager(FinanceCheckUpDbContext _dbContext) : GenericDapperRepositoryBase(_dbContext), IReminderRuleJobManager
    {
        public IEnumerable<ReminderRuleJob> Get_ReminderRuleJob()
        {
            return StaticQuery<ReminderRuleJob>("Select * From [ReminderRuleJob]");
        }
        public ReminderRuleJob GetRow_ReminderRuleJob(long _ID)
        {
            return StaticQuery<ReminderRuleJob>("Select * From [ReminderRuleJob] where ID=@ID ", new { ID = _ID }).FirstOrDefault();
        }

        public long Save_ReminderRuleJob(ReminderRuleJob reminderRuleJob)
        {
            string sql = @"  INSERT INTO [ReminderRuleJob]
          ( 
        [CompanyId] ,
        [ReminderRuleId] ,
        [Year] ,
        [Quarter] ,
        [Month] ,
        [CreatedDate] ,
        [ScheduledDate] ,
        [CompareScheduleDate] ,
        [CompletedDate] ,
        [JobStatus] ,
        [JobStatusText] 
          ) 
           VALUES 
         ( 
        @CompanyId ,
        @ReminderRuleId ,
        @Year ,
        @Quarter ,
        @Month ,
        @CreatedDate ,
        @ScheduledDate ,
        @CompareScheduleDate ,
        @CompletedDate ,
        @JobStatus ,
        @JobStatusText 
         )  ;select  Cast(SCOPE_IDENTITY() as Int)";
            if (reminderRuleJob.Id > 0)
            {
                sql = "UPDATE   [ReminderRuleJob] SET  [CompanyId]=@CompanyId , [ReminderRuleId]=@ReminderRuleId , [Year]=@Year , [Quarter]=@Quarter , [Month]=@Month , [CreatedDate]=@CreatedDate , [ScheduledDate]=@ScheduledDate , [CompareScheduleDate]=@CompareScheduleDate , [CompletedDate]=@CompletedDate , [JobStatus]=@JobStatus , [JobStatusText]=@JobStatusText  WHERE [ID]=@ID";
            }



            reminderRuleJob.Id = Query<int>(sql, this).FirstOrDefault();
            return reminderRuleJob.Id;
        }

        public bool Update_ReminderRuleJob(ReminderRuleJob reminderRuleJob)
        {
            try
            {
                string sql = "UPDATE   [ReminderRuleJob] SET  [CompanyId]=@CompanyId , [ReminderRuleId]=@ReminderRuleId , [Year]=@Year , [Quarter]=@Quarter , [Month]=@Month , [CreatedDate]=@CreatedDate , [ScheduledDate]=@ScheduledDate , [CompareScheduleDate]=@CompareScheduleDate , [CompletedDate]=@CompletedDate , [JobStatus]=@JobStatus , [JobStatusText]=@JobStatusText  WHERE [ID]=@ID";
                Execute(sql, reminderRuleJob);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
