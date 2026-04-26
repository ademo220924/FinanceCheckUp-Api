using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.UpBalanceNew;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using FinanceCheckUp.Application.Common.Constants;
using fincheckup.Report;
using Microsoft.Extensions.Hosting;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.UpBalanceNew.Query.UpBalanceNewOnGetCheckRepPdf
{
    public class MizanUpBalanceNewOnGetCheckRepPdfQueryHandler(
        ICompanyReportManager companyReportManager,
        ICompanyManager companyManager,
        IHostEnvironment hostEnvironment)
        : IRequestHandler<MizanUpBalanceNewOnGetCheckRepPdfQuery, GenericResult<MizanUpBalanceNewOnGetCheckRepPdfResponse>>
    {
        public Task<GenericResult<MizanUpBalanceNewOnGetCheckRepPdfResponse>> Handle(MizanUpBalanceNewOnGetCheckRepPdfQuery request, CancellationToken cancellationToken)
        {
            try
            {
                string FileDocz = "";

                var userId = Convert.ToInt64(request.UserId);
                request.InitialModel.UserID = userId;


                request.InitialModel.curCompany = companyManager.Get_CompanyRow(request.Request.companyID);
                List<CompanyReport> nlist = companyReportManager.Get_CompanyReportList(request.Request.companyID);
                nlist = nlist.Where(x =>
                    x.MainYear == request.Request.nyear && x.FileTypeID == ReportConstant.FileTypePDF &&
                    x.ReportTypeID == ReportConstant.ReportTypeMizan).ToList();

                var fileContentDir = System.IO.Path.Combine(hostEnvironment.ContentRootPath, "wwwroot", "FileContent");
                System.IO.Directory.CreateDirectory(fileContentDir);

                if (nlist.Count > 0)
                {
                    var existingName = nlist[0].ReportName;
                    var existingFullPath = System.IO.Path.Combine(fileContentDir, existingName);
                    if (System.IO.File.Exists(existingFullPath))
                    {
                        FileDocz = "FileContent/" + existingName;
                        return Task.FromResult(GenericResult<MizanUpBalanceNewOnGetCheckRepPdfResponse>.Success(
                            new MizanUpBalanceNewOnGetCheckRepPdfResponse
                            {
                                InitialModel = request.InitialModel,
                                Response = FileDocz
                            }));
                    }
                }

                string NewRepName = "MizanRapor-" + request.InitialModel.curCompany.TaxId.ToString() +
                                    request.Request.nyear.ToString() + ".pdf";
                FileDocz = "FileContent/" + NewRepName;
                var filePath = System.IO.Path.GetFullPath(System.IO.Path.Combine(fileContentDir, NewRepName));

                BalanceReport report =
                    companyReportManager.getMizanRaporuMizan(request.Request.nyear, request.InitialModel.curCompany);
                report.CreateDocument();
                report.ExportToPdf(filePath);

                if (!System.IO.File.Exists(filePath))
                {
                    return Task.FromResult(GenericResult<MizanUpBalanceNewOnGetCheckRepPdfResponse>.Fail(
                        "PDF oluşturuldu ancak diske yazılamadı veya dosya bulunamıyor: " + filePath));
                }

                companyReportManager.Set_Report(request.Request.companyID, request.InitialModel.UserID, NewRepName,
                    ReportConstant.FileTypePDF, ReportConstant.ReportTypeMizan, 12, request.Request.nyear, 0);

                return Task.FromResult(GenericResult<MizanUpBalanceNewOnGetCheckRepPdfResponse>.Success(
                    new MizanUpBalanceNewOnGetCheckRepPdfResponse
                    {
                        InitialModel = request.InitialModel,
                        Response = FileDocz
                    }));
            }
            catch (Exception ex)
            {
                return Task.FromResult(GenericResult<MizanUpBalanceNewOnGetCheckRepPdfResponse>.Fail(ex.ToString()));
            }
        }
    }
}