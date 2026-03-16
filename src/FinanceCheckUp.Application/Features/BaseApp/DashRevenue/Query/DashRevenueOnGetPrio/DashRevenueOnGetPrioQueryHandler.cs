using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Common.Constants;
using FinanceCheckUp.Application.Models.Responses.DashRevenue;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace FinanceCheckUp.Application.Features.BaseApp.DashRevenue.Query.DashRevenueOnGetPrio;
public class DashRevenueOnGetPrioQueryHandler : IRequestHandler<DashRevenueOnGetPrioQuery, GenericResult<DashRevenueOnGetPrioResponse>>
{

    public async Task<GenericResult<DashRevenueOnGetPrioResponse>> Handle(DashRevenueOnGetPrioQuery request, CancellationToken cancellationToken)
    {
        return GenericResult<DashRevenueOnGetPrioResponse>.Success(new DashRevenueOnGetPrioResponse { Response = new JsonResult(DataSourceLoader.Load(AppConst.PriorityResources, request.Request.Options)) });
    }
}