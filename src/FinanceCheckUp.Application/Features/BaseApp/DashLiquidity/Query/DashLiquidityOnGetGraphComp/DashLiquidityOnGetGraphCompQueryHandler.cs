using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace FinanceCheckUp.Application.Features.BaseApp.DashLiquidity.Query.DashLiquidityOnGetGraphComp;
public class DashLiquidityOnGetGraphCompQueryHandler(IHhvnUsersManager hhvnUsersManager, IUserCompanyManager userCompanyManager) : IRequestHandler<DashLiquidityOnGetGraphCompQuery, GenericResult<DashLiquidityOnGetGraphCompResponse>>
{

    public async Task<GenericResult<DashLiquidityOnGetGraphCompResponse>> Handle(DashLiquidityOnGetGraphCompQuery request, CancellationToken cancellationToken)
    {

        var UserID = Convert.ToInt64(request.UserId);

        if (request.Request.ncompid < 1)
            return GenericResult<DashLiquidityOnGetGraphCompResponse>.Success(new DashLiquidityOnGetGraphCompResponse { Response = new JsonResult("nok") });

        if (!hhvnUsersManager.CheckUser(request.Request.ncompid, (int)UserID))
            return GenericResult<DashLiquidityOnGetGraphCompResponse>.Success(new DashLiquidityOnGetGraphCompResponse { Response = new JsonResult("ok") });

        userCompanyManager.Update_UserDefault((int)UserID, request.Request.ncompid);

        return GenericResult<DashLiquidityOnGetGraphCompResponse>.Success(new DashLiquidityOnGetGraphCompResponse { Response = new JsonResult("ok") });
    }
}