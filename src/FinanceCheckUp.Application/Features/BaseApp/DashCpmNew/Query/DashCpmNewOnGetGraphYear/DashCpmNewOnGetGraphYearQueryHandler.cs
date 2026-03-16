using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Responses.DashCpmNew;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinanceCheckUp.Application.Features.BaseApp.DashCpmNew.Query.DashCpmNewOnGetGraphYear;
public class DashCpmNewOnGetGraphYearQueryHandler(IHhvnUsersManager hhvnUsersManager) : IRequestHandler<DashCpmNewOnGetGraphYearQuery, GenericResult<DashCpmNewOnGetGraphYearResponse>>
{

    public async Task<GenericResult<DashCpmNewOnGetGraphYearResponse>> Handle(DashCpmNewOnGetGraphYearQuery request, CancellationToken cancellationToken)
    {
        var UserID = Convert.ToInt64(request.UserId);
        hhvnUsersManager.SetYear(request.Request.nyear, UserID);
        return GenericResult<DashCpmNewOnGetGraphYearResponse>.Success(new DashCpmNewOnGetGraphYearResponse { Response = new JsonResult("ok") });
    }
}