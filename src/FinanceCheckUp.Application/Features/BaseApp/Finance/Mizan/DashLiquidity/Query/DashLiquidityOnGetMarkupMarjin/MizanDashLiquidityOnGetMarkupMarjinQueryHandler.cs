using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.DashLiquidity;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.DashLiquidity.Query.DashLiquidityOnGetMarkupMarjin;
public class MizanDashLiquidityOnGetMarkupMarjinQueryHandler(IDashLikiditeMizanManager dashLikiditeMizanManager) : IRequestHandler<MizanDashLiquidityOnGetMarkupMarjinQuery, GenericResult<MizanDashLiquidityOnGetMarkupMarjinResponse>>
{
    public Task<GenericResult<MizanDashLiquidityOnGetMarkupMarjinResponse>> Handle(MizanDashLiquidityOnGetMarkupMarjinQuery request, CancellationToken cancellationToken)
    {
        var nRequestList = dashLikiditeMizanManager.Get_MAINRESULTMultiMain(request.Request.compid);
        request.InitialModel.nRequestList = nRequestList;
        
                return Task.FromResult(GenericResult<MizanDashLiquidityOnGetMarkupMarjinResponse>.Success(
            new MizanDashLiquidityOnGetMarkupMarjinResponse
            {
                Response = DataSourceLoader.Load(nRequestList, request.Request.options),
                InitialModel = request.InitialModel
            }));
    }
}
