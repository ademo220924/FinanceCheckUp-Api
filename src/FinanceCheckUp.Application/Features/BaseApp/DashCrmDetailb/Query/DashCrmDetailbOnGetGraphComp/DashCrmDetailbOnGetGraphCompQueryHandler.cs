using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Responses.DashCrmDetailb;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace FinanceCheckUp.Application.Features.BaseApp.DashCrmDetailb.Query.DashCrmDetailbOnGetGraphComp;
public class DashCrmDetailbOnGetGraphCompQueryHandler(IHhvnUsersManager hhvnUsersManager, IUserCompanyManager userCompanyManager) : IRequestHandler<DashCrmDetailbOnGetGraphCompQuery, GenericResult<DashCrmDetailbOnGetGraphCompResponse>>
{

    public async Task<GenericResult<DashCrmDetailbOnGetGraphCompResponse>> Handle(DashCrmDetailbOnGetGraphCompQuery request, CancellationToken cancellationToken)
    {
        var UserID = Convert.ToInt64(request.UserId);

        if (request.Request.ncompid < 1)
            return GenericResult<DashCrmDetailbOnGetGraphCompResponse>.Success(new DashCrmDetailbOnGetGraphCompResponse { Response = new JsonResult("nok") });

        if (!hhvnUsersManager.CheckUser(request.Request.ncompid, (int)UserID))
            return GenericResult<DashCrmDetailbOnGetGraphCompResponse>.Success(new DashCrmDetailbOnGetGraphCompResponse { Response = new JsonResult("ok") });

        userCompanyManager.Update_UserDefault((int)UserID, request.Request.ncompid);

        return GenericResult<DashCrmDetailbOnGetGraphCompResponse>.Success(new DashCrmDetailbOnGetGraphCompResponse { Response = new JsonResult("ok") });
    }
}