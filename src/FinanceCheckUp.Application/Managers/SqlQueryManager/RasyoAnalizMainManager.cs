using FinanceCheckUp.Application.Contexts.Concretes.Databases;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Framework.Data;
using FinanceCheckUp.Framework.Data.MsSql.Repositories;

namespace FinanceCheckUp.Application.Managers.SqlQueryManager;

public interface IRasyoAnalizMainManager : IGenericDapperRepository
{
    public List<DashYearlyResult> RasyoAnalizBFinalMBeyanname(int _year, long _compID);
    public List<DashYearlyResult> RasyoAnalizBFinalM(int _year, long _compID);
    public List<DashYearlyResult> RasyoAnalizCFinalM(int _year, long _compID);
    public List<DashYearlyResult> RasyoAnalizDFinal(int _year, long _compID);
    public List<DashYearlyResult> RasyoAnalizEFinal(int _year, long _compID);
    public List<DashYearlyResult> RasyoAnalizFFinal(int _year, long _compID);
    public List<DashYearlyResult> RasyoAnalizGFinal(int _year, long _compID);
    public List<DashYearlyResult> RasyoAnalizHFinal(int _year, long _compID);
    public List<DashYearlyResult> RasyoAnalizH1Final(int _year, long _compID);
    public List<DashYearlyResult> RasyoAnalizIFinalT(int _year, long _compID);
    public List<DashYearlyResult> RasyoAnalizIFinalKarT(int _year, long _compID);
    public List<DashYearlyResult> RasyoAnalizIFinalAktifKarT(int _year, long _compID);
    public List<DashYearlyResult> RasyoAnalizIFinalAktifKarT1(int _year, long _compID);
    public List<DashYearlyResult> RasyoAnalizIFinalAktifKarT2(int _year, long _compID);
    public List<DashYearlyResult> RasyoAnalizIFinalAktifKarT3(int _year, long _compID);
    public List<DashYearlyResult> RasyoAnalizIFinalAktifKarT5(int _year, long _compID);
    public List<DashYearlyResult> RasyoAnalizTOTALFinal(int _year, long _compID);
    public List<DashYearlyResultCRMMain> CRMAnalizTOTAL102(int _year, long _compID);
    public List<DashYearlyResultCRMMain> CRMAnalizTOTAL102T(int _year, long _compID);
    public List<DashYearlyResultCRMMain> CRMAnalizTOTAL103T(int _year, long _compID);
    public List<DashYearlyResultCRMMain> CRMAnalizTOTAL120T(int _year, long _compID);
    public List<DashYearlyResultCRMMain> CRMAnalizTOTAL320T(int _year, long _compID);
    public List<DashYearlyResultCRMMain> CRMAnalizTOTAL103(int _year, long _compID);
    public List<DashYearlyResultCRMMain> CRMAnalizTOTAL101(int _year, long _compID);
    public List<DashYearlyResultCRMMain> CRMAnalizTOTAL101T(int _year, long _compID);
    public List<DashYearlyResultCRMMain> CRMAnalizTOTAL120(int _year, long _compID);
    public List<DashYearlyResultCRMMain> CRMAnalizTOTAL320(int _year, long _compID);
    public List<DashYearlyResultCRMMain> CRMAnalizTOTAL102Mizan(int _year, long _compID);
    public List<DashYearlyResultCRMMain> CRMAnalizTOTAL103Mizan(int _year, long _compID);
    public List<DashYearlyResultCRMMain> CRMAnalizTOTAL120Mizan(int _year, long _compID);
    public List<DashYearlyResultCRMMain> CRMAnalizTOTAL101Mizan(int _year, long _compID);
}

public class RasyoAnalizMainManager(FinanceCheckUpDbContext _dbContext) : GenericDapperRepositoryBase(_dbContext), IRasyoAnalizMainManager
{
    public List<DashYearlyResult> RasyoAnalizBFinalMBeyanname(int _year, long _compID)
    { //SP_RasyoFinansalBorclar
        StaticQuery<int>("EXEC [SPO_TBLMSampleBlncoRasTBeyanname] @companyID, @nyear", new { nyear = _year, companyID = _compID });

        return StaticQuery<DashYearlyResult>("EXEC SP_RasyoFinansalBorclar @companyID, @nyear", new { nyear = _year, companyID = _compID }).ToList();
    }

