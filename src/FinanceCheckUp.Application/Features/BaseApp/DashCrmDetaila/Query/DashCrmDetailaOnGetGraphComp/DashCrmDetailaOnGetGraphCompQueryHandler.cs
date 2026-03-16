using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Responses.DashCrmDetaila;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace FinanceCheckUp.Application.Features.BaseApp.DashCrmDetaila.Query.DashCrmDetailaOnGetGraphComp;
public class DashCrmDetailaOnGetGraphCompQueryHandler(IHhvnUsersManager hhvnUsersManager, IUserCompanyManager userCompanyManager) : IRequestHandler<DashCrmDetailaOnGetGraphCompQuery, GenericResult<DashCrmDetailaOnGetGraphCompResponse>>
{

    public async Task<GenericResult<DashCrmDetailaOnGetGraphCompResponse>> Handle(DashCrmDetailaOnGetGraphCompQuery request, CancellationToken cancellationToken)
    {
        var UserID = Convert.ToInt64(request.UserId);

        if (request.Request.ncompid < 1)
            return GenericResult<DashCrmDetailaOnGetGraphCompResponse>.Success(new DashCrmDetailaOnGetGraphCompResponse { Response = new JsonResult("nok") });

        if (!hhvnUsersManager.CheckUser(request.Request.ncompid, (int)UserID))
            return GenericResult<DashCrmDetailaOnGetGraphCompResponse>.Success(new DashCrmDetailaOnGetGraphCompResponse { Response = new JsonResult("ok") });

        userCompanyManager.Update_UserDefault((int)UserID, request.Request.ncompid);

        return GenericResult<DashCrmDetailaOnGetGraphCompResponse>.Success(new DashCrmDetailaOnGetGraphCompResponse { Response = new JsonResult("ok") });

    }
}