using FinanceCheckUp.Application.Contexts.Concretes.Databases;
using FinanceCheckUp.Framework.Data;
using FinanceCheckUp.Framework.Data.MsSql.Repositories;

namespace FinanceCheckUp.Application.Managers.SqlQueryManager;
public interface IReportSetMainAktarmaSqlOperationManager : IGenericDapperRepository
{

    string Set_ReportStartAktarma(int _year, long _compID, List<int> typelist);
    int Set_ReportSetfirst(int _year, long _compID);
    int Set_ReportSet001(int _year, long _compID);
    int Set_ReportSet141(int _year, long _compID);

    int Set_ReportSet1(int _year, long _compID);
    int Set_ReportSet2(int _year, long _compID);
    int Set_ReportSet3(int _year, long _compID);
    int Set_ReportSet4(int _year, long _compID);

    int Set_ReportSet41(int _year, long _compID);
    int Set_ReportSet5(int _year, long _compID);
    int Set_ReportSet7(int _year, long _compID);
    int Set_ReportSet8(int _year, long _compID);

    int Set_ReportSet9(int _year, long _compID);
    int Set_ReportSet91(int _year, long _compID);
    int Set_ReportSet93(int _year, long _compID);


}


public class ReportSetMainAktarmaSqlOperationManager(FinanceCheckUpDbContext _dbContext) : GenericDapperRepositoryBase(_dbContext), IReportSetMainAktarmaSqlOperationManager
{
    public string Set_ReportStartAktarma(int _year, long _compID, List<int> typelist)
    {

        if (typelist.Contains(1))
        {
            Set_ReportSet1(_year, _compID);
        }

        if (typelist.Contains(2))
        {
            Set_ReportSet2(_year, _compID);
        }

        if (typelist.Contains(3))
        {
            Set_ReportSet3(_year, _compID);
        }

        if (typelist.Contains(4))
        {
            Set_ReportSet4(_year, _compID);
        }

        if (typelist.Contains(41))
        {
            Set_ReportSet41(_year, _compID);
        }

        if (typelist.Contains(5))
        {
            Set_ReportSet5(_year, _compID);
        }


        if (typelist.Contains(7))
        {
            Set_ReportSet7(_year, _compID);
        }

        if (typelist.Contains(8))
        {
            Set_ReportSet8(_year, _compID);
        }

        if (typelist.Contains(9))
        {
            Set_ReportSet9(_year, _compID);
        }

        if (typelist.Contains(91))
        {
            Set_ReportSet91(_year, _compID);
        }

        if (typelist.Contains(93))
        {
            Set_ReportSet93(_year, _compID);
        }

        if (typelist.Contains(51))
        {
            Set_ReportSet001(_year, _compID);
        }

        if (typelist.Contains(141))
        {
            Set_ReportSet141(_year, _compID);
        }
        return "ok";
    }


    public int Set_ReportSetfirst(int _year, long _compID)
    {
        try
        {
            return Query<int>("EXEC SPAKT_PROCT000First @companyID, @nyear", new { nyear = _year, companyID = _compID }).FirstOrDefault();
        }
        catch (Exception ex)
        {
            var chk = ex;
            throw;
        }
    }
    public int Set_ReportSet001(int _year, long _compID)
    {
        try
        {
            return Query<int>("EXEC SPAKT_PROCT001 @companyID, @nyear", new { nyear = _year, companyID = _compID }).FirstOrDefault();
        }
        catch (Exception ex)
        {
            var chk = ex;
            throw;
        }
    }
    public int Set_ReportSet141(int _year, long _compID)
    {
        try
        {
            return Query<int>("EXEC [SPAKT_PROCT51] @companyID, @nyear", new { nyear = _year, companyID = _compID }).FirstOrDefault();
        }
        catch (Exception ex)
        {
            var chk = ex;
            throw;
        }
    }
    public int Set_ReportSet1(int _year, long _compID)
    {
        try
        { return Query<int>("EXEC SPAKT_PROCT1 @companyID, @nyear", new { nyear = _year, companyID = _compID }).FirstOrDefault(); }
        catch (Exception ex)
        {
            var chk = ex;
            throw;
        }
    }
    public int Set_ReportSet2(int _year, long _compID)
    {
        try
        { return Query<int>("EXEC SPAKT_PROCT2 @companyID, @nyear", new { nyear = _year, companyID = _compID }).FirstOrDefault(); }
        catch (Exception ex)
        {
            var chk = ex;
            throw;
        }
    }
    public int Set_ReportSet3(int _year, long _compID)
    {
        try
        { return Query<int>("EXEC SPAKT_PROCT3 @companyID, @nyear", new { nyear = _year, companyID = _compID }).FirstOrDefault(); }
        catch (Exception ex)
        {
            var chk = ex;
            throw;
        }
    }
    public int Set_ReportSet4(int _year, long _compID)
    {
        try
        { return Query<int>("EXEC SPAKT_PROCT4 @companyID, @nyear", new { nyear = _year, companyID = _compID }).FirstOrDefault(); }
        catch (Exception ex)
        {
            var chk = ex;
            throw;
        }
    }
    public int Set_ReportSet41(int _year, long _compID)
    {
        try
        { return Query<int>("EXEC SPAKT_PROCT41 @companyID, @nyear", new { nyear = _year, companyID = _compID }).FirstOrDefault(); }
        catch (Exception ex)
        {
            var chk = ex;
            throw;
        }
    }
    public int Set_ReportSet5(int _year, long _compID)
    {
        try
        { return Query<int>("EXEC SPAKT_PROCT5 @companyID, @nyear", new { nyear = _year, companyID = _compID }).FirstOrDefault(); }
        catch (Exception ex)
        {
            var chk = ex;
            throw;
        }
    }
    public int Set_ReportSet7(int _year, long _compID)
    {
        try
        { return Query<int>("EXEC SPAKT_PROCT7 @companyID, @nyear", new { nyear = _year, companyID = _compID }).FirstOrDefault(); }
        catch (Exception ex)
        {
            var chk = ex;
            throw;
        }
    }
    public int Set_ReportSet8(int _year, long _compID)
    {
        try
        { return Query<int>("EXEC SPAKT_PROCT8 @companyID, @nyear", new { nyear = _year, companyID = _compID }).FirstOrDefault(); }
        catch (Exception ex)
        {
            var chk = ex;
            throw;
        }
    }
    public int Set_ReportSet9(int _year, long _compID)
    {
        try
        { return Query<int>("EXEC SPAKT_PROCT9 @companyID, @nyear", new { nyear = _year, companyID = _compID }).FirstOrDefault(); }
        catch (Exception ex)
        {
            var chk = ex;
            throw;
        }
    }
    public int Set_ReportSet91(int _year, long _compID)
    {
        try
        { return Query<int>("EXEC SPAKT_PROCT91 @companyID, @nyear", new { nyear = _year, companyID = _compID }).FirstOrDefault(); }
        catch (Exception ex)
        {
            var chk = ex;
            throw;
        }
    }
    public int Set_ReportSet93(int _year, long _compID)
    {
        try
        { return Query<int>("EXEC SPAKT_PROCT93 @companyID, @nyear", new { nyear = _year, companyID = _compID }).FirstOrDefault(); }
        catch (Exception ex)
        {
            var chk = ex;
            throw;
        }
    }
}