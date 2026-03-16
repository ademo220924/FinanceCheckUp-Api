using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Responses.upbalance;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinanceCheckUp.Application.Features.BaseApp.upbalance.Query.upbalanceOnGetGraphComp;
public class upbalanceOnGetGraphCompQueryHandler(IHhvnUsersManager hhvnUsersManager, IUserCompanyManager userCompanyManager) : IRequestHandler<upbalanceOnGetGraphCompQuery, GenericResult<upbalanceOnGetGraphCompResponse>>
{

    public async Task<GenericResult<upbalanceOnGetGraphCompResponse>> Handle(upbalanceOnGetGraphCompQuery request, CancellationToken cancellationToken)
    {
        var UserID = Convert.ToInt32(request.UserId);

        if (request.Request.ncompid < 1)
            return GenericResult<upbalanceOnGetGraphCompResponse>.Success(new upbalanceOnGetGraphCompResponse { Result = new JsonResult("nok") });

        if (hhvnUsersManager.CheckUser(request.Request.ncompid, UserID))
            userCompanyManager.Update_UserDefault(UserID, request.Request.ncompid);

        return GenericResult<upbalanceOnGetGraphCompResponse>.Success(new upbalanceOnGetGraphCompResponse { Result = new JsonResult("ok") });
    }
}