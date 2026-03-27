using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Common.Constants;
using FinanceCheckUp.Application.Models.Responses.DashCrmDetail;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
namespace FinanceCheckUp.Application.Features.BaseApp.DashCrmDetail.Query.DashCrmDetailOnGetPrio;
public class DashCrmDetailOnGetPrioQueryHandler : IRequestHandler<DashCrmDetailOnGetPrioQuery, GenericResult<DashCrmDetailOnGetPrioResponse>>
{

    public async Task<GenericResult<DashCrmDetailOnGetPrioResponse>> Handle(DashCrmDetailOnGetPrioQuery request, CancellationToken cancellationToken)
    {
                return GenericResult<DashCrmDetailOnGetPrioResponse>.Success(new DashCrmDetailOnGetPrioResponse { Response = DataSourceLoader.Load(AppConst.PriorityResources, request.Request.Options) });
    }
}