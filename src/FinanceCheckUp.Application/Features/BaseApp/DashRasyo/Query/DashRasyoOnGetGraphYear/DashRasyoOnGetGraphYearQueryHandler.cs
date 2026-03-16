using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Responses.DashRasyo;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace FinanceCheckUp.Application.Features.BaseApp.DashRasyo.Query.DashRasyoOnGetGraphYear;
public class DashRasyoOnGetGraphYearQueryHandler(IHhvnUsersManager hhvnUsersManager) : IRequestHandler<DashRasyoOnGetGraphYearQuery, GenericResult<DashRasyoOnGetGraphYearResponse>>
{

    public async Task<GenericResult<DashRasyoOnGetGraphYearResponse>> Handle(DashRasyoOnGetGraphYearQuery request, CancellationToken cancellationToken)
    {
        var UserID = Convert.ToInt64(request.UserId);
        hhvnUsersManager.SetYear(request.Request.nyear, UserID);
        return GenericResult<DashRasyoOnGetGraphYearResponse>.Success(new DashRasyoOnGetGraphYearResponse { Response = new JsonResult("ok") });
    }
}