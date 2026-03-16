using FinanceCheckUp.Application.Contexts.Concretes.Databases;
using FinanceCheckUp.Domain.Entities;
using FinanceCheckUp.Framework.Data;
using FinanceCheckUp.Framework.Data.MsSql.Repositories;

namespace FinanceCheckUp.Application.Managers.SqlQueryManager;

public interface IUserManager : IGenericDapperRepository//  IGenericDapperRepository//  ISqlOperationalHelper
{
    IEnumerable<User> Get_All();
    List<int> Get_AllMAsters();
    int SetYearMain(long _compID, long _userid);
    int SetYear(int _year, long _userid);
    int ViewCountUp(int _ID);
    IEnumerable<User> GetByAdminUser(int _ID);
    User GetUserbyGuid(string gdi);
    int DeleteUser(int _ID);
    (int, IEnumerable<User>) ListView(int page, int count, string status, int requestID = -1);
    User GetRow_User(long _ID);
    int GetRow_UserKonsolide(int _ID);
    User GetRow_UserGuid(string _ID);
    User GetbyUrl(string pname);

    User GetPasswordwithAppUser(string _email);
    int Save_User(User user);
    bool CheckUser(long compid, int userid);
    bool Update_User(User user);
    bool Update_Password(User user);
}

public class UserManager(FinanceCheckUpDbContext _dbContext) : GenericDapperRepositoryBase(_dbContext), IUserManager
{
    public IEnumerable<User> Get_All()
    {

        return StaticQuery<User>("Select * From [User]");
    }

    public List<int> Get_AllMAsters()
    {
        return StaticQuery<int>("Select DISTINCT(ID) From [User] where UserTypeID in (4,1001)").ToList();
    }
    public int SetYearMain(long _compID, long _userid)
    {
        return StaticQuery<int>(@" declare @yearcount int =ISNULL((SELECT Count(DISTINCT(YEAR)) from TBLXml where CompanyID=@ID),0);
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
        return StaticQuery<int>(@"UPDATE   [dbo].[User] set selectedYear=@year where ID =@ID ", new { ID = _userid, year = _year }).FirstOrDefault();

    }
    public int ViewCountUp(int _ID)
    {
        return StaticQuery<int>(@"UPDATE   [dbo].[User] set ViewCount=ViewCount+1   where ID =@ID ", new { ID = _ID }).FirstOrDefault();

    }
    public IEnumerable<User> GetByAdminUser(int _ID)
    {
        return StaticQuery<User>(@"Select * from [User] Where ID in  (SELECT DISTINCT([UserID] )   FROM [dbo].[UserCompany] where[CompanyID] in (Select t.ID From[Company] as t JOIN UserCompany as u on t.ID=u.CompanyID where u.UserID=@ide))", new { ide = _ID });

    }

    public User GetUserbyGuid(string gdi)
    {
        User hvvn = StaticQuery<User>(@"Select * from [User] Where AccessToken=@nguid", new { nguid = gdi }).FirstOrDefault();
        StaticExecute(@"UPDATE  [User] Set  AccessToken=''  Where AccessToken=@nguid", new { nguid = gdi });
        return hvvn;

    }
    // 
    public int DeleteUser(int _ID)
    {
        return StaticQuery<int>("Update  [User] set IsDeleted=1 where ID=@ID ", new { ID = _ID }).FirstOrDefault();
    }
    public (int, IEnumerable<User>) ListView(int page, int count, string status, int requestID = -1)
    {
        string sql = @"Select * From [User] ";


        var totalSql = "SELECT COUNT(*) FROM (" + sql + " ) QR";
        int totalCount = StaticQuery<int>(totalSql).FirstOrDefault();

        sql += " ORDER BY  ID desc OFFSET " + ((page - 1) * count).ToString() + " ROWS FETCH NEXT " + count.ToString() + " ROWS ONLY";

        var result = new List<User>();
        result = StaticQuery<User>(sql).ToList();


        return (totalCount, result);




    }
    public User GetRow_User(long _ID)
    {
        return StaticQuery<User>("Select * From [User] where ID=@ID ", new { ID = _ID }).FirstOrDefault();
    }
    public int GetRow_UserKonsolide(int _ID)
    {
        return StaticQuery<int>("Select Count(ID) from Company where MainCompanyID= (SELECT  [CompanyID]   FROM [EDEFTERDB].[dbo].[UserCompany] where [UserID]=@ID and [IsDefault]=1)", new { ID = _ID }).FirstOrDefault();
    }
    public User GetRow_UserGuid(string _ID)
    {
        return StaticQuery<User>("Select * From [User] where  UserGuid=@ID ", new { ID = _ID }).FirstOrDefault();
    }
    public User GetbyUrl(string pname)
    {
        return StaticQuery<User>("SELECT * FROM   [dbo].[User] where[AuthorUrl]=@p_name ", new { p_name = pname }).FirstOrDefault();
    }

    public User GetPasswordwithAppUser(string _email)
    {
        try
        {
            return StaticQuery<User>("SELECT * FROM   [dbo].[User] WHERE Email=@p_email", new { p_email = _email }).FirstOrDefault();
        }
        catch (Exception ex)
        {
            var chk = ex;
            throw;
        }

    }
    public int Save_User()
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
        return StaticQuery<int>(sql, this).FirstOrDefault();
    }

    public bool CheckUser(long compid, int userid)
    {
        string sql = "SELECT  top 1   CASE WHEN EXISTS     (SELECT  cx.[ID]     FROM  [dbo].[UserCompany] as cx       WHERE cx.[CompanyID]=@qcomp and cx.[UserID]=@user)  THEN 1   ELSE 0   END FROM  [dbo].[UserCompany] ";
        return StaticQuery<bool>(sql, new { user = userid, qcomp = compid }).FirstOrDefault();
    }

    public bool Update_User(User user)
    {
        try
        {
            string sql = "UPDATE   [User] SET  [FirstName]=@FirstName , [LastName]=@LastName , IsActive=@IsActive, [Phone]=@Phone ,  [CityID]=@CityID ,  SessionGuid=@SessionGuid,PasswordReset=@PasswordReset, ProfilePhoto=@ProfilePhoto,Email=@Email,IsDeleted=@IsDeleted,UserTypeID=@UserTypeID   WHERE [ID]=@ID";
            StaticQuery<bool>(sql, user);
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
            return StaticQuery<bool>(sql, user).FirstOrDefault();

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
        return StaticQuery<int>(sql, user).FirstOrDefault();
    }
}
