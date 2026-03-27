using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Application.Models.Responses.Finance.ReportMainTestOld;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
namespace FinanceCheckUp.Application.Features.BaseApp.Finance.ReportMainTestOld.Query.FinanceReportMainTestOldOnGetSalerYear;
public class FinanceReportMainTestOldOnGetSalerYearQueryHandler : IRequestHandler<FinanceReportMainTestOldOnGetSalerYearQuery, GenericResult<FinanceReportMainTestOldOnGetSalerYearResponse>>
{
    public Task<GenericResult<FinanceReportMainTestOldOnGetSalerYearResponse>> Handle(FinanceReportMainTestOldOnGetSalerYearQuery request, CancellationToken cancellationToken)
    {
        var yearSetMonth = YearResult.getValue().OrderByDescending(x => x.MYear);
                return Task.FromResult(GenericResult<FinanceReportMainTestOldOnGetSalerYearResponse>.Success(new FinanceReportMainTestOldOnGetSalerYearResponse
        {
            Response =DataSourceLoader.Load(yearSetMonth, request.Request.options)
        }));

    }
}
