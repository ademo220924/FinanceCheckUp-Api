using FinanceCheckUp.Application.Configurations.Settings;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.ReportMainTestMizan;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using Microsoft.Extensions.Options;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.ReportMainTestMizan.Query.ReportMainTestMizanOnGetCheckUrl;
public class MizanReportMainTestMizanOnGetCheckUrlQueryHandler(
    ICompanyReportManager companyReportManager,
    IOptions<PublicFileHostingSettings> publicFileHosting) 
    : IRequestHandler<MizanReportMainTestMizanOnGetCheckUrlQuery, GenericResult<MizanReportMainTestMizanOnGetCheckUrlResponse>>
{
    public Task<GenericResult<MizanReportMainTestMizanOnGetCheckUrlResponse>> Handle(MizanReportMainTestMizanOnGetCheckUrlQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var nlist = companyReportManager.Get_CompanyReport(request.Request.fileID);
            var relative = "FileContent/" + nlist.ReportName;
            var fileUrl = BuildPublicFileUrl(relative, publicFileHosting.Value);
            return Task.FromResult(GenericResult<MizanReportMainTestMizanOnGetCheckUrlResponse>.Success(new MizanReportMainTestMizanOnGetCheckUrlResponse
            {
                FileUrl = fileUrl
            }));
        }
        catch (Exception ex)
        {
            return Task.FromResult(GenericResult<MizanReportMainTestMizanOnGetCheckUrlResponse>.Fail(ex.ToString()));
        }
    }

    private static string BuildPublicFileUrl(string relativePath, PublicFileHostingSettings? settings)
    {
        relativePath = relativePath.Replace('\\', '/');
        var b = (settings?.BaseUrl ?? "").Trim().TrimEnd('/');
        return string.IsNullOrEmpty(b) ? relativePath : $"{b}/{relativePath}";
    }
}
