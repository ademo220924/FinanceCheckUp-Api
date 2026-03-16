using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Responses.DashRevenue;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace FinanceCheckUp.Application.Features.BaseApp.DashRevenue.Query.DashRevenueOnGetGraphYear;
public class DashRevenueOnGetGraphYearQueryHandler(IHhvnUsersManager hhvnUsersManager) : IRequestHandler<DashRevenueOnGetGraphYearQuery, GenericResult<DashRevenueOnGetGraphYearResponse>>
{

    public async Task<GenericResult<DashRevenueOnGetGraphYearResponse>> Handle(DashRevenueOnGetGraphYearQuery request, CancellationToken cancellationToken)
    {
        var UserID = Convert.ToInt64(request.UserId);
        hhvnUsersManager.SetYear(request.Request.nyear, UserID);
        return GenericResult<DashRevenueOnGetGraphYearResponse>.Success(new DashRevenueOnGetGraphYearResponse { Response = new JsonResult("ok") });
    }
}