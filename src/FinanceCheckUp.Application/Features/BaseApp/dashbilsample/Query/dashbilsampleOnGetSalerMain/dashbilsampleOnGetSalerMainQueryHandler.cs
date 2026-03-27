using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Responses.dashbilsample;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
namespace FinanceCheckUp.Application.Features.BaseApp.dashbilsample.Query.dashbilsampleOnGetSalerMain;
public class dashbilsampleOnGetSalerMainQueryHandler(IDataManager dataManager) : IRequestHandler<dashbilsampleOnGetSalerMainQuery, GenericResult<dashbilsampleOnGetSalerMainResponse>>
{

    public async Task<GenericResult<dashbilsampleOnGetSalerMainResponse>> Handle(dashbilsampleOnGetSalerMainQuery request, CancellationToken cancellationToken)
    {
        var dt1 = "105";
        var winModelTlist = dataManager.Get_AllbyCsvID(dt1);
                return GenericResult<dashbilsampleOnGetSalerMainResponse>.Success(new dashbilsampleOnGetSalerMainResponse { Result = DataSourceLoader.Load(winModelTlist, request.Request.DataSourceLoadOptions) });
    }
}