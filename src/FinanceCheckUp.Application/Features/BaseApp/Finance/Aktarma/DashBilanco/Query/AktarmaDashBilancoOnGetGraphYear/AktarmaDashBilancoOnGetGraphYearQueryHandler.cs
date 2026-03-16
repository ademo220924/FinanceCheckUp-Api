using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Responses.Finance.Aktarma.DashBilanco;
using FinanceCheckUp.Domain.Entities;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Aktarma.DashBilanco.Query.AktarmaDashBilancoOnGetGraphYear;
public class AktarmaDashBilancoOnGetGraphYearQueryHandler(IHhvnUsersManager hhvnUsersManager) 
    : IRequestHandler<AktarmaDashBilancoOnGetGraphYearQuery, GenericResult<AktarmaDashBilancoOnGetGraphYearResponse>>
{

    public Task<GenericResult<AktarmaDashBilancoOnGetGraphYearResponse>> Handle(AktarmaDashBilancoOnGetGraphYearQuery request, CancellationToken cancellationToken)
    {
        var userId = Convert.ToInt64(request.UserId);
        hhvnUsersManager.SetYear(request.Request.nyear, userId);
            
        return Task.FromResult(GenericResult<AktarmaDashBilancoOnGetGraphYearResponse>.Success(
            new AktarmaDashBilancoOnGetGraphYearResponse
            {
                Response = new JsonResult("OK")
            }));
    }
}