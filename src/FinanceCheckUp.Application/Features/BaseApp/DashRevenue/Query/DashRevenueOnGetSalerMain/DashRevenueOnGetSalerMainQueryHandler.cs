using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Responses.DashRevenue;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
namespace FinanceCheckUp.Application.Features.BaseApp.DashRevenue.Query.DashRevenueOnGetSalerMain;
public class DashRevenueOnGetSalerMainQueryHandler(IDataManager dataManager) : IRequestHandler<DashRevenueOnGetSalerMainQuery, GenericResult<DashRevenueOnGetSalerMainResponse>>
{

    public async Task<GenericResult<DashRevenueOnGetSalerMainResponse>> Handle(DashRevenueOnGetSalerMainQuery request, CancellationToken cancellationToken)
    {
        var dt1 = "105";
        var winModelTlist = dataManager.Get_AllbyCsvID(dt1);
                return GenericResult<DashRevenueOnGetSalerMainResponse>.Success(new DashRevenueOnGetSalerMainResponse { Response = DataSourceLoader.Load(winModelTlist, request.Request.Options) });
    }
}