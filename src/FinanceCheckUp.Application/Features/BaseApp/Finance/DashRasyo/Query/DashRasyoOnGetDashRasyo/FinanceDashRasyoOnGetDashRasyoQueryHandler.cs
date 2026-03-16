using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Responses.Finance.DashRasyo;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.DashRasyo.Query.DashRasyoOnGetDashRasyo;
public class FinanceDashRasyoOnGetDashRasyoQueryHandler(IDashBoardRasyoManager dashBoardRasyoManager) : IRequestHandler<FinanceDashRasyoOnGetDashRasyoQuery, GenericResult<FinanceDashRasyoOnGetDashRasyoResponse>>
{
    public Task<GenericResult<FinanceDashRasyoOnGetDashRasyoResponse>> Handle(FinanceDashRasyoOnGetDashRasyoQuery request, CancellationToken cancellationToken)
    {
        var userId = Convert.ToInt64(request.UserId);
        request.InitialModel.dashrasyo = dashBoardRasyoManager.Get_List();

        return Task.FromResult(GenericResult<FinanceDashRasyoOnGetDashRasyoResponse>.Success(new FinanceDashRasyoOnGetDashRasyoResponse
        {
            Response = new JsonResult(DataSourceLoader.Load(request.InitialModel.dashrasyo, request.Request.options))
        }));

    }
}
