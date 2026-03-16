using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Responses.DashCrmDetail;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace FinanceCheckUp.Application.Features.BaseApp.DashCrmDetail.Query.DashCrmDetailOnGetSalerMain;
public class DashCrmDetailOnGetSalerMainQueryHandler(IDataManager dataManager) : IRequestHandler<DashCrmDetailOnGetSalerMainQuery, GenericResult<DashCrmDetailOnGetSalerMainResponse>>
{

    public async Task<GenericResult<DashCrmDetailOnGetSalerMainResponse>> Handle(DashCrmDetailOnGetSalerMainQuery request, CancellationToken cancellationToken)
    {
        var dt1 = "105";
        var winModelTlist = dataManager.Get_AllbyCsvID(dt1);
        return GenericResult<DashCrmDetailOnGetSalerMainResponse>.Success(new DashCrmDetailOnGetSalerMainResponse { Response = new JsonResult(DataSourceLoader.Load(winModelTlist, request.Request.Options)) });
    }
}