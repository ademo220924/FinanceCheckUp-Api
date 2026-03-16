using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Responses.dashbilancorvnakt;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinanceCheckUp.Application.Features.BaseApp.dashbilancorvnakt.Query.dashbilancorvnaktOnGetGraphYear;
public class dashbilancorvnaktOnGetGraphYearQueryHandler(IHhvnUsersManager hhvnUsersManager) : IRequestHandler<dashbilancorvnaktOnGetGraphYearQuery, GenericResult<dashbilancorvnaktOnGetGraphYearResponse>>
{

    public async Task<GenericResult<dashbilancorvnaktOnGetGraphYearResponse>> Handle(dashbilancorvnaktOnGetGraphYearQuery request, CancellationToken cancellationToken)
    {
        var UserID = Convert.ToInt32(request.UserId);
        hhvnUsersManager.SetYear(request.Request.nyear, UserID);
        return GenericResult<dashbilancorvnaktOnGetGraphYearResponse>.Success(new dashbilancorvnaktOnGetGraphYearResponse { Result = new JsonResult("ok") });
    }
}