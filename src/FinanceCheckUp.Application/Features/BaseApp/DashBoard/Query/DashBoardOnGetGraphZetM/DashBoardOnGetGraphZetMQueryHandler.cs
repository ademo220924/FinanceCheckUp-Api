using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Responses.DashBoard;
using FinanceCheckUp.Application.Models.ViewModel;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinanceCheckUp.Application.Features.BaseApp.DashBoard.Query.DashBoardOnGetGraphZetM;
public class DashBoardOnGetGraphZetMQueryHandler(IHhvnUsersManager hhvnUsersManager, IMainDashManager mainDashManager) : IRequestHandler<DashBoardOnGetGraphZetMQuery, GenericResult<DashBoardOnGetGraphZetMResponse>>
{

    public async Task<GenericResult<DashBoardOnGetGraphZetMResponse>> Handle(DashBoardOnGetGraphZetMQuery request, CancellationToken cancellationToken)
    {

        var UserID = Convert.ToInt32(request.UserId);

        if (!hhvnUsersManager.CheckUser(request.Request.compid, UserID))
            return GenericResult<DashBoardOnGetGraphZetMResponse>.Success(new DashBoardOnGetGraphZetMResponse { Result = new JsonResult(new List<YearlyErrorResult>()) });

        var retval = mainDashManager.Get_Data(request.Request.myear, request.Request.compid);
        return GenericResult<DashBoardOnGetGraphZetMResponse>.Success(new DashBoardOnGetGraphZetMResponse { Result = new JsonResult(retval) });
    }
}