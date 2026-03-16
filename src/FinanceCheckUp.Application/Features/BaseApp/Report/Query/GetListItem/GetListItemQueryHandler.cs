using FinanceCheckUp.Application.Models.Responses.ReportApis;
using FinanceCheckUp.Application.Models.ViewModel.Reports;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using Newtonsoft.Json;

namespace FinanceCheckUp.Application.Features.BaseApp.Report.Query.GetListItem;

public class GetListItemQueryHandler : IRequestHandler<GetListItemQuery, GenericResult<GetListItemResponse>>
{
    public Task<GenericResult<GetListItemResponse>> Handle(GetListItemQuery request, CancellationToken cancellationToken)
    {
        var stockFilterView = JsonConvert.DeserializeObject<ReportFilterView>(request.UserData);
        return Task.FromResult(GenericResult<GetListItemResponse>.Success(new GetListItemResponse() { ResponseText = "OK" }));
    }
}