using FinanceCheckUp.Application.Contexts.Concretes.Databases;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Framework.Data;
using FinanceCheckUp.Framework.Data.MsSql.Repositories;


namespace FinanceCheckUp.Application.Managers;
public interface IDashWCapitalMizanManager : IGenericDapperRepository
{
    public List<DashBilancoViewMizan> Get_getDataWcap1(int _year, long _compID);
    public List<DashBilancoViewMizan> Get_getDataWcap2(int _year, long _compID);
    public List<DashBilancoViewMizan> Get_getDataWcap3(int _year, long _compID);
    public List<DashBilancoViewMizan> Get_getDataWcap4(int _year, long _compID);
    public List<DashBilancoViewMizan> Get_getDataWcap5(int _year, long _compID);
    public List<DashBilancoViewMizan> Get_getDataWcapUc(int _year, long _compID);
    public List<DashBilancoViewMizan> Get_getDataWcapDort(int _year, long _compID);
    public List<DashBilancoViewMizan> Get_getDataWcapBes(int _year, long _compID);
    public List<DashBilancoViewMizan> Get_getDataWcapM1(int _year, long _compID);
    public List<DashBilancoViewMizan> Get_getDataWcapM2(int _year, long _compID);
    public List<DashBilancoViewMizan> Get_getDataWcapM3(int _year, long _compID);
    public List<DashBilancoViewMizan> Get_getDataWcapM4(int _year, long _compID);
    public List<DashBilancoViewMizan> Get_getDataWcapM5(int _year, long _compID);
    public List<DashBilancoViewMizan> Get_getDataWcapM6(int _year, long _compID);
    public List<DashBilancoViewMizan> Get_getDataWcapM7(int _year, long _compID);
    public List<DashBilancoViewMizan> Get_getDataWcapM8(int _year, long _compID);
    public List<DashBilancoViewMizan> Get_getDataWcapM9(int _year, long _compID);
    public List<DashBilancoViewMizan> Get_getDataWcapWCT(int _year, long _compID);
    public List<DashBilancoViewMizan> Get_getDataWcapFINALMain(long _compID);
}


