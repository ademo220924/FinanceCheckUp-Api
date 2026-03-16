using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Responses.DashRevenueJrnl;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace FinanceCheckUp.Application.Features.BaseApp.DashRevenueJrnl.Query.DashRevenueJrnlOnGetGraphComp;
public class DashRevenueJrnlOnGetGraphCompQueryHandler(IHhvnUsersManager hhvnUsersManager, IUserCompanyManager userCompanyManager) : IRequestHandler<DashRevenueJrnlOnGetGraphCompQuery, GenericResult<DashRevenueJrnlOnGetGraphCompResponse>>
{

    public async Task<GenericResult<DashRevenueJrnlOnGetGraphCompResponse>> Handle(DashRevenueJrnlOnGetGraphCompQuery request, CancellationToken cancellationToken)
    {
        var UserID = Convert.ToInt64(request.UserId);

        if (request.Request.ncompid < 1)
            return GenericResult<DashRevenueJrnlOnGetGraphCompResponse>.Success(new DashRevenueJrnlOnGetGraphCompResponse { Response = new JsonResult("nok") });

        if (!hhvnUsersManager.CheckUser(request.Request.ncompid, (int)UserID))
            return GenericResult<DashRevenueJrnlOnGetGraphCompResponse>.Success(new DashRevenueJrnlOnGetGraphCompResponse { Response = new JsonResult("ok") });

        userCompanyManager.Update_UserDefault((int)UserID, request.Request.ncompid);

        return GenericResult<DashRevenueJrnlOnGetGraphCompResponse>.Success(new DashRevenueJrnlOnGetGraphCompResponse { Response = new JsonResult("ok") });

    }
}