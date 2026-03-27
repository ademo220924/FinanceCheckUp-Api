using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Application.Models.Responses.upchecky;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
namespace FinanceCheckUp.Application.Features.BaseApp.upchecky.Query.upcheckyOnGetSalerYear;
public class upcheckyOnGetSalerYearQueryHandler : IRequestHandler<upcheckyOnGetSalerYearQuery, GenericResult<upcheckyOnGetSalerYearResponse>>
{

    public async Task<GenericResult<upcheckyOnGetSalerYearResponse>> Handle(upcheckyOnGetSalerYearQuery request, CancellationToken cancellationToken)
    {
        var UserID = Convert.ToInt32(request.UserId);
        var YearSetm = YearResult.getValue().OrderByDescending(x => x.MYear);
                return GenericResult<upcheckyOnGetSalerYearResponse>.Success(new upcheckyOnGetSalerYearResponse { Result = DataSourceLoader.Load(YearSetm, request.Request.Options) });
    }
}