using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Responses.Views;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;

namespace FinanceCheckUp.Application.Features.Views.Query.GetStockHistory;

public class GetStockHistoryQueryHandler(IStockHistoryViewManager historyViewManager)
    : IRequestHandler<GetStockHistoryQuery, GenericResult<StockHistoryResponse>>
{
    public async Task<GenericResult<StockHistoryResponse>> Handle(GetStockHistoryQuery request,
        CancellationToken cancellationToken)
    {
        var response = historyViewManager.StockHistoryList(request.SerialNumber);
        return await Task.FromResult(GenericResult<StockHistoryResponse>.Success(new StockHistoryResponse()
            { StockHistoryView = response.FirstOrDefault()!=null ? response.FirstOrDefault() : null }));
    }
}