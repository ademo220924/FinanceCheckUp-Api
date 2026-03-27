using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Application.Models.Responses.Finance.UpPageAktarmaJrnl;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
namespace FinanceCheckUp.Application.Features.BaseApp.Finance.UpPageAktarmaJrnl.Query.FinanceUpPageAktarmaJrnlOnGetSalerYear;
public class FinanceUpPageAktarmaJrnlOnGetSalerYearQueryHandler : IRequestHandler<FinanceUpPageAktarmaJrnlOnGetSalerYearQuery, GenericResult<FinanceUpPageAktarmaJrnlOnGetSalerYearResponse>>
{
    public Task<GenericResult<FinanceUpPageAktarmaJrnlOnGetSalerYearResponse>> Handle(FinanceUpPageAktarmaJrnlOnGetSalerYearQuery request, CancellationToken cancellationToken)
    {
        var yearSetMonth = YearResult.getValue().OrderByDescending(x => x.MYear); 
                return Task.FromResult(GenericResult<FinanceUpPageAktarmaJrnlOnGetSalerYearResponse>.Success(new FinanceUpPageAktarmaJrnlOnGetSalerYearResponse
                {
                    Response = DataSourceLoader.Load(yearSetMonth, request.Request.options)
                }));
    }
}
