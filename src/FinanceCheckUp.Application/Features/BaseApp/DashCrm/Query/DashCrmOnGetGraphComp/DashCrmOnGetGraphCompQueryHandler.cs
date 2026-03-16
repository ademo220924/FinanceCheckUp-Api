using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace FinanceCheckUp.Application.Features.BaseApp.DashCrm.Query.DashCrmOnGetGraphComp;
public class DashCrmOnGetGraphCompQueryHandler(IHhvnUsersManager hhvnUsersManager, IUserCompanyManager userCompanyManager) : IRequestHandler<DashCrmOnGetGraphCompQuery, GenericResult<DashCrmOnGetGraphCompResponse>>
{

    public async Task<GenericResult<DashCrmOnGetGraphCompResponse>> Handle(DashCrmOnGetGraphCompQuery request, CancellationToken cancellationToken)
    {
        var UserID = Convert.ToInt64(request.UserId);

        if (request.Request.ncompid < 1)
            return GenericResult<DashCrmOnGetGraphCompResponse>.Success(new DashCrmOnGetGraphCompResponse { Response = new JsonResult("nok") });

        if (!hhvnUsersManager.CheckUser(request.Request.ncompid, (int)UserID))
            return GenericResult<DashCrmOnGetGraphCompResponse>.Success(new DashCrmOnGetGraphCompResponse { Response = new JsonResult("ok") });

        userCompanyManager.Update_UserDefault((int)UserID, request.Request.ncompid);

        return GenericResult<DashCrmOnGetGraphCompResponse>.Success(new DashCrmOnGetGraphCompResponse { Response = new JsonResult("ok") });
    }
}