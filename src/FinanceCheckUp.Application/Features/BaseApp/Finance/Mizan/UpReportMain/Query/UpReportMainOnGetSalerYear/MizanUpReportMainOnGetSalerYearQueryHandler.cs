using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.UpReportMain;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.UpReportMain.Query.UpReportMainOnGetSalerYear
{
    public class MizanUpReportMainOnGetSalerYearQueryHandler : IRequestHandler<MizanUpReportMainOnGetSalerYearQuery, GenericResult<MizanUpReportMainOnGetSalerYearResponse>>
    {
        public Task<GenericResult<MizanUpReportMainOnGetSalerYearResponse>> Handle(MizanUpReportMainOnGetSalerYearQuery request, CancellationToken cancellationToken)
        {
            var yearSetMonth = YearResult.getValue().OrderByDescending(x => x.MYear);
                        return Task.FromResult(GenericResult<MizanUpReportMainOnGetSalerYearResponse>.Success(new MizanUpReportMainOnGetSalerYearResponse
            {
                Response = DataSourceLoader.Load(yearSetMonth, request.Request.options)
            }));
        }
    }
}
