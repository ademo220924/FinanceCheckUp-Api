using FinanceCheckUp.Application.Contexts.Concretes.Databases;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Framework.Data;
using FinanceCheckUp.Framework.Data.MsSql.Repositories;

namespace FinanceCheckUp.Application.Managers.SqlQueryManager;

public interface IUploadMainManager : IGenericDapperRepository
{
    public IEnumerable<YearlyUploadResult> Get_Data(int _year, long _compID);
}

public class UploadMainManager(FinanceCheckUpDbContext _dbContext) : GenericDapperRepositoryBase(_dbContext), IUploadMainManager
{
    public IEnumerable<YearlyUploadResult> Get_Data(int _year, long _compID)
    {
        return StaticQuery<YearlyUploadResult>("EXEC SP_GETYEARLYRESULT @nyear,@companyID", new { nyear = _year, companyID = _compID });
    }
}
