using FinanceCheckUp.Application.Models.Requests.ReportApis;
using FinanceCheckUp.Application.Models.Responses.ReportApis;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;

namespace FinanceCheckUp.Application.Features.BaseApp.Report.Command.ReportPutOrderItem;

public class ReportPutOrderItemCommandHandler : IRequestHandler<ReportPutOrderItemRequest, GenericResult<ReportPutOrderItemResponse>>
{

    public Task<GenericResult<ReportPutOrderItemResponse>> Handle(ReportPutOrderItemRequest request, CancellationToken cancellationToken)
    {
        int UserID =int.Parse(request.UserId);
         return Task.FromResult(GenericResult<ReportPutOrderItemResponse>.Success(new ReportPutOrderItemResponse { UserId = UserID }));
    }
}