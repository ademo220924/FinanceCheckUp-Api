using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Application.Models.Requests.Finance.Mizan.ReportMainTestMizanOld;
using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.ReportMainTestMizanOld;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.ReportMainTestMizanOld.Query.ReportMainTestMizanOldOnGetSalerYear;
public class MizanReportMainTestMizanOldOnGetSalerYearQueryHandler : IRequestHandler<MizanReportMainTestMizanOldOnGetSalerYearQuery, GenericResult<MizanReportMainTestMizanOldOnGetSalerYearResponse>>
{
    
    public Task<GenericResult<MizanReportMainTestMizanOldOnGetSalerYearResponse>> Handle(MizanReportMainTestMizanOldOnGetSalerYearQuery request, CancellationToken cancellationToken)
    {
        var yearMonth = YearResult.getValue().OrderByDescending(x => x.MYear);
        
        return Task.FromResult(GenericResult<MizanReportMainTestMizanOldOnGetSalerYearResponse>.Success(new MizanReportMainTestMizanOldOnGetSalerYearResponse
        {
            Response = new JsonResult(DataSourceLoader.Load(yearMonth, request.Request.options))
        }));

    }
}
