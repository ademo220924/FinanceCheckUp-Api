using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Responses.DashRasyo;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace FinanceCheckUp.Application.Features.BaseApp.DashRasyo.Query.DashRasyoOnGetGraphComp;
public class DashRasyoOnGetGraphCompQueryHandler(IHhvnUsersManager hhvnUsersManager, IUserCompanyManager userCompanyManager) : IRequestHandler<DashRasyoOnGetGraphCompQuery, GenericResult<DashRasyoOnGetGraphCompResponse>>
{

    public async Task<GenericResult<DashRasyoOnGetGraphCompResponse>> Handle(DashRasyoOnGetGraphCompQuery request, CancellationToken cancellationToken)
    {
        var UserID = Convert.ToInt64(request.UserId);

        if (request.Request.ncompid < 1)
            return GenericResult<DashRasyoOnGetGraphCompResponse>.Success(new DashRasyoOnGetGraphCompResponse { Response = new JsonResult("nok") });

        if (!hhvnUsersManager.CheckUser(request.Request.ncompid, (int)UserID))
            return GenericResult<DashRasyoOnGetGraphCompResponse>.Success(new DashRasyoOnGetGraphCompResponse { Response = new JsonResult("ok") });

        userCompanyManager.Update_UserDefault((int)UserID, request.Request.ncompid);

        return GenericResult<DashRasyoOnGetGraphCompResponse>.Success(new DashRasyoOnGetGraphCompResponse { Response = new JsonResult("ok") });
    }
}