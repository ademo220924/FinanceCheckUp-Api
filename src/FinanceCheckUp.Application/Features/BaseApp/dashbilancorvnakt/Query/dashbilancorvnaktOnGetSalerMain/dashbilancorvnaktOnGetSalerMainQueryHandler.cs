using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Responses.dashbilancorvnakt;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
namespace FinanceCheckUp.Application.Features.BaseApp.dashbilancorvnakt.Query.dashbilancorvnaktOnGetSalerMain;
public class dashbilancorvnaktOnGetSalerMainQueryHandler(IDataManager dataManager) : IRequestHandler<dashbilancorvnaktOnGetSalerMainQuery, GenericResult<dashbilancorvnaktOnGetSalerMainResponse>>
{

    public async Task<GenericResult<dashbilancorvnaktOnGetSalerMainResponse>> Handle(dashbilancorvnaktOnGetSalerMainQuery request, CancellationToken cancellationToken)
    {
        var dt1 = "105";
        var winModelTlist = dataManager.Get_AllbyCsvID(dt1);
                return GenericResult<dashbilancorvnaktOnGetSalerMainResponse>.Success(new dashbilancorvnaktOnGetSalerMainResponse { Result = DataSourceLoader.Load(winModelTlist, request.Request.DataSourceLoadOptions) });
    }
}