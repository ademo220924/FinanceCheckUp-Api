using FinanceCheckUp.Application.ExtensionHelpers;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Managers.StaticManagers;
using FinanceCheckUp.Application.Models.Responses.upreportqnb;
using FinanceCheckUp.Application.Models.ViewModel;
using FinanceCheckUp.Framework.Core.Models;
using fincheckup.Report;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace FinanceCheckUp.Application.Features.BaseApp.upreportqnb.Query.upreportqnbOnGetCheckRep;
public class upreportqnbOnGetCheckRepQueryHandler(
    ICompanyManager companyManager,
    INaceCodeManager naceCodeManager,
    ICompanyQnbReportManager companyQnbReportManager,
    IReportCheckZoneManager reportCheckZoneManager) : IRequestHandler<upreportqnbOnGetCheckRepQuery, GenericResult<upreportqnbOnGetCheckRepResponse>>
{

    public async Task<GenericResult<upreportqnbOnGetCheckRepResponse>> Handle(upreportqnbOnGetCheckRepQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var UserID = Convert.ToInt64(request.UserId);
            var codde = naceCodeManager.GetRow_NaceCodes(Convert.ToInt32(request.Request.nacceco));
            List<int> yearCount = companyManager.Get_CompanyReportYear(request.Request.companyID);
            List<int> yearCountFull = companyManager.Get_CompanyReportYearFull(request.Request.companyID);

            int repcount = companyQnbReportManager.Get_CompanyReportCount(request.Request.companyID);
            var curCompany = companyManager.Get_CompanyRow(request.Request.companyID);
            var NewRepName = curCompany.TaxId.ToString() + "-FinReport-" + (repcount + 1).ToString("D4") + ".pdf";

            var FileDic = "UploadFiles\\Documents\\" + NewRepName;
            string filePathZ = WebHelper.path;
            string FilePath = Path.Combine(filePathZ, FileDic);
            CompanyReportView grview = companyManager.Get_CompanyReportView(request.Request.companyID);
            yearCount.Sort();
            yearCountFull.Sort();
            switch (yearCountFull.Count)
            {
                case 1:
                    FinansRaporu report = reportCheckZoneManager.getReport(request.Request.companyID, yearCount, codde.Id.ToString(), (int)UserID, yearCountFull[0], grview);
                    report.CreateDocument();
                    report.ExportToPdf(FilePath);
                    companyQnbReportManager.Set_Report(request.Request.companyID, UserID, NewRepName); break;
                case 2:
                    FinansRaporua reporta = reportCheckZoneManager.getReporta(request.Request.companyID, yearCount, codde.Id.ToString(), (int)UserID, yearCountFull, grview);
                    reporta.CreateDocument();
                    reporta.ExportToPdf(FilePath);
                    companyQnbReportManager.Set_Report(request.Request.companyID, UserID, NewRepName); break;
                case 3:
                    FinansRaporub reportb = reportCheckZoneManager.getReportb(request.Request.companyID, yearCount, codde.Id.ToString(), (int)UserID, yearCountFull, grview);
                    reportb.CreateDocument();
                    reportb.ExportToPdf(FilePath);
                    companyQnbReportManager.Set_Report(request.Request.companyID, UserID, NewRepName); break;
                case 4:
                    FinansRaporuc reportc = reportCheckZoneManager.getReportc(request.Request.companyID, yearCount, codde.Id.ToString(), (int)UserID, yearCountFull, grview);
                    reportc.CreateDocument();
                    reportc.ExportToPdf(FilePath);
                    companyQnbReportManager.Set_Report(request.Request.companyID, UserID, NewRepName); break;
                default:
                    break;
            }


        }
        catch (Exception ex)
        {
            var chk = ex;
            return GenericResult<upreportqnbOnGetCheckRepResponse>.Success(new upreportqnbOnGetCheckRepResponse { Result = new JsonResult(ex.ToString()) });


        }

        //var FileDocz = "/FileContent/" + NewRepName;

        //Send the File to Download.
        return GenericResult<upreportqnbOnGetCheckRepResponse>.Success(new upreportqnbOnGetCheckRepResponse { Result = new JsonResult("ok") });


    }
}