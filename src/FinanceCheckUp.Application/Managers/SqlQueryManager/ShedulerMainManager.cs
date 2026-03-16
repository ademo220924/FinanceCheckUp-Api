using FinanceCheckUp.Application.Contexts.Concretes.Databases;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Framework.Data;
using FinanceCheckUp.Framework.Data.MsSql.Repositories;


namespace FinanceCheckUp.Application.Managers.SqlQueryManager;
public interface IShedulerMainManager : IGenericDapperRepository
{
    public IEnumerable<AdaptabilityAppointment> Get_Data(int _year);
}

public class ShedulerMainManager(FinanceCheckUpDbContext _dbContext) : GenericDapperRepositoryBase(_dbContext), IShedulerMainManager
{
    public IEnumerable<AdaptabilityAppointment> Get_Data(int _year)
    {
        return StaticQuery<AdaptabilityAppointment>("SELECT *  FROM    [dbo].[Appointment] where  YEAR([EndDate])=@nyear", new { nyear = _year });
    }
}