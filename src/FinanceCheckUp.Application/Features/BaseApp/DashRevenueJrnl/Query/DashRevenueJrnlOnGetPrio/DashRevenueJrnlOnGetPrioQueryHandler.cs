using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Common.Constants;
using FinanceCheckUp.Application.Models.Responses.DashRevenueJrnl;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
namespace FinanceCheckUp.Application.Features.BaseApp.DashRevenueJrnl.Query.DashRevenueJrnlOnGetPrio;
public class DashRevenueJrnlOnGetPrioQueryHandler : IRequestHandler<DashRevenueJrnlOnGetPrioQuery, GenericResult<DashRevenueJrnlOnGetPrioResponse>>
{

    public async Task<GenericResult<DashRevenueJrnlOnGetPrioResponse>> Handle(DashRevenueJrnlOnGetPrioQuery request, CancellationToken cancellationToken)
    {
                return GenericResult<DashRevenueJrnlOnGetPrioResponse>.Success(new DashRevenueJrnlOnGetPrioResponse { Response = DataSourceLoader.Load(AppConst.PriorityResources, request.Request.Options) });
    }
}