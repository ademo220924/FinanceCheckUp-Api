using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Responses.DashCrmDetailc;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace FinanceCheckUp.Application.Features.BaseApp.DashCrmDetailc.Query.DashCrmDetailcOnGetGraphYear;
public class DashCrmDetailcOnGetGraphYearQueryHandler(IHhvnUsersManager hhvnUsersManager) : IRequestHandler<DashCrmDetailcOnGetGraphYearQuery, GenericResult<DashCrmDetailcOnGetGraphYearResponse>>
{

    public async Task<GenericResult<DashCrmDetailcOnGetGraphYearResponse>> Handle(DashCrmDetailcOnGetGraphYearQuery request, CancellationToken cancellationToken)
    {
        var UserID = Convert.ToInt64(request.UserId);
        hhvnUsersManager.SetYear(request.Request.nyear, UserID);
        return GenericResult<DashCrmDetailcOnGetGraphYearResponse>.Success(new DashCrmDetailcOnGetGraphYearResponse { Response = new JsonResult("ok") });
    }
}