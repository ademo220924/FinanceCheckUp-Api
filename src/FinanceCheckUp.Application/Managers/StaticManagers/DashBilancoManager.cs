using FinanceCheckUp.Application.Contexts.Concretes.Databases;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Framework.Data;
using FinanceCheckUp.Framework.Data.MsSql.Repositories;

namespace FinanceCheckUp.Application.Managers.StaticManagers;


public interface IDashBilancoManager : IGenericDapperRepository
{
    List<DashBilancoView> Get_MAINRESULT(int _year, long _compID);

    DashBilancoViewMarj Get_MAINBrutKarZarar(int _year, long _compID);
    DashBilancoViewMarj Get_MAINNetSatis(int _year, long _compID);

}
public class DashBilancoManager(
    FinanceCheckUpDbContext _dbContext,
    IDashBilancoViewMizanCheckManager dashBilancoViewMizanCheckManager,
    IDashBilancoSetBeyanManager dashBilancoSetBeyanManager) : GenericDapperRepositoryBase(_dbContext), IDashBilancoManager
{
    public List<DashBilancoView> Get_MAINRESULT(int _year, long _compID)
    {
        return Query<DashBilancoView>("Select * from  TBLMRevenue Where CompanyID=@companyID and [Year]=@nyear", new { nyear = _year, companyID = _compID }).ToList();
    }
    public DashBilancoViewMarj Get_MAINBrutKarZarar(int _year, long _compID)
    {
        return Query<DashBilancoViewMarj>("SELECT TOP 1 *  FROM [dbo].[TBLWcapBrutKarZarar] Where [CompanyID]=@companyID and[Year]=@nyear", new { nyear = _year, companyID = _compID }).FirstOrDefault();
    }

    public DashBilancoViewMarj Get_MAINNetSatis(int _year, long _compID)
    {
        return Query<DashBilancoViewMarj>("SELECT  TOP 1 *  FROM [dbo].[TBLWcapNetSatis] Where [CompanyID]=@companyID and[Year]=@nyear", new { nyear = _year, companyID = _compID }).FirstOrDefault();
    }
}
