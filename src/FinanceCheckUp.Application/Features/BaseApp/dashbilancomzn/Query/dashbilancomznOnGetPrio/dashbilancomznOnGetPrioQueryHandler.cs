using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Common.Constants;
using FinanceCheckUp.Application.Models.Responses.dashbilancomzn;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
namespace FinanceCheckUp.Application.Features.BaseApp.dashbilancomzn.Query.dashbilancomznOnGetPrio;
public class dashbilancomznOnGetPrioQueryHandler : IRequestHandler<dashbilancomznOnGetPrioQuery, GenericResult<dashbilancomznOnGetPrioResponse>>
{

    public async Task<GenericResult<dashbilancomznOnGetPrioResponse>> Handle(dashbilancomznOnGetPrioQuery request, CancellationToken cancellationToken)
    {
                return GenericResult<dashbilancomznOnGetPrioResponse>.Success(new dashbilancomznOnGetPrioResponse { Result = DataSourceLoader.Load(AppConst.PriorityResources, request.Request.DataSourceLoadOptions) });
    }
}