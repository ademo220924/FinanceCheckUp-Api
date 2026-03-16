using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Common.Constants;
using FinanceCheckUp.Application.Models.Responses;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;

namespace FinanceCheckUp.Application.Features.BaseApp.Daily.Query.Priority;

public class DailyGetPriorityQueryHandler : IRequestHandler<DailyGetPriorityQuery, GenericResult<DailyGetPriorityResponse>>
{
    public async Task<GenericResult<DailyGetPriorityResponse>> Handle(DailyGetPriorityQuery request, CancellationToken cancellationToken)
    {
        var mRequestList = AppConst.PriorityResources;
        var loadResult = DataSourceLoader.Load(mRequestList, request.DataSourceLoadOptions);
        return GenericResult<DailyGetPriorityResponse>.Success(new DailyGetPriorityResponse { LoadResult = loadResult });
    }
}