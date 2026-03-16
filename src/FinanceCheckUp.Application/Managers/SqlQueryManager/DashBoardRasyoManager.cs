using FinanceCheckUp.Application.Contexts.Concretes.Databases;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Framework.Data;
using FinanceCheckUp.Framework.Data.MsSql.Repositories;

namespace FinanceCheckUp.Application.Managers.SqlQueryManager;


public interface IDashBoardRasyoManager : IGenericDapperRepository
{
    public IEnumerable<DashBoardRasyo> Get_List();
}

public class DashBoardRasyoManager(FinanceCheckUpDbContext _dbContext) : GenericDapperRepositoryBase(_dbContext), IDashBoardRasyoManager
{
    public IEnumerable<DashBoardRasyo> Get_List()
    {
        string sql = @"SELECT  [Description]
      ,[January] as 'Ocak'
      ,[February] as 'Subat'
      ,[March] as 'Mart'
      ,[April] as 'Nisan'
      ,[May] as 'Mayis'
      ,[June] as 'Haziran'
      ,[July] as 'Temmuz'
      ,[August] as 'Agustos'
      ,[September] as 'Eylül'
      ,[October] as 'Ekim'
      ,[November] as 'Kasim'
      ,[December] as 'Aralik'
      ,[CompanyID] 
  FROM  [dbo].[TTZDashBoardOran]";
        return Query<DashBoardRasyo>(sql);
    }
}
