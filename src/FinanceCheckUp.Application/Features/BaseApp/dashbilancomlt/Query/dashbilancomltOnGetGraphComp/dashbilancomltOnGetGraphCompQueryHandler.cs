using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Responses.dashbilancomlt;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace FinanceCheckUp.Application.Features.BaseApp.dashbilancomlt.Query.dashbilancomltOnGetGraphComp;
public class dashbilancomltOnGetGraphCompQueryHandler(IHhvnUsersManager hhvnUsersManager, IUserCompanyManager userCompanyManager) : IRequestHandler<dashbilancomltOnGetGraphCompQuery, GenericResult<dashbilancomltOnGetGraphCompResponse>>
{

    public async Task<GenericResult<dashbilancomltOnGetGraphCompResponse>> Handle(dashbilancomltOnGetGraphCompQuery request, CancellationToken cancellationToken)
    {
        var UserID = Convert.ToInt32(request.UserId);

        if (request.Request.ncompid < 1)
            return GenericResult<dashbilancomltOnGetGraphCompResponse>.Success(new dashbilancomltOnGetGraphCompResponse { Result = new JsonResult("nok") });

        if (!hhvnUsersManager.CheckUser(request.Request.ncompid, UserID))
            return GenericResult<dashbilancomltOnGetGraphCompResponse>.Success(new dashbilancomltOnGetGraphCompResponse { Result = new JsonResult("ok") });

        userCompanyManager.Update_UserDefault(UserID, request.Request.ncompid);
        return GenericResult<dashbilancomltOnGetGraphCompResponse>.Success(new dashbilancomltOnGetGraphCompResponse { Result = new JsonResult("ok") });
    }
}