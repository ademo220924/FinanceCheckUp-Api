using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Responses.DashBoard;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinanceCheckUp.Application.Features.BaseApp.DashBoard.Query.DashBoardOnGetGraphYear;
public class DashBoardOnGetGraphYearQueryHandler(IHhvnUsersManager hhvnUsersManager) : IRequestHandler<DashBoardOnGetGraphYearQuery, GenericResult<DashBoardOnGetGraphYearResponse>>
{
    public async Task<GenericResult<DashBoardOnGetGraphYearResponse>> Handle(DashBoardOnGetGraphYearQuery request, CancellationToken cancellationToken)
    {
        var UserID = Convert.ToInt32(request.UserId);
        hhvnUsersManager.SetYear(request.Request.nyear, UserID);
        return GenericResult<DashBoardOnGetGraphYearResponse>.Success(new DashBoardOnGetGraphYearResponse { Result = new JsonResult("ok") });
    }
}