using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Responses.DashCpmNew;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinanceCheckUp.Application.Features.BaseApp.DashCpmNew.Query.DashCpmNewOnGetCasino;

public class DashCpmNewOnGetCasinoQueryHandler(IDashBoardManager dashBoardManager) : IRequestHandler<DashCpmNewOnGetCasinoQuery, GenericResult<DashCpmNewOnGetCasinoResponse>>
{

    public async Task<GenericResult<DashCpmNewOnGetCasinoResponse>> Handle(DashCpmNewOnGetCasinoQuery request, CancellationToken cancellationToken)
    {
        var dash = dashBoardManager.Get_ErroorList();
        return GenericResult<DashCpmNewOnGetCasinoResponse>.Success(new DashCpmNewOnGetCasinoResponse { Response = new JsonResult(DataSourceLoader.Load(dash, request.Options)) });
    }

}