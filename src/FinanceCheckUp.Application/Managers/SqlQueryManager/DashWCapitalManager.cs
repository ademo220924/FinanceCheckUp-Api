using FinanceCheckUp.Application.Contexts.Concretes.Databases;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Framework.Data;
using FinanceCheckUp.Framework.Data.MsSql.Repositories;

namespace FinanceCheckUp.Application.Managers.SqlQueryManager
{
    public interface IDashWCapitalManager : IGenericDapperRepository
    {
        public List<DashBilancoView> Get_getDataWcap1(int _year, long _compID);
        public List<DashBilancoView> Get_getDataWcap2(int _year, long _compID);
        public List<DashBilancoView> Get_getDataWcap3(int _year, long _compID);
        public List<DashBilancoView> Get_getDataWcap4(int _year, long _compID);
        public List<DashBilancoView> Get_getDataWcap5(int _year, long _compID);
        public List<DashBilancoView> Get_getDataWcapUc(int _year, long _compID);
        public List<DashBilancoView> Get_getDataWcapDort(int _year, long _compID);
        public List<DashBilancoView> Get_getDataWcapBes(int _year, long _compID);
        public List<DashBilancoView> Get_getDataWcapM1(int _year, long _compID);
        public List<DashBilancoView> Get_getDataWcapM2(int _year, long _compID);
        public List<DashBilancoView> Get_getDataWcapM3(int _year, long _compID);
        public List<DashBilancoView> Get_getDataWcapM4(int _year, long _compID);
        public List<DashBilancoView> Get_getDataWcapM5(int _year, long _compID);
        public List<DashBilancoView> Get_getDataWcapM6(int _year, long _compID);
        public List<DashBilancoView> Get_getDataWcapM7(int _year, long _compID);
        public List<DashBilancoView> Get_getDataWcapM8(int _year, long _compID);
        public List<DashBilancoView> Get_getDataWcapM9(int _year, long _compID);
        public List<DashBilancoView> Get_getDataWcapWCT(int _year, long _compID);
        public List<DashBilancoView> Get_getDataWcapFINAL(int _year, long _compID);
    }


    public class DashWCapitalManager(FinanceCheckUpDbContext _dbContext) : GenericDapperRepositoryBase(_dbContext), IDashWCapitalManager
    {
        public List<DashBilancoView> Get_getDataWcap1(int _year, long _compID)
        {
            return Query<DashBilancoView>("EXEC SP_Main_Grow_Header @companyID, @nyear,10", new { nyear = _year, companyID = _compID }).ToList();
        }
        public List<DashBilancoView> Get_getDataWcap2(int _year, long _compID)
        {
            return Query<DashBilancoView>("EXEC SP_Main_Grow_Header @companyID, @nyear,11", new { nyear = _year, companyID = _compID }).ToList();
        }
        public List<DashBilancoView> Get_getDataWcap3(int _year, long _compID)
        {
            return Query<DashBilancoView>("EXEC SP_Main_Grow_Header @companyID, @nyear,12", new { nyear = _year, companyID = _compID }).ToList();
        }
        public List<DashBilancoView> Get_getDataWcap4(int _year, long _compID)
        {
            return Query<DashBilancoView>("EXEC SP_Main_Grow_Header @companyID, @nyear,13", new { nyear = _year, companyID = _compID }).ToList();
        }
        public List<DashBilancoView> Get_getDataWcap5(int _year, long _compID)
        {
            return Query<DashBilancoView>("EXEC SP_Main_Grow_Header @companyID, @nyear,15", new { nyear = _year, companyID = _compID }).ToList();
        }
        public List<DashBilancoView> Get_getDataWcapUc(int _year, long _compID)
        {
            return Query<DashBilancoView>("EXEC SP_Main_Grow_Header @companyID, @nyear,17", new { nyear = _year, companyID = _compID }).ToList();
        }
        public List<DashBilancoView> Get_getDataWcapDort(int _year, long _compID)
        {
            return Query<DashBilancoView>("EXEC SP_Main_Grow_Header @companyID, @nyear,18", new { nyear = _year, companyID = _compID }).ToList();
        }
        public List<DashBilancoView> Get_getDataWcapBes(int _year, long _compID)
        {
            return Query<DashBilancoView>("EXEC SP_Main_Grow_Header @companyID, @nyear,19", new { nyear = _year, companyID = _compID }).ToList();
        }
        public List<DashBilancoView> Get_getDataWcapM1(int _year, long _compID)
        {
            return Query<DashBilancoView>("EXEC SP_Main_Grow_Header @companyID, @nyear,30", new { nyear = _year, companyID = _compID }).ToList();
        }
        public List<DashBilancoView> Get_getDataWcapM2(int _year, long _compID)
        {
            return Query<DashBilancoView>("EXEC SP_Main_Grow_Header @companyID, @nyear,32", new { nyear = _year, companyID = _compID }).ToList();
        }
        public List<DashBilancoView> Get_getDataWcapM3(int _year, long _compID)
        {
            return Query<DashBilancoView>("EXEC SP_Main_Grow_Header @companyID, @nyear,33", new { nyear = _year, companyID = _compID }).ToList();
        }
        public List<DashBilancoView> Get_getDataWcapM4(int _year, long _compID)
        {
            return Query<DashBilancoView>("EXEC SP_Main_Grow_Header @companyID, @nyear,34", new { nyear = _year, companyID = _compID }).ToList();
        }
        public List<DashBilancoView> Get_getDataWcapM5(int _year, long _compID)
        {
            return Query<DashBilancoView>("EXEC SP_Main_Grow_Header @companyID, @nyear,35", new { nyear = _year, companyID = _compID }).ToList();
        }
        public List<DashBilancoView> Get_getDataWcapM6(int _year, long _compID)
        {
            return Query<DashBilancoView>("EXEC SP_Main_Grow_Header @companyID, @nyear,36", new { nyear = _year, companyID = _compID }).ToList();
        }
        public List<DashBilancoView> Get_getDataWcapM7(int _year, long _compID)
        {
            return Query<DashBilancoView>("EXEC SP_Main_Grow_Header @companyID, @nyear,37", new { nyear = _year, companyID = _compID }).ToList();
        }
        public List<DashBilancoView> Get_getDataWcapM8(int _year, long _compID)
        {
            return Query<DashBilancoView>("EXEC SP_Main_Grow_Header @companyID, @nyear,38", new { nyear = _year, companyID = _compID }).ToList();
        }
        public List<DashBilancoView> Get_getDataWcapM9(int _year, long _compID)
        {
            return Query<DashBilancoView>("EXEC SP_Main_Grow_Header @companyID, @nyear,39", new { nyear = _year, companyID = _compID }).ToList();
        }

        public List<DashBilancoView> Get_getDataWcapWCT(int _year, long _compID)
        {
            return Query<DashBilancoView>("EXEC SP_WCAPITALBYMONTH  @nyear, @companyID", new { nyear = _year, companyID = _compID }).ToList();
        }

        public List<DashBilancoView> Get_getDataWcapFINAL(int _year, long _compID)
        {
            return Query<DashBilancoView>("Select * from  TBLWcapital where CompanyID= @companyID and Year=@nyear", new { nyear = _year, companyID = _compID }).ToList();
        }
    }
}
