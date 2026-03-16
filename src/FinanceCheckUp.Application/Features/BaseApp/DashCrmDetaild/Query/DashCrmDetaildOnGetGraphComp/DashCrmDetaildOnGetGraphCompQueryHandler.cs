using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Responses.DashCrmDetaild;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace FinanceCheckUp.Application.Features.BaseApp.DashCrmDetaild.Query.DashCrmDetaildOnGetGraphComp;
public class DashCrmDetaildOnGetGraphCompQueryHandler(IHhvnUsersManager hhvnUsersManager, IUserCompanyManager userCompanyManager) : IRequestHandler<DashCrmDetaildOnGetGraphCompQuery, GenericResult<DashCrmDetaildOnGetGraphCompResponse>>
{

    public async Task<GenericResult<DashCrmDetaildOnGetGraphCompResponse>> Handle(DashCrmDetaildOnGetGraphCompQuery request, CancellationToken cancellationToken)
    {
        var UserID = Convert.ToInt64(request.UserId);

        if (request.Request.ncompid < 1)
            return GenericResult<DashCrmDetaildOnGetGraphCompResponse>.Success(new DashCrmDetaildOnGetGraphCompResponse { Response = new JsonResult("nok") });

        if (!hhvnUsersManager.CheckUser(request.Request.ncompid, (int)UserID))
            return GenericResult<DashCrmDetaildOnGetGraphCompResponse>.Success(new DashCrmDetaildOnGetGraphCompResponse { Response = new JsonResult("ok") });

        userCompanyManager.Update_UserDefault((int)UserID, request.Request.ncompid);

        return GenericResult<DashCrmDetaildOnGetGraphCompResponse>.Success(new DashCrmDetaildOnGetGraphCompResponse { Response = new JsonResult("ok") });
    }
}