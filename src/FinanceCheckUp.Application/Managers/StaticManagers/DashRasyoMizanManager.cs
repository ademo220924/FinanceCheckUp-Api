using FinanceCheckUp.Application.Contexts.Concretes.Databases;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Framework.Data;
using FinanceCheckUp.Framework.Data.MsSql.Repositories;

namespace FinanceCheckUp.Application.Managers.StaticManagers;

public interface IDashRasyoMizanManager : IGenericDapperRepository
{
    public bool GetDashLikiditeRiskTrend(int _year, long _compID);
    public bool GetDashOzetMali(int _year, long _compID);

    public bool GetDashOzetMaliByn(int _year, long _compID);
    public bool GetDashRasyoAnaliz(int _year, long _compID);
}



public class DashRasyoMizanManager
    (
    FinanceCheckUpDbContext _dbContext,
    IDashLikiditeRiskTrendMizanManager dashLikiditeRiskTrendMizanManager,
    IDashOzetMaliMizanManager dashOzetMaliMizanManager,
    IRasyoAnalizMainMizanManager rasyoAnalizMainMizanManager
    )
    : GenericDapperRepositoryBase(_dbContext), IDashRasyoMizanManager
{
    public bool GetDashLikiditeRiskTrend(int _year, long _compID)
    {

        dashLikiditeRiskTrendMizanManager.LikiditeRiskTrend21(_year, _compID);
        return true;
    }

    public bool GetDashOzetMali(int _year, long _compID)
    {

        dashOzetMaliMizanManager.OzetMali8(_year, _compID);


        return true;
    }

    public bool GetDashOzetMaliByn(int _year, long _compID)
    {

        dashOzetMaliMizanManager.OzetMali8Byn(_year, _compID);


        return true;
    }

    public bool GetDashRasyoAnaliz(int _year, long _compID)
    {

        rasyoAnalizMainMizanManager.RasyoAnalizBFinalM(_year, _compID);
        rasyoAnalizMainMizanManager.RasyoAnalizCFinalM(_year, _compID);
        rasyoAnalizMainMizanManager.RasyoAnalizDFinal(_year, _compID);
        rasyoAnalizMainMizanManager.RasyoAnalizEFinal(_year, _compID);
        rasyoAnalizMainMizanManager.RasyoAnalizFFinal(_year, _compID);
        rasyoAnalizMainMizanManager.RasyoAnalizGFinal(_year, _compID);
        rasyoAnalizMainMizanManager.RasyoAnalizHFinal(_year, _compID);
        rasyoAnalizMainMizanManager.RasyoAnalizH1Final(_year, _compID);
        //RasyoAnalizMaMizanin.RasyoAnalizIFinal(_year, _compID);
        rasyoAnalizMainMizanManager.RasyoAnalizIFinalT(_year, _compID);
        rasyoAnalizMainMizanManager.RasyoAnalizIFinalKarT(_year, _compID);
        rasyoAnalizMainMizanManager.RasyoAnalizIFinalAktifKarT(_year, _compID);
        rasyoAnalizMainMizanManager.RasyoAnalizIFinalAktifKarT1(_year, _compID);
        rasyoAnalizMainMizanManager.RasyoAnalizIFinalAktifKarT2(_year, _compID);
        rasyoAnalizMainMizanManager.RasyoAnalizIFinalAktifKarT3(_year, _compID);
        rasyoAnalizMainMizanManager.RasyoAnalizIFinalAktifKarT5(_year, _compID);
        return true;
    }
}