using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Responses;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;

namespace FinanceCheckUp.Application.Features.BaseApp.Daily.Query.GetList;

public class DailyGetListQueryHandle(IShedulerMainManager shedulerMainManager) : IRequestHandler<DailyGetListQuery, GenericResult<DailyGetListResponse>>
{
    public async Task<GenericResult<DailyGetListResponse>> Handle(DailyGetListQuery request, CancellationToken cancellationToken)
    {
        var mRequestList = shedulerMainManager.Get_Data(request.Year);
        var loadResult = DataSourceLoader.Load(mRequestList, request.DataSourceLoadOptions);

        return GenericResult<DailyGetListResponse>.Success(new DailyGetListResponse { LoadResult = loadResult });
    }
}