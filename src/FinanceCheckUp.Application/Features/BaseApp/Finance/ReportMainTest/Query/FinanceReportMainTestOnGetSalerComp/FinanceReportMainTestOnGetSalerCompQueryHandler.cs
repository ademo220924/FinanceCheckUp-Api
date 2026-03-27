using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Responses.Finance.ReportMainTest;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
namespace FinanceCheckUp.Application.Features.BaseApp.Finance.ReportMainTest.Query.FinanceReportMainTestOnGetSalerComp;
public class FinanceReportMainTestOnGetSalerCompQueryHandler(ICompanyManager companyManager) : IRequestHandler<FinanceReportMainTestOnGetSalerCompQuery, GenericResult<FinanceReportMainTestOnGetSalerCompResponse>>
{
    public Task<GenericResult<FinanceReportMainTestOnGetSalerCompResponse>> Handle(FinanceReportMainTestOnGetSalerCompQuery request, CancellationToken cancellationToken)
    {
        var userId = Convert.ToInt64(request.UserId);
        var mreqListCompany = companyManager.Getby_User(userId);
        
                return Task.FromResult(GenericResult<FinanceReportMainTestOnGetSalerCompResponse>.Success(new FinanceReportMainTestOnGetSalerCompResponse
        {
            Response =DataSourceLoader.Load(mreqListCompany, request.Request.options)
        }));

    }
}
