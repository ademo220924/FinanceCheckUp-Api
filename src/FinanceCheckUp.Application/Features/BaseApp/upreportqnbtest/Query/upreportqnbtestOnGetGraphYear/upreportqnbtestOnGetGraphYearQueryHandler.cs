using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Responses.upreportqnbtest;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace FinanceCheckUp.Application.Features.BaseApp.upreportqnbtest.Query.upreportqnbtestOnGetGraphYear;
public class upreportqnbtestOnGetGraphYearQueryHandler(IHhvnUsersManager hhvnUsersManager) : IRequestHandler<upreportqnbtestOnGetGraphYearQuery, GenericResult<upreportqnbtestOnGetGraphYearResponse>>
{

    public async Task<GenericResult<upreportqnbtestOnGetGraphYearResponse>> Handle(upreportqnbtestOnGetGraphYearQuery request, CancellationToken cancellationToken)
    {
        var UserID = Convert.ToInt32(request.UserId);
        hhvnUsersManager.SetYear(request.Request.nyear, UserID);
        return GenericResult<upreportqnbtestOnGetGraphYearResponse>.Success(new upreportqnbtestOnGetGraphYearResponse { Result = new JsonResult("ok") });
    }
}