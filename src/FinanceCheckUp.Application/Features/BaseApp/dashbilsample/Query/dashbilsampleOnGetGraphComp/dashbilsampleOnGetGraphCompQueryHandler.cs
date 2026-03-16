using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Responses.dashbilsample;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace FinanceCheckUp.Application.Features.BaseApp.dashbilsample.Query.dashbilsampleOnGetGraphComp;
public class dashbilsampleOnGetGraphCompQueryHandler(IHhvnUsersManager hhvnUsersManager, IUserCompanyManager userCompanyManager) : IRequestHandler<dashbilsampleOnGetGraphCompQuery, GenericResult<dashbilsampleOnGetGraphCompResponse>>
{

    public async Task<GenericResult<dashbilsampleOnGetGraphCompResponse>> Handle(dashbilsampleOnGetGraphCompQuery request, CancellationToken cancellationToken)
    {
        var UserID = Convert.ToInt32(request.UserId);

        if (request.Request.ncompid < 1)
            return GenericResult<dashbilsampleOnGetGraphCompResponse>.Success(new dashbilsampleOnGetGraphCompResponse { Result = new JsonResult("nok") });

        if (!hhvnUsersManager.CheckUser(request.Request.ncompid, UserID))
            return GenericResult<dashbilsampleOnGetGraphCompResponse>.Success(new dashbilsampleOnGetGraphCompResponse { Result = new JsonResult("ok") });

        userCompanyManager.Update_UserDefault(UserID, request.Request.ncompid);
        return GenericResult<dashbilsampleOnGetGraphCompResponse>.Success(new dashbilsampleOnGetGraphCompResponse { Result = new JsonResult("ok") });
    }
}