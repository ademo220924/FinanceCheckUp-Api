using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Responses.upreportmainy;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace FinanceCheckUp.Application.Features.BaseApp.upreportmainy.Query.upreportmainyOnGetGraphYear;
public class upreportmainyOnGetGraphYearQueryHandler(IHhvnUsersManager hhvnUsersManager) : IRequestHandler<upreportmainyOnGetGraphYearQuery, GenericResult<upreportmainyOnGetGraphYearResponse>>
{

    public async Task<GenericResult<upreportmainyOnGetGraphYearResponse>> Handle(upreportmainyOnGetGraphYearQuery request, CancellationToken cancellationToken)
    {
        var UserID = Convert.ToInt32(request.UserId);
        hhvnUsersManager.SetYear(request.Request.nyear, UserID);
        return GenericResult<upreportmainyOnGetGraphYearResponse>.Success(new upreportmainyOnGetGraphYearResponse { Result = new JsonResult("ok") });
    }
}