    public List<DashYearlyResult> RasyoAnalizBFinalM(int _year, long _compID)
    { //SP_RasyoFinansalBorclar
        StaticQuery<int>("EXEC SPO_TBLMSampleBlncoRasT @companyID, @nyear", new { nyear = _year, companyID = _compID });

        return StaticQuery<DashYearlyResult>("EXEC SP_RasyoFinansalBorclar @companyID, @nyear", new { nyear = _year, companyID = _compID }).ToList();
    }


    public List<DashYearlyResult> RasyoAnalizCFinalM(int _year, long _compID)
    {//SP_RasyoFinansalKaldirac
        return StaticQuery<DashYearlyResult>("EXEC SP_RasyoFinansalKaldirac @companyID, @nyear", new { nyear = _year, companyID = _compID }).ToList();
    }

    public List<DashYearlyResult> RasyoAnalizDFinal(int _year, long _compID)
    {//SP_RasyoKisaVadeliBorclar
        return StaticQuery<DashYearlyResult>("EXEC SP_RasyoKisaVadeliBorclar @companyID, @nyear", new { nyear = _year, companyID = _compID }).ToList();
    }


    public List<DashYearlyResult> RasyoAnalizEFinal(int _year, long _compID)
    {//SP_RasyoLikiditeOran
        return StaticQuery<DashYearlyResult>("EXEC  SP_RasyoLikiditeOran  @companyID, @nyear", new { nyear = _year, companyID = _compID }).ToList();
    }

    public List<DashYearlyResult> RasyoAnalizFFinal(int _year, long _compID)
    {//SP_RasyoDuranVarlkOzSermye
        return StaticQuery<DashYearlyResult>("EXEC SP_RasyoDuranVarlkOzSermye @companyID, @nyear", new { nyear = _year, companyID = _compID }).ToList();
    }

    public List<DashYearlyResult> RasyoAnalizGFinal(int _year, long _compID)
    {//SP_RasyoNakiOran
        return StaticQuery<DashYearlyResult>("EXEC SP_RasyoNakiOran @companyID, @nyear", new { nyear = _year, companyID = _compID }).ToList();
    }

    public List<DashYearlyResult> RasyoAnalizHFinal(int _year, long _compID)
    {//SP_RasyoIsltmeSermyeAktif
        return StaticQuery<DashYearlyResult>("EXEC SP_RasyoIsltmeSermyeAktif @companyID, @nyear", new { nyear = _year, companyID = _compID }).ToList();
    }
    public List<DashYearlyResult> RasyoAnalizH1Final(int _year, long _compID)
    {//SP_RasyoCari
        return StaticQuery<DashYearlyResult>("EXEC SP_RasyoCari @companyID, @nyear", new { nyear = _year, companyID = _compID }).ToList();
    }
    // return StaticQuery<DashBilancoView>("EXEC MainZZCariOranTM @companyID, @nyear", new { nyear = _year, companyID = _compID }).FirstOrDefault();
    //public  List<DashYearlyResult> RasyoAnalizIFinal(int _year, long _compID)
    //{//SP_RasyoSermOzSermyeOran
    //    return StaticQuery<DashYearlyResult>("EXEC SP_RasyoSermOzSermyeOran @companyID, @nyear", new { nyear = _year, companyID = _compID }).ToList();
    //}
    public List<DashYearlyResult> RasyoAnalizIFinalT(int _year, long _compID)
    {//SP_RasyoOzsermayeDevirHizi
        return StaticQuery<DashYearlyResult>("EXEC [SP_RasyoOzsermayeDevirHizi] @companyID, @nyear", new { nyear = _year, companyID = _compID }).ToList();
    }
    public List<DashYearlyResult> RasyoAnalizIFinalKarT(int _year, long _compID)
    {//SP_RasyoOzsermayeKarlilikT
        return StaticQuery<DashYearlyResult>("EXEC [SP_RasyoOzsermayeKarlilikT] @companyID, @nyear", new { nyear = _year, companyID = _compID }).ToList();
    }
    public List<DashYearlyResult> RasyoAnalizIFinalAktifKarT(int _year, long _compID)
    {//SP_RasyoAktifKarlilik
        return StaticQuery<DashYearlyResult>("EXEC [SP_RasyoAktifKarlilik] @companyID, @nyear", new { nyear = _year, companyID = _compID }).ToList();
    }
    public List<DashYearlyResult> RasyoAnalizIFinalAktifKarT1(int _year, long _compID)
    {//SP_RasyoEkonomikRantabilite
        return StaticQuery<DashYearlyResult>("EXEC [SP_RasyoEkonomikRantabilite] @companyID, @nyear", new { nyear = _year, companyID = _compID }).ToList();
    }
    public List<DashYearlyResult> RasyoAnalizIFinalAktifKarT2(int _year, long _compID)
    {//SP_RasyoAktifDevirHiz
        return StaticQuery<DashYearlyResult>("EXEC [SP_RasyoAktifDevirHiz] @companyID, @nyear", new { nyear = _year, companyID = _compID }).ToList();
    }
    public List<DashYearlyResult> RasyoAnalizIFinalAktifKarT3(int _year, long _compID)
    {//SP_RasyoFaizKarsilamaT
        return StaticQuery<DashYearlyResult>("EXEC [SP_RasyoFaizKarsilamaT] @companyID, @nyear", new { nyear = _year, companyID = _compID }).ToList();
    }
    public List<DashYearlyResult> RasyoAnalizIFinalAktifKarT5(int _year, long _compID)
    {//SP_RasyoLikiditeOran
        return StaticQuery<DashYearlyResult>("EXEC [SP_RasyoLikiditeOran] @companyID, @nyear", new { nyear = _year, companyID = _compID }).ToList();
    }

