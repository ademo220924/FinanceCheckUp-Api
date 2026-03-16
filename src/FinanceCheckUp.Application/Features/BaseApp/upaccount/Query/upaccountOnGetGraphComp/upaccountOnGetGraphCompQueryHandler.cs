using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Responses.upaccount;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinanceCheckUp.Application.Features.BaseApp.upaccount.Query.upaccountOnGetGraphComp;
public class upaccountOnGetGraphCompQueryHandler(IHhvnUsersManager hhvnUsersManager, IUserCompanyManager userCompanyManager) : IRequestHandler<upaccountOnGetGraphCompQuery, GenericResult<upaccountOnGetGraphCompResponse>>
{

    public async Task<GenericResult<upaccountOnGetGraphCompResponse>> Handle(upaccountOnGetGraphCompQuery request, CancellationToken cancellationToken)
    {
        var UserID = Convert.ToInt32(request.UserId);

        if (request.Request.ncompid < 1)
            return GenericResult<upaccountOnGetGraphCompResponse>.Success(new upaccountOnGetGraphCompResponse { Result = new JsonResult("nok") });

        if (hhvnUsersManager.CheckUser(request.Request.ncompid, UserID))
            userCompanyManager.Update_UserDefault(UserID, request.Request.ncompid);

        return GenericResult<upaccountOnGetGraphCompResponse>.Success(new upaccountOnGetGraphCompResponse { Result = new JsonResult("ok") });
    }
}