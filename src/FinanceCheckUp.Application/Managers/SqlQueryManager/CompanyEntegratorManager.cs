using FinanceCheckUp.Application.Contexts.Concretes.Databases;
using FinanceCheckUp.Domain.Entities;
using FinanceCheckUp.Framework.Data;
using FinanceCheckUp.Framework.Data.MsSql.Repositories;

namespace FinanceCheckUp.Application.Managers.SqlQueryManager;
public interface ICompanyEntegratorManager : IGenericDapperRepository

{

    public CompanyEntegrator Get_Company(long ide);
    public Company Get_CompanyRow(long ide);
    public IEnumerable<CompanyEntegrator> Get_All();
    public long Save_Company();

    public bool Update_Company();
    public long Save_Company(CompanyEntegrator companyEntegrator);

    public bool Update_Company(CompanyEntegrator companyEntegrator);

}


public class CompanyEntegratorManager(FinanceCheckUpDbContext _dbContext) : GenericDapperRepositoryBase(_dbContext), ICompanyEntegratorManager
{

    public CompanyEntegrator Get_Company(long ide)
    {
        return StaticQuery<CompanyEntegrator>("SELECT Company.* ,Cities.City  FROM [dbo].[CompanyEntegrator] LEFT JOIN Cities on Company.CityID = Cities.ID  where  Company.ID=@ID", new { ID = ide }).FirstOrDefault();
    }
    public Company Get_CompanyRow(long ide)
    {
        return StaticQuery<Company>("SELECT *  FROM [dbo].[CompanyEntegrator] where ID=@ID", new { ID = ide }).FirstOrDefault();
    }
    public IEnumerable<CompanyEntegrator> Get_All()
    {
        return StaticQuery<CompanyEntegrator>("SELECT Company.* ,Cities.City  FROM [dbo].[CompanyEntegrator] LEFT JOIN Cities on Company.CityID = Cities.ID");
    }
    public long Save_Company()
    {
        string sql = @" 
IF NOT EXISTS
(
  SELECT
    *
  FROM
   [CompanyEntegrator]
  WHERE
    CompanyName = @CompanyName
    TaxID =@TaxID
)
BEGIN
INSERT INTO [CompanyEntegrator]
          (  
        [CompanyName] ,
        [ContactName] ,
        [ContactMail] ,
        [ContactGSM] ,
        [CityID] ,
        [State] ,
        [Adress] ,
        [TaxID] ,
        [TaxOffice] ,
        [Notes]  ,IsVisible
          ) 
           VALUES 
         (  
        @CompanyName ,
        @ContactName ,
        @ContactMail ,
        @ContactGSM ,
        @CityID ,
        @State ,
        @Adress ,
        @TaxID ,
        @TaxOffice ,
        @Notes  ,@IsVisible

         )  ;select  Cast(SCOPE_IDENTITY() as Int)

END

";
        return Execute(sql, this);
    }

    public bool Update_Company()
    {
        try
        {
            string sql = "UPDATE   [CompanyEntegrator] SET    [CompanyName]=@CompanyName , [ContactName]=@ContactName , [ContactMail]=@ContactMail , [ContactGSM]=@ContactGSM , [CityID]=@CityID , [State]=@State , [Adress]=@Adress , [TaxID]=@TaxID , [TaxOffice]=@TaxOffice , [Notes]=@Notes, IsVisible=@IsVisible  WHERE [ID]=@ID";
            Execute(sql, this);
            return true;
        }
        catch
        {
            throw;
        }
    }

    public long Save_Company(CompanyEntegrator companyEntegrator)
    {
        string sql = @" 
IF NOT EXISTS
(
  SELECT
    *
  FROM
   [CompanyEntegrator]
  WHERE
    CompanyName = @CompanyName
    TaxID =@TaxID
)
BEGIN
INSERT INTO [CompanyEntegrator]
          (  
        [CompanyName] ,
        [ContactName] ,
        [ContactMail] ,
        [ContactGSM] ,
        [CityID] ,
        [State] ,
        [Adress] ,
        [TaxID] ,
        [TaxOffice] ,
        [Notes]  ,IsVisible
          ) 
           VALUES 
         (  
        @CompanyName ,
        @ContactName ,
        @ContactMail ,
        @ContactGSM ,
        @CityID ,
        @State ,
        @Adress ,
        @TaxID ,
        @TaxOffice ,
        @Notes  ,@IsVisible

         )  ;select  Cast(SCOPE_IDENTITY() as Int)

END

";
        return Execute(sql, companyEntegrator);
    }

    public bool Update_Company(CompanyEntegrator companyEntegrator)
    {
        try
        {
            string sql = "UPDATE   [CompanyEntegrator] SET    [CompanyName]=@CompanyName , [ContactName]=@ContactName , [ContactMail]=@ContactMail , [ContactGSM]=@ContactGSM , [CityID]=@CityID , [State]=@State , [Adress]=@Adress , [TaxID]=@TaxID , [TaxOffice]=@TaxOffice , [Notes]=@Notes, IsVisible=@IsVisible  WHERE [ID]=@ID";
            Execute(sql, companyEntegrator);
            return true;
        }
        catch
        {
            throw;
        }
    }

}