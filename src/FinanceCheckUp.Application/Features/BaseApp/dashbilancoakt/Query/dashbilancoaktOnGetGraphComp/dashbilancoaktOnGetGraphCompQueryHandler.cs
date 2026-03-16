using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Responses.dashbilancoakt;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace FinanceCheckUp.Application.Features.BaseApp.dashbilancoakt.Query.dashbilancoaktOnGetGraphComp;
public class dashbilancoaktOnGetGraphCompQueryHandler(IHhvnUsersManager hhvnUsersManager, IUserCompanyManager userCompanyManager) : IRequestHandler<dashbilancoaktOnGetGraphCompQuery, GenericResult<dashbilancoaktOnGetGraphCompResponse>>
{

    public async Task<GenericResult<dashbilancoaktOnGetGraphCompResponse>> Handle(dashbilancoaktOnGetGraphCompQuery request, CancellationToken cancellationToken)
    {

        var UserID = Convert.ToInt32(request.UserId);

        if (request.Request.ncompid < 1)
            return GenericResult<dashbilancoaktOnGetGraphCompResponse>.Success(new dashbilancoaktOnGetGraphCompResponse { Result = new JsonResult("nok") });

        if (!hhvnUsersManager.CheckUser(request.Request.ncompid, UserID))
            return GenericResult<dashbilancoaktOnGetGraphCompResponse>.Success(new dashbilancoaktOnGetGraphCompResponse { Result = new JsonResult("ok") });

        userCompanyManager.Update_UserDefault(UserID, request.Request.ncompid);
        return GenericResult<dashbilancoaktOnGetGraphCompResponse>.Success(new dashbilancoaktOnGetGraphCompResponse { Result = new JsonResult("ok") });
    }
}