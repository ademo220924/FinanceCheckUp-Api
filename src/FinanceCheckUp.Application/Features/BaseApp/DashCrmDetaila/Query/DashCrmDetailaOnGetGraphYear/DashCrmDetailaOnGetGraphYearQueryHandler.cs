using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Responses.DashCrmDetaila;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace FinanceCheckUp.Application.Features.BaseApp.DashCrmDetaila.Query.DashCrmDetailaOnGetGraphYear;
public class DashCrmDetailaOnGetGraphYearQueryHandler(IHhvnUsersManager hhvnUsersManager) : IRequestHandler<DashCrmDetailaOnGetGraphYearQuery, GenericResult<DashCrmDetailaOnGetGraphYearResponse>>
{

    public async Task<GenericResult<DashCrmDetailaOnGetGraphYearResponse>> Handle(DashCrmDetailaOnGetGraphYearQuery request, CancellationToken cancellationToken)
    {
        var UserID = Convert.ToInt64(request.UserId);
        hhvnUsersManager.SetYear(request.Request.nyear, UserID);
        return GenericResult<DashCrmDetailaOnGetGraphYearResponse>.Success(new DashCrmDetailaOnGetGraphYearResponse { Response = new JsonResult("ok") });
    }
}