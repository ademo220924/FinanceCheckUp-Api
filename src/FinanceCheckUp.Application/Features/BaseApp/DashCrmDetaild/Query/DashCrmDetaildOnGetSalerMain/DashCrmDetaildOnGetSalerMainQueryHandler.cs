using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Responses.DashCrmDetaild;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace FinanceCheckUp.Application.Features.BaseApp.DashCrmDetaild.Query.DashCrmDetaildOnGetSalerMain;
public class DashCrmDetaildOnGetSalerMainQueryHandler(IDataManager dataManager) : IRequestHandler<DashCrmDetaildOnGetSalerMainQuery, GenericResult<DashCrmDetaildOnGetSalerMainResponse>>
{

    public async Task<GenericResult<DashCrmDetaildOnGetSalerMainResponse>> Handle(DashCrmDetaildOnGetSalerMainQuery request, CancellationToken cancellationToken)
    {
        var dt1 = "105";
        var winModelTlist = dataManager.Get_AllbyCsvID(dt1);
        return GenericResult<DashCrmDetaildOnGetSalerMainResponse>.Success(new DashCrmDetaildOnGetSalerMainResponse { Response = new JsonResult(DataSourceLoader.Load(winModelTlist, request.Request.Options)) });
    }
}