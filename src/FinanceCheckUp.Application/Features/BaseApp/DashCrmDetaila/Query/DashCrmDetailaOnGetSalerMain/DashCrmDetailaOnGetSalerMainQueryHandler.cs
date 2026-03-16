using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Responses.DashCrmDetaila;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace FinanceCheckUp.Application.Features.BaseApp.DashCrmDetaila.Query.DashCrmDetailaOnGetSalerMain;
public class DashCrmDetailaOnGetSalerMainQueryHandler(IDataManager dataManager) : IRequestHandler<DashCrmDetailaOnGetSalerMainQuery, GenericResult<DashCrmDetailaOnGetSalerMainResponse>>
{

    public async Task<GenericResult<DashCrmDetailaOnGetSalerMainResponse>> Handle(DashCrmDetailaOnGetSalerMainQuery request, CancellationToken cancellationToken)
    {
        var dt1 = "105";
        var winModelTlist = dataManager.Get_AllbyCsvID(dt1);
        return GenericResult<DashCrmDetailaOnGetSalerMainResponse>.Success(new DashCrmDetailaOnGetSalerMainResponse { Response = new JsonResult(DataSourceLoader.Load(winModelTlist, request.Request.Options)) });
    }
}