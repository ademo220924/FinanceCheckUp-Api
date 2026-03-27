using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Common.Constants;
using FinanceCheckUp.Application.Models.Responses.DashBilanco;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
namespace FinanceCheckUp.Application.Features.BaseApp.DashBilanco.Query.DashBilancoOnGetPrio;
public class DashBilancoOnGetPrioQueryHandler : IRequestHandler<DashBilancoOnGetPrioQuery, GenericResult<DashBilancoOnGetPrioResponse>>
{

    public async Task<GenericResult<DashBilancoOnGetPrioResponse>> Handle(DashBilancoOnGetPrioQuery request, CancellationToken cancellationToken)
    {
                return GenericResult<DashBilancoOnGetPrioResponse>.Success(new DashBilancoOnGetPrioResponse { Result = DataSourceLoader.Load(AppConst.PriorityResources, request.RequestModel.DataSourceLoadOptions) });
    }
}