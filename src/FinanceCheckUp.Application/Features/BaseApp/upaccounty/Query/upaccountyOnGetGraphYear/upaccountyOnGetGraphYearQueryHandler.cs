using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Responses.upaccounty;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace FinanceCheckUp.Application.Features.BaseApp.upaccounty.Query.upaccountyOnGetGraphYear;
public class upaccountyOnGetGraphYearQueryHandler(IHhvnUsersManager hhvnUsersManager) : IRequestHandler<upaccountyOnGetGraphYearQuery, GenericResult<upaccountyOnGetGraphYearResponse>>
{

    public async Task<GenericResult<upaccountyOnGetGraphYearResponse>> Handle(upaccountyOnGetGraphYearQuery request, CancellationToken cancellationToken)
    {
        var UserID = Convert.ToInt32(request.UserId);
        hhvnUsersManager.SetYear(request.Request.nyear, UserID);
        return GenericResult<upaccountyOnGetGraphYearResponse>.Success(new upaccountyOnGetGraphYearResponse { Result = new JsonResult("ok") });
    }
}