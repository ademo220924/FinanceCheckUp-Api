using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.ReportMainTestMizanOld;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.ReportMainTestMizanOld.Query.
    ReportMainTestMizanOldOnGetCheckUrl;

public class MizanReportMainTestMizanOldOnGetCheckUrlQueryHandler(ICompanyReportManager companyReportManager)
    : IRequestHandler<MizanReportMainTestMizanOldOnGetCheckUrlQuery,
        GenericResult<MizanReportMainTestMizanOldOnGetCheckUrlResponse>>
{
    public Task<GenericResult<MizanReportMainTestMizanOldOnGetCheckUrlResponse>> Handle(MizanReportMainTestMizanOldOnGetCheckUrlQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var nlist = companyReportManager.Get_CompanyReport(request.Request.fileID);
            var fileDocz = "FileContent/" + nlist.ReportName;

            return Task.FromResult(GenericResult<MizanReportMainTestMizanOldOnGetCheckUrlResponse>.Success(
                new MizanReportMainTestMizanOldOnGetCheckUrlResponse
                {
                    Response = new JsonResult(fileDocz)
                }));
        }
        catch (Exception ex)
        {
            return Task.FromResult(GenericResult<MizanReportMainTestMizanOldOnGetCheckUrlResponse>.Fail(ex.ToString()));
        }
    }
}