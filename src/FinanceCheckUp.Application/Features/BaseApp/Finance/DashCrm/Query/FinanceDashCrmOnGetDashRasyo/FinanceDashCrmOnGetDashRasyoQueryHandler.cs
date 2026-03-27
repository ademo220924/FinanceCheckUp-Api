using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Application.Models.Responses.Finance.DashCrm;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
namespace FinanceCheckUp.Application.Features.BaseApp.Finance.DashCrm.Query.FinanceDashCrmOnGetDashRasyo;
public class FinanceDashCrmOnGetDashRasyoQueryHandler(IDashBoardRasyoManager dashBoardRasyoManager) : IRequestHandler<FinanceDashCrmOnGetDashRasyoQuery, GenericResult<FinanceDashCrmOnGetDashRasyoResponse>>
{
    public Task<GenericResult<FinanceDashCrmOnGetDashRasyoResponse>> Handle(FinanceDashCrmOnGetDashRasyoQuery request, CancellationToken cancellationToken)
    {
        var userId = Convert.ToInt64(request.UserId);
        request.InitialModel.dashrasyo = dashBoardRasyoManager.Get_List();

                return Task.FromResult(GenericResult<FinanceDashCrmOnGetDashRasyoResponse>.Success(new FinanceDashCrmOnGetDashRasyoResponse
        {
            Response = DataSourceLoader.Load(request.InitialModel.dashrasyo, request.Request.options)
        }));

    }
}
