using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Application.Models.Responses.Finance.UpPageAktarma;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
namespace FinanceCheckUp.Application.Features.BaseApp.Finance.UpPageAktarma.Query.FinanceUpPageAktarmaOnGetSalerYear;
public class FinanceUpPageAktarmaOnGetSalerYearQueryHandler 
    : IRequestHandler<FinanceUpPageAktarmaOnGetSalerYearQuery, GenericResult<FinanceUpPageAktarmaOnGetSalerYearResponse>>
{
    public Task<GenericResult<FinanceUpPageAktarmaOnGetSalerYearResponse>> Handle(FinanceUpPageAktarmaOnGetSalerYearQuery request, CancellationToken cancellationToken)
    {
        var yearSetMonth = YearResult.getValue().OrderByDescending(x => x.MYear);
                return Task.FromResult(GenericResult<FinanceUpPageAktarmaOnGetSalerYearResponse>.Success(new FinanceUpPageAktarmaOnGetSalerYearResponse
                {
                    Response = DataSourceLoader.Load(yearSetMonth, request.Request.options)
                }));
    }
}
