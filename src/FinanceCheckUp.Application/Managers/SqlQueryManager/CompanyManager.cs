using FinanceCheckUp.Application.Contexts.Concretes.Databases;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Application.Models.ViewModel;
using FinanceCheckUp.Domain.Entities;
using FinanceCheckUp.Framework.Data;
using FinanceCheckUp.Framework.Data.MsSql.Repositories;

namespace FinanceCheckUp.Application.Managers.SqlQueryManager;
public interface ICompanyManager : IGenericDapperRepository
{
    List<int> Get_CompanyReportYearMainMizan(long ide);
    List<Company> Get_ReportCompanyQnb();
    List<Company> Get_LimitedCompanyQnb();
    List<Company> Get_ASCompaniesQnb();
    IEnumerable<XmlSourceTb> GetCompany_Entegrator();
    IEnumerable<Company> Get_ConsoleAll(long ide);
    IEnumerable<Company> UpdateStat_Console(long ide);
    Company Get_Company(long ide);
    Company Get_CompanyRow(long ide);
    List<int> Get_CompanyReportYear(long ide);
    float Get_ReportREELPUAN(long ide);
    float Get_ReportTrendSectorPerc(long ide);
    float Get_ReportSectorTrendPerc(long ide);
    List<RepUstKalemPuan> Get_UstKalemPuan(long ide);
    int Get_LastTCMBReportYear();
    List<int> Get_CompanyReportYearFull(long ide);
    CompanyReportView Get_CompanyReportView(long ide);
    int DataReportMainLastMonth(int _year, long _compID);
    int DataReportMainNace(string _nace, long _compID);
    IEnumerable<Company> Get_All();
    IEnumerable<Company> Get_CompanyT(long ide);
    IEnumerable<Company> Get_CompanyNames(long ide);
    IEnumerable<Company> Get_CompanyNamesT(long ide);
    IEnumerable<Company> Getby_User(long ide);
    int Save_Company();
    int Save_Company(Company company);
    bool Update_Company();
    bool Update_Company(Company company);
    Company Get_CompanybyTax(string ide);
    List<int> GetCompanyAktarma(long ide);
    List<DashMizanResult> GetCompanyAktarmaResult(long ide, int yeare_);
    List<DashMizanResult> GetCompanyAktarmaDonuk(long ide, int yeare_);
    List<int> Get_CompanyReportYearMain(long responseModelCurcomId);
    List<int> Get_CompanyReportYearMainMizanReport(long ide);
    IEnumerable<CsvDynamic> GetCompanyReportCsv(long ide, int type_);
    IEnumerable<CsvDynamicII> GetCompanyReportCsvII(long ide, int type_);
    IEnumerable<CsvDynamicIII> GetCompanyReportCsvIII(long ide, int type_);
    IEnumerable<CsvDynamicIIII> GetCompanyReportCsvIIII(long ide, int type_);
}


public class CompanyManager(FinanceCheckUpDbContext _dbContext, IHhvnUsersManager hhvnUsersManager, IUserCompanyManager userCompanyManager) : GenericDapperRepositoryBase(_dbContext), ICompanyManager
{
    public   List<int> Get_CompanyReportYearMainMizan(long ide)
    {
        return StaticQuery<int>("SELECT  DISTINCT([Year])  FROM  [dbo].TBLMSampleBlncoMzn where CompanyID=@ID ", new { ID = ide }).ToList();
    }
    
    public List<Company> Get_ReportCompanyQnb()
    {
        string sqll = @"  Select MAX(k.LastLogin) as LastLogin,k.ID,k.TaxID,k.qnbCorporateId,k.applicationId,k.Adress,k.CompanyName,k.CreatedDate,k.ContactName,k.ContactMail,k.ContactGSM,k.qnbUserId from
 (  select ul.CreatedDate as LastLogin ,c.ID,c.TaxID,c.qnbCorporateId,c.applicationId,c.Adress,c.CompanyName,c.CreatedDate,c.ContactName,c.ContactMail,c.ContactGSM,u.qnbUserId  from  [EDEFTERDB].[dbo].[Company] c
    LEFT JOIN [EDEFTERDB].[dbo].UserCompany uc on uc.CompanyID=c.ID
   LEFT JOIN [EDEFTERDB].[dbo].[User] u on u.ID=uc.UserID
   LEFT JOIN [EDEFTERDB].[dbo].[UserLogin] ul on ul.UserID=u.ID
   
   where c.ID in(select [CompanyID]  FROM [EDEFTERDB].[dbo].[TBLXml] group by [CompanyID]) and c.ID>136 and [applicationId] is not null   )k group by  k.ID,k.TaxID,k.qnbCorporateId,k.applicationId,k.Adress,k.CompanyName,k.CreatedDate,k.ContactGSM,k.ContactMail,k.ContactName,k.qnbUserId"
    ;

        return StaticQuery<Company>(sqll).ToList();
    }
    //ID,CompanyName,ContactName,ContactMail,ContactGSM,Adress,qnbUserId,qnbCorporateId,CreatedDate

