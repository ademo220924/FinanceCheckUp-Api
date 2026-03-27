using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Common.Constants;
using FinanceCheckUp.Application.Models.Responses.dashbilancorvnmzn;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
namespace FinanceCheckUp.Application.Features.BaseApp.dashbilancorvnmzn.Query.dashbilancorvnmznOnGetPrio;
public class dashbilancorvnmznOnGetPrioQueryHandler : IRequestHandler<dashbilancorvnmznOnGetPrioQuery, GenericResult<dashbilancorvnmznOnGetPrioResponse>>
{

    public async Task<GenericResult<dashbilancorvnmznOnGetPrioResponse>> Handle(dashbilancorvnmznOnGetPrioQuery request, CancellationToken cancellationToken)
    {
                return GenericResult<dashbilancorvnmznOnGetPrioResponse>.Success(new dashbilancorvnmznOnGetPrioResponse { Result = DataSourceLoader.Load(AppConst.PriorityResources, request.Request.DataSourceLoadOptions) });
    }
}