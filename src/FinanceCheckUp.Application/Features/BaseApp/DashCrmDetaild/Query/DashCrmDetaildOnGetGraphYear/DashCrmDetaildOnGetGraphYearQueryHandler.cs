using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Responses.DashCrmDetaild;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinanceCheckUp.Application.Features.BaseApp.DashCrmDetaild.Query.DashCrmDetaildOnGetGraphYear;

public class DashCrmDetaildOnGetGraphYearQueryHandler(IHhvnUsersManager hhvnUsersManager) : IRequestHandler<DashCrmDetaildOnGetGraphYearQuery, GenericResult<DashCrmDetaildOnGetGraphYearResponse>>
{

    public async Task<GenericResult<DashCrmDetaildOnGetGraphYearResponse>> Handle(DashCrmDetaildOnGetGraphYearQuery request, CancellationToken cancellationToken)
    {
        var UserID = Convert.ToInt64(request.UserId);
        hhvnUsersManager.SetYear(request.Request.nyear, UserID);
        return GenericResult<DashCrmDetaildOnGetGraphYearResponse>.Success(new DashCrmDetaildOnGetGraphYearResponse { Response = new JsonResult("ok") });
    }
}