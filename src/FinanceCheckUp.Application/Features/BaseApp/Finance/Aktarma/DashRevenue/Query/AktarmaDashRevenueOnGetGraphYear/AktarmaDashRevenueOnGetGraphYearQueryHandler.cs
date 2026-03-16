using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Responses.Finance.Aktarma.DashRevenue;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Aktarma.DashRevenue.Query.AktarmaDashRevenueOnGetGraphYear;
public class AktarmaDashRevenueOnGetGraphYearQueryHandler(IHhvnUsersManager hhvnUsersManager) 
    : IRequestHandler<AktarmaDashRevenueOnGetGraphYearQuery, GenericResult<AktarmaDashRevenueOnGetGraphYearResponse>>
{
    public Task<GenericResult<AktarmaDashRevenueOnGetGraphYearResponse>> Handle(AktarmaDashRevenueOnGetGraphYearQuery request, CancellationToken cancellationToken)
    {
        var userId = Convert.ToInt64(request.UserId);
        hhvnUsersManager.SetYear(request.Request.nyear, userId);
            
        return Task.FromResult(GenericResult<AktarmaDashRevenueOnGetGraphYearResponse>.Success(
            new AktarmaDashRevenueOnGetGraphYearResponse
            {
                Response = new JsonResult("OK")
            })); 
    }
}