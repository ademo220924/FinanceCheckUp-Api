using FinanceCheckUp.Application.Contexts.Concretes.Databases;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Framework.Data;
using FinanceCheckUp.Framework.Data.MsSql.Repositories;

namespace FinanceCheckUp.Application.Managers.SqlQueryManager;


public interface ISupportGroupManager : IGenericDapperRepository
{
    public SupportGroup GetRow(int _supportgroupid);
    public IEnumerable<SupportGroup> SupportGroupViews();
    public bool Delete(int _supportgroupid);
    public int Upsert(SupportGroup supportGroup);
    public IEnumerable<SupportGroup> ToList();
}

public class SupportGroupManager(FinanceCheckUpDbContext _dbContext) : GenericDapperRepositoryBase(_dbContext), ISupportGroupManager
{
    public SupportGroup GetRow(int _supportgroupid)
    {
        return StaticQuery<SupportGroup>("SELECT * FROM [Users].[SupportGroup] WHERE SupportGroupID=@p_supportgroupid", new { p_supportgroupid = _supportgroupid }).FirstOrDefault();
    }
    public IEnumerable<SupportGroup> SupportGroupViews()
    {

        return StaticQuery<SupportGroup>("SELECT *  FROM [dbo].[User_SupportGroupView] (NOLOCK) WHERE IsDeleted=0");

    }
    public bool Delete(int _supportgroupid)
    {
        return Query<bool>("UPDATE  [Users].[SupportGroup]  SET IsDeleted=1 WHERE SupportGroupID=@p_supportgroupid", new { p_supportgroupid = _supportgroupid }).FirstOrDefault();
    }

    public int Upsert(SupportGroup supportGroup)
    {
        string isql = @"INSERT INTO [Users].[SupportGroup]
			([SupportGroupName],
			[SupportGroupDescription],
			[ImpactID],
			[UserID] ) 
			VALUES 
			(@SupportGroupName,
			@SupportGroupDescription,
			@ImpactID,
			@UserID );
			select cast(scope_identity() as int);";

        string usql = @"UPDATE Users.SupportGroup
			SET [SupportGroupName] = @SupportGroupName,
			[SupportGroupDescription] = @SupportGroupDescription,
			[ImpactID] = @ImpactID,
			[UserID] = @UserID,
			[ModifiedDate] = GETDATE()
			 WHERE SupportGroupID = @SupportGroupID";

        if (supportGroup.SupportGroupID == 0)
        {
            supportGroup.SupportGroupID = Query<int>(isql, supportGroup).FirstOrDefault();
        }
        else
        {
            Execute(usql, supportGroup);
        }

        return supportGroup.SupportGroupID;
    }




    public IEnumerable<SupportGroup> ToList()
    {

        return StaticQuery<SupportGroup>("SELECT *  FROM [Users].[SupportGroup] (NOLOCK)");

    }
}
