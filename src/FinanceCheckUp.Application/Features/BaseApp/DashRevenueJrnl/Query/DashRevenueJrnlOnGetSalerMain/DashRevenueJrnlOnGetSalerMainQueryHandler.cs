using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Responses.DashRevenueJrnl;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
namespace FinanceCheckUp.Application.Features.BaseApp.DashRevenueJrnl.Query.DashRevenueJrnlOnGetSalerMain;
public class DashRevenueJrnlOnGetSalerMainQueryHandler(IDataManager dataManager) : IRequestHandler<DashRevenueJrnlOnGetSalerMainQuery, GenericResult<DashRevenueJrnlOnGetSalerMainResponse>>
{

    public async Task<GenericResult<DashRevenueJrnlOnGetSalerMainResponse>> Handle(DashRevenueJrnlOnGetSalerMainQuery request, CancellationToken cancellationToken)
    {
        var dt1 = "105";
        var winModelTlist = dataManager.Get_AllbyCsvID(dt1);
                return GenericResult<DashRevenueJrnlOnGetSalerMainResponse>.Success(new DashRevenueJrnlOnGetSalerMainResponse { Response = DataSourceLoader.Load(winModelTlist, request.Request.Options) });
    }
}