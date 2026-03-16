using FinanceCheckUp.Application.Common.Constants;
using FinanceCheckUp.Application.ExtensionHelpers;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Application.Models.Common;
using FinanceCheckUp.Application.Models.Responses.upaccount;
using FinanceCheckUp.Framework.Core.Models;
using fincheckup.Report;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace FinanceCheckUp.Application.Features.BaseApp.upaccount.Query.upaccountOnGetCheckRepPdf;
public class upaccountOnGetCheckRepPdfQueryHandler(ICompanyManager companyManager, ICompanyReportManager companyReportManager, IMainDashManager mainDashManager, IErrorCheckMainManager errorCheckMainManager) : IRequestHandler<upaccountOnGetCheckRepPdfQuery, GenericResult<upaccountOnGetCheckRepPdfResponse>>
{

    public async Task<GenericResult<upaccountOnGetCheckRepPdfResponse>> Handle(upaccountOnGetCheckRepPdfQuery request, CancellationToken cancellationToken)
    {
        try
        {
            string FileDocz = "";
            var UserID = Convert.ToInt64(request.UserId);

            var curCompany = companyManager.Get_CompanyRow(request.Request.companyID);
            List<CompanyReport> nlist = companyReportManager.Get_CompanyReportList(request.Request.companyID);
            nlist = nlist.Where(x => x.MainMonth == request.Request.nmonth && x.MainYear == request.Request.nyear && x.FileTypeID == ReportConstant.FileTypePDF && x.ReportTypeID == ReportConstant.ReportTypeAccounting).ToList();

            if (nlist.Count > 0)
            {
                FileDocz = "Document/" + nlist[0].ReportName;
                return GenericResult<upaccountOnGetCheckRepPdfResponse>.Success(new upaccountOnGetCheckRepPdfResponse { Result = new JsonResult(FileDocz) });
            }
            string NewRepName = "MuhasebeKayitRapor-" + curCompany.TaxId.ToString() + request.Request.nyear.ToString() + "-" + request.Request.nmonth.ToString() + ".pdf";
            FileDocz = "Document/" + NewRepName;
            var FileDic = "UploadFiles\\Document\\" + NewRepName;


            string filePathZ = WebHelper.path;
            string FilePath = System.IO.Path.Combine(filePathZ, FileDic);

            List<DataViewer> ncheck = mainDashManager.DataViewerMainSourceT(request.Request.nyear, request.Request.companyID, request.Request.nmonth);
            List<DataViewer> ncheckMain = errorCheckMainManager.Get_ReportSetAll(request.Request.nyear, request.Request.companyID, request.Request.nmonth);
            ncheck.AddRange(ncheckMain);

            if (ncheck.Count < 1)
            {
                return GenericResult<upaccountOnGetCheckRepPdfResponse>.Success(new upaccountOnGetCheckRepPdfResponse { Result = new JsonResult("nok") });
            }

            KontrolRaporu report = companyReportManager.getKontrolRaporu(request.Request.nyear, request.Request.companyID, request.Request.nmonth, ncheck);
            report.CreateDocument();
            report.ExportToPdf(FilePath);
            companyReportManager.Set_Report(request.Request.companyID, UserID, NewRepName, ReportConstant.FileTypePDF, ReportConstant.ReportTypeAccounting, request.Request.nmonth, request.Request.nyear, 0);

            return GenericResult<upaccountOnGetCheckRepPdfResponse>.Success(new upaccountOnGetCheckRepPdfResponse { Result = new JsonResult(FileDocz) });

        }
        catch (Exception ex)
        {
            var chk = ex;
            return GenericResult<upaccountOnGetCheckRepPdfResponse>.Fail(ex.ToString());
        }
    }
}