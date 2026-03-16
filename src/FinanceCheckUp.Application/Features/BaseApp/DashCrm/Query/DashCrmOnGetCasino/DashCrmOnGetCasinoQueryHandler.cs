using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Responses.DashCrm;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace FinanceCheckUp.Application.Features.BaseApp.DashCrm.Query.DashCrmOnGetCasino;
public class DashCrmOnGetCasinoQueryHandler(IDashBoardManager dashBoardManager) : IRequestHandler<DashCrmOnGetCasinoQuery, GenericResult<DashCrmOnGetCasinoResponse>>
{
    public async Task<GenericResult<DashCrmOnGetCasinoResponse>> Handle(DashCrmOnGetCasinoQuery request, CancellationToken cancellationToken)
    {
        var dash = dashBoardManager.Get_ErroorList();
        return GenericResult<DashCrmOnGetCasinoResponse>.Success(new DashCrmOnGetCasinoResponse { Response = new JsonResult(DataSourceLoader.Load(dash, request.Request.Options)) });
    }
}