using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Common.Constants;
using FinanceCheckUp.Application.Models.Responses.dashbilancojrnl;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinanceCheckUp.Application.Features.BaseApp.dashbilancojrnl.Query.dashbilancojrnlOnGetPrio;
public class dashbilancojrnlOnGetPrioQueryHandler : IRequestHandler<dashbilancojrnlOnGetPrioQuery, GenericResult<dashbilancojrnlOnGetPrioResponse>>
{

    public async Task<GenericResult<dashbilancojrnlOnGetPrioResponse>> Handle(dashbilancojrnlOnGetPrioQuery request, CancellationToken cancellationToken)
    {
        return GenericResult<dashbilancojrnlOnGetPrioResponse>.Success(new dashbilancojrnlOnGetPrioResponse { Result = new JsonResult(DataSourceLoader.Load(AppConst.PriorityResources, request.Request.DataSourceLoadOptions)) });
    }
}