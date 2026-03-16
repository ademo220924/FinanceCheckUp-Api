using FinanceCheckUp.Application.Contexts.Concretes.Databases;
using FinanceCheckUp.Application.Models.ViewModel;
using FinanceCheckUp.Framework.Data;
using FinanceCheckUp.Framework.Data.MsSql.Repositories;

namespace FinanceCheckUp.Application.Managers.SqlQueryManager;
public interface IDashBilancoSetQnbGelirIManager : IGenericDapperRepository
{
    List<DashBilancoViewQnb> Get_1(int _year, long _compID);
    List<DashBilancoViewQnb> SetSektor(int _year, long _compID);
}


public class DashBilancoSetQnbGelirIManager(FinanceCheckUpDbContext _dbContext) : GenericDapperRepositoryBase(_dbContext), IDashBilancoSetQnbGelirIManager
{
    public List<DashBilancoViewQnb> Get_1(int _year, long _compID)
    {
        return Query<DashBilancoViewQnb>("EXEC [SP_QnbRepor27Ebitda] @companyID, @nyear", new { nyear = _year, companyID = _compID }).ToList();
    }
    public List<DashBilancoViewQnb> SetSektor(int _year, long _compID)
    {
        var chk = Query<DashBilancoViewQnb>("EXEC [SP_QnbReporALL] @companyID, @nyear ", new { nyear = _year, companyID = _compID }).ToList();
        Execute(" update  [EDEFTERDB].[dbo].[TBLXml] set  [IsReported]=1 where CompanyID=@companyID and Year=@nyear ", new { nyear = _year, companyID = _compID });
        //    
        Query<DashBilancoViewQnb>("EXEC [SP_Main_Grow_HeaderQnbRATIO0ALL] @companyID ", new { companyID = _compID }).ToList();
        Query<DashBilancoViewQnb>("EXEC [SP_Main_Grow_HeaderQnbRATIOChartAll] @companyID ", new { companyID = _compID }).ToList();
        Query<DashBilancoViewQnb>("EXEC [SP_Main_Grow_HeaderQnbRATIOChrtLat] @companyID  ", new { companyID = _compID }).ToList();
        Query<DashBilancoViewQnb>("EXEC [SP_Main_Grow_HeaderQnbReportLat] @companyID  ", new { companyID = _compID }).ToList();
        return chk;
    }
}