using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Responses.dashbilancorvnmzn;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace FinanceCheckUp.Application.Features.BaseApp.dashbilancorvnmzn.Query.dashbilancorvnmznOnGetSalerMain;
public class dashbilancorvnmznOnGetSalerMainQueryHandler(IDataManager dataManager) : IRequestHandler<dashbilancorvnmznOnGetSalerMainQuery, GenericResult<dashbilancorvnmznOnGetSalerMainResponse>>
{
    public async Task<GenericResult<dashbilancorvnmznOnGetSalerMainResponse>> Handle(dashbilancorvnmznOnGetSalerMainQuery request, CancellationToken cancellationToken)
    {
        var dt1 = "105";
        var winModelTlist = dataManager.Get_AllbyCsvID(dt1);
        return GenericResult<dashbilancorvnmznOnGetSalerMainResponse>.Success(new dashbilancorvnmznOnGetSalerMainResponse { Result = new JsonResult(DataSourceLoader.Load(winModelTlist, request.Request.DataSourceLoadOptions)) });
    }
}