    public List<Company> Get_LimitedCompanyQnb()
    {
        return StaticQuery<Company>("select ID,CompanyName,ContactName,ContactMail,ContactGSM,Adress,qnbUserId,qnbCorporateId,CreatedDate from  [EDEFTERDB].[dbo].[Company] where ID>139 and (UPPER(CompanyName) like '%LIMI%' or UPPER(CompanyName) like '%LİMİ%' or UPPER(CompanyName) like '%LTD%')  order by ID desc").ToList();
    }
    public List<Company> Get_ASCompaniesQnb()
    {
        return StaticQuery<Company>("select ID,CompanyName,ContactName,ContactMail,ContactGSM,Adress,qnbUserId,qnbCorporateId,CreatedDate from  [EDEFTERDB].[dbo].[Company] where ID>139 and (UPPER(CompanyName) like '%A.S%' or UPPER(CompanyName) like '%A.Ş%'or UPPER(CompanyName) like '%ANO%')   order by ID desc").ToList();
    }
    public IEnumerable<XmlSourceTb> GetCompany_Entegrator()
    {
        Execute("UPDATE   [dbo].[Company] set XmlSourceID=3 where XmlSourceID=5");
        XmlSourceTb nnew = new() { Id = 1, XmlSource = "E-defter" };
        XmlSourceTb nnew1 = new() { Id = 3, XmlSource = "Mizan-Beyanname" };
        List<XmlSourceTb> nlist = [nnew, nnew1];
        return nlist;
    }
    public IEnumerable<Company> Get_ConsoleAll(long ide)
    {
        return StaticQuery<Company>("SELECT Company.* ,Cities.City  FROM [dbo].[Company] LEFT JOIN Cities on Company.CityID = Cities.ID  where  Company.MainCompanyID=@ID", new { ID = ide });
    }
    public IEnumerable<Company> UpdateStat_Console(long ide)
    {
        return StaticQuery<Company>("UPDATE   [dbo].[Company] set MainCompanyID=0 where ID=@ID", new { ID = ide });
    }
    public Company Get_Company(long ide)
    {
        return StaticQuery<Company>("SELECT Company.* ,Cities.City  FROM [dbo].[Company] LEFT JOIN Cities on Company.CityID = Cities.ID  where  Company.ID=@ID", new { ID = ide }).FirstOrDefault();
    }
    public Company Get_CompanyRow(long ide)
    {
        return StaticQuery<Company>("SELECT *  FROM [dbo].[Company] where ID=@ID", new { ID = ide }).FirstOrDefault();
    }
    public List<int> Get_CompanyReportYear(long ide)
    {
        return StaticQuery<int>("SELECT DISTINCT([Year]) from  [TBLXml] where CompanyID=@ID and [IsReported]=0", new { ID = ide }).ToList();
    }


