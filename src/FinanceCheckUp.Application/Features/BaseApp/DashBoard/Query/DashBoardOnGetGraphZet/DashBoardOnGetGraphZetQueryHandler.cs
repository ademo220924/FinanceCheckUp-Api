using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Responses.DashBoard;
using FinanceCheckUp.Application.Models.ViewModel;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace FinanceCheckUp.Application.Features.BaseApp.DashBoard.Query.DashBoardOnGetGraphZet;
public class DashBoardOnGetGraphZetQueryHandler(IHhvnUsersManager hhvnUsersManager, IMainDashManager mainDashManager) : IRequestHandler<DashBoardOnGetGraphZetQuery, GenericResult<DashBoardOnGetGraphZetResponse>>
{

    public async Task<GenericResult<DashBoardOnGetGraphZetResponse>> Handle(DashBoardOnGetGraphZetQuery request, CancellationToken cancellationToken)
    {
        var UserID = Convert.ToInt32(request.UserId);

        if (!hhvnUsersManager.CheckUser(request.Request.compid, UserID))
            return GenericResult<DashBoardOnGetGraphZetResponse>.Success(new DashBoardOnGetGraphZetResponse { Result = new JsonResult(DataSourceLoader.Load(new List<YearlyErrorResult>(), request.Request.DataSourceLoadOptions)) });

        var retval = mainDashManager.Get_Data(request.Request.myear, request.Request.compid).OrderBy(x => x.MainMonth);
        return GenericResult<DashBoardOnGetGraphZetResponse>.Success(new DashBoardOnGetGraphZetResponse { Result = new JsonResult(DataSourceLoader.Load(retval, request.Request.DataSourceLoadOptions)) });
    }
}