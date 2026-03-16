using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Responses.DashCrmDetailc;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace FinanceCheckUp.Application.Features.BaseApp.DashCrmDetailc.Query.DashCrmDetailcOnGetGraphComp;
public class DashCrmDetailcOnGetGraphCompQueryHandler(IHhvnUsersManager hhvnUsersManager, IUserCompanyManager userCompanyManager) : IRequestHandler<DashCrmDetailcOnGetGraphCompQuery, GenericResult<DashCrmDetailcOnGetGraphCompResponse>>
{

    public async Task<GenericResult<DashCrmDetailcOnGetGraphCompResponse>> Handle(DashCrmDetailcOnGetGraphCompQuery request, CancellationToken cancellationToken)
    {
        var UserID = Convert.ToInt64(request.UserId);

        if (request.Request.ncompid < 1)
            return GenericResult<DashCrmDetailcOnGetGraphCompResponse>.Success(new DashCrmDetailcOnGetGraphCompResponse { Response = new JsonResult("nok") });

        if (!hhvnUsersManager.CheckUser(request.Request.ncompid, (int)UserID))
            return GenericResult<DashCrmDetailcOnGetGraphCompResponse>.Success(new DashCrmDetailcOnGetGraphCompResponse { Response = new JsonResult("ok") });

        userCompanyManager.Update_UserDefault((int)UserID, request.Request.ncompid);

        return GenericResult<DashCrmDetailcOnGetGraphCompResponse>.Success(new DashCrmDetailcOnGetGraphCompResponse { Response = new JsonResult("ok") });
    }
}