using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Responses.CashFlow;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinanceCheckUp.Application.Features.BaseApp.CashFlow.Query.GetGraphYear;
public class GetGraphYearQueryHandle(IHhvnUsersManager hhvnUsersManager) : IRequestHandler<GetGraphYearQuery, GenericResult<GetGraphYearResponseModel>>
{
    public async Task<GenericResult<GetGraphYearResponseModel>> Handle(GetGraphYearQuery request, CancellationToken cancellationToken)
    {
        var UserID = int.Parse(request.UserId);
        hhvnUsersManager.SetYear(request.RequestModel.Nyear, UserID);
        return GenericResult<GetGraphYearResponseModel>.Success(new GetGraphYearResponseModel { Response = new JsonResult("ok") });
    }
}

