using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Common.Constants;
using FinanceCheckUp.Application.Models.Responses.DashLiquidity;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
namespace FinanceCheckUp.Application.Features.BaseApp.DashLiquidity.Query.DashLiquidityOnGetPrio;
public class DashLiquidityOnGetPrioQueryHandler : IRequestHandler<DashLiquidityOnGetPrioQuery, GenericResult<DashLiquidityOnGetPrioResponse>>
{

    public async Task<GenericResult<DashLiquidityOnGetPrioResponse>> Handle(DashLiquidityOnGetPrioQuery request, CancellationToken cancellationToken)
    {
                return GenericResult<DashLiquidityOnGetPrioResponse>.Success(new DashLiquidityOnGetPrioResponse { Response = DataSourceLoader.Load(AppConst.PriorityResources, request.Request.options) });
    }
}