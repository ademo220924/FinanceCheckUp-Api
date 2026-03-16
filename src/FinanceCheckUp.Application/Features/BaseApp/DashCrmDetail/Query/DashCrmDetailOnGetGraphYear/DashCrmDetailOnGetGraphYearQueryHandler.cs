using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Responses.DashCrmDetail;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace FinanceCheckUp.Application.Features.BaseApp.DashCrmDetail.Query.DashCrmDetailOnGetGraphYear;
public class DashCrmDetailOnGetGraphYearQueryHandler(IHhvnUsersManager hhvnUsersManager) : IRequestHandler<DashCrmDetailOnGetGraphYearQuery, GenericResult<DashCrmDetailOnGetGraphYearResponse>>
{

    public async Task<GenericResult<DashCrmDetailOnGetGraphYearResponse>> Handle(DashCrmDetailOnGetGraphYearQuery request, CancellationToken cancellationToken)
    {
        var UserID = Convert.ToInt64(request.UserId);
        hhvnUsersManager.SetYear(request.Request.nyear, UserID);
        return GenericResult<DashCrmDetailOnGetGraphYearResponse>.Success(new DashCrmDetailOnGetGraphYearResponse { Response = new JsonResult("ok") });
    }
}