public class DashWCapitalMizanManager(FinanceCheckUpDbContext _dbContext) : GenericDapperRepositoryBase(_dbContext), IDashWCapitalMizanManager
{
    public List<DashBilancoViewMizan> Get_getDataWcap1(int _year, long _compID)
    {
        return Query<DashBilancoViewMizan>("EXEC SP_Main_Grow_Header__Mizan @companyID, @nyear,10", new { nyear = _year, companyID = _compID }).ToList();
    }
    public List<DashBilancoViewMizan> Get_getDataWcap2(int _year, long _compID)
    {
        return Query<DashBilancoViewMizan>("EXEC SP_Main_Grow_Header__Mizan @companyID, @nyear,11", new { nyear = _year, companyID = _compID }).ToList();
    }
    public List<DashBilancoViewMizan> Get_getDataWcap3(int _year, long _compID)
    {
        return Query<DashBilancoViewMizan>("EXEC SP_Main_Grow_Header__Mizan @companyID, @nyear,12", new { nyear = _year, companyID = _compID }).ToList();
    }
    public List<DashBilancoViewMizan> Get_getDataWcap4(int _year, long _compID)
    {
        return Query<DashBilancoViewMizan>("EXEC SP_Main_Grow_Header__Mizan @companyID, @nyear,13", new { nyear = _year, companyID = _compID }).ToList();
    }
    public List<DashBilancoViewMizan> Get_getDataWcap5(int _year, long _compID)
    {
        return Query<DashBilancoViewMizan>("EXEC SP_Main_Grow_Header__Mizan @companyID, @nyear,15", new { nyear = _year, companyID = _compID }).ToList();
    }
    public List<DashBilancoViewMizan> Get_getDataWcapUc(int _year, long _compID)
    {
        return Query<DashBilancoViewMizan>("EXEC SP_Main_Grow_Header__Mizan @companyID, @nyear,17", new { nyear = _year, companyID = _compID }).ToList();
    }
    public List<DashBilancoViewMizan> Get_getDataWcapDort(int _year, long _compID)
    {
        return Query<DashBilancoViewMizan>("EXEC SP_Main_Grow_Header__Mizan @companyID, @nyear,18", new { nyear = _year, companyID = _compID }).ToList();
    }
    public List<DashBilancoViewMizan> Get_getDataWcapBes(int _year, long _compID)
    {
        return Query<DashBilancoViewMizan>("EXEC SP_Main_Grow_Header__Mizan @companyID, @nyear,19", new { nyear = _year, companyID = _compID }).ToList();
    }
    public List<DashBilancoViewMizan> Get_getDataWcapM1(int _year, long _compID)
    {
        return Query<DashBilancoViewMizan>("EXEC SP_Main_Grow_Header__Mizan @companyID, @nyear,30", new { nyear = _year, companyID = _compID }).ToList();
    }
    public List<DashBilancoViewMizan> Get_getDataWcapM2(int _year, long _compID)
    {
        return Query<DashBilancoViewMizan>("EXEC SP_Main_Grow_Header__Mizan @companyID, @nyear,32", new { nyear = _year, companyID = _compID }).ToList();
    }
    public List<DashBilancoViewMizan> Get_getDataWcapM3(int _year, long _compID)
    {
        return Query<DashBilancoViewMizan>("EXEC SP_Main_Grow_Header__Mizan @companyID, @nyear,33", new { nyear = _year, companyID = _compID }).ToList();
    }
    public List<DashBilancoViewMizan> Get_getDataWcapM4(int _year, long _compID)
    {
        return Query<DashBilancoViewMizan>("EXEC SP_Main_Grow_Header__Mizan @companyID, @nyear,34", new { nyear = _year, companyID = _compID }).ToList();
    }
    public List<DashBilancoViewMizan> Get_getDataWcapM5(int _year, long _compID)
    {
        return Query<DashBilancoViewMizan>("EXEC SP_Main_Grow_Header__Mizan @companyID, @nyear,35", new { nyear = _year, companyID = _compID }).ToList();
    }
    public List<DashBilancoViewMizan> Get_getDataWcapM6(int _year, long _compID)
    {
        return Query<DashBilancoViewMizan>("EXEC SP_Main_Grow_Header__Mizan @companyID, @nyear,36", new { nyear = _year, companyID = _compID }).ToList();
    }
    public List<DashBilancoViewMizan> Get_getDataWcapM7(int _year, long _compID)
    {
        return Query<DashBilancoViewMizan>("EXEC SP_Main_Grow_Header__Mizan @companyID, @nyear,37", new { nyear = _year, companyID = _compID }).ToList();
    }
    public List<DashBilancoViewMizan> Get_getDataWcapM8(int _year, long _compID)
    {
        return Query<DashBilancoViewMizan>("EXEC SP_Main_Grow_Header__Mizan @companyID, @nyear,38", new { nyear = _year, companyID = _compID }).ToList();
    }
    public List<DashBilancoViewMizan> Get_getDataWcapM9(int _year, long _compID)
    {
        return Query<DashBilancoViewMizan>("EXEC SP_Main_Grow_Header__Mizan @companyID, @nyear,39", new { nyear = _year, companyID = _compID }).ToList();
    }

    public List<DashBilancoViewMizan> Get_getDataWcapWCT(int _year, long _compID)
    {
        return Query<DashBilancoViewMizan>("EXEC SP_WCAPITALBYMONTH  @nyear, @companyID", new { nyear = _year, companyID = _compID }).ToList();
    }


    public List<DashBilancoViewMizan> Get_getDataWcapFINALMain(long _compID)
    {
        return Query<DashBilancoViewMizan>("Select * from  TBLWcapitalMZN where CompanyID= @companyID  ", new { companyID = _compID }).ToList();
    }
}