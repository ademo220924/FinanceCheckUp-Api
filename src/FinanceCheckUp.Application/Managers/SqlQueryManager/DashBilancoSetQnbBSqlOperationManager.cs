using FinanceCheckUp.Application.Contexts.Concretes.Databases;
using FinanceCheckUp.Application.Models.ViewModel;
using FinanceCheckUp.Framework.Data;
using FinanceCheckUp.Framework.Data.MsSql.Repositories;

namespace FinanceCheckUp.Application.Managers.SqlQueryManager;
public interface IDashBilancoSetQnbBSqlOperationManager : IGenericDapperRepository
{
    List<DashBilancoViewQnb> Get_1(int _year, long _compID);
    List<DashBilancoViewQnb> Get_2(int _year, long _compID);
    List<DashBilancoViewQnb> Get_3(int _year, long _compID);
    List<DashBilancoViewQnb> Get_4(int _year, long _compID);
    List<DashBilancoViewQnb> Get_5(int _year, long _compID);
    List<DashBilancoViewQnb> Get_6(int _year, long _compID);
    List<DashBilancoViewQnb> Get_7(int _year, long _compID);
    List<DashBilancoViewQnb> Get_8(int _year, long _compID);
    List<DashBilancoViewQnb> Get_9(int _year, long _compID);
    List<DashBilancoViewQnb> Get_10(int _year, long _compID);
    List<DashBilancoViewQnb> Get_11(int _year, long _compID);
    List<DashBilancoViewQnb> Get_12(int _year, long _compID);
    List<DashBilancoViewQnb> Get_13(int _year, long _compID);
    List<DashBilancoViewQnb> Get_Toplam(int _year, long _compID);

}


public class DashBilancoSetQnbBSqlOperationManager(FinanceCheckUpDbContext _dbContext) : GenericDapperRepositoryBase(_dbContext), IDashBilancoSetQnbBSqlOperationManager
{
    public List<DashBilancoViewQnb> Get_1(int _year, long _compID)
    {
        return StaticQuery<DashBilancoViewQnb>("EXEC [SP_Main_Grow_HeaderQnb] @companyID, @nyear,49", new { nyear = _year, companyID = _compID }).ToList();
    }
    public List<DashBilancoViewQnb> Get_2(int _year, long _compID)
    {
        return StaticQuery<DashBilancoViewQnb>("EXEC [SP_Main_Grow_HeaderQnb] @companyID, @nyear,51", new { nyear = _year, companyID = _compID }).ToList();
    }
    public List<DashBilancoViewQnb> Get_3(int _year, long _compID)
    {
        return StaticQuery<DashBilancoViewQnb>("EXEC SP_Main_Grow_HeaderQnb @companyID, @nyear,53", new { nyear = _year, companyID = _compID }).ToList();
    }

    public List<DashBilancoViewQnb> Get_4(int _year, long _compID)
    {
        return StaticQuery<DashBilancoViewQnb>("EXEC [SP_Main_Grow_HeaderQnb] @companyID, @nyear,55", new { nyear = _year, companyID = _compID }).ToList();
    }
    public List<DashBilancoViewQnb> Get_5(int _year, long _compID)
    {
        return StaticQuery<DashBilancoViewQnb>("EXEC [SP_Main_Grow_HeaderQnb] @companyID, @nyear,57", new { nyear = _year, companyID = _compID }).ToList();
    }
    public List<DashBilancoViewQnb> Get_6(int _year, long _compID)
    {
        return StaticQuery<DashBilancoViewQnb>("EXEC SP_Main_Grow_HeaderQnb @companyID, @nyear,59", new { nyear = _year, companyID = _compID }).ToList();
    }
    public List<DashBilancoViewQnb> Get_7(int _year, long _compID)
    {
        return StaticQuery<DashBilancoViewQnb>("EXEC SP_Main_Grow_HeaderQnb @companyID, @nyear,61", new { nyear = _year, companyID = _compID }).ToList();
    }
    public List<DashBilancoViewQnb> Get_8(int _year, long _compID)
    {
        return StaticQuery<DashBilancoViewQnb>("EXEC [SP_Main_Grow_HeaderQnb] @companyID, @nyear,63", new { nyear = _year, companyID = _compID }).ToList();
    }
    public List<DashBilancoViewQnb> Get_9(int _year, long _compID)
    {
        return StaticQuery<DashBilancoViewQnb>("EXEC [SP_Main_Grow_HeaderQnb] @companyID, @nyear,65", new { nyear = _year, companyID = _compID }).ToList();
    }
    public List<DashBilancoViewQnb> Get_10(int _year, long _compID)
    {
        return StaticQuery<DashBilancoViewQnb>("EXEC SP_Main_Grow_HeaderQnb @companyID, @nyear,67", new { nyear = _year, companyID = _compID }).ToList();
    }

    public List<DashBilancoViewQnb> Get_11(int _year, long _compID)
    {
        return StaticQuery<DashBilancoViewQnb>("EXEC [SP_Main_Grow_HeaderQnb] @companyID, @nyear,69", new { nyear = _year, companyID = _compID }).ToList();
    }
    public List<DashBilancoViewQnb> Get_12(int _year, long _compID)
    {
        return StaticQuery<DashBilancoViewQnb>("EXEC [SP_Main_Grow_HeaderQnb] @companyID, @nyear,71", new { nyear = _year, companyID = _compID }).ToList();
    }
    public List<DashBilancoViewQnb> Get_13(int _year, long _compID)
    {
        return StaticQuery<DashBilancoViewQnb>("EXEC [SP_Main_Grow_HeaderQnb] @companyID, @nyear,711", new { nyear = _year, companyID = _compID }).ToList();
    }
    public List<DashBilancoViewQnb> Get_Toplam(int _year, long _compID)
    {
        List<DashBilancoViewQnb> nnnn = StaticQuery<DashBilancoViewQnb>("EXEC SP_Main_Grow_HeaderQnbSubType @companyID, @nyear,3", new { nyear = _year, companyID = _compID }).ToList();


        if (nnnn == null)
        {
            nnnn = new List<DashBilancoViewQnb>();
            DashBilancoViewQnb ll = new DashBilancoViewQnb();
            nnnn.Add(ll);
        }

        return nnnn;
    }

}