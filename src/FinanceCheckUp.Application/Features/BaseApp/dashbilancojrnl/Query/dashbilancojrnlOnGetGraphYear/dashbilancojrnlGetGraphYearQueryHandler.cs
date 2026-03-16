using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Responses.dashbilancojrnl;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;



namespace FinanceCheckUp.Application.Features.BaseApp.dashbilancojrnl.Query.dashbilancojrnlOnGetGraphYear;
public class dashbilancojrnlOnGetGraphYearQueryHandler(IHhvnUsersManager hhvnUsersManager) : IRequestHandler<dashbilancojrnlOnGetGraphYearQuery, GenericResult<dashbilancojrnlOnGetGraphYearResponse>>
{
    public async Task<GenericResult<dashbilancojrnlOnGetGraphYearResponse>> Handle(dashbilancojrnlOnGetGraphYearQuery request, CancellationToken cancellationToken)
    {
        var UserID = Convert.ToInt32(request.UserId);
        hhvnUsersManager.SetYear(request.Request.nyear, UserID);
        return GenericResult<dashbilancojrnlOnGetGraphYearResponse>.Success(new dashbilancojrnlOnGetGraphYearResponse { Result = new JsonResult("ok") });
    }
}