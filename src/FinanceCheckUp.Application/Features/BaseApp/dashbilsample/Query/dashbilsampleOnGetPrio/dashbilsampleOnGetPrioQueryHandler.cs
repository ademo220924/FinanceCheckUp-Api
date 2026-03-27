using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Common.Constants;
using FinanceCheckUp.Application.Models.Responses.dashbilsample;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
namespace FinanceCheckUp.Application.Features.BaseApp.dashbilsample.Query.dashbilsampleOnGetPrio;
public class dashbilsampleOnGetPrioQueryHandler : IRequestHandler<dashbilsampleOnGetPrioQuery, GenericResult<dashbilsampleOnGetPrioResponse>>
{

    public async Task<GenericResult<dashbilsampleOnGetPrioResponse>> Handle(dashbilsampleOnGetPrioQuery request, CancellationToken cancellationToken)
    {
                return GenericResult<dashbilsampleOnGetPrioResponse>.Success(new dashbilsampleOnGetPrioResponse { Result = DataSourceLoader.Load(AppConst.PriorityResources, request.Request.DataSourceLoadOptions) });
    }
}