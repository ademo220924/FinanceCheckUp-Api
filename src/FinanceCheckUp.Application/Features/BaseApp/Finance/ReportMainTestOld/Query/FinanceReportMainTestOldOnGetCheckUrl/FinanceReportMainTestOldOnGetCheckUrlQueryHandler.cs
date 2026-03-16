using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Application.Models.Requests.Finance.ReportMainTestOld;
using FinanceCheckUp.Application.Models.Responses.Finance.ReportMainTestOld;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.ReportMainTestOld.Query.FinanceReportMainTestOldOnGetCheckUrl;
public class FinanceReportMainTestOldOnGetCheckUrlQueryHandler(ICompanyReportManager companyReportManager) 
    : IRequestHandler<FinanceReportMainTestOldOnGetCheckUrlQuery, GenericResult<FinanceReportMainTestOldOnGetCheckUrlResponse>>
{
    public Task<GenericResult<FinanceReportMainTestOldOnGetCheckUrlResponse>> Handle(FinanceReportMainTestOldOnGetCheckUrlQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var nlist = companyReportManager.Get_CompanyReport(request.Request.fileID);
            var fileDocz = "FileContent/" + nlist.ReportName;
            
            return Task.FromResult(GenericResult<FinanceReportMainTestOldOnGetCheckUrlResponse>.Success(new FinanceReportMainTestOldOnGetCheckUrlResponse
            {
                Response = new JsonResult(fileDocz)
            }));

        }
        catch (Exception ex)
        {
            return Task.FromResult(GenericResult<FinanceReportMainTestOldOnGetCheckUrlResponse>.Fail(ex.Message));
        }
    }
}
