using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Responses.DashCrmDetailc;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace FinanceCheckUp.Application.Features.BaseApp.DashCrmDetailc.Query.DashCrmDetailcOnGetSalerMain;
public class DashCrmDetailcOnGetSalerMainQueryHandler(IDataManager dataManager) : IRequestHandler<DashCrmDetailcOnGetSalerMainQuery, GenericResult<DashCrmDetailcOnGetSalerMainResponse>>
{

    public async Task<GenericResult<DashCrmDetailcOnGetSalerMainResponse>> Handle(DashCrmDetailcOnGetSalerMainQuery request, CancellationToken cancellationToken)
    {
        var dt1 = "105";
        var winModelTlist = dataManager.Get_AllbyCsvID(dt1);
        return GenericResult<DashCrmDetailcOnGetSalerMainResponse>.Success(new DashCrmDetailcOnGetSalerMainResponse { Response = new JsonResult(DataSourceLoader.Load(winModelTlist, request.Request.Options)) });
    }
}