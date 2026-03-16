using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Responses.dashbilancorvnmlt;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinanceCheckUp.Application.Features.BaseApp.dashbilancorvnmlt.Query.dashbilancorvnmltOnGetGraphYear;
public class dashbilancorvnmltOnGetGraphYearQueryHandler(IHhvnUsersManager hhvnUsersManager) : IRequestHandler<dashbilancorvnmltOnGetGraphYearQuery, GenericResult<dashbilancorvnmltOnGetGraphYearResponse>>
{

    public async Task<GenericResult<dashbilancorvnmltOnGetGraphYearResponse>> Handle(dashbilancorvnmltOnGetGraphYearQuery request, CancellationToken cancellationToken)
    {
        var UserID = Convert.ToInt32(request.UserId);
        hhvnUsersManager.SetYear(request.Request.nyear, UserID);
        return GenericResult<dashbilancorvnmltOnGetGraphYearResponse>.Success(new dashbilancorvnmltOnGetGraphYearResponse { Result = new JsonResult("ok") });
    }
}