    public List<DashYearlyResult> RasyoAnalizTOTALFinal(int _year, long _compID)
    {
        return StaticQuery<DashYearlyResult>("Select * from TTZDashBoardOran   where CompanyID=@companyID and [Year]=@nyear", new { nyear = _year, companyID = _compID }).ToList();
    }
    public List<DashYearlyResultCRMMain> CRMAnalizTOTAL102(int _year, long _compID)
    {
        string sqlll = @"SELECT TOP (10) 
       [AccountSubID]
      ,[AccountSubDescription]  as Description
      ,SUM([Borc]) as Debit
      ,SUM([Alacak])   as Credit
  FROM [EDEFTERDB].[dbo].[TBLXMLSourceSub] where CsvID in (Select ID from TBLXml where CompanyID=@companyID and Year=@nyear) and AccountMainID='102' group by [AccountSubID]
      ,[AccountSubDescription]  order by SUM(ABS([Borc])) desc";

        return StaticQuery<DashYearlyResultCRMMain>(sqlll, new { nyear = _year, companyID = _compID }).ToList();
    }
    public List<DashYearlyResultCRMMain> CRMAnalizTOTAL102T(int _year, long _compID)
    {
        string sqlll = @"SELECT  
       [AccountSubID]
      ,[AccountSubDescription]  as Description
      ,SUM([Borc]) as Debit
      ,SUM([Alacak])   as Credit
   ,SUM(Amount)   as AmountBakiye
  FROM [EDEFTERDB].[dbo].[TBLXMLSourceSub] where CsvID in (Select ID from TBLXml where CompanyID=@companyID and Year=@nyear) and AccountMainID='102' group by [AccountSubID]
      ,[AccountSubDescription]  order by SUM(ABS([Borc])) desc";

        return StaticQuery<DashYearlyResultCRMMain>(sqlll, new { nyear = _year, companyID = _compID }).ToList();
    }
    public List<DashYearlyResultCRMMain> CRMAnalizTOTAL103T(int _year, long _compID)
    {
        string sqlll = @"SELECT  
       [AccountSubID]
      ,[AccountSubDescription]    as Description
      ,SUM([Borc]) as Debit
      ,SUM([Alacak])   as Credit
   ,SUM(Amount)   as AmountBakiye
  FROM [EDEFTERDB].[dbo].[TBLXMLSourceSub] where CsvID in (Select ID from TBLXml where CompanyID=@companyID and Year=@nyear) and AccountMainID='103' group by [AccountSubID]
      ,[AccountSubDescription]  order by SUM(ABS([Borc])) desc";

        return StaticQuery<DashYearlyResultCRMMain>(sqlll, new { nyear = _year, companyID = _compID }).ToList();
    }
    public List<DashYearlyResultCRMMain> CRMAnalizTOTAL120T(int _year, long _compID)
    {
        string sqlll = @"SELECT  
       [AccountSubID]
      ,[AccountSubDescription]    as Description
      ,SUM([Borc]) as Debit
      ,SUM([Alacak])   as Credit
   ,SUM(Amount)   as AmountBakiye
  FROM [EDEFTERDB].[dbo].[TBLXMLSourceSub] where CsvID in (Select ID from TBLXml where CompanyID=@companyID and Year=@nyear) and AccountMainID='120' group by [AccountSubID]
      ,[AccountSubDescription]  order by SUM(ABS([Borc])) desc";

        return StaticQuery<DashYearlyResultCRMMain>(sqlll, new { nyear = _year, companyID = _compID }).ToList();
    }
    public List<DashYearlyResultCRMMain> CRMAnalizTOTAL320T(int _year, long _compID)
    {
        string sqlll = @"SELECT  
       [AccountSubID]
      ,[AccountSubDescription]    as Description
      ,SUM([Borc]) as Debit
      ,SUM([Alacak])   as Credit
   ,SUM(Amount)   as AmountBakiye
  FROM [EDEFTERDB].[dbo].[TBLXMLSourceSub] where CsvID in (Select ID from TBLXml where CompanyID=@companyID and Year=@nyear) and AccountMainID='320' group by [AccountSubID]
      ,[AccountSubDescription]  order by SUM(ABS([Borc])) desc";

        return StaticQuery<DashYearlyResultCRMMain>(sqlll, new { nyear = _year, companyID = _compID }).ToList();
    }
    public List<DashYearlyResultCRMMain> CRMAnalizTOTAL103(int _year, long _compID)
    {
        string sqlll = @"SELECT TOP (10) 
       [AccountSubID]
      ,[AccountSubDescription]    as Description
      ,SUM([Borc]) as Debit
      ,SUM([Alacak])   as Credit
  FROM [EDEFTERDB].[dbo].[TBLXMLSourceSub] where CsvID in (Select ID from TBLXml where CompanyID=@companyID and Year=@nyear) and AccountMainID='103' group by [AccountSubID]
      ,[AccountSubDescription]  order by SUM(ABS([Borc])) desc";

        return StaticQuery<DashYearlyResultCRMMain>(sqlll, new { nyear = _year, companyID = _compID }).ToList();
    }
    public List<DashYearlyResultCRMMain> CRMAnalizTOTAL101(int _year, long _compID)
    {
        string sqlll = @"SELECT  
       [AccountSubID]
      ,[AccountSubDescription]    as Description
      ,SUM([Borc]) as Debit
      ,SUM([Alacak])   as Credit
   ,SUM(Amount)   as AmountBakiye
  FROM [EDEFTERDB].[dbo].[TBLXMLSourceSub] where CsvID in (Select ID from TBLXml where CompanyID=@companyID and Year=@nyear) and AccountMainID='101' group by [AccountSubID]
      ,[AccountSubDescription]  order by SUM(ABS([Borc])) desc";

        return StaticQuery<DashYearlyResultCRMMain>(sqlll, new { nyear = _year, companyID = _compID }).ToList();
    }
    public List<DashYearlyResultCRMMain> CRMAnalizTOTAL101T(int _year, long _compID)
    {
        string sqlll = @"SELECT TOP (10) 
       [AccountSubID]
      ,[AccountSubDescription]    as Description
      ,SUM([Borc]) as Debit
      ,SUM([Alacak])   as Credit
  FROM [EDEFTERDB].[dbo].[TBLXMLSourceSub] where CsvID in (Select ID from TBLXml where CompanyID=@companyID and Year=@nyear) and AccountMainID='101' group by [AccountSubID]
      ,[AccountSubDescription]  order by SUM(ABS([Borc])) desc";

        return StaticQuery<DashYearlyResultCRMMain>(sqlll, new { nyear = _year, companyID = _compID }).ToList();
    }
    public List<DashYearlyResultCRMMain> CRMAnalizTOTAL120(int _year, long _compID)
    {
        string sqlll = @"SELECT TOP (10) 
       [AccountSubID]
      ,[AccountSubDescription]    as Description
      ,SUM([Borc]) as Debit
      ,SUM([Alacak])   as Credit
  FROM [EDEFTERDB].[dbo].[TBLXMLSourceSub] where CsvID in (Select ID from TBLXml where CompanyID=@companyID and Year=@nyear) and AccountMainID='120' group by [AccountSubID]
      ,[AccountSubDescription]  order by SUM(ABS([Borc])) desc";

        return StaticQuery<DashYearlyResultCRMMain>(sqlll, new { nyear = _year, companyID = _compID }).ToList();
    }


