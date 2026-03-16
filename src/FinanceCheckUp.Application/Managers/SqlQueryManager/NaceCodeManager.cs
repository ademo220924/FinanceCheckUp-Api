using FinanceCheckUp.Application.Contexts.Concretes.Databases;
using FinanceCheckUp.Domain.Entities;
using FinanceCheckUp.Framework.Data;
using FinanceCheckUp.Framework.Data.MsSql.Repositories;

namespace FinanceCheckUp.Application.Managers.SqlQueryManager;
public interface INaceCodeManager : IGenericDapperRepository
{
    IEnumerable<Nacecode> Get_NaceCode();
    Nacecode GetRow_NaceCodes(int _ID);
    string Get_Description(string _nacecode);

}

public class NaceCodeManager(FinanceCheckUpDbContext _dbContext) : GenericDapperRepositoryBase(_dbContext), INaceCodeManager
{
    public IEnumerable<Nacecode> Get_NaceCode()
    {
        return StaticQuery<Nacecode>("Select * From NACECODEMain");
    }
    public Nacecode GetRow_NaceCodes(int _ID)
    {
        return StaticQuery<Nacecode>("Select * From [NACECODEMain] where ID=@ID ", new { ID = _ID }).FirstOrDefault();
    }
    public string Get_Description(string _nacecode)
    {
        return StaticQuery<string>("Select top 1 Description From [NACECODEMain] where ID=@ID ", new { ID = _nacecode }).FirstOrDefault();
    }
}