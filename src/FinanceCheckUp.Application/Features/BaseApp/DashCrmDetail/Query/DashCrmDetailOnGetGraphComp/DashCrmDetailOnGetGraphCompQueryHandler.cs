using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Responses.DashCrmDetail;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace FinanceCheckUp.Application.Features.BaseApp.DashCrmDetail.Query.DashCrmDetailOnGetGraphComp;
public class DashCrmDetailOnGetGrapCompQueryHandler(IHhvnUsersManager hhvnUsersManager, IUserCompanyManager userCompanyManager) : IRequestHandler<DashCrmDetailOnGetGrapCompQuery, GenericResult<DashCrmDetailOnGetGraphCompResponse>>
{

    public async Task<GenericResult<DashCrmDetailOnGetGraphCompResponse>> Handle(DashCrmDetailOnGetGrapCompQuery request, CancellationToken cancellationToken)
    {
        var UserID = Convert.ToInt64(request.UserId);

        if (request.Request.ncompid < 1)
            return GenericResult<DashCrmDetailOnGetGraphCompResponse>.Success(new DashCrmDetailOnGetGraphCompResponse { Response = new JsonResult("nok") });

        if (!hhvnUsersManager.CheckUser(request.Request.ncompid, (int)UserID))
            return GenericResult<DashCrmDetailOnGetGraphCompResponse>.Success(new DashCrmDetailOnGetGraphCompResponse { Response = new JsonResult("ok") });

        userCompanyManager.Update_UserDefault((int)UserID, request.Request.ncompid);

        return GenericResult<DashCrmDetailOnGetGraphCompResponse>.Success(new DashCrmDetailOnGetGraphCompResponse { Response = new JsonResult("ok") });
    }
}