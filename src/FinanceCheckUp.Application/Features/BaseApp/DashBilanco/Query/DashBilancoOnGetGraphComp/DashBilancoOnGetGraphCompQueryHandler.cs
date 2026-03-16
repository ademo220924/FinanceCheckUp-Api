using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Responses.DashBilanco;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace FinanceCheckUp.Application.Features.BaseApp.DashBilanco.Query.DashBilancoOnGetGraphComp;
public class DashBilancoOnGetGraphCompQueryHandler(IHhvnUsersManager hhvnUsersManager, IUserCompanyManager userCompanyManager) : IRequestHandler<DashBilancoOnGetGraphCompQuery, GenericResult<DashBilancoOnGetGraphCompResponse>>
{

    public async Task<GenericResult<DashBilancoOnGetGraphCompResponse>> Handle(DashBilancoOnGetGraphCompQuery request, CancellationToken cancellationToken)
    {
        if (request.RequestModel.ncompid < 1)
            return GenericResult<DashBilancoOnGetGraphCompResponse>.Success(new DashBilancoOnGetGraphCompResponse { Result = new JsonResult("nok") });

        var UserID = Convert.ToInt32(request.UserId);
        if (!hhvnUsersManager.CheckUser(request.RequestModel.ncompid, UserID))
            return GenericResult<DashBilancoOnGetGraphCompResponse>.Success(new DashBilancoOnGetGraphCompResponse { Result = new JsonResult("ok") });

        userCompanyManager.Update_UserDefault(UserID, request.RequestModel.ncompid);
        return GenericResult<DashBilancoOnGetGraphCompResponse>.Success(new DashBilancoOnGetGraphCompResponse { Result = new JsonResult("ok") });
    }
}