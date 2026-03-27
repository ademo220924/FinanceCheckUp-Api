using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Responses.Finance.ReportMainTestOld;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
namespace FinanceCheckUp.Application.Features.BaseApp.Finance.ReportMainTestOld.Query.FinanceReportMainTestOldOnGetSalerComp;
public class FinanceReportMainTestOldOnGetSalerCompQueryHandler(ICompanyManager companyManager) 
    : IRequestHandler<FinanceReportMainTestOldOnGetSalerCompQuery, GenericResult<FinanceReportMainTestOldOnGetSalerCompResponse>>
{
    public Task<GenericResult<FinanceReportMainTestOldOnGetSalerCompResponse>> Handle(FinanceReportMainTestOldOnGetSalerCompQuery request, CancellationToken cancellationToken)
    {
        var userId = Convert.ToInt64(request.UserId);
        var mreqListCompany = companyManager.Getby_User(userId);
       
                return Task.FromResult(GenericResult<FinanceReportMainTestOldOnGetSalerCompResponse>.Success(new FinanceReportMainTestOldOnGetSalerCompResponse
        {
            Response = DataSourceLoader.Load(mreqListCompany, request.Request.options)
        }));
    }
}
