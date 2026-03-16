using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Framework.Data;

namespace FinanceCheckUp.Infrastructure.Repository
{
    public interface IDatazRepository : IGenericRepository<Dataz, int>
    {
        int BulkInsert(BulkUploadToSqlOptions options, CancellationToken cancellationToken);
    }
}