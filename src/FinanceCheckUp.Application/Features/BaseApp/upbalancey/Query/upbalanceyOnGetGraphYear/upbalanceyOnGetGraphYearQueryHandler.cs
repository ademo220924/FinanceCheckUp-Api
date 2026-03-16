using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Responses.upbalancey;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinanceCheckUp.Application.Features.BaseApp.upbalancey.Query.upbalanceyOnGetGraphYear;
public class upbalanceyOnGetGraphYearQueryHandler(IHhvnUsersManager hhvnUsersManager) : IRequestHandler<upbalanceyOnGetGraphYearQuery, GenericResult<upbalanceyOnGetGraphYearResponse>>
{

    public async Task<GenericResult<upbalanceyOnGetGraphYearResponse>> Handle(upbalanceyOnGetGraphYearQuery request, CancellationToken cancellationToken)
    {
        var UserID = Convert.ToInt32(request.UserId);
        hhvnUsersManager.SetYear(request.Request.nyear, UserID);
        return GenericResult<upbalanceyOnGetGraphYearResponse>.Success(new upbalanceyOnGetGraphYearResponse { Result = new JsonResult("ok") });
    }
}