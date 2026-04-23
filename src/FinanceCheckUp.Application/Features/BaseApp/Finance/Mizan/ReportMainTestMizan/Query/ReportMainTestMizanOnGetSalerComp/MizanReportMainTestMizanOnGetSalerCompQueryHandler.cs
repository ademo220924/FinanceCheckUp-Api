using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.ReportMainTestMizan;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.ReportMainTestMizan.Query.ReportMainTestMizanOnGetSalerComp;
public class MizanReportMainTestMizanOnGetSalerCompQueryHandler(ICompanyManager companyManager) 
    : IRequestHandler<MizanReportMainTestMizanOnGetSalerCompQuery, GenericResult<MizanReportMainTestMizanOnGetSalerCompResponse>>
{
    public Task<GenericResult<MizanReportMainTestMizanOnGetSalerCompResponse>> Handle(MizanReportMainTestMizanOnGetSalerCompQuery request, CancellationToken cancellationToken)
    {
        return Task.FromResult(GenericResult<MizanReportMainTestMizanOnGetSalerCompResponse>.Success(new MizanReportMainTestMizanOnGetSalerCompResponse
        {
            Response = DataSourceLoader.Load(companyManager.Getby_User(Convert.ToInt64(request.UserId)), request.Request.options)
        }));
    }
}
