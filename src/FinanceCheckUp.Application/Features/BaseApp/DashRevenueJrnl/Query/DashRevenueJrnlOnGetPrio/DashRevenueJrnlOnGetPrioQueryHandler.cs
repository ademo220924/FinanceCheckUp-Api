using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Common.Constants;
using FinanceCheckUp.Application.Models.Responses.DashRevenueJrnl;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace FinanceCheckUp.Application.Features.BaseApp.DashRevenueJrnl.Query.DashRevenueJrnlOnGetPrio;
public class DashRevenueJrnlOnGetPrioQueryHandler : IRequestHandler<DashRevenueJrnlOnGetPrioQuery, GenericResult<DashRevenueJrnlOnGetPrioResponse>>
{

    public async Task<GenericResult<DashRevenueJrnlOnGetPrioResponse>> Handle(DashRevenueJrnlOnGetPrioQuery request, CancellationToken cancellationToken)
    {
        return GenericResult<DashRevenueJrnlOnGetPrioResponse>.Success(new DashRevenueJrnlOnGetPrioResponse { Response = new JsonResult(DataSourceLoader.Load(AppConst.PriorityResources, request.Request.Options)) });
    }
}