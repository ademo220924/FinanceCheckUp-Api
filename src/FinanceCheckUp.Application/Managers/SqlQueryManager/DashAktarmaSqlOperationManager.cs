using FinanceCheckUp.Application.Contexts.Concretes.Databases;
using FinanceCheckUp.Application.Models.ViewModel;
using FinanceCheckUp.Framework.Data;
using FinanceCheckUp.Framework.Data.MsSql.Repositories;

namespace FinanceCheckUp.Application.Managers.SqlQueryManager;

public interface IDashAktarmaSqlOperationManager : IGenericDapperRepository
{
    List<DashAktarma> AddSMMM(List<DashAktarma> nlist);
    List<DashAktarma> Get_MAINRESULTMultiMain(long _compID);

}

public class DashAktarmaSqlOperationManager(FinanceCheckUpDbContext _dbContext) : GenericDapperRepositoryBase(_dbContext), IDashAktarmaSqlOperationManager
{
    public List<DashAktarma> AddSMMM(List<DashAktarma> nlist)
    {

        return nlist;
    }

    public List<DashAktarma> Get_MAINRESULTMultiMain(long _compID)
    {
        return StaticQuery<DashAktarma>("Select * from  SPO_TBMLAKTARMA WITH (NOLOCK) Where CompanyID=@companyID  ", new { companyID = _compID }).ToList();
    }
}