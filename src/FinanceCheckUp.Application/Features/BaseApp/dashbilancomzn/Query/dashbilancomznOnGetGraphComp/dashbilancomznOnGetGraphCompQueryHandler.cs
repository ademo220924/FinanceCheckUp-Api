using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Responses.dashbilancomzn;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace FinanceCheckUp.Application.Features.BaseApp.dashbilancomzn.Query.dashbilancomznOnGetGraphComp;
public class dashbilancomznOnGetGraphCompQueryHandler(IHhvnUsersManager hhvnUsersManager, IUserCompanyManager userCompanyManager) : IRequestHandler<dashbilancomznOnGetGraphCompQuery, GenericResult<dashbilancomznOnGetGraphCompResponse>>
{

    public async Task<GenericResult<dashbilancomznOnGetGraphCompResponse>> Handle(dashbilancomznOnGetGraphCompQuery request, CancellationToken cancellationToken)
    {
        var UserID = Convert.ToInt32(request.UserId);

        if (request.Request.ncompid < 1)
            return GenericResult<dashbilancomznOnGetGraphCompResponse>.Success(new dashbilancomznOnGetGraphCompResponse { Result = new JsonResult("nok") });

        if (!hhvnUsersManager.CheckUser(request.Request.ncompid, UserID))
            return GenericResult<dashbilancomznOnGetGraphCompResponse>.Success(new dashbilancomznOnGetGraphCompResponse { Result = new JsonResult("ok") });

        userCompanyManager.Update_UserDefault(UserID, request.Request.ncompid);
        return GenericResult<dashbilancomznOnGetGraphCompResponse>.Success(new dashbilancomznOnGetGraphCompResponse { Result = new JsonResult("ok") });
    }
}