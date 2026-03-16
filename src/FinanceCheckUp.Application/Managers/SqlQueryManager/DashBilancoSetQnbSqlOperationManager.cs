using FinanceCheckUp.Application.Contexts.Concretes.Databases;
using FinanceCheckUp.Application.Models.ViewModel;
using FinanceCheckUp.Framework.Data;
using FinanceCheckUp.Framework.Data.MsSql.Repositories;


namespace FinanceCheckUp.Application.Managers.SqlQueryManager;
public interface IDashBilancoSetQnbSqlOperationManager : IGenericDapperRepository
{
    List<DashBilancoViewQnb> Get_HazirDegerT(int _year, long _compID);
    List<DashBilancoViewQnb> Get_MenkulKiymetT(int _year, long _compID);
    List<DashBilancoViewQnb> Get_TicariAlacakT(int _year, long _compID);
    List<DashBilancoViewQnb> Get_AlicilarT(int _year, long _compID);

    List<DashBilancoViewQnb> Get_AlinanCeklerT(int _year, long _compID);
    List<DashBilancoViewQnb> Get_SupheliTicariT(int _year, long _compID);
    List<DashBilancoViewQnb> Get_StoklarT(int _year, long _compID);
    List<DashBilancoViewQnb> Get_HammaddeT(int _year, long _compID);
    List<DashBilancoViewQnb> Get_YariMamulT(int _year, long _compID);
    List<DashBilancoViewQnb> Get_TicariMalT(int _year, long _compID);
    List<DashBilancoViewQnb> Get_VerilenSiparisT(int _year, long _compID);
    List<DashBilancoViewQnb> Get_insaatT(int _year, long _compID);
    List<DashBilancoViewQnb> Get_OrtakalacakT(int _year, long _compID);
    List<DashBilancoViewQnb> Get_DigerAlacakT(int _year, long _compID);
    List<DashBilancoViewQnb> Get_GelecekAyT(int _year, long _compID);
    List<DashBilancoViewQnb> Get_DigerDonenT(int _year, long _compID);
    List<DashBilancoViewQnb> Get_Toplam(int _year, long _compID);
}


public class DashBilancoSetQnbSqlOperationManager(FinanceCheckUpDbContext _dbContext) : GenericDapperRepositoryBase(_dbContext), IDashBilancoSetQnbSqlOperationManager
{

    public List<DashBilancoViewQnb> Get_HazirDegerT(int _year, long _compID)
    {
        return Query<DashBilancoViewQnb>("EXEC [SP_Main_Grow_HeaderQnb] @companyID, @nyear,1", new { nyear = _year, companyID = _compID }).ToList();
    }
    public List<DashBilancoViewQnb> Get_MenkulKiymetT(int _year, long _compID)
    {
        return Query<DashBilancoViewQnb>("EXEC [SP_Main_Grow_HeaderQnb] @companyID, @nyear,3", new { nyear = _year, companyID = _compID }).ToList();
    }
    public List<DashBilancoViewQnb> Get_TicariAlacakT(int _year, long _compID)
    {
        return Query<DashBilancoViewQnb>("EXEC SP_Main_Grow_HeaderQnb @companyID, @nyear,5", new { nyear = _year, companyID = _compID }).ToList();
    }
    public List<DashBilancoViewQnb> Get_AlicilarT(int _year, long _compID)
    {
        return Query<DashBilancoViewQnb>("EXEC [SP_Main_Grow_HeaderQnb] @companyID, @nyear,7", new { nyear = _year, companyID = _compID }).ToList();
    }
    public List<DashBilancoViewQnb> Get_AlinanCeklerT(int _year, long _compID)
    {
        return Query<DashBilancoViewQnb>("EXEC [SP_Main_Grow_HeaderQnb] @companyID, @nyear,9", new { nyear = _year, companyID = _compID }).ToList();
    }
    public List<DashBilancoViewQnb> Get_SupheliTicariT(int _year, long _compID)
    {
        return Query<DashBilancoViewQnb>("EXEC SP_Main_Grow_HeaderQnb @companyID, @nyear,11", new { nyear = _year, companyID = _compID }).ToList();
    }
    public List<DashBilancoViewQnb> Get_StoklarT(int _year, long _compID)
    {
        return Query<DashBilancoViewQnb>("EXEC SP_Main_Grow_HeaderQnb @companyID, @nyear,13", new { nyear = _year, companyID = _compID }).ToList();
    }
    public List<DashBilancoViewQnb> Get_HammaddeT(int _year, long _compID)
    {
        return Query<DashBilancoViewQnb>("EXEC [SP_Main_Grow_HeaderQnb] @companyID, @nyear,15", new { nyear = _year, companyID = _compID }).ToList();
    }
    public List<DashBilancoViewQnb> Get_YariMamulT(int _year, long _compID)
    {
        return Query<DashBilancoViewQnb>("EXEC [SP_Main_Grow_HeaderQnb] @companyID, @nyear,17", new { nyear = _year, companyID = _compID }).ToList();
    }
    public List<DashBilancoViewQnb> Get_TicariMalT(int _year, long _compID)
    {
        return Query<DashBilancoViewQnb>("EXEC SP_Main_Grow_HeaderQnb @companyID, @nyear,19", new { nyear = _year, companyID = _compID }).ToList();
    }
    public List<DashBilancoViewQnb> Get_VerilenSiparisT(int _year, long _compID)
    {
        return Query<DashBilancoViewQnb>("EXEC [SP_Main_Grow_HeaderQnb] @companyID, @nyear,21", new { nyear = _year, companyID = _compID }).ToList();
    }
    public List<DashBilancoViewQnb> Get_insaatT(int _year, long _compID)
    {
        return Query<DashBilancoViewQnb>("EXEC [SP_Main_Grow_HeaderQnb] @companyID, @nyear,23", new { nyear = _year, companyID = _compID }).ToList();
    }
    public List<DashBilancoViewQnb> Get_OrtakalacakT(int _year, long _compID)
    {
        return Query<DashBilancoViewQnb>("EXEC SP_Main_Grow_HeaderQnb @companyID, @nyear,25", new { nyear = _year, companyID = _compID }).ToList();
    }
    public List<DashBilancoViewQnb> Get_DigerAlacakT(int _year, long _compID)
    {
        return Query<DashBilancoViewQnb>("EXEC [SP_Main_Grow_HeaderQnb] @companyID, @nyear,27", new { nyear = _year, companyID = _compID }).ToList();
    }
    public List<DashBilancoViewQnb> Get_GelecekAyT(int _year, long _compID)
    {
        return Query<DashBilancoViewQnb>("EXEC [SP_Main_Grow_HeaderQnb] @companyID, @nyear,29", new { nyear = _year, companyID = _compID }).ToList();
    }
    public List<DashBilancoViewQnb> Get_DigerDonenT(int _year, long _compID)
    {
        return Query<DashBilancoViewQnb>("EXEC SP_Main_Grow_HeaderQnb @companyID, @nyear,31", new { nyear = _year, companyID = _compID }).ToList();
    }
    public List<DashBilancoViewQnb> Get_Toplam(int _year, long _compID)
    {
        List<DashBilancoViewQnb> nnnn = Query<DashBilancoViewQnb>("EXEC SP_Main_Grow_HeaderQnbSubType @companyID, @nyear,1", new { nyear = _year, companyID = _compID }).ToList();
        if (nnnn == null)
        {
            nnnn = new List<DashBilancoViewQnb>();
            DashBilancoViewQnb ll = new DashBilancoViewQnb();
            nnnn.Add(ll);
        }

        return nnnn;
    }
}