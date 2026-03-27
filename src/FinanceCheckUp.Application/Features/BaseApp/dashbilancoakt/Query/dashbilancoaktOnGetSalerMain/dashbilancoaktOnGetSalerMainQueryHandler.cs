using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Responses.dashbilancoakt;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
namespace FinanceCheckUp.Application.Features.BaseApp.dashbilancoakt.Query.dashbilancoaktOnGetSalerMain;
public class dashbilancoaktOnGetSalerMainQueryHandler(IDataManager dataManager) : IRequestHandler<dashbilancoaktOnGetSalerMainQuery, GenericResult<dashbilancoaktOnGetSalerMainResponse>>
{

    public async Task<GenericResult<dashbilancoaktOnGetSalerMainResponse>> Handle(dashbilancoaktOnGetSalerMainQuery request, CancellationToken cancellationToken)
    {
        var dt1 = "105";
        var winModelTlist = dataManager.Get_AllbyCsvID(dt1);
                return GenericResult<dashbilancoaktOnGetSalerMainResponse>.Success(new dashbilancoaktOnGetSalerMainResponse { Result = DataSourceLoader.Load(winModelTlist, request.Request.DataSourceLoadOptions) });
    }
}