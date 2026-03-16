using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Responses.Finance.Konsol.DashRevenueKon;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Konsol.DashRevenueKon.Query.DashRevenueKonOnGetGraphYear;
public class DashRevenueKonOnGetGraphYearQueryHandler(IHhvnUsersManager hhvnUsersManager) 
    : IRequestHandler<DashRevenueKonOnGetGraphYearQuery, GenericResult<DashRevenueKonOnGetGraphYearResponse>>
{
    public Task<GenericResult<DashRevenueKonOnGetGraphYearResponse>> Handle(DashRevenueKonOnGetGraphYearQuery request, CancellationToken cancellationToken)
    {
        var userId = Convert.ToInt64(request.UserId);
        hhvnUsersManager.SetYear(request.Request.nyear, userId);
        
        return Task.FromResult(GenericResult<DashRevenueKonOnGetGraphYearResponse>.Success(
            new DashRevenueKonOnGetGraphYearResponse
            {
                Response = new JsonResult("OK")
            })); 
    }
}

