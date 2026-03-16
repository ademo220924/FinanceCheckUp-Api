using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Responses.upaccounty;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;



namespace FinanceCheckUp.Application.Features.BaseApp.upaccounty.Query.upaccountyOnGetGraphComp;
public class upaccountyOnGetGraphCompQueryHandler(IHhvnUsersManager hhvnUsersManager, IUserCompanyManager userCompanyManager) : IRequestHandler<upaccountyOnGetGraphCompQuery, GenericResult<upaccountyOnGetGraphCompResponse>>
{

    public async Task<GenericResult<upaccountyOnGetGraphCompResponse>> Handle(upaccountyOnGetGraphCompQuery request, CancellationToken cancellationToken)
    {
        var UserID = Convert.ToInt32(request.UserId);

        if (request.Request.ncompid < 1)
            return GenericResult<upaccountyOnGetGraphCompResponse>.Success(new upaccountyOnGetGraphCompResponse { Result = new JsonResult("nok") });


        if (hhvnUsersManager.CheckUser(request.Request.ncompid, UserID))
            userCompanyManager.Update_UserDefault(UserID, request.Request.ncompid);

        return GenericResult<upaccountyOnGetGraphCompResponse>.Success(new upaccountyOnGetGraphCompResponse { Result = new JsonResult("ok") });
    }
}