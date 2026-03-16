using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Common.Constants;
using FinanceCheckUp.Application.Models.Responses.DashBoard;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinanceCheckUp.Application.Features.BaseApp.DashBoard.Query.DashBoardOnGetPrio;
public class DashBoardOnGetPrioQueryHandler : IRequestHandler<DashBoardOnGetPrioQuery, GenericResult<DashBoardOnGetPrioResponse>>
{

    public async Task<GenericResult<DashBoardOnGetPrioResponse>> Handle(DashBoardOnGetPrioQuery request, CancellationToken cancellationToken)
    {
        return GenericResult<DashBoardOnGetPrioResponse>.Success(new DashBoardOnGetPrioResponse { Result = new JsonResult(DataSourceLoader.Load(AppConst.PriorityResources, request.Request.DataSourceLoadOptions)) });
    }
}