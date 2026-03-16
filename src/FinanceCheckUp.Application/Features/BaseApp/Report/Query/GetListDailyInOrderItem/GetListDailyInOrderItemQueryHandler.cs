using FinanceCheckUp.Application.Models.Responses.ReportApis;
using FinanceCheckUp.Application.Models.ViewModel.Reports;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using Newtonsoft.Json;

namespace FinanceCheckUp.Application.Features.BaseApp.Report.Query.GetListDailyInOrderItem;

public class GetListDailyInOrderItemQueryHandler : IRequestHandler<GetListDailyInOrderItemQuery, GenericResult<GetListDailyInOrderItemResponse>>
{
    public Task<GenericResult<GetListDailyInOrderItemResponse>> Handle(GetListDailyInOrderItemQuery request, CancellationToken cancellationToken)
    {
        var stockFilterView = JsonConvert.DeserializeObject<StockInReportFilterView>(request.UserData);
        return Task.FromResult(GenericResult<GetListDailyInOrderItemResponse>.Success(new GetListDailyInOrderItemResponse() { ResponseText = "OK" }));
    }
}