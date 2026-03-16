using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Responses.dashbilancoakt;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace FinanceCheckUp.Application.Features.BaseApp.dashbilancoakt.Query.dashbilancoaktOnGetGraphYear;
public class dashbilancoaktOnGetGraphYearQueryHandler(IHhvnUsersManager hhvnUsersManager) : IRequestHandler<dashbilancoaktOnGetGraphYearQuery, GenericResult<dashbilancoaktOnGetGraphYearResponse>>
{
    public async Task<GenericResult<dashbilancoaktOnGetGraphYearResponse>> Handle(dashbilancoaktOnGetGraphYearQuery request, CancellationToken cancellationToken)
    {
        var UserID = Convert.ToInt32(request.UserId);
        hhvnUsersManager.SetYear(request.Request.nyear, UserID);
        return GenericResult<dashbilancoaktOnGetGraphYearResponse>.Success(new dashbilancoaktOnGetGraphYearResponse { Result = new JsonResult("ok") });
    }
}