    public float Get_ReportREELPUAN(long ide)
    {
        return StaticQuery<float>("Select SUM(REELPUAN) FROM [EDEFTERDB].[dbo].[TBLMQnbReportRatioView] where CompanyID=@ID ", new { ID = ide }).FirstOrDefault();
    }
    //  Select SUM([AreaValue])-SUM([SectorValue])FROM [EDEFTERDB].[dbo].[TBLMQnbReportRatioView] where CompanyID=9 and SectorValue<>0
    public float Get_ReportTrendSectorPerc(long ide)
    {
        return StaticQuery<float>(" Select CASE WHEN ISNULL(SUM([SectorValue]),0)=0 then 0 else (ISNULL(SUM([AreaValue]),0)/ISNULL(SUM([SectorValue]),0)) *100 end FROM [EDEFTERDB].[dbo].[TBLMQnbReportRatioView] where CompanyID=@ID  and SectorValue<>0", new { ID = ide }).FirstOrDefault();
    }
    public float Get_ReportSectorTrendPerc(long ide)
    {
        return StaticQuery<float>("Select CASE WHEN ISNULL(SUM([AreaValue]),0)=0 then 0 else (ISNULL(SUM([SectorValue]),0)/ISNULL(SUM([AreaValue]),0))*100 end FROM [EDEFTERDB].[dbo].[TBLMQnbReportRatioView] where CompanyID=@ID  and SectorValue<>0", new { ID = ide }).FirstOrDefault();
    }
    public List<RepUstKalemPuan> Get_UstKalemPuan(long ide)
    {
        return StaticQuery<RepUstKalemPuan>(" Select MainID,[USTKALEMPUAN]  FROM [EDEFTERDB].[dbo].[TBLMQnbReportRatioView] where CompanyID=@ID  and [MainID]<>111 group by  MainID,[USTKALEMPUAN]", new { ID = ide }).ToList();
    }
    public int Get_LastTCMBReportYear()
    {
        return StaticQuery<int>("SELECT TOP 1 [YIL]   FROM [EDEFTERDB].[dbo].[TBLF11NAKITORAN] order by YIL desc").FirstOrDefault();
    }
    public List<int> Get_CompanyReportYearFull(long ide)
    {
        return StaticQuery<int>("SELECT top 4  [Year]  from  [TBLXml] where CompanyID=@ID group by [Year]  order by [Year] desc ", new { ID = ide }).ToList();
    }
    public CompanyReportView Get_CompanyReportView(long ide)
    {
        return StaticQuery<CompanyReportView>(" SELECT t.[CompanyName]   , t.[NaceID] , o.Code, o.[Description], o.MainDescription FROM [EDEFTERDB].[dbo].[Company] t LEFT JOIN NACECODEMain o on t.NaceID= o.ID where t.ID=@ID", new { ID = ide }).FirstOrDefault();
    }
    //( Select MAX(LastMonth) FROM   [dbo].[TBLMRevenueRast] where [CompanyID]=@CompID and [Year]=@year )
    public int DataReportMainLastMonth(int _year, long _compID)
    {
        string sql = @"Select MAX(LastMonth) FROM   [dbo].[TBLMRevenueRast] where [CompanyID]=@companyID and [Year]=@nyear";
        var ttt = StaticQuery<int>(sql, new { nyear = _year, companyID = _compID }).FirstOrDefault();
        return ttt;
    }
    public int DataReportMainNace(string _nace, long _compID)
    {
        string sql = @"UPDATE [dbo].[Company] set NaceID=@nnace ,NaceCode=(Select ManCode from NACECODEMain where ID=@nnace) where  ID=@companyID ";
        var ttt = Execute(sql, new { nnace = _nace, companyID = _compID });
        return ttt;
    }
    public IEnumerable<Company> Get_All()
    {
        return StaticQuery<Company>("SELECT Company.* ,Cities.City  FROM [dbo].[Company] LEFT JOIN Cities on Company.CityID = Cities.ID");
    }
    public IEnumerable<Company> Get_CompanyT(long ide)
    {
        return StaticQuery<Company>("SELECT Company.* ,Cities.City  FROM [dbo].[Company] LEFT JOIN Cities on Company.CityID = Cities.ID  where  MainCompanyID=@ID", new { ID = ide });
    }
    public IEnumerable<Company> Get_CompanyNames(long ide)
    {
        return StaticQuery<Company>("SELECT Company.* ,Cities.City  FROM [dbo].[Company] LEFT JOIN Cities on Company.CityID = Cities.ID  where  ID=@ID", new { ID = ide });
    }
    public IEnumerable<Company> Get_CompanyNamesT(long ide)
    {
        return StaticQuery<Company>("SELECT Company.* ,Cities.City  FROM [dbo].[Company] LEFT JOIN Cities on Company.CityID = Cities.ID  where  MainCompanyID=@ID", new { ID = ide });
    }
    public IEnumerable<Company> Getby_User(long ide)
    {
        //string sql = @"SELECT t.ID,t.CompanyName ,c.City,u.IsDefault  FROM [dbo].[Company] as t LEFT JOIN Cities as c on t.CityID = c.ID  JOIN UserCompany as u on t.ID=u.CompanyID where u.UserID=@userid";

        return StaticQuery<Company>("SELECT t.ID,t.CompanyName ,t.NaceID,t.TaxID ,t.NaceCode  ,c.City,u.IsDefault  FROM [dbo].[Company] as t LEFT JOIN Cities as c on t.CityID = c.ID  JOIN UserCompany as u on t.ID=u.CompanyID where u.UserID=@userid", new { userid = ide });
    }

    public int Save_Company()
    {
        string sql = @"  INSERT INTO [Company]
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
        [Notes] ,NaceCode,
        MainCompanyID,XmlSourceID
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
        @Notes ,@NaceCode,
        @MainCompanyID,@XmlSourceID

         )  ;select  Cast(SCOPE_IDENTITY() as Int)";
        var companyId = Execute(sql, this);

        List<int> userMaterID = hhvnUsersManager.Get_AllMAsters();
        foreach (var item in userMaterID)
        {
            userCompanyManager.Save_User(new UserCompany
            {
                CompanyId = companyId,
                UserId = item,
                IsDefault = 0
            });
        }

