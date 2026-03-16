using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Responses.dashbilancorvnmlt;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace FinanceCheckUp.Application.Features.BaseApp.dashbilancorvnmlt.Query.dashbilancorvnmltOnGetGraphComp;
public class dashbilancorvnmltOnGetGraphCompQueryHandler(IHhvnUsersManager hhvnUsersManager, IUserCompanyManager userCompanyManager) : IRequestHandler<dashbilancorvnmltOnGetGraphCompQuery, GenericResult<dashbilancorvnmltOnGetGraphCompResponse>>
{

    public async Task<GenericResult<dashbilancorvnmltOnGetGraphCompResponse>> Handle(dashbilancorvnmltOnGetGraphCompQuery request, CancellationToken cancellationToken)
    {

        var UserID = Convert.ToInt32(request.UserId);

        if (request.Request.ncompid < 1)
            return GenericResult<dashbilancorvnmltOnGetGraphCompResponse>.Success(new dashbilancorvnmltOnGetGraphCompResponse { Result = new JsonResult("nok") });

        if (!hhvnUsersManager.CheckUser(request.Request.ncompid, UserID))
            return GenericResult<dashbilancorvnmltOnGetGraphCompResponse>.Success(new dashbilancorvnmltOnGetGraphCompResponse { Result = new JsonResult("ok") });

        userCompanyManager.Update_UserDefault(UserID, request.Request.ncompid);
        return GenericResult<dashbilancorvnmltOnGetGraphCompResponse>.Success(new dashbilancorvnmltOnGetGraphCompResponse { Result = new JsonResult("ok") });
    }
}