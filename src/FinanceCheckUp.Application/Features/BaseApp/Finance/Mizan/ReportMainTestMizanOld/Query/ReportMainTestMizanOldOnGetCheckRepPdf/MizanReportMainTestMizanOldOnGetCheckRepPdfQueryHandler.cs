using FinanceCheckUp.Application.Common.Constants;
using FinanceCheckUp.Application.ExtensionHelpers;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Application.Models.Requests.Finance.Mizan.ReportMainTestMizanOld;
using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.ReportMainTestMizanOld;
using FinanceCheckUp.Domain.Entities;
using FinanceCheckUp.Framework.Core.Models;
using fincheckup.Report;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.ReportMainTestMizanOld.Query.ReportMainTestMizanOldOnGetCheckRepPdf
{
    public class MizanReportMainTestMizanOldOnGetCheckRepPdfQueryHandler(IHhvnUsersManager hhvnUsersManager, ICompanyManager companiesManager, IUserTypeManager userTypeManager, ICompanyManager companyManager, ITBLXmlManager tBLXmlManager) : IRequestHandler<MizanReportMainTestMizanOldOnGetCheckRepPdfQuery, GenericResult<MizanReportMainTestMizanOldOnGetCheckRepPdfResponse>>
    {
        public MizanReportMainTestMizanOldRequestInitialModel responseModel = new();

        public Task<GenericResult<MizanReportMainTestMizanOldOnGetCheckRepPdfResponse>> Handle(MizanReportMainTestMizanOldOnGetCheckRepPdfQuery request, CancellationToken cancellationToken)
        {
            // try
            // {
            //     var codde = NaceCode.GetRow_NaceCodes(Convert.ToInt32(nacceco));
            //     string FileDocz = "";
            //
            //     UserID = Int64.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            //     Companies curCompany = Companies.Get_CompanyRow(companyID);
            //     List<int> curCompanyYearList = Companies.Get_CompanyReportYearMainMizan(companyID);
            //
            //     curCompanyYearList.Sort();
            //     int nyear = curCompanyYearList.Max();
            //     List<CompanyReport> nlist = CompanyReport.Get_CompanyReportList(companyID);
            //     nlist = nlist.Where(x => x.MainYear == nyear && x.FileTypeID == ReportConstant.FileTypePDF && x.ReportTypeID == ReportConstant.ReportTypeMainOld).ToList();
            //     string compnacecode = "2790";
            //     if (!string.IsNullOrEmpty(curCompany.NaceCode) && !string.IsNullOrWhiteSpace(curCompany.NaceCode))
            //     {
            //         if (curCompany.NaceCode.Length == 3)
            //         { compnacecode = curCompany.NaceCode.Replace(".", "").Substring(0, 3); }
            //         else { compnacecode = curCompany.NaceCode.Replace(".", "").Substring(0, 4); }
            //     }
            //     if (nlist.Count > 0)
            //     {
            //         FileDocz = "FileContent/" + nlist[0].ReportName;
            //         return new JsonResult(FileDocz);
            //     }
            //     string NewRepName = "FinansalDurumRapor-" + curCompany.TaxID.ToString() + ".pdf";
            //     FileDocz = "FileContent/" + NewRepName;
            //     var FileDic = "wwwroot\\FileContent\\" + NewRepName;
            //
            //     string filePathZ = WebHelper.path;
            //     string FilePath = System.IO.Path.Combine(filePathZ, FileDic);
            //
            //
            //     if (curCompanyYearList.Count >= 4)
            //     {
            //         ReportFinancialdynamicd report = ReportCheckZoneold.getReportMizanIV(curCompany.ID, compnacecode, UserID, curCompanyYearList, codde.ID.ToString());
            //         report.CreateDocument();
            //         report.ExportToPdf(FilePath);
            //         CompanyReport.Set_Report(companyID, UserID, NewRepName, ReportConstant.FileTypePDF, ReportConstant.ReportTypeMainOld, 12, nyear, 0);
            //     }
            //     else if (curCompanyYearList.Count == 3)
            //     {
            //         ReportFinancialdynamic report = ReportCheckZoneold.getReportMizanIII(curCompany.ID, compnacecode, UserID, curCompanyYearList, codde.ID.ToString());
            //         report.CreateDocument();
            //         report.ExportToPdf(FilePath);
            //         CompanyReport.Set_Report(companyID, UserID, NewRepName, ReportConstant.FileTypePDF, ReportConstant.ReportTypeMainOld, 12, nyear, 0);
            //     }
            //     else if (curCompanyYearList.Count == 2)
            //     {
            //         ReportFinancialdynamicb report = ReportCheckZoneold.getReportMizanII(curCompany.ID, compnacecode, UserID, curCompanyYearList, codde.ID.ToString());
            //         report.CreateDocument();
            //         report.ExportToPdf(FilePath);
            //         CompanyReport.Set_Report(companyID, UserID, NewRepName, ReportConstant.FileTypePDF, ReportConstant.ReportTypeMainOld, 12, nyear, 0);
            //     }
            //
            //     return new JsonResult(FileDocz);
            //
            // }
            // catch (Exception ex)
            // {
            //     var chk = ex;
            //     return new JsonResult(ex.ToString());
            //
            //
            // }


            throw new Exception();
        }
    }
}
