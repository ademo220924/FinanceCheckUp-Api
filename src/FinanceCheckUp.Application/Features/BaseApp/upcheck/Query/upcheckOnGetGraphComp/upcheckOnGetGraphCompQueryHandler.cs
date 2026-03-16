using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Responses.upcheck;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace FinanceCheckUp.Application.Features.BaseApp.upcheck.Query.upcheckOnGetGraphComp;
public class upcheckOnGetGraphCompQueryHandler(IHhvnUsersManager hhvnUsersManager, IUserCompanyManager userCompanyManager) : IRequestHandler<upcheckOnGetGraphCompQuery, GenericResult<upcheckOnGetGraphCompResponse>>
{

    public async Task<GenericResult<upcheckOnGetGraphCompResponse>> Handle(upcheckOnGetGraphCompQuery request, CancellationToken cancellationToken)
    {
        var UserID = Convert.ToInt32(request.UserId);

        if (request.Request.ncompid < 1)
            return GenericResult<upcheckOnGetGraphCompResponse>.Success(new upcheckOnGetGraphCompResponse { Result = new JsonResult("nok") });

        if (hhvnUsersManager.CheckUser(request.Request.ncompid, UserID))
            userCompanyManager.Update_UserDefault(UserID, request.Request.ncompid);

        return GenericResult<upcheckOnGetGraphCompResponse>.Success(new upcheckOnGetGraphCompResponse { Result = new JsonResult("ok") });
    }
}