using FinanceCheckUp.Application.Contexts.Concretes.Databases;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Framework.Data;
using FinanceCheckUp.Framework.Data.MsSql.Repositories;

namespace FinanceCheckUp.Application.Managers.SqlQueryManager;


public interface IStockHistoryViewManager : IGenericDapperRepository
{
    public IEnumerable<StockHistoryView> StockHistoryList(string serialNumber);
}

public class StockHistoryViewManager(FinanceCheckUpDbContext dbContext) : GenericDapperRepositoryBase(dbContext), IStockHistoryViewManager
{
    public IEnumerable<StockHistoryView> StockHistoryList(string serialNumber)
    {
        return StaticQuery<StockHistoryView>("SELECT StockHistoryID,SerialNumber,(select StoreName from [AssetManagement].[Store] where StoreID=InStoreID)as InStoreName,(select StoreName from [AssetManagement].[Store] where StoreID=OutStoreID)as OutStoreName, Piece ,ModifiedDate FROM [AssetManagement].[StockHistory] (NOLOCK) where SerialNumber=@p_serialNumber and Piece!=0 ", new { p_serialNumber = serialNumber });
    }
}
