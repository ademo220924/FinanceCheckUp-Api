using FinanceCheckUp.Application.Models.Responses.ReportApis;
using FinanceCheckUp.Application.Models.ViewModel.Reports;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using Newtonsoft.Json;

namespace FinanceCheckUp.Application.Features.BaseApp.Report.Query.GetListOrderItem;

public class GetListOrderItemQueryHandler : IRequestHandler<GetListOrderItemQuery, GenericResult<GetListOrderItemResponse>>
{
    public Task<GenericResult<GetListOrderItemResponse>> Handle(GetListOrderItemQuery request, CancellationToken cancellationToken)
    {
        var stockFilterView = JsonConvert.DeserializeObject<StockInFilterView>(request.UserData);
        return Task.FromResult(GenericResult<GetListOrderItemResponse>.Success(new GetListOrderItemResponse() { ResponseText = "OK" }));
    }
}