using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Common.Constants;
using FinanceCheckUp.Application.Models.Responses.DashCrmDetaild;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinanceCheckUp.Application.Features.BaseApp.DashCrmDetaild.Query.DashCrmDetaildOnGetPrio;

public class DashCrmDetaildOnGetPrioQueryHandler : IRequestHandler<DashCrmDetaildOnGetPrioQuery, GenericResult<DashCrmDetaildOnGetPrioResponse>>
{

    public async Task<GenericResult<DashCrmDetaildOnGetPrioResponse>> Handle(DashCrmDetaildOnGetPrioQuery request, CancellationToken cancellationToken)
    {
        return GenericResult<DashCrmDetaildOnGetPrioResponse>.Success(new DashCrmDetaildOnGetPrioResponse { Response = new JsonResult(DataSourceLoader.Load(AppConst.PriorityResources, request.Request.Options)) });
    }
}