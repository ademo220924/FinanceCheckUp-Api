using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Responses.dashbilancorvnmzn;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace FinanceCheckUp.Application.Features.BaseApp.dashbilancorvnmzn.Query.dashbilancorvnmznOnGetGraphYear;
public class dashbilancorvnmznOnGetGraphYearQueryHandler(IHhvnUsersManager hhvnUsersManager) : IRequestHandler<dashbilancorvnmznOnGetGraphYearQuery, GenericResult<dashbilancorvnmznOnGetGraphYearResponse>>
{

    public async Task<GenericResult<dashbilancorvnmznOnGetGraphYearResponse>> Handle(dashbilancorvnmznOnGetGraphYearQuery request, CancellationToken cancellationToken)
    {

        var UserID = Convert.ToInt32(request.UserId);
        hhvnUsersManager.SetYear(request.Request.nyear, UserID);
        return GenericResult<dashbilancorvnmznOnGetGraphYearResponse>.Success(new dashbilancorvnmznOnGetGraphYearResponse { Result = new JsonResult("ok") });
    }
}