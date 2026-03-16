using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Responses.upcmconsole;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace FinanceCheckUp.Application.Features.BaseApp.upcmconsole.Query.upcmconsoleOnGetGraphYear;
public class upcmconsoleOnGetGraphYearQueryHandler(IHhvnUsersManager hhvnUsersManager) : IRequestHandler<upcmconsoleOnGetGraphYearQuery, GenericResult<upcmconsoleOnGetGraphYearResponse>>
{
    public async Task<GenericResult<upcmconsoleOnGetGraphYearResponse>> Handle(upcmconsoleOnGetGraphYearQuery request, CancellationToken cancellationToken)
    {
        var UserID = Convert.ToInt32(request.UserId);
        hhvnUsersManager.SetYear(request.Request.nyear, UserID);
        return GenericResult<upcmconsoleOnGetGraphYearResponse>.Success(new upcmconsoleOnGetGraphYearResponse { Result = new JsonResult("ok") });
    }
}
