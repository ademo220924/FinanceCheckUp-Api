using FinanceCheckUp.Application.Contexts.Concretes.Databases;
using FinanceCheckUp.Domain.Entities;
using FinanceCheckUp.Framework.Data;
using FinanceCheckUp.Framework.Data.MsSql.Repositories;


namespace FinanceCheckUp.Application.Managers.SqlQueryManager;
public interface IUserCompanyManager : IGenericDapperRepository
{
    public IEnumerable<UserCompany> Get_All(string ide);
    public int SetUpdateUser(int useride, long comide);
    public int DeleteUser(string ide);
    public bool Update_UserCompany(int Userid_, List<long> companyid_, List<long> userCompanyids);
    public bool Update_UserDefault(int Userid_, int companyid_);
    public bool Update_User(UserCompany userCompany);
    public long Save_User(UserCompany userCompany);
}


public class UserCompanyManager(FinanceCheckUpDbContext _dbContext) : GenericDapperRepositoryBase(_dbContext), IUserCompanyManager
{
    public IEnumerable<UserCompany> Get_All(string ide)
    {
        return StaticQuery<UserCompany>("Select * From [UserCompany]  where  CompanyID=@ID", new { ID = ide });
    }

    public int SetUpdateUser(int useride, long comide)
    {
        StaticQuery<int>("UPDATE   [UserCompany] set IsDefault=0 where  UserID=@ID ", new { ID = useride });
        return StaticQuery<int>("UPDATE   [UserCompany] set IsDefault=1 where  UserID=@ID  and CompanyID=@compid", new { ID = useride, compid = comide }).FirstOrDefault();
    }
    public int DeleteUser(string ide)
    {
        return StaticQuery<int>("Delete From [UserCompany]  where  ID=@ID and IsAdmin='0'", new { ID = ide }).FirstOrDefault();
    }
    public bool Update_UserCompany(int Userid_, List<long> companyid_, List<long> userCompanyids)
    {
        try
        {
            var mreqListCompanyx = userCompanyids;// companiesManager.Getby_User(Userid_).Select(x => x.Id).ToList();
            var list3 = companyid_.Except(mreqListCompanyx).ToList();
            var list4 = mreqListCompanyx.Except(companyid_).ToList();
            if (companyid_.Count > 0 && Userid_ > 0 && (list3.Count > 0 || list4.Count > 0))
            {
                string sql = "DELETE FROM   [UserCompany]  WHERE UserID=@userid ";
                Execute(sql, new { userid = Userid_ });
                sql = "INSERT INTO   [UserCompany](CompanyID,UserID) VALUES(@companyid,@userid)";
                foreach (var item in companyid_)
                {
                    Execute(sql, new { userid = Userid_, companyid = item });
                }

                sql = "UPDATE   [UserCompany] SET  [IsDefault]=1  WHERE [CompanyID]=@companyid and UserID=@userid";
                Execute(sql, new { userid = Userid_, companyid = companyid_.FirstOrDefault() });
            }

            return true;
        }
        catch
        {
            throw;
        }
    }
    public bool Update_UserDefault(int Userid_, int companyid_)
    {
        try
        {
            string sql = "UPDATE   [UserCompany] SET  [IsDefault]=0  WHERE UserID=@userid ;UPDATE   [UserCompany] SET  [IsDefault]=1  WHERE [CompanyID]=@companyid and UserID=@userid ; ";
            Execute(sql, new { userid = Userid_, companyid = companyid_ });
            return true;
        }
        catch
        {
            throw;
        }
    }


    public bool Update_User(UserCompany userCompany)
    {
        try
        {
            string sql = "UPDATE   [UserCompany] SET  [CompanyID]=@CompanyID , [UserID]=@UserID , [IsDefault]=@IsDefault WHERE [ID]=@ID";
            Execute(sql, userCompany);
            return true;
        }
        catch
        {
            throw;
        }
    }

    public long Save_User(UserCompany userCompany)
    {
        string sql = @"  INSERT INTO [UserCompany]
          (  
        [CompanyID] ,
        [UserID] ,
        [IsDefault]    
          ) 
           VALUES 
         (  
        @CompanyID ,
        @UserID ,
        @IsDefault   
         )  ;select  Cast(SCOPE_IDENTITY() as Int)";
        userCompany.Id = Query<int>(sql, userCompany).FirstOrDefault();
        return userCompany.Id;

    }
}
