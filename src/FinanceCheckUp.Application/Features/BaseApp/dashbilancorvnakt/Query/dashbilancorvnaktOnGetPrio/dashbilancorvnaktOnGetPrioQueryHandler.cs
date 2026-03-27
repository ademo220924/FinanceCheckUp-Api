using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Common.Constants;
using FinanceCheckUp.Application.Models.Responses.dashbilancorvnakt;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
namespace FinanceCheckUp.Application.Features.BaseApp.dashbilancorvnakt.Query.dashbilancorvnaktOnGetPrio;
public class dashbilancorvnaktOnGetPrioQueryHandler : IRequestHandler<dashbilancorvnaktOnGetPrioQuery, GenericResult<dashbilancorvnaktOnGetPrioResponse>>
{

    public async Task<GenericResult<dashbilancorvnaktOnGetPrioResponse>> Handle(dashbilancorvnaktOnGetPrioQuery request, CancellationToken cancellationToken)
    {
                return GenericResult<dashbilancorvnaktOnGetPrioResponse>.Success(new dashbilancorvnaktOnGetPrioResponse { Result = DataSourceLoader.Load(AppConst.PriorityResources, request.Request.DataSourceLoadOptions) });
    }
}