using FinanceCheckUp.Application.Contexts.Concretes.Databases;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Framework.Data;
using FinanceCheckUp.Framework.Data.MsSql.Repositories;


namespace FinanceCheckUp.Application.Managers.SqlQueryManager;
public interface IRasyoAnalizMainMizanManager : IGenericDapperRepository
{
    public List<DashYearlyResultMizan> RasyoAnalizBFinalM(int _year, long _compID);
    public List<DashYearlyResultMizan> RasyoAnalizCFinalM(int _year, long _compID);
    public List<DashYearlyResultMizan> RasyoAnalizDFinal(int _year, long _compID);
    public List<DashYearlyResultMizan> RasyoAnalizEFinal(int _year, long _compID);
    public List<DashYearlyResultMizan> RasyoAnalizFFinal(int _year, long _compID);
    public List<DashYearlyResultMizan> RasyoAnalizGFinal(int _year, long _compID);
    public List<DashYearlyResultMizan> RasyoAnalizHFinal(int _year, long _compID);
    public List<DashYearlyResultMizan> RasyoAnalizH1Final(int _year, long _compID);
    public List<DashYearlyResultMizan> RasyoAnalizIFinalT(int _year, long _compID);
    public List<DashYearlyResultMizan> RasyoAnalizIFinalKarT(int _year, long _compID);
    public List<DashYearlyResultMizan> RasyoAnalizIFinalAktifKarT(int _year, long _compID);
    public List<DashYearlyResultMizan> RasyoAnalizIFinalAktifKarT1(int _year, long _compID);
    public List<DashYearlyResultMizan> RasyoAnalizIFinalAktifKarT2(int _year, long _compID);
    public List<DashYearlyResultMizan> RasyoAnalizIFinalAktifKarT3(int _year, long _compID);
    public List<DashYearlyResultMizan> RasyoAnalizIFinalAktifKarT5(int _year, long _compID);
    public List<DashYearlyResultMizan> RasyoAnalizTOTALFinal(int _year, long _compID);
}


public class RasyoAnalizMainMizanManager(FinanceCheckUpDbContext _dbContext) : GenericDapperRepositoryBase(_dbContext), IRasyoAnalizMainMizanManager
{
    public List<DashYearlyResultMizan> RasyoAnalizBFinalM(int _year, long _compID)
    { //SP_RasyoFinansalBorclar


        return StaticQuery<DashYearlyResultMizan>("EXEC SP_RasyoFinansalBorclarMZN @companyID, @nyear", new { nyear = _year, companyID = _compID }).ToList();
    }


    public List<DashYearlyResultMizan> RasyoAnalizCFinalM(int _year, long _compID)
    {//SP_RasyoFinansalKaldirac
        return StaticQuery<DashYearlyResultMizan>("EXEC SP_RasyoFinansalKaldiracMZN @companyID, @nyear", new { nyear = _year, companyID = _compID }).ToList();
    }

    public List<DashYearlyResultMizan> RasyoAnalizDFinal(int _year, long _compID)
    {//SP_RasyoKisaVadeliBorclar
        return StaticQuery<DashYearlyResultMizan>("EXEC SP_RasyoKisaVadeliBorclarMZN @companyID, @nyear", new { nyear = _year, companyID = _compID }).ToList();
    }


    public List<DashYearlyResultMizan> RasyoAnalizEFinal(int _year, long _compID)
    {//SP_RasyoLikiditeOran
        return StaticQuery<DashYearlyResultMizan>("EXEC  SP_RasyoLikiditeOranMZN  @companyID, @nyear", new { nyear = _year, companyID = _compID }).ToList();
    }

    public List<DashYearlyResultMizan> RasyoAnalizFFinal(int _year, long _compID)
    {//SP_RasyoDuranVarlkOzSermye
        return StaticQuery<DashYearlyResultMizan>("EXEC SP_RasyoDuranVarlkOzSermyeMZN @companyID, @nyear", new { nyear = _year, companyID = _compID }).ToList();
    }

    public List<DashYearlyResultMizan> RasyoAnalizGFinal(int _year, long _compID)
    {//SP_RasyoNakiOran
        return StaticQuery<DashYearlyResultMizan>("EXEC SP_RasyoNakiOranMZN @companyID, @nyear", new { nyear = _year, companyID = _compID }).ToList();
    }

