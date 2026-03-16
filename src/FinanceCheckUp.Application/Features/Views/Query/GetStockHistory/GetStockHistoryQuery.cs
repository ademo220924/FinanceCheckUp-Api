using FinanceCheckUp.Application.Models.Responses.Views;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;

namespace FinanceCheckUp.Application.Features.Views.Query.GetStockHistory;

public class GetStockHistoryQuery:  IRequest<GenericResult<StockHistoryResponse>>
{
    public string SerialNumber { get; set; }
}