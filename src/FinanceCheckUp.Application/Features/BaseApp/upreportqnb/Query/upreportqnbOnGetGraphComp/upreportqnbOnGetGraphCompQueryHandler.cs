using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Responses.upreportqnb;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace FinanceCheckUp.Application.Features.BaseApp.upreportqnb.Query.upreportqnbOnGetGraphComp;
public class upreportqnbOnGetGraphCompQueryHandler(IHhvnUsersManager hhvnUsersManager, IUserCompanyManager userCompanyManager) : IRequestHandler<upreportqnbOnGetGraphCompQuery, GenericResult<upreportqnbOnGetGraphCompResponse>>
{
    public async Task<GenericResult<upreportqnbOnGetGraphCompResponse>> Handle(upreportqnbOnGetGraphCompQuery request, CancellationToken cancellationToken)
    {
        var UserID = Convert.ToInt32(request.UserId);

        if (request.Request.ncompid < 1)
            return GenericResult<upreportqnbOnGetGraphCompResponse>.Success(new upreportqnbOnGetGraphCompResponse { Result = new JsonResult("nok") });

        if (hhvnUsersManager.CheckUser(request.Request.ncompid, UserID))
            userCompanyManager.Update_UserDefault(UserID, request.Request.ncompid);

        return GenericResult<upreportqnbOnGetGraphCompResponse>.Success(new upreportqnbOnGetGraphCompResponse { Result = new JsonResult("ok") });
    }
}