using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.UpBalance;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.UpBalance.Query.UpBalanceOnGetGraphYear;

public class MizanUpBalanceOnGetGraphYearQueryHandler(IHhvnUsersManager hhvnUsersManager) : IRequestHandler<MizanUpBalanceOnGetGraphYearQuery, GenericResult<MizanUpBalanceOnGetGraphYearResponse>>
{
    public Task<GenericResult<MizanUpBalanceOnGetGraphYearResponse>> Handle(MizanUpBalanceOnGetGraphYearQuery request, CancellationToken cancellationToken)
    {
        var userId = Convert.ToInt64(request.UserId);
        hhvnUsersManager.SetYear(request.Request.nyear, userId);
        return Task.FromResult(GenericResult<MizanUpBalanceOnGetGraphYearResponse>.Success(new MizanUpBalanceOnGetGraphYearResponse
            {
                Response = new JsonResult("ok")
            }));
    }
}