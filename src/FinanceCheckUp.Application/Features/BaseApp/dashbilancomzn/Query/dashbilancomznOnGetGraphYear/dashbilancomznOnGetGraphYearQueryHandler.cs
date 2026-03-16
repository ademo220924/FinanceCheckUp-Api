using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Responses.dashbilancomzn;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinanceCheckUp.Application.Features.BaseApp.dashbilancomzn.Query.dashbilancomznOnGetGraphYear;
public class dashbilancomznOnGetGraphYearQueryHandler(IHhvnUsersManager hhvnUsersManager) : IRequestHandler<dashbilancomznOnGetGraphYearQuery, GenericResult<dashbilancomznOnGetGraphYearResponse>>
{

    public async Task<GenericResult<dashbilancomznOnGetGraphYearResponse>> Handle(dashbilancomznOnGetGraphYearQuery request, CancellationToken cancellationToken)
    {
        var UserID = Convert.ToInt32(request.UserId);
        hhvnUsersManager.SetYear(request.Request.nyear, UserID);
        return GenericResult<dashbilancomznOnGetGraphYearResponse>.Success(new dashbilancomznOnGetGraphYearResponse { Result = new JsonResult("ok") });
    }
}