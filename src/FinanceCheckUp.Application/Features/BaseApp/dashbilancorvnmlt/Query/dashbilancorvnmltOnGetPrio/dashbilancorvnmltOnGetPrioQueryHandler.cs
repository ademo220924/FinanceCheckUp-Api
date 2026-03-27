using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Common.Constants;
using FinanceCheckUp.Application.Models.Responses.dashbilancorvnmlt;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
namespace FinanceCheckUp.Application.Features.BaseApp.dashbilancorvnmlt.Query.dashbilancorvnmltOnGetPrio;
public class dashbilancorvnmltOnGetPrioQueryHandler : IRequestHandler<dashbilancorvnmltOnGetPrioQuery, GenericResult<dashbilancorvnmltOnGetPrioResponse>>
{

    public async Task<GenericResult<dashbilancorvnmltOnGetPrioResponse>> Handle(dashbilancorvnmltOnGetPrioQuery request, CancellationToken cancellationToken)
    {
                return GenericResult<dashbilancorvnmltOnGetPrioResponse>.Success(new dashbilancorvnmltOnGetPrioResponse { Result = DataSourceLoader.Load(AppConst.PriorityResources, request.Request.DataSourceLoadOptions) });
    }
}