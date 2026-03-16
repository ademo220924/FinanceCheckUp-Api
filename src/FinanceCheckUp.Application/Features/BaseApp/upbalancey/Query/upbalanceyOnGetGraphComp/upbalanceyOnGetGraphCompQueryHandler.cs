using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Responses.upbalancey;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace FinanceCheckUp.Application.Features.BaseApp.upbalancey.Query.upbalanceyOnGetGraphComp;
public class upbalanceyOnGetGraphCompQueryHandler(IHhvnUsersManager hhvnUsersManager, IUserCompanyManager userCompanyManager) : IRequestHandler<upbalanceyOnGetGraphCompQuery, GenericResult<upbalanceyOnGetGraphCompResponse>>
{

    public async Task<GenericResult<upbalanceyOnGetGraphCompResponse>> Handle(upbalanceyOnGetGraphCompQuery request, CancellationToken cancellationToken)
    {
        var UserID = Convert.ToInt32(request.UserId);

        if (request.Request.ncompid < 1)
            return GenericResult<upbalanceyOnGetGraphCompResponse>.Success(new upbalanceyOnGetGraphCompResponse { Result = new JsonResult("nok") });


        if (hhvnUsersManager.CheckUser(request.Request.ncompid, UserID))
            userCompanyManager.Update_UserDefault(UserID, request.Request.ncompid);

        return GenericResult<upbalanceyOnGetGraphCompResponse>.Success(new upbalanceyOnGetGraphCompResponse { Result = new JsonResult("ok") });
    }
}