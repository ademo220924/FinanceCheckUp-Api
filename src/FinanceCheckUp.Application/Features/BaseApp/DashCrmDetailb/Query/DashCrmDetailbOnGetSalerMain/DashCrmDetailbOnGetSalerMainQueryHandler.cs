using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Responses.DashCrmDetailb;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace FinanceCheckUp.Application.Features.BaseApp.DashCrmDetailb.Query.DashCrmDetailbOnGetSalerMain;
public class DashCrmDetailbOnGetSalerMainQueryHandler(IDataManager dataManager) : IRequestHandler<DashCrmDetailbOnGetSalerMainQuery, GenericResult<DashCrmDetailbOnGetSalerMainResponse>>
{

    public async Task<GenericResult<DashCrmDetailbOnGetSalerMainResponse>> Handle(DashCrmDetailbOnGetSalerMainQuery request, CancellationToken cancellationToken)
    {
        var dt1 = "105";
        var winModelTlist = dataManager.Get_AllbyCsvID(dt1);
        return GenericResult<DashCrmDetailbOnGetSalerMainResponse>.Success(new DashCrmDetailbOnGetSalerMainResponse { Response = new JsonResult(DataSourceLoader.Load(winModelTlist, request.Request.Options)) });
    }

}