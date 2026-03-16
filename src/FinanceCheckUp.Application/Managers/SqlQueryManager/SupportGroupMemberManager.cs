using FinanceCheckUp.Application.Contexts.Concretes.Databases;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Framework.Data;
using FinanceCheckUp.Framework.Data.MsSql.Repositories;

namespace FinanceCheckUp.Application.Managers.SqlQueryManager;

public interface ISupportGroupMemberManager : IGenericDapperRepository
{
    public SupportGroupMember GetRow(int _supportgroupmemberid);
    public int Upsert(SupportGroupMember supportGroupMember);
}

public class SupportGroupMemberManager(FinanceCheckUpDbContext _dbContext) : GenericDapperRepositoryBase(_dbContext), ISupportGroupMemberManager
{
    public SupportGroupMember GetRow(int _supportgroupmemberid)
    {
        return StaticQuery<SupportGroupMember>("SELECT * FROM [Users].[SupportGroupMember] WHERE SupportGroupMemberID=@p_supportgroupmemberid", new { p_supportgroupmemberid = _supportgroupmemberid }).FirstOrDefault();
    }


    public int Upsert(SupportGroupMember supportGroupMember)
    {
        string isql = @"INSERT INTO [Users].[SupportGroupMember]
			([SupportGroupID],
			[UserID] ) 
			VALUES 
			(@SupportGroupID,
			@UserID );
			select cast(scope_identity() as int);";

        string usql = @"UPDATE Users.SupportGroupMember
			SET [SupportGroupID] = @SupportGroupID,
			[UserID] = @UserID,
			[ModifiedDate] = GETDATE()
			 WHERE SupportGroupMemberID = @SupportGroupMemberID";

        if (supportGroupMember.SupportGroupMemberID == 0)
        {
            supportGroupMember.SupportGroupMemberID = Query<int>(isql, supportGroupMember).FirstOrDefault();
        }
        else
        {
            Execute(usql, supportGroupMember);
        }

        return supportGroupMember.SupportGroupMemberID;
    }

    public IEnumerable<SupportGroupMember> ToList()
    {
        return StaticQuery<SupportGroupMember>("SELECT *  FROM [Users].[SupportGroupMember] (NOLOCK)");

    }

}
