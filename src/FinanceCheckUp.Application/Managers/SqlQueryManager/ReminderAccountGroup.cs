using FinanceCheckUp.Application.Contexts.Concretes.Databases;
using FinanceCheckUp.Domain.Entities.BgServer;
using FinanceCheckUp.Framework.Data;
using FinanceCheckUp.Framework.Data.MsSql.Repositories;

namespace FinanceCheckUp.Application.Managers.SqlQueryManager
{
    public interface IReminderAccountGroupManager : IGenericDapperRepository
    {
        IEnumerable<ReminderAccountGroup> Get_ReminderAccountGroup();
        ReminderAccountGroup GetRow_ReminderAccountGroup(long _ID);
        long Save_ReminderAccountGroup(ReminderAccountGroup reminderAccountGroup);
        bool Update_ReminderAccountGroup(ReminderAccountGroup reminderAccountGroup);
    }


    public class ReminderAccountGroupManager(FinanceCheckUpDbContext _dbContext) : GenericDapperRepositoryBase(_dbContext), IReminderAccountGroupManager
    {
        public IEnumerable<ReminderAccountGroup> Get_ReminderAccountGroup()
        {
            return StaticQuery<ReminderAccountGroup>("Select * From [ReminderAccountGroup]");
        }
        public ReminderAccountGroup GetRow_ReminderAccountGroup(long _ID)
        {
            return StaticQuery<ReminderAccountGroup>("Select * From [ReminderAccountGroup] where ID=@ID ", new { ID = _ID }).FirstOrDefault();
        }

        public long Save_ReminderAccountGroup(ReminderAccountGroup reminderAccountGroup)
        {

            string sql = @"  INSERT INTO [ReminderAccountGroup] ([Name]) VALUES (@Name );
                             select  Cast(SCOPE_IDENTITY() as Int) ";

            if (reminderAccountGroup.Id > 0) { sql = "UPDATE   [ReminderAccountGroup] SET  [Name]=@Name  WHERE [ID]=@ID"; }

            reminderAccountGroup.Id = Query<int>(sql, reminderAccountGroup).FirstOrDefault();
            return reminderAccountGroup.Id;
        }

        public bool Update_ReminderAccountGroup(ReminderAccountGroup reminderAccountGroup)
        {
            try
            {
                string sql = "UPDATE   [ReminderAccountGroup] SET  [Name]=@Name  WHERE [ID]=@ID";
                Execute(sql, reminderAccountGroup);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
