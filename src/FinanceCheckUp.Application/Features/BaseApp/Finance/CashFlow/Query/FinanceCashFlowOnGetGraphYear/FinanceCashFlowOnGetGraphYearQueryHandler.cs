using FinanceCheckUp.Framework.Core.Models;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Responses.Finance.CashFlow;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.CashFlow.Query.FinanceCashFlowOnGetGraphYear;

public class FinanceCashFlowOnGetGraphYearQueryHandler(IHhvnUsersManager hhvnUsersManager) : IRequestHandler<FinanceCashFlowOnGetGraphYearQuery, GenericResult<FinanceCashFlowOnGetGraphYearResponse>>
{
    public Task<GenericResult<FinanceCashFlowOnGetGraphYearResponse>> Handle(FinanceCashFlowOnGetGraphYearQuery request, CancellationToken cancellationToken)
    {
        var userId = Convert.ToInt64(request.UserId);
        hhvnUsersManager.SetYear(request.Request.nyear, userId);
        return Task.FromResult(GenericResult<FinanceCashFlowOnGetGraphYearResponse>.Success(new FinanceCashFlowOnGetGraphYearResponse
        {
            Response = new JsonResult("ok"),
            InitialModel = request.InitialModel
        }));
    }
}
