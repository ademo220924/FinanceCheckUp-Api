using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Responses.DashWorkingCapital;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace FinanceCheckUp.Application.Features.BaseApp.DashWorkingCapital.Query.DashWorkingCapitalOnGetGraphComp;
public class DashWorkingCapitalOnGetGraphCompQueryHandler(IHhvnUsersManager hhvnUsersManager, IUserCompanyManager userCompanyManager) : IRequestHandler<DashWorkingCapitalOnGetGraphCompQuery, GenericResult<DashWorkingCapitalOnGetGraphCompResponse>>
{

    public async Task<GenericResult<DashWorkingCapitalOnGetGraphCompResponse>> Handle(DashWorkingCapitalOnGetGraphCompQuery request, CancellationToken cancellationToken)
    {
        var UserID = Convert.ToInt64(request.UserId);

        if (request.Request.ncompid < 1)
            return GenericResult<DashWorkingCapitalOnGetGraphCompResponse>.Success(new DashWorkingCapitalOnGetGraphCompResponse { Response = new JsonResult("nok") });

        if (!hhvnUsersManager.CheckUser(request.Request.ncompid, (int)UserID))
            return GenericResult<DashWorkingCapitalOnGetGraphCompResponse>.Success(new DashWorkingCapitalOnGetGraphCompResponse { Response = new JsonResult("ok") });

        userCompanyManager.Update_UserDefault((int)UserID, request.Request.ncompid);

        return GenericResult<DashWorkingCapitalOnGetGraphCompResponse>.Success(new DashWorkingCapitalOnGetGraphCompResponse { Response = new JsonResult("ok") });
    }
}