        return companyId;

    }

    public int Save_Company(Company company)
    {
        string sql = @"  INSERT INTO [Company]
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
        [Notes] ,NaceCode,
        MainCompanyID,XmlSourceID
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
        @Notes ,@NaceCode,
        @MainCompanyID,@XmlSourceID

         )  ;select  Cast(SCOPE_IDENTITY() as Int)";
        var companyId = Execute(sql, company);

        List<int> userMaterID = hhvnUsersManager.Get_AllMAsters();
        foreach (var item in userMaterID)
        {
            userCompanyManager.Save_User(new UserCompany()
            {
                CompanyId = companyId,
                UserId = item,
                IsDefault = 0
            });
        }

        return companyId;

    }

    public bool Update_Company()
    {
        try
        {
            string sql = "UPDATE   [Company] SET    [CompanyName]=@CompanyName , [ContactName]=@ContactName , [ContactMail]=@ContactMail , [ContactGSM]=@ContactGSM , [CityID]=@CityID , [State]=@State , [Adress]=@Adress , [TaxID]=@TaxID , [TaxOffice]=@TaxOffice , [Notes]=@Notes,XmlSourceID=@XmlSourceID,NaceCode=@NaceCode  WHERE [ID]=@ID";
            Execute(sql, this);
            return true;
        }
        catch
        {
            throw;
        }
    }

    public bool Update_Company(Company company)
    {
        try
        {
            string sql = "UPDATE   [Company] SET    [CompanyName]=@CompanyName , [ContactName]=@ContactName , [ContactMail]=@ContactMail , [ContactGSM]=@ContactGSM , [CityID]=@CityID , [State]=@State , [Adress]=@Adress , [TaxID]=@TaxID , [TaxOffice]=@TaxOffice , [Notes]=@Notes,XmlSourceID=@XmlSourceID,NaceCode=@NaceCode  WHERE [ID]=@ID";
            Execute(sql, company);
            return true;
        }
        catch
        {
            throw;
        }
    }

    public Company Get_CompanybyTax(string ide)
    {
        return StaticQuery<Company>("SELECT  *  FROM  [Company]    where  TaxID=@ID", new { ID = ide }).FirstOrDefault();
    }

    public   List<int> GetCompanyAktarma(long ide)
    {
        return StaticQuery<int>("SELECT DISTINCT([YEAR])  FROM [EDEFTERDB].[dbo].[SPO_TBMLAKTARMA] where  [CompanyID]=@comid ", new { comid = ide }).ToList();
    }

    public   List<DashMizanResult> GetCompanyAktarmaResult(long ide, int yeare_)
    {
        return StaticQuery<DashMizanResult>("SELECT [Message] as Description, [Value] as Amount      FROM [EDEFTERDB].[dbo].[SPO_TBMLAKTARMA] where [IsChecked]=1 and [Value]!=0 and  [CompanyID]=@comid  and [YEAR]=@year", new { comid = ide, year = yeare_ }).ToList();
    }

    public   List<DashMizanResult> GetCompanyAktarmaDonuk(long ide, int yeare_)
    {
        return StaticQuery<DashMizanResult>("SELECT AccountSubDescription as Description , Amount     FROM [EDEFTERDB].[dbo].TBLMDONUKACCNTCHKYEAR where   [CompanyID]=@comid   and [YEAR]=@year", new { comid = ide, year = yeare_ }).ToList();
    }
    
    public   List<int> Get_CompanyReportYearMain(long ide)
    {
        return StaticQuery<int>("SELECT DISTINCT([Year]) from  [TBLXml] where CompanyID=@ID  and MONTH([DocumentDate])>2 ", new { ID = ide }).ToList();
    }

    public List<int> Get_CompanyReportYearMainMizanReport(long ide)
    {
        return StaticQuery<int>(
                "SELECT DISTINCT([Year]) from  [TBLMizan] where CompanyID=@ID and MainMonth=12",
                new { ID = ide })
            .ToList();
    }

    public IEnumerable<CsvDynamic> GetCompanyReportCsv(long ide, int type_) =>
        StaticQuery<CsvDynamic>("EXEC SA_GetCompanyReportCsv @companyID,@type", new { companyID = ide, type = type_ });

    public IEnumerable<CsvDynamicII> GetCompanyReportCsvII(long ide, int type_) =>
        StaticQuery<CsvDynamicII>("EXEC SA_GetCompanyReportCsv @companyID,@type", new { companyID = ide, type = type_ });

    public IEnumerable<CsvDynamicIII> GetCompanyReportCsvIII(long ide, int type_) =>
        StaticQuery<CsvDynamicIII>("EXEC SA_GetCompanyReportCsv @companyID,@type", new { companyID = ide, type = type_ });

    public IEnumerable<CsvDynamicIIII> GetCompanyReportCsvIIII(long ide, int type_) =>
        StaticQuery<CsvDynamicIIII>("EXEC SA_GetCompanyReportCsv @companyID,@type", new { companyID = ide, type = type_ });
}