using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Responses.dashbilancomlt;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace FinanceCheckUp.Application.Features.BaseApp.dashbilancomlt.Query.dashbilancomltOnGetGraphYear;
public class dashbilancomltOnGetGraphYearQueryHandler(IHhvnUsersManager hhvnUsersManager) : IRequestHandler<dashbilancomltOnGetGraphYearQuery, GenericResult<dashbilancomltOnGetGraphYearResponse>>
{

    public async Task<GenericResult<dashbilancomltOnGetGraphYearResponse>> Handle(dashbilancomltOnGetGraphYearQuery request, CancellationToken cancellationToken)
    {
        var UserID = Convert.ToInt32(request.UserId);
        hhvnUsersManager.SetYear(request.Request.nyear, UserID);
        return GenericResult<dashbilancomltOnGetGraphYearResponse>.Success(new dashbilancomltOnGetGraphYearResponse { Result = new JsonResult("ok") });
    }
}