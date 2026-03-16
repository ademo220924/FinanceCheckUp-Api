using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Responses.dashbilsample;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace FinanceCheckUp.Application.Features.BaseApp.dashbilsample.Query.dashbilsampleOnGetGraphYear;
public class dashbilsampleOnGetGraphYearQueryHandler(IHhvnUsersManager hhvnUsersManager) : IRequestHandler<dashbilsampleOnGetGraphYearQuery, GenericResult<dashbilsampleOnGetGraphYearResponse>>
{

    public async Task<GenericResult<dashbilsampleOnGetGraphYearResponse>> Handle(dashbilsampleOnGetGraphYearQuery request, CancellationToken cancellationToken)
    {
        var UserID = Convert.ToInt32(request.UserId);
        hhvnUsersManager.SetYear(request.Request.nyear, UserID);
        return GenericResult<dashbilsampleOnGetGraphYearResponse>.Success(new dashbilsampleOnGetGraphYearResponse { Result = new JsonResult("ok") });
    }
}