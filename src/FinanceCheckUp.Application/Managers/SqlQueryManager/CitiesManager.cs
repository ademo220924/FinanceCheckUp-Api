using FinanceCheckUp.Application.Contexts.Concretes.Databases;
using FinanceCheckUp.Domain.Entities;
using FinanceCheckUp.Framework.Data;
using FinanceCheckUp.Framework.Data.MsSql.Repositories;

namespace FinanceCheckUp.Application.Managers.SqlQueryManager
{
    public interface ICitiesManager : IGenericDapperRepository
    {
        IEnumerable<City> Get_Cities();
        City GetRow_Cities(int _ID);
        long Save_Cities(City city);

        bool Update_Cities(City city);
    }


    public class CitiesManager(FinanceCheckUpDbContext _dbContext) : GenericDapperRepositoryBase(_dbContext), ICitiesManager
    {
        public IEnumerable<City> Get_Cities()
        {
            // Dapper maps by result column name; [Column("City")] on CityName is EF-only — alias so CityName is filled.
            return StaticQuery<City>("SELECT [ID] AS Id, [City] AS CityName FROM [Cities]");
        }
        public City GetRow_Cities(int _ID)
        {
            return StaticQuery<City>("SELECT [ID] AS Id, [City] AS CityName FROM [Cities] WHERE [ID]=@ID", new { ID = _ID }).FirstOrDefault();
        }

        public long Save_Cities(City city)
        {
            string sql = @"  INSERT INTO [Cities]
          ( 
        [City] 
          ) 
           VALUES 
         ( 
        @City 
         )  ;select  Cast(SCOPE_IDENTITY() as Int)";
            city.Id = Query<int>(sql, city).FirstOrDefault();
            return city.Id;
        }

        public bool Update_Cities(City city)
        {
            try
            {
                string sql = "UPDATE   [Cities] SET  [City]=@City  WHERE [ID]=@ID";
                Execute(sql, city);
                return true;
            }
            catch
            {
                throw;
            }
        }
    }
}
