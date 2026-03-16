using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Responses.DashCrmDetailb;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace FinanceCheckUp.Application.Features.BaseApp.DashCrmDetailb.Query.DashCrmDetailbOnGetGraphYear;
public class DashCrmDetailbOnGetGraphYearQueryHandler(IHhvnUsersManager hhvnUsersManager) : IRequestHandler<DashCrmDetailbOnGetGraphYearQuery, GenericResult<DashCrmDetailbOnGetGraphYearResponse>>
{

    public async Task<GenericResult<DashCrmDetailbOnGetGraphYearResponse>> Handle(DashCrmDetailbOnGetGraphYearQuery request, CancellationToken cancellationToken)
    {
        var UserID = Convert.ToInt64(request.UserId);
        hhvnUsersManager.SetYear(request.Request.nyear, UserID);
        return GenericResult<DashCrmDetailbOnGetGraphYearResponse>.Success(new DashCrmDetailbOnGetGraphYearResponse { Response = new JsonResult("ok") });
    }
}