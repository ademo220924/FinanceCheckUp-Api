using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Common.Constants;
using FinanceCheckUp.Application.Models.Responses.DashCrmDetailc;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
namespace FinanceCheckUp.Application.Features.BaseApp.DashCrmDetailc.Query.DashCrmDetailcOnGetPrio;
public class DashCrmDetailcOnGetPrioQueryHandler : IRequestHandler<DashCrmDetailcOnGetPrioQuery, GenericResult<DashCrmDetailcOnGetPrioResponse>>
{

    public async Task<GenericResult<DashCrmDetailcOnGetPrioResponse>> Handle(DashCrmDetailcOnGetPrioQuery request, CancellationToken cancellationToken)
    {
                return GenericResult<DashCrmDetailcOnGetPrioResponse>.Success(new DashCrmDetailcOnGetPrioResponse { Response = DataSourceLoader.Load(AppConst.PriorityResources, request.Request.Options) });
    }
}