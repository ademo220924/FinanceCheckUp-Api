using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Common.Constants;
using FinanceCheckUp.Application.Models.Responses.DashWorkingCapital;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
namespace FinanceCheckUp.Application.Features.BaseApp.DashWorkingCapital.Query.DashWorkingCapitalOnGetPrio;
public class DashWorkingCapitalOnGetPrioQueryHandler : IRequestHandler<DashWorkingCapitalOnGetPrioQuery, GenericResult<DashWorkingCapitalOnGetPrioResponse>>
{

    public async Task<GenericResult<DashWorkingCapitalOnGetPrioResponse>> Handle(DashWorkingCapitalOnGetPrioQuery request, CancellationToken cancellationToken)
    {
                return GenericResult<DashWorkingCapitalOnGetPrioResponse>.Success(new DashWorkingCapitalOnGetPrioResponse { Response = DataSourceLoader.Load(AppConst.PriorityResources, request.Request.Options) });
    }
}