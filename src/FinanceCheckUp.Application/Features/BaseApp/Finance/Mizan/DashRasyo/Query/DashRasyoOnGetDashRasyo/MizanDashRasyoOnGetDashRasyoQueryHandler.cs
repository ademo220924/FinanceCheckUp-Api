using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Requests.Finance.Mizan.DashRasyo;
using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.DashRasyo;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.DashRasyo.Query.DashRasyoOnGetDashRasyo;
public class MizanDashRasyoOnGetDashRasyoQueryHandler(IDashBoardRasyoManager dashBoardRasyoManager) : IRequestHandler<MizanDashRasyoOnGetDashRasyoQuery, GenericResult<MizanDashRasyoOnGetDashRasyoResponse>>
{
    public MizanDashRasyoRequestInitialModel responseModel = new();

    public Task<GenericResult<MizanDashRasyoOnGetDashRasyoResponse>> Handle(MizanDashRasyoOnGetDashRasyoQuery request, CancellationToken cancellationToken)
    {
        request.InitialModel.dashrasyo = dashBoardRasyoManager.Get_List();

        return Task.FromResult(GenericResult<MizanDashRasyoOnGetDashRasyoResponse>.Success(
            new MizanDashRasyoOnGetDashRasyoResponse
            {
                Response = new JsonResult(DataSourceLoader.Load(request.InitialModel.dashrasyo, request.Request.options)),
                InitialModel = request.InitialModel
            }));
         
    }
}
