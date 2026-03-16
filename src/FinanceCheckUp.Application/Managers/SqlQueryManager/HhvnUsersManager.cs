using FinanceCheckUp.Application.Contexts.Concretes.Databases;
using FinanceCheckUp.Domain.Entities;
using FinanceCheckUp.Framework.Data;
using FinanceCheckUp.Framework.Data.MsSql.Repositories;

namespace FinanceCheckUp.Application.Managers.SqlQueryManager;

public interface IHhvnUsersManager : IGenericDapperRepository
{
    IEnumerable<HhvnUsers> Get_All();
    List<int> Get_AllMAsters();
    int SetYearMain(long _compID, long _userid);
    int SetYear(int _year, long _userid);
    int ViewCountUp(int _ID);
    IEnumerable<HhvnUsers> GetByAdminUser(int _ID);
    HhvnUsers GetUserbyGuid(string gdi);
    int DeleteUser(int _ID);
    (int, IEnumerable<HhvnUsers>) ListView(int page, int count, string status, int requestID = -1);
    HhvnUsers GetRow_User(long _ID);
    int GetRow_UserKonsolide(int _ID);
    HhvnUsers GetRow_UserGuid(string _ID);
    HhvnUsers GetbyUrl(string pname);

    HhvnUsers GetPasswordwithAppUser(string _email);
    int Save_User(User user);
    bool CheckUser(long compid, int userid);
    bool Update_User(User user);
    bool Update_Password(User user);
}

public class HhvnUsersManager(FinanceCheckUpDbContext _dbContext) : GenericDapperRepositoryBase(_dbContext), IHhvnUsersManager
{
    public IEnumerable<HhvnUsers> Get_All()
    {

        return Query<HhvnUsers>("Select * From [User]");
    }

