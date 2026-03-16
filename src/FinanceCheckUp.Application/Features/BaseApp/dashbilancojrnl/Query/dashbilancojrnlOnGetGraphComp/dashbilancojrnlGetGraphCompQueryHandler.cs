using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Responses.dashbilancojrnl;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;



namespace FinanceCheckUp.Application.Features.BaseApp.dashbilancojrnl.Query.dashbilancojrnlOnGetGraphComp;
public class dashbilancojrnlOnGetGraphCompQueryHandler(IHhvnUsersManager hhvnUsersManager, IUserCompanyManager userCompanyManager) : IRequestHandler<dashbilancojrnlOnGetGraphCompQuery, GenericResult<dashbilancojrnlOnGetGraphCompResponse>>
{

    public async Task<GenericResult<dashbilancojrnlOnGetGraphCompResponse>> Handle(dashbilancojrnlOnGetGraphCompQuery request, CancellationToken cancellationToken)
    {
        var UserID = Convert.ToInt32(request.UserId);

        if (request.Request.ncompid < 1)
            return GenericResult<dashbilancojrnlOnGetGraphCompResponse>.Success(new dashbilancojrnlOnGetGraphCompResponse { Result = new JsonResult("nok") });

        if (!hhvnUsersManager.CheckUser(request.Request.ncompid, UserID))
            return GenericResult<dashbilancojrnlOnGetGraphCompResponse>.Success(new dashbilancojrnlOnGetGraphCompResponse { Result = new JsonResult("ok") });

        userCompanyManager.Update_UserDefault(UserID, request.Request.ncompid);
        return GenericResult<dashbilancojrnlOnGetGraphCompResponse>.Success(new dashbilancojrnlOnGetGraphCompResponse { Result = new JsonResult("ok") });
    }
}