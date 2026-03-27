using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Responses.DashCrm;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
namespace FinanceCheckUp.Application.Features.BaseApp.DashCrm.Query.DashCrmOnGetDashRasyo;
public class DashCrmOnGetDashRasyoQueryHandler(IDashBoardRasyoManager dashBoardRasyoManager) : IRequestHandler<DashCrmOnGetDashRasyoQuery, GenericResult<DashCrmOnGetDashRasyoResponse>>
{

    public async Task<GenericResult<DashCrmOnGetDashRasyoResponse>> Handle(DashCrmOnGetDashRasyoQuery request, CancellationToken cancellationToken)
    {
        var dashrasyo = dashBoardRasyoManager.Get_List();
                return GenericResult<DashCrmOnGetDashRasyoResponse>.Success(new DashCrmOnGetDashRasyoResponse { Response = DataSourceLoader.Load(dashrasyo, request.Request.Options) });
    }
}