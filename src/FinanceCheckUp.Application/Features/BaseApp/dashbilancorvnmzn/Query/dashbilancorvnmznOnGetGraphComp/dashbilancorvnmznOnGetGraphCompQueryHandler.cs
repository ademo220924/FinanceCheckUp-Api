using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Responses.dashbilancorvnmzn;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace FinanceCheckUp.Application.Features.BaseApp.dashbilancorvnmzn.Query.dashbilancorvnmznOnGetGraphComp;
public class dashbilancorvnmznOnGetGraphCompQueryHandler(IHhvnUsersManager hhvnUsersManager, IUserCompanyManager userCompanyManager) : IRequestHandler<dashbilancorvnmznOnGetGraphCompQuery, GenericResult<dashbilancorvnmznOnGetGraphCompResponse>>
{

    public async Task<GenericResult<dashbilancorvnmznOnGetGraphCompResponse>> Handle(dashbilancorvnmznOnGetGraphCompQuery request, CancellationToken cancellationToken)
    {
        var UserID = Convert.ToInt32(request.UserId);

        if (request.Request.ncompid < 1)
            return GenericResult<dashbilancorvnmznOnGetGraphCompResponse>.Success(new dashbilancorvnmznOnGetGraphCompResponse { Result = new JsonResult("nok") });

        if (!hhvnUsersManager.CheckUser(request.Request.ncompid, UserID))
            return GenericResult<dashbilancorvnmznOnGetGraphCompResponse>.Success(new dashbilancorvnmznOnGetGraphCompResponse { Result = new JsonResult("ok") });

        userCompanyManager.Update_UserDefault(UserID, request.Request.ncompid);
        return GenericResult<dashbilancorvnmznOnGetGraphCompResponse>.Success(new dashbilancorvnmznOnGetGraphCompResponse { Result = new JsonResult("ok") });
    }
}