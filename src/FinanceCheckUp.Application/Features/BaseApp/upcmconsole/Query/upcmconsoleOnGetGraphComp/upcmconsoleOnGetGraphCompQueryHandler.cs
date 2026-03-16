using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Responses.upcmconsole;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace FinanceCheckUp.Application.Features.BaseApp.upcmconsole.Query.upcmconsoleOnGetGraphComp;
public class upcmconsoleOnGetGraphCompQueryHandler(IHhvnUsersManager hhvnUsersManager, IUserCompanyManager userCompanyManager) : IRequestHandler<upcmconsoleOnGetGraphCompQuery, GenericResult<upcmconsoleOnGetGraphCompResponse>>
{

    public async Task<GenericResult<upcmconsoleOnGetGraphCompResponse>> Handle(upcmconsoleOnGetGraphCompQuery request, CancellationToken cancellationToken)
    {
        var UserID = Convert.ToInt32(request.UserId);

        if (request.Request.ncompid < 1)
            return GenericResult<upcmconsoleOnGetGraphCompResponse>.Success(new upcmconsoleOnGetGraphCompResponse { Result = new JsonResult("nok") });

        if (hhvnUsersManager.CheckUser(request.Request.ncompid, UserID))
            userCompanyManager.Update_UserDefault(UserID, request.Request.ncompid);

        return GenericResult<upcmconsoleOnGetGraphCompResponse>.Success(new upcmconsoleOnGetGraphCompResponse { Result = new JsonResult("ok") });
    }
}