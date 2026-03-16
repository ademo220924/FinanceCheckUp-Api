using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Responses.DashBoard;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;



namespace FinanceCheckUp.Application.Features.BaseApp.DashBoard.Query.DashBoardOnGetGraphComp;
public class DashBoardOnGetGraphCompQueryHandler(IHhvnUsersManager hhvnUsersManager, IUserCompanyManager userCompanyManager) : IRequestHandler<DashBoardOnGetGraphCompQuery, GenericResult<DashBoardOnGetGraphCompResponse>>
{

    public async Task<GenericResult<DashBoardOnGetGraphCompResponse>> Handle(DashBoardOnGetGraphCompQuery request, CancellationToken cancellationToken)
    {
        var UserID = Convert.ToInt32(request.UserId);

        if (request.Request.ncompid < 1)
            return GenericResult<DashBoardOnGetGraphCompResponse>.Success(new DashBoardOnGetGraphCompResponse { Result = new JsonResult("nok") });

        if (!hhvnUsersManager.CheckUser(request.Request.ncompid, UserID))
            return GenericResult<DashBoardOnGetGraphCompResponse>.Success(new DashBoardOnGetGraphCompResponse { Result = new JsonResult("ok") });

        userCompanyManager.Update_UserDefault(UserID, request.Request.ncompid);
        return GenericResult<DashBoardOnGetGraphCompResponse>.Success(new DashBoardOnGetGraphCompResponse { Result = new JsonResult("ok") });
    }
}