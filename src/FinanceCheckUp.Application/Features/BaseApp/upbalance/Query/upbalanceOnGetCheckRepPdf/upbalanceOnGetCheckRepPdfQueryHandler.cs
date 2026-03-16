using FinanceCheckUp.Application.Common.Constants;
using FinanceCheckUp.Application.ExtensionHelpers;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Application.Models.Responses.upbalance;
using FinanceCheckUp.Framework.Core.Models;
using fincheckup.Report;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinanceCheckUp.Application.Features.BaseApp.upbalance.Query.upbalanceOnGetCheckRepPdf;
public class upbalanceOnGetCheckRepPdfQueryHandler(ICompanyManager companyManager, ICompanyReportManager companyReportManager) : IRequestHandler<upbalanceOnGetCheckRepPdfQuery, GenericResult<upbalanceOnGetCheckRepPdfResponse>>
{

    public async Task<GenericResult<upbalanceOnGetCheckRepPdfResponse>> Handle(upbalanceOnGetCheckRepPdfQuery request, CancellationToken cancellationToken)
    {

        try
        {
            string FileDocz = "";
            var UserID = Convert.ToInt64(request.UserId);

            var curCompany = companyManager.Get_CompanyRow(request.Request.companyID);
            List<CompanyReport> nlist = companyReportManager.Get_CompanyReportList(request.Request.companyID);
            nlist = nlist.Where(x => x.MainYear == request.Request.nyear && x.FileTypeID == ReportConstant.FileTypePDF && x.ReportTypeID == ReportConstant.ReportTypeMizan).ToList();

            if (nlist.Count > 0)
            {
                FileDocz = "Document/" + nlist[0].ReportName;
                return GenericResult<upbalanceOnGetCheckRepPdfResponse>.Success(new upbalanceOnGetCheckRepPdfResponse { Result = new JsonResult(FileDocz) });
            }
            string NewRepName = "MizanRapor-" + curCompany.TaxId.ToString() + request.Request.nyear.ToString() + ".pdf";
            FileDocz = "Document/" + NewRepName;
            var FileDic = "UploadFiles\\Document\\" + NewRepName;


            string filePathZ = WebHelper.path;
            string FilePath = Path.Combine(filePathZ, FileDic);



            BalanceReport report = companyReportManager.getMizanRaporu(request.Request.nyear, curCompany);
            report.CreateDocument();
            report.ExportToPdf(FilePath);
            companyReportManager.Set_Report(request.Request.companyID, UserID, NewRepName, ReportConstant.FileTypePDF, ReportConstant.ReportTypeMizan, 12, request.Request.nyear, 0);

            return GenericResult<upbalanceOnGetCheckRepPdfResponse>.Success(new upbalanceOnGetCheckRepPdfResponse { Result = new JsonResult(FileDocz) });

        }
        catch (Exception ex)
        {
            var chk = ex;
            return GenericResult<upbalanceOnGetCheckRepPdfResponse>.Success(new upbalanceOnGetCheckRepPdfResponse { Result = new JsonResult(ex.ToString()) });
        }

    }
}