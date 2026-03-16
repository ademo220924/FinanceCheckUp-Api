using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Responses.upreportqnb;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace FinanceCheckUp.Application.Features.BaseApp.upreportqnb.Query.upreportqnbOnGetGraphYear;
public class upreportqnbOnGetGraphYearQueryHandler(IHhvnUsersManager hhvnUsersManager) : IRequestHandler<upreportqnbOnGetGraphYearQuery, GenericResult<upreportqnbOnGetGraphYearResponse>>
{

    public async Task<GenericResult<upreportqnbOnGetGraphYearResponse>> Handle(upreportqnbOnGetGraphYearQuery request, CancellationToken cancellationToken)
    {
        var UserID = Convert.ToInt32(request.UserId);
        hhvnUsersManager.SetYear(request.Request.nyear, UserID);
        return GenericResult<upreportqnbOnGetGraphYearResponse>.Success(new upreportqnbOnGetGraphYearResponse { Result = new JsonResult("ok") });
    }
}