using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Responses.upreportmainy;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace FinanceCheckUp.Application.Features.BaseApp.upreportmainy.Query.upreportmainyOnGetGraphComp;
public class upreportmainyOnGetGraphCompQueryHandler(IHhvnUsersManager hhvnUsersManager, IUserCompanyManager userCompanyManager) : IRequestHandler<upreportmainyOnGetGraphCompQuery, GenericResult<upreportmainyOnGetGraphCompResponse>>
{

    public async Task<GenericResult<upreportmainyOnGetGraphCompResponse>> Handle(upreportmainyOnGetGraphCompQuery request, CancellationToken cancellationToken)
    {
        var UserID = Convert.ToInt32(request.UserId);

        if (request.Request.ncompid < 1)
            return GenericResult<upreportmainyOnGetGraphCompResponse>.Success(new upreportmainyOnGetGraphCompResponse { Result = new JsonResult("nok") });

        if (hhvnUsersManager.CheckUser(request.Request.ncompid, UserID))
            userCompanyManager.Update_UserDefault(UserID, request.Request.ncompid);

        return GenericResult<upreportmainyOnGetGraphCompResponse>.Success(new upreportmainyOnGetGraphCompResponse { Result = new JsonResult("ok") });
    }
}