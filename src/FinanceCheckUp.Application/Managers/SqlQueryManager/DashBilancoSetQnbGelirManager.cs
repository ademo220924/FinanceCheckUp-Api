using FinanceCheckUp.Application.Contexts.Concretes.Databases;
using FinanceCheckUp.Application.Models.ViewModel;
using FinanceCheckUp.Framework.Data;
using FinanceCheckUp.Framework.Data.MsSql.Repositories;


namespace FinanceCheckUp.Application.Managers.SqlQueryManager;
public interface IDashBilancoSetQnbGelirManager : IGenericDapperRepository
{
    List<DashBilancoViewQnb> Get_1(int _year, long _compID);
    List<DashBilancoViewQnb> Get_3(int _year, long _compID);
    List<DashBilancoViewQnb> Get_5(int _year, long _compID);
    List<DashBilancoViewQnb> Get_7(int _year, long _compID);
    List<DashBilancoViewQnb> Get_9(int _year, long _compID);
    List<DashBilancoViewQnb> Get_11(int _year, long _compID);

}


public class DashBilancoSetQnbGelirManager(FinanceCheckUpDbContext _dbContext) : GenericDapperRepositoryBase(_dbContext), IDashBilancoSetQnbGelirManager
{
    public List<DashBilancoViewQnb> Get_1(int _year, long _compID)
    {
        return Query<DashBilancoViewQnb>("EXEC [SP_Main_Grow_HeaderQnb] @companyID, @nyear,97", new { nyear = _year, companyID = _compID }).ToList();
    }
    public List<DashBilancoViewQnb> Get_3(int _year, long _compID)
    {
        return Query<DashBilancoViewQnb>("EXEC [SP_Main_Grow_HeaderQnb] @companyID, @nyear,99", new { nyear = _year, companyID = _compID }).ToList();
    }
    public List<DashBilancoViewQnb> Get_5(int _year, long _compID)
    {
        return Query<DashBilancoViewQnb>("EXEC SP_Main_Grow_HeaderQnb @companyID, @nyear,101", new { nyear = _year, companyID = _compID }).ToList();
    }

    public List<DashBilancoViewQnb> Get_7(int _year, long _compID)
    {
        return Query<DashBilancoViewQnb>("EXEC [SP_Main_Grow_HeaderQnb] @companyID, @nyear,103", new { nyear = _year, companyID = _compID }).ToList();
    }
    public List<DashBilancoViewQnb> Get_9(int _year, long _compID)
    {
        return Query<DashBilancoViewQnb>("EXEC [SP_Main_Grow_HeaderQnb] @companyID, @nyear,105", new { nyear = _year, companyID = _compID }).ToList();
    }
    public List<DashBilancoViewQnb> Get_11(int _year, long _compID)
    {
        return Query<DashBilancoViewQnb>("EXEC [SP_Main_Grow_HeaderQnbSatisMaliyet] @companyID, @nyear,107", new { nyear = _year, companyID = _compID }).ToList();
    }
}