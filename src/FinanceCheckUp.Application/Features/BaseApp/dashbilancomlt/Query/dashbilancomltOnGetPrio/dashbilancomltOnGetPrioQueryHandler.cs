using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Common.Constants;
using FinanceCheckUp.Application.Models.Responses.dashbilancomlt;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinanceCheckUp.Application.Features.BaseApp.dashbilancomlt.Query.dashbilancomltOnGetPrio;
public class dashbilancomltOnGetPrioQueryHandler : IRequestHandler<dashbilancomltOnGetPrioQuery, GenericResult<dashbilancomltOnGetPrioResponse>>
{

    public async Task<GenericResult<dashbilancomltOnGetPrioResponse>> Handle(dashbilancomltOnGetPrioQuery request, CancellationToken cancellationToken)
    {
        return GenericResult<dashbilancomltOnGetPrioResponse>.Success(new dashbilancomltOnGetPrioResponse { Result = new JsonResult(DataSourceLoader.Load(AppConst.PriorityResources, request.Request.DataSourceLoadOptions)) });
    }
}