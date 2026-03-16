using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Responses.dashbilancorvnakt;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace FinanceCheckUp.Application.Features.BaseApp.dashbilancorvnakt.Query.dashbilancorvnaktOnGetGraphComp;
public class dashbilancorvnaktOnGetGraphCompQueryHandler(IHhvnUsersManager hhvnUsersManager, IUserCompanyManager userCompanyManager) : IRequestHandler<dashbilancorvnaktOnGetGraphCompQuery, GenericResult<dashbilancorvnaktOnGetGraphCompResponse>>
{

    public async Task<GenericResult<dashbilancorvnaktOnGetGraphCompResponse>> Handle(dashbilancorvnaktOnGetGraphCompQuery request, CancellationToken cancellationToken)
    {
        var UserID = Convert.ToInt32(request.UserId);

        if (request.Request.ncompid < 1)
            return GenericResult<dashbilancorvnaktOnGetGraphCompResponse>.Success(new dashbilancorvnaktOnGetGraphCompResponse { Result = new JsonResult("nok") });

        if (!hhvnUsersManager.CheckUser(request.Request.ncompid, UserID))
            return GenericResult<dashbilancorvnaktOnGetGraphCompResponse>.Success(new dashbilancorvnaktOnGetGraphCompResponse { Result = new JsonResult("ok") });

        userCompanyManager.Update_UserDefault(UserID, request.Request.ncompid);
        return GenericResult<dashbilancorvnaktOnGetGraphCompResponse>.Success(new dashbilancorvnaktOnGetGraphCompResponse { Result = new JsonResult("ok") });
    }
}