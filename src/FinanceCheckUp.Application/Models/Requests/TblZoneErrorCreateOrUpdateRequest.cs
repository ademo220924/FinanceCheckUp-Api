using FinanceCheckUp.Application.Models.Common;

namespace FinanceCheckUp.Application.Models.Requests;

public class TblZoneErrorCreateOrUpdateRequest
{
    public DataViewerError DataViewerError { get; set; }
}