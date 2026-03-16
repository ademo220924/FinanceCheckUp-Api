using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Responses.dashbilancomlt;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace FinanceCheckUp.Application.Features.BaseApp.dashbilancomlt.Query.dashbilancomltOnGetSalerMain;
public class dashbilancomltOnGetSalerMainQueryHandler(IDataManager dataManager) : IRequestHandler<dashbilancomltOnGetSalerMainQuery, GenericResult<dashbilancomltOnGetSalerMainResponse>>
{
    public async Task<GenericResult<dashbilancomltOnGetSalerMainResponse>> Handle(dashbilancomltOnGetSalerMainQuery request, CancellationToken cancellationToken)
    {
        var dt1 = "105";
        var winModelTlist = dataManager.Get_AllbyCsvID(dt1);
        return GenericResult<dashbilancomltOnGetSalerMainResponse>.Success(new dashbilancomltOnGetSalerMainResponse { Result = new JsonResult(DataSourceLoader.Load(winModelTlist, request.Request.DataSourceLoadOptions)) });
    }
}