    public List<DashYearlyResultMizan> RasyoAnalizHFinal(int _year, long _compID)
    {//SP_RasyoIsltmeSermyeAktif
        return StaticQuery<DashYearlyResultMizan>("EXEC SP_RasyoIsltmeSermyeAktifMZN @companyID, @nyear", new { nyear = _year, companyID = _compID }).ToList();
    }
    public List<DashYearlyResultMizan> RasyoAnalizH1Final(int _year, long _compID)
    {//SP_RasyoCari
        return StaticQuery<DashYearlyResultMizan>("EXEC SP_RasyoCariMZN @companyID, @nyear", new { nyear = _year, companyID = _compID }).ToList();
    }
    // return StaticQuery<DashBilancoView>("EXEC MainZZCariOranTM @companyID, @nyear", new { nyear = _year, companyID = _compID }).FirstOrDefault();
    //public  List<DashYearlyResultMizan> RasyoAnalizIFinal(int _year, long _compID)
    //{//SP_RasyoSermOzSermyeOran
    //    return StaticQuery<DashYearlyResultMizan>("EXEC SP_RasyoSermOzSermyeOran @companyID, @nyear", new { nyear = _year, companyID = _compID }).ToList();
    //}
    public List<DashYearlyResultMizan> RasyoAnalizIFinalT(int _year, long _compID)
    {//SP_RasyoOzsermayeDevirHizi
        return StaticQuery<DashYearlyResultMizan>("EXEC [SP_RasyoOzsermayeDevirHiziMZN] @companyID, @nyear", new { nyear = _year, companyID = _compID }).ToList();
    }
    public List<DashYearlyResultMizan> RasyoAnalizIFinalKarT(int _year, long _compID)
    {//SP_RasyoOzsermayeKarlilikT
        return StaticQuery<DashYearlyResultMizan>("EXEC [SP_RasyoOzsermayeKarlilikTMZN] @companyID, @nyear", new { nyear = _year, companyID = _compID }).ToList();
    }
    public List<DashYearlyResultMizan> RasyoAnalizIFinalAktifKarT(int _year, long _compID)
    {//SP_RasyoAktifKarlilik
        return StaticQuery<DashYearlyResultMizan>("EXEC [SP_RasyoAktifKarlilikMZN] @companyID, @nyear", new { nyear = _year, companyID = _compID }).ToList();
    }
    public List<DashYearlyResultMizan> RasyoAnalizIFinalAktifKarT1(int _year, long _compID)
    {//SP_RasyoEkonomikRantabilite
        return StaticQuery<DashYearlyResultMizan>("EXEC [SP_RasyoEkonomikRantabiliteMZN] @companyID, @nyear", new { nyear = _year, companyID = _compID }).ToList();
    }
    public List<DashYearlyResultMizan> RasyoAnalizIFinalAktifKarT2(int _year, long _compID)
    {//SP_RasyoAktifDevirHiz
        return StaticQuery<DashYearlyResultMizan>("EXEC [SP_RasyoAktifDevirHizMZN] @companyID, @nyear", new { nyear = _year, companyID = _compID }).ToList();
    }
    public List<DashYearlyResultMizan> RasyoAnalizIFinalAktifKarT3(int _year, long _compID)
    {//SP_RasyoFaizKarsilamaT
        return StaticQuery<DashYearlyResultMizan>("EXEC [SP_RasyoFaizKarsilamaTMZN] @companyID, @nyear", new { nyear = _year, companyID = _compID }).ToList();
    }
    public List<DashYearlyResultMizan> RasyoAnalizIFinalAktifKarT5(int _year, long _compID)
    {//SP_RasyoLikiditeOran
        return StaticQuery<DashYearlyResultMizan>("EXEC [SP_RasyoLikiditeOranMZN] @companyID, @nyear", new { nyear = _year, companyID = _compID }).ToList();
    }

    public List<DashYearlyResultMizan> RasyoAnalizTOTALFinal(int _year, long _compID)
    {
        return StaticQuery<DashYearlyResultMizan>("Select * from TTZDashBoardOranMzn   where CompanyID=@companyID  ", new { nyear = _year, companyID = _compID }).ToList();
    }
}