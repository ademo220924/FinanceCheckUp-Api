using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Application.Models.Responses.upcmconsole;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
namespace FinanceCheckUp.Application.Features.BaseApp.upcmconsole.Query.upcmconsoleOnGetSalerYear;
public class upcmconsoleOnGetSalerYearQueryHandler : IRequestHandler<upcmconsoleOnGetSalerYearQuery, GenericResult<upcmconsoleOnGetSalerYearResponse>>
{

    public async Task<GenericResult<upcmconsoleOnGetSalerYearResponse>> Handle(upcmconsoleOnGetSalerYearQuery request, CancellationToken cancellationToken)
    {
        var UserID = Convert.ToInt32(request.UserId);
        var YearSetm = YearResult.getValue().OrderByDescending(x => x.MYear);
                return GenericResult<upcmconsoleOnGetSalerYearResponse>.Success(new upcmconsoleOnGetSalerYearResponse { Result = DataSourceLoader.Load(YearSetm, request.Request.Options) });
    }
}