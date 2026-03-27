using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Responses.DashLiquidity;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
namespace FinanceCheckUp.Application.Features.BaseApp.DashLiquidity.Query.DashLiquidityOnGetSalerMain;
public class DashLiquidityOnGetSalerMainQueryHandler(IDataManager dataManager) : IRequestHandler<DashLiquidityOnGetSalerMainQuery, GenericResult<DashLiquidityOnGetSalerMainResponse>>
{

    public async Task<GenericResult<DashLiquidityOnGetSalerMainResponse>> Handle(DashLiquidityOnGetSalerMainQuery request, CancellationToken cancellationToken)
    {
        var dt1 = "105";
        var winModelTlist = dataManager.Get_AllbyCsvID(dt1);
                return GenericResult<DashLiquidityOnGetSalerMainResponse>.Success(new DashLiquidityOnGetSalerMainResponse { Response = DataSourceLoader.Load(winModelTlist, request.Request.Options) });
    }
}