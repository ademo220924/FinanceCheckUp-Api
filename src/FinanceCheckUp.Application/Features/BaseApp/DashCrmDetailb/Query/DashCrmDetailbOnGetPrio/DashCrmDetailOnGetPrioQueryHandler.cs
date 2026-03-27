using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Common.Constants;
using FinanceCheckUp.Application.Models.Responses.DashCrmDetailb;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
namespace FinanceCheckUp.Application.Features.BaseApp.DashCrmDetailb.Query.DashCrmDetailbOnGetPrio;
public class DashCrmDetailbOnGetPrioQueryHandler : IRequestHandler<DashCrmDetailbOnGetPrioQuery, GenericResult<DashCrmDetailbOnGetPrioResponse>>
{

    public async Task<GenericResult<DashCrmDetailbOnGetPrioResponse>> Handle(DashCrmDetailbOnGetPrioQuery request, CancellationToken cancellationToken)
    {
                return GenericResult<DashCrmDetailbOnGetPrioResponse>.Success(new DashCrmDetailbOnGetPrioResponse { Response = DataSourceLoader.Load(AppConst.PriorityResources, request.Request.Options) });
    }
}