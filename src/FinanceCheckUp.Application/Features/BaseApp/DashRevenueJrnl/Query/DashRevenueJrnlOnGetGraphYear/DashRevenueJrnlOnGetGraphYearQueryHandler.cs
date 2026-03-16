using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Responses.DashRevenueJrnl;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace FinanceCheckUp.Application.Features.BaseApp.DashRevenueJrnl.Query.DashRevenueJrnlOnGetGraphYear;
public class DashRevenueJrnlOnGetGraphYearQueryHandler(IHhvnUsersManager hhvnUsersManager) : IRequestHandler<DashRevenueJrnlOnGetGraphYearQuery, GenericResult<DashRevenueJrnlOnGetGraphYearResponse>>
{

    public async Task<GenericResult<DashRevenueJrnlOnGetGraphYearResponse>> Handle(DashRevenueJrnlOnGetGraphYearQuery request, CancellationToken cancellationToken)
    {
        var UserID = Convert.ToInt64(request.UserId);
        hhvnUsersManager.SetYear(request.Request.nyear, UserID);
        return GenericResult<DashRevenueJrnlOnGetGraphYearResponse>.Success(new DashRevenueJrnlOnGetGraphYearResponse { Response = new JsonResult("ok") });

    }
}