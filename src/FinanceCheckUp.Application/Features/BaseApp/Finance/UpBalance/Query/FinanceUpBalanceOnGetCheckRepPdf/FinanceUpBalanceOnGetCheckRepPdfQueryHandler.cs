using FinanceCheckUp.Application.Common.Constants;
using FinanceCheckUp.Application.ExtensionHelpers;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Application.Models.Responses.Finance.UpBalance;
using FinanceCheckUp.Framework.Core.Models;
using fincheckup.Report;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.UpBalance.Query.FinanceUpBalanceOnGetCheckRepPdf;
public class FinanceUpBalanceOnGetCheckRepPdfQueryHandler(
    ICompanyReportManager companyReportManager,
    ICompanyManager companyManager) 
    : IRequestHandler<FinanceUpBalanceOnGetCheckRepPdfQuery, GenericResult<FinanceUpBalanceOnGetCheckRepPdfResponse>>
{

    public Task<GenericResult<FinanceUpBalanceOnGetCheckRepPdfResponse>> Handle(FinanceUpBalanceOnGetCheckRepPdfQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var userId = Convert.ToInt64(request.UserId);
            request.InitialModel.UserID = userId;

            
            string FileDocz = "";
 
            request.InitialModel.curCompany = companyManager.Get_CompanyRow(request.Request.companyID);
            List<CompanyReport> nlist = companyReportManager.Get_CompanyReportList(request.Request.companyID);
            nlist = nlist.Where(x => x.MainYear == request.Request.nyear && x.FileTypeID == ReportConstant.FileTypePDF && x.ReportTypeID == ReportConstant.ReportTypeMizan).ToList();

            if (nlist.Count > 0)
            {
                FileDocz = "FileContent/" + nlist[0].ReportName;
               
                
                return Task.FromResult(GenericResult<FinanceUpBalanceOnGetCheckRepPdfResponse>.Success(new FinanceUpBalanceOnGetCheckRepPdfResponse
                {
                    InitialModel = request.InitialModel,
                    Response = new JsonResult(FileDocz)
                }));
            }
            string NewRepName = "MizanRapor-" + request.InitialModel.curCompany.TaxId.ToString() + request.Request.nyear.ToString() + ".pdf";
            FileDocz = "FileContent/" + NewRepName;
            var FileDic = "wwwroot\\FileContent\\" + NewRepName;


            string filePathZ = WebHelper.path;
            string FilePath = System.IO.Path.Combine(filePathZ, FileDic);



            BalanceReport report = companyReportManager.getMizanRaporu(request.Request.nyear, request.InitialModel.curCompany);
            report.CreateDocument();
            report.ExportToPdf(FilePath);
            companyReportManager.Set_Report(request.Request.companyID, userId, NewRepName, ReportConstant.FileTypePDF, ReportConstant.ReportTypeMizan, 12, request.Request.nyear, 0);

            return Task.FromResult(GenericResult<FinanceUpBalanceOnGetCheckRepPdfResponse>.Success(new FinanceUpBalanceOnGetCheckRepPdfResponse
            {
                InitialModel = request.InitialModel,
                Response = new JsonResult(FileDocz)
            }));

        }
        catch (Exception ex)
        {
            return Task.FromResult(GenericResult<FinanceUpBalanceOnGetCheckRepPdfResponse>.Fail(ex.Message));
        }
    }
}
