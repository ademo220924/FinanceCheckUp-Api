using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Application.Models.Responses.upbalance;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
namespace FinanceCheckUp.Application.Features.BaseApp.upbalance.Query.upbalanceOnGetSalerYear;
public class upbalanceOnGetSalerYearQueryHandler : IRequestHandler<upbalanceOnGetSalerYearQuery, GenericResult<upbalanceOnGetSalerYearResponse>>
{

    public async Task<GenericResult<upbalanceOnGetSalerYearResponse>> Handle(upbalanceOnGetSalerYearQuery request, CancellationToken cancellationToken)
    {
        var UserID = Convert.ToInt32(request.UserId);
        var YearSetm = YearResult.getValue().OrderByDescending(x => x.MYear);
                return GenericResult<upbalanceOnGetSalerYearResponse>.Success(new upbalanceOnGetSalerYearResponse { Result = DataSourceLoader.Load(YearSetm, request.Request.Options) });
    }
}