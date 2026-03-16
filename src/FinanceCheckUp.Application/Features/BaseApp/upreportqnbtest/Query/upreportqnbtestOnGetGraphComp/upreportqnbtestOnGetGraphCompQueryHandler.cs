using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Responses.upreportqnbtest;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace FinanceCheckUp.Application.Features.BaseApp.upreportqnbtest.Query.upreportqnbtestOnGetGraphComp;
public class upreportqnbtestOnGetGraphCompQueryHandler(IHhvnUsersManager hhvnUsersManager, IUserCompanyManager userCompanyManager) : IRequestHandler<upreportqnbtestOnGetGraphCompQuery, GenericResult<upreportqnbtestOnGetGraphCompResponse>>
{

    public async Task<GenericResult<upreportqnbtestOnGetGraphCompResponse>> Handle(upreportqnbtestOnGetGraphCompQuery request, CancellationToken cancellationToken)
    {
        var UserID = Convert.ToInt32(request.UserId);

        if (request.Request.ncompid < 1)
            return GenericResult<upreportqnbtestOnGetGraphCompResponse>.Success(new upreportqnbtestOnGetGraphCompResponse { Result = new JsonResult("nok") });

        if (hhvnUsersManager.CheckUser(request.Request.ncompid, UserID))
            userCompanyManager.Update_UserDefault(UserID, request.Request.ncompid);

        return GenericResult<upreportqnbtestOnGetGraphCompResponse>.Success(new upreportqnbtestOnGetGraphCompResponse { Result = new JsonResult("ok") });
    }
}