using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Common.Constants;
using FinanceCheckUp.Application.Models.Responses.dashbilancoakt;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinanceCheckUp.Application.Features.BaseApp.dashbilancoakt.Query.dashbilancoaktOnGetPrio;
public class dashbilancoaktOnGetPrioQueryHandler : IRequestHandler<dashbilancoaktOnGetPrioQuery, GenericResult<dashbilancoaktOnGetPrioResponse>>
{
    public async Task<GenericResult<dashbilancoaktOnGetPrioResponse>> Handle(dashbilancoaktOnGetPrioQuery request, CancellationToken cancellationToken)
    {
        return GenericResult<dashbilancoaktOnGetPrioResponse>.Success(new dashbilancoaktOnGetPrioResponse { Result = new JsonResult(DataSourceLoader.Load(AppConst.PriorityResources, request.Request.DataSourceLoadOptions)) });
    }
}