using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Responses.upcheck;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinanceCheckUp.Application.Features.BaseApp.upcheck.Query.upcheckOnGetGraphYear;
public class upcheckOnGetGraphYearQueryHandler(IHhvnUsersManager hhvnUsersManager) : IRequestHandler<upcheckOnGetGraphYearQuery, GenericResult<upcheckOnGetGraphYearResponse>>
{

    public async Task<GenericResult<upcheckOnGetGraphYearResponse>> Handle(upcheckOnGetGraphYearQuery request, CancellationToken cancellationToken)
    {
        var UserID = Convert.ToInt32(request.UserId);
        hhvnUsersManager.SetYear(request.Request.nyear, UserID);
        return GenericResult<upcheckOnGetGraphYearResponse>.Success(new upcheckOnGetGraphYearResponse { Result = new JsonResult("ok") });
    }
}