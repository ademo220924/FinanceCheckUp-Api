using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Application.Models.Responses.Finance.ReportMainTest;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.ReportMainTest.Query.FinanceReportMainTestOnGetSalerYear;
public class FinanceReportMainTestOnGetSalerYearQueryHandler : IRequestHandler<FinanceReportMainTestOnGetSalerYearQuery, GenericResult<FinanceReportMainTestOnGetSalerYearResponse>>
{
    public Task<GenericResult<FinanceReportMainTestOnGetSalerYearResponse>> Handle(FinanceReportMainTestOnGetSalerYearQuery request, CancellationToken cancellationToken)
    {
        var yearSetMonth = YearResult.getValue().OrderByDescending(x => x.MYear);
        return Task.FromResult(GenericResult<FinanceReportMainTestOnGetSalerYearResponse>.Success(new FinanceReportMainTestOnGetSalerYearResponse
        {
            Response = new JsonResult(DataSourceLoader.Load(yearSetMonth, request.Request.options))
        }));

    }
}
