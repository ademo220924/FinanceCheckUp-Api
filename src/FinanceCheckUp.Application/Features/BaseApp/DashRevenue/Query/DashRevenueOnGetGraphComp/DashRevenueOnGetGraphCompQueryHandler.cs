using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Responses.DashRevenue;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace FinanceCheckUp.Application.Features.BaseApp.DashRevenue.Query.DashRevenueOnGetGraphComp;
public class DashRevenueOnGetGraphCompQueryHandler(IHhvnUsersManager hhvnUsersManager, IUserCompanyManager userCompanyManager) : IRequestHandler<DashRevenueOnGetGraphCompQuery, GenericResult<DashRevenueOnGetGraphCompResponse>>
{

    public async Task<GenericResult<DashRevenueOnGetGraphCompResponse>> Handle(DashRevenueOnGetGraphCompQuery request, CancellationToken cancellationToken)
    {
        var UserID = Convert.ToInt64(request.UserId);

        if (request.Request.ncompid < 1)
            return GenericResult<DashRevenueOnGetGraphCompResponse>.Success(new DashRevenueOnGetGraphCompResponse { Response = new JsonResult("nok") });

        if (!hhvnUsersManager.CheckUser(request.Request.ncompid, (int)UserID))
            return GenericResult<DashRevenueOnGetGraphCompResponse>.Success(new DashRevenueOnGetGraphCompResponse { Response = new JsonResult("ok") });

        userCompanyManager.Update_UserDefault((int)UserID, request.Request.ncompid);

        return GenericResult<DashRevenueOnGetGraphCompResponse>.Success(new DashRevenueOnGetGraphCompResponse { Response = new JsonResult("ok") });
    }
}