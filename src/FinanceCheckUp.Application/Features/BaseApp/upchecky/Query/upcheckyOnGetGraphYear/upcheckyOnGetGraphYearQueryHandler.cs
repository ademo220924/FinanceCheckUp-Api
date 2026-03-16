using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Responses.upchecky;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinanceCheckUp.Application.Features.BaseApp.upchecky.Query.upcheckyOnGetGraphYear;
public class upcheckyOnGetGraphYearQueryHandler(IHhvnUsersManager hhvnUsersManager) : IRequestHandler<upcheckyOnGetGraphYearQuery, GenericResult<upcheckyOnGetGraphYearResponse>>
{

    public async Task<GenericResult<upcheckyOnGetGraphYearResponse>> Handle(upcheckyOnGetGraphYearQuery request, CancellationToken cancellationToken)
    {
        var UserID = Convert.ToInt32(request.UserId);
        hhvnUsersManager.SetYear(request.Request.nyear, UserID);
        return GenericResult<upcheckyOnGetGraphYearResponse>.Success(new upcheckyOnGetGraphYearResponse { Result = new JsonResult("ok") });
    }
}