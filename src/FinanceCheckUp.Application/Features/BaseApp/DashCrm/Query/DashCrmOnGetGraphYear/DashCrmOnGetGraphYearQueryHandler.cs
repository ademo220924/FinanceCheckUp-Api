using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Responses.DashCrm;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace FinanceCheckUp.Application.Features.BaseApp.DashCrm.Query.DashCrmOnGetGraphYear;
public class DashCrmOnGetGraphYearQueryHandler(IHhvnUsersManager hhvnUsersManager) : IRequestHandler<DashCrmOnGetGraphYearQuery, GenericResult<DashCrmOnGetGraphYearResponse>>
{

    public async Task<GenericResult<DashCrmOnGetGraphYearResponse>> Handle(DashCrmOnGetGraphYearQuery request, CancellationToken cancellationToken)
    {
        var UserID = Convert.ToInt64(request.UserId);
        hhvnUsersManager.SetYear(request.Request.nyear, UserID);
        return GenericResult<DashCrmOnGetGraphYearResponse>.Success(new DashCrmOnGetGraphYearResponse { Response = new JsonResult("ok") });
    }
}