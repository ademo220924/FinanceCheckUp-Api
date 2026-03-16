using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Common.Constants;
using FinanceCheckUp.Application.Models.Responses.DashCrmDetaila;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace FinanceCheckUp.Application.Features.BaseApp.DashCrmDetaila.Query.DashCrmDetailaOnGetPrio;
public class DashCrmDetailaOnGetPrioQueryHandler : IRequestHandler<DashCrmDetailaOnGetPrioQuery, GenericResult<DashCrmDetailaOnGetPrioResponse>>
{

    public async Task<GenericResult<DashCrmDetailaOnGetPrioResponse>> Handle(DashCrmDetailaOnGetPrioQuery request, CancellationToken cancellationToken)
    {
        return GenericResult<DashCrmDetailaOnGetPrioResponse>.Success(new DashCrmDetailaOnGetPrioResponse { Response = new JsonResult(DataSourceLoader.Load(AppConst.PriorityResources, request.Request.Options)) });
    }
}