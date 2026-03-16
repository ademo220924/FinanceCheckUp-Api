using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Responses.Layouts;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;

namespace FinanceCheckUp.Application.Features.Layouts.Query.LayoutReport;

public class LayoutReportQueryHandler(IHhvnUsersManager hhvnUsersManager): IRequestHandler<LayoutReportQuery, GenericResult<LayoutReportResponse>>
{
    public Task<GenericResult<LayoutReportResponse>> Handle(LayoutReportQuery request, CancellationToken cancellationToken)
    {
        var layoutResponse = new LayoutReportResponse
        { 
            UserId = Convert.ToInt64(request.UserId)
        };

        layoutResponse.HhvnUsers= hhvnUsersManager.GetRow_User(layoutResponse.UserId);
        return Task.FromResult(GenericResult<LayoutReportResponse>.Success(layoutResponse));
    }
}