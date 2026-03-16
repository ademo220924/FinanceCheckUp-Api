using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Responses.DashBilanco;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace FinanceCheckUp.Application.Features.BaseApp.DashBilanco.Query.DashBilancoOnGetGraphYear;
public class DashBilancoOnGetGraphYearQueryHandler(IHhvnUsersManager hhvnUsersManager) : IRequestHandler<DashBilancoOnGetGraphYearQuery, GenericResult<DashBilancoOnGetGraphYearResponse>>
{

    public async Task<GenericResult<DashBilancoOnGetGraphYearResponse>> Handle(DashBilancoOnGetGraphYearQuery request, CancellationToken cancellationToken)
    {
        var UserID = Convert.ToInt64(request.UserId);
        hhvnUsersManager.SetYear(request.RequestModel.nyear, UserID);
        return GenericResult<DashBilancoOnGetGraphYearResponse>.Success(new DashBilancoOnGetGraphYearResponse { Response = new JsonResult("ok") });
    }
}