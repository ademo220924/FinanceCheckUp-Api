using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Responses.upaccount;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinanceCheckUp.Application.Features.BaseApp.upaccount.Query.upaccountOnGetGraphYear;
public class upaccountOnGetGraphYearQueryHandler(IHhvnUsersManager hhvnUsersManager) : IRequestHandler<upaccountOnGetGraphYearQuery, GenericResult<upaccountOnGetGraphYearResponse>>
{

    public async Task<GenericResult<upaccountOnGetGraphYearResponse>> Handle(upaccountOnGetGraphYearQuery request, CancellationToken cancellationToken)
    {
        var UserID = Convert.ToInt32(request.UserId);
        hhvnUsersManager.SetYear(request.Request.nyear, UserID);
        return GenericResult<upaccountOnGetGraphYearResponse>.Success(new upaccountOnGetGraphYearResponse { Result = new JsonResult("ok") });
    }
}