using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Application.Models.Responses.Finance.UpReportMain;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
namespace FinanceCheckUp.Application.Features.BaseApp.Finance.UpReportMain.Query.FinanceUpReportMainOnGetSalerYear;
public class FinanceUpReportMainOnGetSalerYearQueryHandler : IRequestHandler<FinanceUpReportMainOnGetSalerYearQuery, GenericResult<FinanceUpReportMainOnGetSalerYearResponse>>
{
    public Task<GenericResult<FinanceUpReportMainOnGetSalerYearResponse>> Handle(FinanceUpReportMainOnGetSalerYearQuery request, CancellationToken cancellationToken)
    {
        var yearSetMonth = YearResult.getValue().OrderByDescending(x => x.MYear);
                return Task.FromResult(GenericResult<FinanceUpReportMainOnGetSalerYearResponse>.Success(new FinanceUpReportMainOnGetSalerYearResponse
        {
            Response  = DataSourceLoader.Load(yearSetMonth, request.Request.options)
        }));
    }
}
