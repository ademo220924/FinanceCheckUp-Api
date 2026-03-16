using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.ReportMainTestMizan;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.ReportMainTestMizan.Query.ReportMainTestMizanOnGetSalerYear;
public class MizanReportMainTestMizanOnGetSalerYearQueryHandler : IRequestHandler<MizanReportMainTestMizanOnGetSalerYearQuery, GenericResult<MizanReportMainTestMizanOnGetSalerYearResponse>>
{
    public Task<GenericResult<MizanReportMainTestMizanOnGetSalerYearResponse>> Handle(MizanReportMainTestMizanOnGetSalerYearQuery request, CancellationToken cancellationToken)
    {
        var year = YearResult.getValue().OrderByDescending(x => x.MYear);
        return Task.FromResult(GenericResult<MizanReportMainTestMizanOnGetSalerYearResponse>.Success(new MizanReportMainTestMizanOnGetSalerYearResponse
        {
            Response = new JsonResult(DataSourceLoader.Load(year, request.Request.options))
        }));
    }
}
