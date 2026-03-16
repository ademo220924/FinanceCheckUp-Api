using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Responses.DashCpmNew;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinanceCheckUp.Application.Features.BaseApp.DashCpmNew.Query.DashCpmNewOnGetGraphComp;
public class DashCpmNewOnGetGraphCompQueryHandler(IHhvnUsersManager hhvnUsersManager, IUserCompanyManager userCompanyManager) : IRequestHandler<DashCpmNewOnGetGraphCompQuery, GenericResult<DashCpmNewOnGetGraphCompResponse>>
{

    public async Task<GenericResult<DashCpmNewOnGetGraphCompResponse>> Handle(DashCpmNewOnGetGraphCompQuery request, CancellationToken cancellationToken)
    {
        var UserID = Convert.ToInt64(request.UserId);

        if (request.Request.ncompid < 1)
            return GenericResult<DashCpmNewOnGetGraphCompResponse>.Success(new DashCpmNewOnGetGraphCompResponse { Response = new JsonResult("nok") });

        if (!hhvnUsersManager.CheckUser(request.Request.ncompid, (int)UserID))
            return GenericResult<DashCpmNewOnGetGraphCompResponse>.Success(new DashCpmNewOnGetGraphCompResponse { Response = new JsonResult("ok") });

        userCompanyManager.Update_UserDefault((int)UserID, request.Request.ncompid);

        return GenericResult<DashCpmNewOnGetGraphCompResponse>.Success(new DashCpmNewOnGetGraphCompResponse { Response = new JsonResult("ok") });
    }
}