    public List<int> Get_AllMAsters()
    {
        return Query<int>("Select DISTINCT(ID) From [User] where UserTypeID in (4,1001)").ToList();
    }
    public int SetYearMain(long _compID, long _userid)
    {
        return Query<int>(@" declare @yearcount int =ISNULL((SELECT Count(DISTINCT(YEAR)) from TBLXml where CompanyID=@ID),0);
IF @yearcount = 0
BEGIN 
UPDATE   [dbo].[User] set selectedYear=(SELECT YEAR(getdate())) where ID =@userID 

END
ELSE
BEGIN 
IF @yearcount<2
BEGIN
UPDATE   [dbo].[User] set selectedYear=(SELECT TOP 1 Year from TBLXml where CompanyID=@ID) where ID =@userID 
END
END
", new { ID = _compID, userID = _userid }).FirstOrDefault();

    }
    public int SetYear(int _year, long _userid)
    {
        return Query<int>(@"UPDATE   [dbo].[User] set selectedYear=@year where ID =@ID ", new { ID = _userid, year = _year }).FirstOrDefault();

    }
    public int ViewCountUp(int _ID)
    {
        return Query<int>(@"UPDATE   [dbo].[User] set ViewCount=ViewCount+1   where ID =@ID ", new { ID = _ID }).FirstOrDefault();

    }
    public IEnumerable<HhvnUsers> GetByAdminUser(int _ID)
    {
        return Query<HhvnUsers>(@"Select * from [User] Where ID in  (SELECT DISTINCT([UserID] )   FROM [dbo].[UserCompany] where[CompanyID] in (Select t.ID From[Company] as t JOIN UserCompany as u on t.ID=u.CompanyID where u.UserID=@ide))", new { ide = _ID });

    }

    public HhvnUsers GetUserbyGuid(string gdi)
    {
        HhvnUsers hvvn = Query<HhvnUsers>(@"Select * from [User] Where AccessToken=@nguid", new { nguid = gdi }).FirstOrDefault();
        Execute(@"UPDATE  [User] Set  AccessToken=''  Where AccessToken=@nguid", new { nguid = gdi });
        return hvvn;

    }
    // 
    public int DeleteUser(int _ID)
    {
        return Query<int>("Update  [User] set IsDeleted=1 where ID=@ID ", new { ID = _ID }).FirstOrDefault();
    }
    public (int, IEnumerable<HhvnUsers>) ListView(int page, int count, string status, int requestID = -1)
    {
        string sql = @"Select * From [User] ";


        var totalSql = "SELECT COUNT(*) FROM (" + sql + " ) QR";
        int totalCount = Query<int>(totalSql).FirstOrDefault();

        sql += " ORDER BY  ID desc OFFSET " + ((page - 1) * count).ToString() + " ROWS FETCH NEXT " + count.ToString() + " ROWS ONLY";

        var result = new List<HhvnUsers>();
        result = Query<HhvnUsers>(sql).ToList();


        return (totalCount, result);




    }
    public HhvnUsers GetRow_User(long _ID)
    {
        return Query<HhvnUsers>("Select * From [User] where ID=@ID ", new { ID = _ID }).FirstOrDefault();
    }
    public int GetRow_UserKonsolide(int _ID)
    {
        return Query<int>("Select Count(ID) from Company where MainCompanyID= (SELECT  [CompanyID]   FROM [EDEFTERDB].[dbo].[UserCompany] where [UserID]=@ID and [IsDefault]=1)", new { ID = _ID }).FirstOrDefault();
    }
    public HhvnUsers GetRow_UserGuid(string _ID)
    {
        return Query<HhvnUsers>("Select * From [User] where  UserGuid=@ID ", new { ID = _ID }).FirstOrDefault();
    }
    public HhvnUsers GetbyUrl(string pname)
    {
        return Query<HhvnUsers>("SELECT * FROM   [dbo].[User] where[AuthorUrl]=@p_name ", new { p_name = pname }).FirstOrDefault();
    }

    public HhvnUsers GetPasswordwithAppUser(string _email)
    {
        try
        {
            return Query<HhvnUsers>("SELECT * FROM   [dbo].[User] WHERE Email=@p_email", new { p_email = _email }).FirstOrDefault();
        }
        catch
        {
            throw;
        }

    }


    public bool CheckUser(long compid, int userid)
    {
        string sql = "SELECT  top 1   CASE WHEN EXISTS     (SELECT  cx.[ID]     FROM  [dbo].[UserCompany] as cx       WHERE cx.[CompanyID]=@qcomp and cx.[UserID]=@user)  THEN 1   ELSE 0   END FROM  [dbo].[UserCompany] ";
        return Query<bool>(sql, new { user = userid, qcomp = compid }).FirstOrDefault();
    }

    public bool Update_User(User user)
    {
        try
        {
            string sql = "UPDATE   [User] SET  [FirstName]=@FirstName , [LastName]=@LastName , IsActive=@IsActive, [Phone]=@Phone ,  [CityID]=@CityID ,  SessionGuid=@SessionGuid,PasswordReset=@PasswordReset, ProfilePhoto=@ProfilePhoto,Email=@Email,IsDeleted=@IsDeleted,UserTypeID=@UserTypeID   WHERE [ID]=@ID";
            Query<bool>(sql, user);
            return true;
        }
        catch
        {
            throw;
        }
    }

    public bool Update_Password(User user)
    {
        try
        {
            string sql = "UPDATE  [User] SET Password=@Password WHERE [ID]=@ID";
            Query<bool>(sql, user);
            return true;
        }
        catch
        {
            throw;
        }
    }

    public int Save_User(User user)
    {
        string sql = @"  INSERT INTO [User]
          ( 
        [FirstName] ,
        [LastName] , 
        [Phone] ,Email, 
        [CityID] , 
PasswordReset,Password,ProfilePhoto,IsDeleted,UserTypeID ,UserGuid
          ) 
           VALUES 
         ( 
        @FirstName ,
        @LastName , 
        @Phone ,@Email, 
        @CityID ,  @PasswordReset,@Password,@ProfilePhoto,0,@UserTypeID ,CONVERT(varchar(36), (SELECT NEWID()))
         )  ;select  Cast(SCOPE_IDENTITY() as Int)";
        user.Id = Query<int>(sql, user).FirstOrDefault();

        return (int)user.Id;
    }
}
