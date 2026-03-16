using FinanceCheckUp.Application.Contexts.Concretes.Databases;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Framework.Data;
using FinanceCheckUp.Framework.Data.MsSql.Repositories;

namespace FinanceCheckUp.Application.Managers.StaticManagers;

public interface IDashRasyoManager : IGenericDapperRepository
{
    public bool GetDashLikiditeRiskTrend(int _year, long _compID);
    public bool GetDashOzetMali(int _year, long _compID, int monthid_);
    public bool GetDashRasyoAnalizBeyanname(int _year, long _compID);
    public bool GetDashRasyoAnaliz(int _year, long _compID);


}

public class DashRasyoManager(
    FinanceCheckUpDbContext _dbContext,
    IDashLikiditeRiskTrendManager dashLikiditeRiskTrendManager,
    IDashOzetMaliManager dashOzetMaliManager,
    IRasyoAnalizMainManager rasyoAnalizMainManager) : GenericDapperRepositoryBase(_dbContext), IDashRasyoManager
{
    public bool GetDashLikiditeRiskTrend(int _year, long _compID)
    {

        dashLikiditeRiskTrendManager.LikiditeRiskTrend21(_year, _compID);
        return true;
    }

    public bool GetDashOzetMali(int _year, long _compID, int monthid_)
    {

        dashOzetMaliManager.OzetMali8(_year, _compID);

        return true;
    }

    public bool GetDashRasyoAnalizBeyanname(int _year, long _compID)
    {

        rasyoAnalizMainManager.RasyoAnalizBFinalMBeyanname(_year, _compID);

        rasyoAnalizMainManager.RasyoAnalizCFinalM(_year, _compID);
        rasyoAnalizMainManager.RasyoAnalizDFinal(_year, _compID);

        rasyoAnalizMainManager.RasyoAnalizEFinal(_year, _compID);

        rasyoAnalizMainManager.RasyoAnalizFFinal(_year, _compID);

        rasyoAnalizMainManager.RasyoAnalizGFinal(_year, _compID);
        rasyoAnalizMainManager.RasyoAnalizHFinal(_year, _compID);
        rasyoAnalizMainManager.RasyoAnalizH1Final(_year, _compID);
        //rasyoAnalizMainManager.RasyoAnalizIFinal(_year, _compID);
        rasyoAnalizMainManager.RasyoAnalizIFinalT(_year, _compID);
        rasyoAnalizMainManager.RasyoAnalizIFinalKarT(_year, _compID);
        rasyoAnalizMainManager.RasyoAnalizIFinalAktifKarT(_year, _compID);
        rasyoAnalizMainManager.RasyoAnalizIFinalAktifKarT1(_year, _compID);
        rasyoAnalizMainManager.RasyoAnalizIFinalAktifKarT2(_year, _compID);
        rasyoAnalizMainManager.RasyoAnalizIFinalAktifKarT3(_year, _compID);
        rasyoAnalizMainManager.RasyoAnalizIFinalAktifKarT5(_year, _compID);



        return true;
    }
    public bool GetDashRasyoAnaliz(int _year, long _compID)
    {

        rasyoAnalizMainManager.RasyoAnalizBFinalM(_year, _compID);

        rasyoAnalizMainManager.RasyoAnalizCFinalM(_year, _compID);
        rasyoAnalizMainManager.RasyoAnalizDFinal(_year, _compID);

        rasyoAnalizMainManager.RasyoAnalizEFinal(_year, _compID);

        rasyoAnalizMainManager.RasyoAnalizFFinal(_year, _compID);

        rasyoAnalizMainManager.RasyoAnalizGFinal(_year, _compID);
        rasyoAnalizMainManager.RasyoAnalizHFinal(_year, _compID);
        rasyoAnalizMainManager.RasyoAnalizH1Final(_year, _compID);
        //rasyoAnalizMainManager.RasyoAnalizIFinal(_year, _compID);
        rasyoAnalizMainManager.RasyoAnalizIFinalT(_year, _compID);
        rasyoAnalizMainManager.RasyoAnalizIFinalKarT(_year, _compID);
        rasyoAnalizMainManager.RasyoAnalizIFinalAktifKarT(_year, _compID);
        rasyoAnalizMainManager.RasyoAnalizIFinalAktifKarT1(_year, _compID);
        rasyoAnalizMainManager.RasyoAnalizIFinalAktifKarT2(_year, _compID);
        rasyoAnalizMainManager.RasyoAnalizIFinalAktifKarT3(_year, _compID);
        rasyoAnalizMainManager.RasyoAnalizIFinalAktifKarT5(_year, _compID);



        return true;
    }

}
