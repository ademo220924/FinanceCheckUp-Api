using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Responses.DashRasyo;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
namespace FinanceCheckUp.Application.Features.BaseApp.DashRasyo.Query.DashRasyoOnGetDashRasyo;
public class DashRasyoOnGetDashRasyoQueryHandler(IDashBoardRasyoManager dashBoardRasyoManager) : IRequestHandler<DashRasyoOnGetDashRasyoQuery, GenericResult<DashRasyoOnGetDashRasyoResponse>>
{

    public async Task<GenericResult<DashRasyoOnGetDashRasyoResponse>> Handle(DashRasyoOnGetDashRasyoQuery request, CancellationToken cancellationToken)
    {
        var dashrasyo = dashBoardRasyoManager.Get_List();
                return GenericResult<DashRasyoOnGetDashRasyoResponse>.Success(new DashRasyoOnGetDashRasyoResponse { Response = DataSourceLoader.Load(dashrasyo, request.Request.Options) });
    }
}