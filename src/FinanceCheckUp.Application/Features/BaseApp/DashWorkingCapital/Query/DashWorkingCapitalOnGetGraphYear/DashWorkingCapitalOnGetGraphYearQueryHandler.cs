using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Responses.DashWorkingCapital;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace FinanceCheckUp.Application.Features.BaseApp.DashWorkingCapital.Query.DashWorkingCapitalOnGetGraphYear;
public class DashWorkingCapitalOnGetGraphYearQueryHandler(IHhvnUsersManager hhvnUsersManager) : IRequestHandler<DashWorkingCapitalOnGetGraphYearQuery, GenericResult<DashWorkingCapitalOnGetGraphYearResponse>>
{

    public async Task<GenericResult<DashWorkingCapitalOnGetGraphYearResponse>> Handle(DashWorkingCapitalOnGetGraphYearQuery request, CancellationToken cancellationToken)
    {
        var UserID = Convert.ToInt64(request.UserId);
        hhvnUsersManager.SetYear(request.Request.nyear, UserID);
        return GenericResult<DashWorkingCapitalOnGetGraphYearResponse>.Success(new DashWorkingCapitalOnGetGraphYearResponse { Response = new JsonResult("ok") });
    }
}