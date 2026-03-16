using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Responses.Finance.DashCrm;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.DashCrm.Query.FinanceDashCrmOnGetCasino;
public class FinanceDashCrmOnGetCasinoQueryHandler(IDashBoardManager dashBoardManager) : IRequestHandler<FinanceDashCrmOnGetCasinoQuery, GenericResult<FinanceDashCrmOnGetCasinoResponse>>
{
    public Task<GenericResult<FinanceDashCrmOnGetCasinoResponse>> Handle(FinanceDashCrmOnGetCasinoQuery request, CancellationToken cancellationToken)
    {
        var userId = Convert.ToInt64(request.UserId);
        request.InitialModel.dash = dashBoardManager.Get_ErroorList();

        return Task.FromResult(GenericResult<FinanceDashCrmOnGetCasinoResponse>.Success(new FinanceDashCrmOnGetCasinoResponse
        {
            Response = new JsonResult(DataSourceLoader.Load(request.InitialModel.dash, request.Request.options))
        }));

    }
}
