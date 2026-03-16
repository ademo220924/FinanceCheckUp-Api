using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Responses.dashbilancomzn;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinanceCheckUp.Application.Features.BaseApp.dashbilancomzn.Query.dashbilancomznOnGetSalerMain;
public class dashbilancomznOnGetSalerMainQueryHandler(IDataManager dataManager) : IRequestHandler<dashbilancomznOnGetSalerMainQuery, GenericResult<dashbilancomznOnGetSalerMainResponse>>
{

    public async Task<GenericResult<dashbilancomznOnGetSalerMainResponse>> Handle(dashbilancomznOnGetSalerMainQuery request, CancellationToken cancellationToken)
    {
        var dt1 = "105";
        var winModelTlist = dataManager.Get_AllbyCsvID(dt1);
        return GenericResult<dashbilancomznOnGetSalerMainResponse>.Success(new dashbilancomznOnGetSalerMainResponse { Result = new JsonResult(DataSourceLoader.Load(winModelTlist, request.Request.DataSourceLoadOptions)) });
    }
}