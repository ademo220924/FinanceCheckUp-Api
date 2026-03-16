using FinanceCheckUp.Application.Contexts.Concretes.Databases;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Framework.Data;
using FinanceCheckUp.Framework.Data.MsSql.Repositories;

namespace FinanceCheckUp.Application.Managers.SqlQueryManager;


public interface IDashBoardManager : IGenericDapperRepository
{
    public IEnumerable<DashBoard> Get_ErroorList();
}

public class DashBoardManager(FinanceCheckUpDbContext _dbContext) : GenericDapperRepositoryBase(_dbContext), IDashBoardManager
{
    public IEnumerable<DashBoard> Get_ErroorList()
    {
        string sql = @" 
SELECT   [Pass]
      ,[Fail]
      ,[MonthPay]
      ,[YearPay],    CAST(
      CAST([YearPay] AS VARCHAR(4)) +
      RIGHT('0' + CAST([MonthPay] AS VARCHAR(2)), 2) +
      RIGHT('0' + CAST(1 AS VARCHAR(2)), 2)  
   AS DATETIME) as Datum,CsvID,CompanyID,   (
      CAST([YearPay] AS VARCHAR(4)) +'-'+
      RIGHT('0' + CAST([MonthPay] AS VARCHAR(2)), 2) ) as datetext
  FROM  [dbo].[ERRORVIEW] order by [YearPay],[MonthPay]";
        return Query<DashBoard>(sql);
    }
}