    public List<DashYearlyResultCRMMain> CRMAnalizTOTAL320(int _year, long _compID)
    {
        string sqlll = @"SELECT TOP (10) 
       [AccountSubID]
      ,[AccountSubDescription]    as Description
      ,SUM([Borc]) as Debit
      ,SUM([Alacak])   as Credit
  FROM [EDEFTERDB].[dbo].[TBLXMLSourceSub] where CsvID in (Select ID from TBLXml where CompanyID=@companyID and Year=@nyear) and AccountMainID='320' group by [AccountSubID]
      ,[AccountSubDescription]  order by SUM(ABS([Borc])) desc";

        return StaticQuery<DashYearlyResultCRMMain>(sqlll, new { nyear = _year, companyID = _compID }).ToList();
    }
    
    public   List<DashYearlyResultCRMMain> CRMAnalizTOTAL102Mizan(int _year, long _compID)
    {
        string sqlll = @"SELECT TOP (10) 
       [AccountSubID]
      ,[AccountSubDescription]  as Description
      ,SUM(Debit) as Debit
      ,SUM(Credit)   as Credit
  FROM [EDEFTERDB].[dbo].TBLXMLSourceOneT where   CompanyID=@companyID and Year=@nyear and AccountMainID='102' group by [AccountSubID]
      ,[AccountSubDescription]  order by SUM(ABS(Debit)) desc ";

        return StaticQuery<DashYearlyResultCRMMain>(sqlll, new { nyear = _year, companyID = _compID }).ToList();
    }
    
    
    public   List<DashYearlyResultCRMMain> CRMAnalizTOTAL103Mizan(int _year, long _compID)
    {
        string sqlll = @"SELECT TOP (10) 
       [AccountSubID]
      ,[AccountSubDescription]  as Description
      ,SUM(Debit) as Debit
      ,SUM(Credit)   as Credit
  FROM [EDEFTERDB].[dbo].TBLXMLSourceOneT where   CompanyID=@companyID and Year=@nyear and AccountMainID='103' group by [AccountSubID]
      ,[AccountSubDescription]  order by SUM(ABS(Debit)) desc ";

        return StaticQuery<DashYearlyResultCRMMain>(sqlll, new { nyear = _year, companyID = _compID }).ToList();
    }
    
    
    public   List<DashYearlyResultCRMMain> CRMAnalizTOTAL120Mizan(int _year, long _compID)
    {
        string sqlll = @"SELECT TOP (10) 
       [AccountSubID]
      ,[AccountSubDescription]  as Description
      ,SUM(Debit) as Debit
      ,SUM(Credit)   as Credit
  FROM [EDEFTERDB].[dbo].TBLXMLSourceOneT where   CompanyID=@companyID and Year=@nyear and AccountMainID='120' group by [AccountSubID]
      ,[AccountSubDescription]  order by SUM(ABS(Debit)) desc ";

        return StaticQuery<DashYearlyResultCRMMain>(sqlll, new { nyear = _year, companyID = _compID }).ToList();
    }

    public   List<DashYearlyResultCRMMain> CRMAnalizTOTAL101Mizan(int _year, long _compID)
    {
        string sqlll = @"SELECT TOP (10) 
       [AccountSubID]
      ,[AccountSubDescription]  as Description
      ,SUM(Debit) as Debit
      ,SUM(Credit)   as Credit
  FROM [EDEFTERDB].[dbo].TBLXMLSourceOneT where   CompanyID=@companyID and Year=@nyear and AccountMainID='101' group by [AccountSubID]
      ,[AccountSubDescription]  order by SUM(ABS(Debit)) desc ";

        return StaticQuery<DashYearlyResultCRMMain>(sqlll, new { nyear = _year, companyID = _compID }).ToList();
    }
    
}
