using FinanceCheckUp.Application.Common.Constants;
using FinanceCheckUp.Application.ExtensionHelpers;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Application.Models.Responses.Finance.ReportMainTestOld;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.ReportMainTestOld.Query.FinanceReportMainTestOldOnGetCheckRepPdf;
public class FinanceReportMainTestOldOnGetCheckRepPdfQueryHandler(
    INaceCodeManager naceCodeManager,
    ICompanyReportManager companyReportManager,
    ICompanyManager companyManager) : IRequestHandler<FinanceReportMainTestOldOnGetCheckRepPdfQuery, GenericResult<FinanceReportMainTestOldOnGetCheckRepPdfResponse>>
{

    public Task<GenericResult<FinanceReportMainTestOldOnGetCheckRepPdfResponse>> Handle(FinanceReportMainTestOldOnGetCheckRepPdfQuery request, CancellationToken cancellationToken)
    {
        try
        {
            
            var userId = Convert.ToInt64(request.UserId);
            request.InitialModel.UserID = userId;
            request.InitialModel.codde = naceCodeManager.GetRow_NaceCodes(Convert.ToInt32(request.Request.nacceco));
            request.InitialModel.FileDocz = ""; 
            request.InitialModel.curCompany = companyManager.Get_CompanyRow(request.Request.companyID);
            request.InitialModel.curCompanyYearList = companyManager.Get_CompanyReportYearMain(request.Request.companyID);
            IEnumerable<int> curCompanyNonYearList = companyManager.Get_CompanyReportYear(request.Request.companyID);
            request.InitialModel.curCompanyYearList.Sort();
            int nyear = request.InitialModel.curCompanyYearList.Max();
            List<CompanyReport> nlist = companyReportManager.Get_CompanyReportList(request.Request.companyID);
            nlist = nlist.Where(x => x.MainYear == nyear && x.FileTypeID == ReportConstant.FileTypePDF && x.ReportTypeID == ReportConstant.ReportTypeMainOld).ToList();
            string compnacecode = "2790";
            if (!string.IsNullOrEmpty(request.InitialModel.curCompany.NaceCode) && !string.IsNullOrWhiteSpace(request.InitialModel.curCompany.NaceCode))
            {
                if (request.InitialModel.curCompany.NaceCode.Length  == 3)
                { compnacecode = request.InitialModel.curCompany.NaceCode.Replace(".", "").Substring(0, 3); }
                else { compnacecode = request.InitialModel.curCompany.NaceCode.Replace(".", "").Substring(0, 4); }
            }
            if (nlist.Count > 0)
            {
                request.InitialModel.FileDocz = "FileContent/" + nlist[0].ReportName;
                return Task.FromResult(GenericResult<FinanceReportMainTestOldOnGetCheckRepPdfResponse>.Success(new FinanceReportMainTestOldOnGetCheckRepPdfResponse
                {
                    InitialModel = request.InitialModel,
                    Response = new JsonResult(request.InitialModel.FileDocz)
                }));
            }
            string NewRepName = "FinansalDurumRapor-" + request.InitialModel.curCompany.TaxId.ToString() + ".pdf";
            request.InitialModel.FileDocz = "FileContent/" + NewRepName;
            var FileDic = "wwwroot\\FileContent\\" + NewRepName;
            request.InitialModel.curCompanyNonYearList = request.InitialModel.curCompanyYearList.Except(curCompanyNonYearList);

            string filePathZ = WebHelper.path;
            request.InitialModel.FilePath = System.IO.Path.Combine(filePathZ, FileDic);

            return Task.FromResult(GenericResult<FinanceReportMainTestOldOnGetCheckRepPdfResponse>.Success(new FinanceReportMainTestOldOnGetCheckRepPdfResponse
            {
                InitialModel = request.InitialModel,
                Response = new JsonResult(request.InitialModel.FileDocz)
            }));

        }
        catch (Exception ex)
        {
            return Task.FromResult(GenericResult<FinanceReportMainTestOldOnGetCheckRepPdfResponse>.Fail(ex.Message));
        }
    }
}
