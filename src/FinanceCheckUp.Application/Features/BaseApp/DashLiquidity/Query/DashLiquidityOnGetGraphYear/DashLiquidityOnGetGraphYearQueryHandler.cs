using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace FinanceCheckUp.Application.Features.BaseApp.DashLiquidity.Query.DashLiquidityOnGetGraphYear;
public class DashLiquidityOnGetGraphYearQueryHandler(IHhvnUsersManager hhvnUsersManager) : IRequestHandler<DashLiquidityOnGetGraphYearQuery, GenericResult<DashLiquidityOnGetGraphYearResponse>>
{

    public async Task<GenericResult<DashLiquidityOnGetGraphYearResponse>> Handle(DashLiquidityOnGetGraphYearQuery request, CancellationToken cancellationToken)
    {
        var UserID = Convert.ToInt64(request.UserId);
        hhvnUsersManager.SetYear(request.Request.nyear, UserID);
        return GenericResult<DashLiquidityOnGetGraphYearResponse>.Success(new DashLiquidityOnGetGraphYearResponse { Response = new JsonResult("ok") });
    }
}