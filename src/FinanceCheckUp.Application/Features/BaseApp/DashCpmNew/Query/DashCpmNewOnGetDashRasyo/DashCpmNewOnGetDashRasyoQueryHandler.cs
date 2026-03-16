using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Responses.DashCpmNew;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinanceCheckUp.Application.Features.BaseApp.DashCpmNew.Query.DashCpmNewOnGetDashRasyo;
public class DashCpmNewOnGetDashRasyoQueryHandler(IDashBoardRasyoManager dashBoardRasyoManager) : IRequestHandler<DashCpmNewOnGetDashRasyoQuery, GenericResult<DashCpmNewOnGetDashRasyoResponse>>
{

    public async Task<GenericResult<DashCpmNewOnGetDashRasyoResponse>> Handle(DashCpmNewOnGetDashRasyoQuery request, CancellationToken cancellationToken)
    {
        var dashrasyo = dashBoardRasyoManager.Get_List();
        return GenericResult<DashCpmNewOnGetDashRasyoResponse>.Success(new DashCpmNewOnGetDashRasyoResponse { Response = new JsonResult(DataSourceLoader.Load(dashrasyo, request.Request.Options)) });
    }
}