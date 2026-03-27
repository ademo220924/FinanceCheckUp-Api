using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Responses.dashbilancorvnmlt;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
namespace FinanceCheckUp.Application.Features.BaseApp.dashbilancorvnmlt.Query.dashbilancorvnmltOnGetSalerMain;
public class dashbilancorvnmltOnGetSalerMainQueryHandler(IDataManager dataManager) : IRequestHandler<dashbilancorvnmltOnGetSalerMainQuery, GenericResult<dashbilancorvnmltOnGetSalerMainResponse>>
{

    public async Task<GenericResult<dashbilancorvnmltOnGetSalerMainResponse>> Handle(dashbilancorvnmltOnGetSalerMainQuery request, CancellationToken cancellationToken)
    {
        var dt1 = "105";
        var winModelTlist = dataManager.Get_AllbyCsvID(dt1);
                return GenericResult<dashbilancorvnmltOnGetSalerMainResponse>.Success(new dashbilancorvnmltOnGetSalerMainResponse { Result = DataSourceLoader.Load(winModelTlist, request.Request.DataSourceLoadOptions) });
    }
}