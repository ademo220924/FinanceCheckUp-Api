using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Responses.upbalance;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinanceCheckUp.Application.Features.BaseApp.upbalance.Query.upbalanceOnGetGraphYear;
public class upbalanceOnGetGraphYearQueryHandler(IHhvnUsersManager hhvnUsersManager) : IRequestHandler<upbalanceOnGetGraphYearQuery, GenericResult<upbalanceOnGetGraphYearResponse>>
{

    public async Task<GenericResult<upbalanceOnGetGraphYearResponse>> Handle(upbalanceOnGetGraphYearQuery request, CancellationToken cancellationToken)
    {
        var UserID = Convert.ToInt32(request.UserId);
        hhvnUsersManager.SetYear(request.Request.nyear, UserID);
        return GenericResult<upbalanceOnGetGraphYearResponse>.Success(new upbalanceOnGetGraphYearResponse { Result = new JsonResult("ok") });
    }
}