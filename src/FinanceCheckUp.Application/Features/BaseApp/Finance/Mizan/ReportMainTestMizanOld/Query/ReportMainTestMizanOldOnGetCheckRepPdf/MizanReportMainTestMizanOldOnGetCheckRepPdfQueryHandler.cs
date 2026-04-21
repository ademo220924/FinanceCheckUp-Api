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
using FinanceCheckUp.Application.Managers.StaticManagers;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.ReportMainTestMizanOld.Query.ReportMainTestMizanOldOnGetCheckRepPdf
{
    public class MizanReportMainTestMizanOldOnGetCheckRepPdfQueryHandler(
        ICompanyReportManager companyReportManager,
        INaceCodeManager naceCodeManager, ICompanyManager companyManager) : IRequestHandler<MizanReportMainTestMizanOldOnGetCheckRepPdfQuery, GenericResult<MizanReportMainTestMizanOldOnGetCheckRepPdfResponse>>
    {

        public Task<GenericResult<MizanReportMainTestMizanOldOnGetCheckRepPdfResponse>> Handle(MizanReportMainTestMizanOldOnGetCheckRepPdfQuery request, CancellationToken cancellationToken)
        {
             try
             {
                 var codde = naceCodeManager.GetRow_NaceCodes(Convert.ToInt32(request.Request.nacceco));
                 string FileDocz = "";
            
                 var userId = Convert.ToInt64(request.UserId);
                 var curCompany = companyManager.Get_CompanyRow(request.Request.companyID);
                 var curCompanyYearList = companyManager.Get_CompanyReportYearMainMizan(request.Request.companyID);
            
                 curCompanyYearList.Sort();
                 int nyear =!curCompanyYearList.Any() ?curCompanyYearList.Max():DateTime.Now.Year;
                 List<CompanyReport> nlist = companyReportManager.Get_CompanyReportList(request.Request.companyID);
                 nlist = nlist.Where(x => x.MainYear == nyear && x.FileTypeID == ReportConstant.FileTypePDF && x.ReportTypeID == ReportConstant.ReportTypeMainOld).ToList();
                 string compnacecode = "2790";
                 if (!string.IsNullOrEmpty(curCompany.NaceCode) && !string.IsNullOrWhiteSpace(curCompany.NaceCode))
                 {
                     if (curCompany.NaceCode.Length == 3)
                     { compnacecode = curCompany.NaceCode.Replace(".", "").Substring(0, 3); }
                     else { compnacecode = curCompany.NaceCode.Replace(".", "").Substring(0, 4); }
                 }
                 if (nlist.Count > 0)
                 {
                     FileDocz = "FileContent/" + nlist[0].ReportName;
                     return Task.FromResult(GenericResult<MizanReportMainTestMizanOldOnGetCheckRepPdfResponse>.Success(new MizanReportMainTestMizanOldOnGetCheckRepPdfResponse
                     {
                         Response = new JsonResult(FileDocz),
                         CurCompanyYearList =  curCompanyYearList,
                         FilePath= FileDocz,
                         UserId= userId,
                         CompanyId= curCompany.Id,
                         Nacceco = compnacecode,
                         Ncccode = codde.Id.ToString()
                     }));
                 }
                 var NewRepName = "FinansalDurumRapor-" + curCompany.TaxId.ToString() + ".pdf";
                 FileDocz = "FileContent/" + NewRepName;
                 var FileDic = "wwwroot\\FileContent\\" + NewRepName;
            
                 string filePathZ = WebHelper.path;
                 string FilePath = System.IO.Path.Combine(filePathZ, FileDic);
            
            
                 switch (curCompanyYearList.Count)
                 {
                     case >= 4:
                     case 3:
                     case 2:
                         companyReportManager.Set_Report(request.Request.companyID, userId, NewRepName, ReportConstant.FileTypePDF, ReportConstant.ReportTypeMainOld, 12, nyear, 0);
                         break;
                 }
                 
                 return Task.FromResult(GenericResult<MizanReportMainTestMizanOldOnGetCheckRepPdfResponse>.Success(new MizanReportMainTestMizanOldOnGetCheckRepPdfResponse
                 {
                     Response = new JsonResult(FileDocz),
                     CurCompanyYearList =  curCompanyYearList,
                     FilePath= FileDocz,
                     UserId= userId,
                     CompanyId= curCompany.Id,
                     Nacceco = compnacecode,
                     Ncccode = codde.Id.ToString()
                 }));
            
             }
             catch (Exception ex)
             {
                 return Task.FromResult(GenericResult<MizanReportMainTestMizanOldOnGetCheckRepPdfResponse>.Fail(ex.Message));
             }
        }
    }
}