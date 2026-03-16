using FinanceCheckUp.Application.Contexts.Concretes.Databases;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Framework.Data;
using FinanceCheckUp.Framework.Data.MsSql.Repositories;

namespace FinanceCheckUp.Application.Managers.SqlQueryManager;


public interface IDistrictsManager : IGenericDapperRepository
{
    public IEnumerable<Districts> Get_Districts();
    public Districts GetRow_Districts(int _ID);
    public List<Districts> GetbyCityID(int _ID);
    public int Save_Districts(Districts districts);

    public bool Update_Districts(Districts districts);
}

public class DistrictsManager(FinanceCheckUpDbContext _dbContext) : GenericDapperRepositoryBase(_dbContext), IDistrictsManager
{
    public IEnumerable<Districts> Get_Districts()
    {
        return Query<Districts>("Select * From [Districts]");
    }
    public Districts GetRow_Districts(int _ID)
    {
        return Query<Districts>("Select * From [Districts] where ID=@ID ", new { ID = _ID }).FirstOrDefault();
    }
    public List<Districts> GetbyCityID(int _ID)
    {
        return Query<Districts>("Select * From [Districts] where CityID=@ID ", new { ID = _ID }).ToList();
    }
    public int Save_Districts(Districts districts)
    {
        string sql = @"  INSERT INTO [Districts]
          ( 
        [District] ,
        [CityID] 
          ) 
           VALUES 
         ( 
        @District ,
        @CityID 
         )  ;select  Cast(SCOPE_IDENTITY() as Int)";
        districts.ID = Query<int>(sql, districts).FirstOrDefault();

        return districts.ID;
    }


    public bool Update_Districts(Districts districts)
    {
        try
        {
            string sql = "UPDATE   [Districts] SET  [District]=@District , [CityID]=@CityID  WHERE [ID]=@ID";
            Execute(sql, districts);
            return true;
        }
        catch
        {
            throw;
        }
    }
}
