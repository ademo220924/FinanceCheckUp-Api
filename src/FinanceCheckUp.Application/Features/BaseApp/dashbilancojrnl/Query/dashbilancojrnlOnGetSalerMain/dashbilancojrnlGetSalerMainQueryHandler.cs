using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Responses.dashbilancojrnl;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace FinanceCheckUp.Application.Features.BaseApp.dashbilancojrnl.Query.dashbilancojrnlOnGetSalerMain;
public class dashbilancojrnlOnGetSalerMainQueryHandler(IDataManager dataManager) : IRequestHandler<dashbilancojrnlOnGetSalerMainQuery, GenericResult<dashbilancojrnlOnGetSalerMainResponse>>
{

    public async Task<GenericResult<dashbilancojrnlOnGetSalerMainResponse>> Handle(dashbilancojrnlOnGetSalerMainQuery request, CancellationToken cancellationToken)
    {
        var dt1 = "105";
        var winModelTlist = dataManager.Get_AllbyCsvID(dt1);
        return GenericResult<dashbilancojrnlOnGetSalerMainResponse>.Success(new dashbilancojrnlOnGetSalerMainResponse { Result = new JsonResult(DataSourceLoader.Load(winModelTlist, request.Request.Options)) });
    }
}