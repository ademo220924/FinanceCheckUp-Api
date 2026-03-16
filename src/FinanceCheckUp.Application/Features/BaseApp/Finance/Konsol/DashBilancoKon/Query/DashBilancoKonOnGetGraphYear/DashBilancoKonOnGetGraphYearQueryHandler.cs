using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using FinanceCheckUp.Application.Models.Responses.Finance.Konsol.DashBilancoKon;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Konsol.DashBilancoKon.Query.DashBilancoKonOnGetGraphYear;
public class DashBilancoKonOnGetGraphYearQueryHandler(IHhvnUsersManager hhvnUsersManager) 
    : IRequestHandler<DashBilancoKonOnGetGraphYearQuery, GenericResult<DashBilancoKonOnGetGraphYearResponse>>
{
    
    public Task<GenericResult<DashBilancoKonOnGetGraphYearResponse>> Handle(DashBilancoKonOnGetGraphYearQuery request, CancellationToken cancellationToken)
    {
        var userId = Convert.ToInt64(request.UserId);
        hhvnUsersManager.SetYear(request.Request.nyear, userId);
            
        return Task.FromResult(GenericResult<DashBilancoKonOnGetGraphYearResponse>.Success(
            new DashBilancoKonOnGetGraphYearResponse
            {
                Response = new JsonResult("OK")
            })); 
    }
}
