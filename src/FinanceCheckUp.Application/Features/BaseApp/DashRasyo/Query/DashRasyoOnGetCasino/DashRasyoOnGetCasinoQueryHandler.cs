using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Common.Constants;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Responses.DashRasyo;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace FinanceCheckUp.Application.Features.BaseApp.DashRasyo.Query.DashRasyoOnGetCasino;
public class DashRasyoOnGetCasinoQueryHandler(IDashBoardManager dashBoardManager) : IRequestHandler<DashRasyoOnGetCasinoQuery, GenericResult<DashRasyoOnGetCasinoResponse>>
{

    public async Task<GenericResult<DashRasyoOnGetCasinoResponse>> Handle(DashRasyoOnGetCasinoQuery request, CancellationToken cancellationToken)
    {
        var dash = dashBoardManager.Get_ErroorList();
        return GenericResult<DashRasyoOnGetCasinoResponse>.Success(new DashRasyoOnGetCasinoResponse { Response = new JsonResult(DataSourceLoader.Load(AppConst.PriorityResources, request.Request.Options)) });
    }
}