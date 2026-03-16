using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Responses.DashBoard;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace FinanceCheckUp.Application.Features.BaseApp.DashBoard.Query.DashBoardOnGetShedule;
public class DashBoardOnGetSheduleQueryHandler(IShedulerMainManager shedulerMainManager) : IRequestHandler<DashBoardOnGetSheduleQuery, GenericResult<DashBoardOnGetSheduleResponse>>
{

    public async Task<GenericResult<DashBoardOnGetSheduleResponse>> Handle(DashBoardOnGetSheduleQuery request, CancellationToken cancellationToken)
    {
        var nreult = shedulerMainManager.Get_Data(DateTime.Now.Year);
        return GenericResult<DashBoardOnGetSheduleResponse>.Success(new DashBoardOnGetSheduleResponse { Result = new JsonResult(DataSourceLoader.Load(nreult, request.Request.DataSourceLoadOptions)) });
    }
}