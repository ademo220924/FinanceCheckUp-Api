using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Responses.CashFlow;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinanceCheckUp.Application.Features.BaseApp.CashFlow.Query.GetGraphComp
{
    public class GetGraphCompQueryHandle(
        IHhvnUsersManager hhvnUsersManager,
        IUserCompanyManager userCompanyManager) : IRequestHandler<GetGraphCompQuery, GenericResult<GetGraphCompResponseModel>>
    {
        public async Task<GenericResult<GetGraphCompResponseModel>> Handle(GetGraphCompQuery request, CancellationToken cancellationToken)
        {
            if (request.RequestModel.ncompid < 1)
            {
                return GenericResult<GetGraphCompResponseModel>.Fail("nok");
            }

            var UserID = int.Parse(request.UserId);
            if (!hhvnUsersManager.CheckUser(request.RequestModel.ncompid, UserID))
            {
                return GenericResult<GetGraphCompResponseModel>.Success(new GetGraphCompResponseModel { Response = new JsonResult("ok") });
            }

            userCompanyManager.Update_UserDefault(UserID, request.RequestModel.ncompid);
            return GenericResult<GetGraphCompResponseModel>.Success(new GetGraphCompResponseModel { Response = new JsonResult("ok") });
        }
    }
}
