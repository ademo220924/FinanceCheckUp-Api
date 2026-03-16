using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Responses.upchecky;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinanceCheckUp.Application.Features.BaseApp.upchecky.Query.upcheckyOnGetGraphComp;
public class upcheckyOnGetGraphCompQueryHandler(IHhvnUsersManager hhvnUsersManager, IUserCompanyManager userCompanyManager) : IRequestHandler<upcheckyOnGetGraphCompQuery, GenericResult<upcheckyOnGetGraphCompResponse>>
{

    public async Task<GenericResult<upcheckyOnGetGraphCompResponse>> Handle(upcheckyOnGetGraphCompQuery request, CancellationToken cancellationToken)
    {
        var UserID = Convert.ToInt32(request.UserId);

        if (request.Request.ncompid < 1)
            return GenericResult<upcheckyOnGetGraphCompResponse>.Success(new upcheckyOnGetGraphCompResponse { Result = new JsonResult("nok") });

        if (hhvnUsersManager.CheckUser(request.Request.ncompid, UserID))
            userCompanyManager.Update_UserDefault(UserID, request.Request.ncompid);

        return GenericResult<upcheckyOnGetGraphCompResponse>.Success(new upcheckyOnGetGraphCompResponse { Result = new JsonResult("ok") });
    }
}