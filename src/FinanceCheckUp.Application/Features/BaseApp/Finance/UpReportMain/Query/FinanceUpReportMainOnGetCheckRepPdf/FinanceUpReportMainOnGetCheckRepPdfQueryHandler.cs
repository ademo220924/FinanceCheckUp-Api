using FinanceCheckUp.Application.Common.Constants;
using FinanceCheckUp.Application.ExtensionHelpers;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Application.Models.Requests.Finance.UpReportMain;
using FinanceCheckUp.Application.Models.Responses.Finance.UpReportMain;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using FinanceCheckUp.Application.Managers.StaticManagers;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.UpReportMain.Query.FinanceUpReportMainOnGetCheckRepPdf;
public class FinanceUpReportMainOnGetCheckRepPdfQueryHandler(
    ICompanyReportManager companyReportManager,
    ICompanyManager companyManager) : IRequestHandler<FinanceUpReportMainOnGetCheckRepPdfQuery, GenericResult<FinanceUpReportMainOnGetCheckRepPdfResponse>>
{
    public Task<GenericResult<FinanceUpReportMainOnGetCheckRepPdfResponse>> Handle(FinanceUpReportMainOnGetCheckRepPdfQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var FileDocz = "";
            var userId = Convert.ToInt64(request.UserId);
            request.InitialModel.UserID = userId;
            request.InitialModel.nyear = request.Request.nyear;
            request.InitialModel.companyID = request.Request.companyID;
            
            request.InitialModel.curCompany = companyManager.Get_CompanyRow(request.InitialModel.companyID);
            List<CompanyReport> nlist = companyReportManager.Get_CompanyReportList(request.InitialModel.companyID);
            nlist = nlist.Where(x => x.MainYear == request.InitialModel.nyear && x.FileTypeID == ReportConstant.FileTypePDF && x.ReportTypeID == ReportConstant.ReportTypeMain).ToList();

            if (nlist.Count > 0)
            {
                FileDocz = "FileContent/" + nlist[0].ReportName;
                
                return Task.FromResult(GenericResult<FinanceUpReportMainOnGetCheckRepPdfResponse>.Success(new FinanceUpReportMainOnGetCheckRepPdfResponse
                {
                    Response =new JsonResult(FileDocz),
                    InitialModel = request.InitialModel
                })); 
            }
            var newRepName = "FinansalRapor-" + request.InitialModel.curCompany.TaxId + request.InitialModel.nyear + ".pdf";
            FileDocz = "FileContent/" + newRepName;
            var FileDic = "wwwroot\\FileContent\\" + newRepName;


            var filePathZ = WebHelper.path;
            request.InitialModel.FilePath = Path.Combine(filePathZ, FileDic);
 
            return Task.FromResult(GenericResult<FinanceUpReportMainOnGetCheckRepPdfResponse>.Success(new FinanceUpReportMainOnGetCheckRepPdfResponse
            {
                Response =new JsonResult(FileDocz),
                InitialModel = request.InitialModel
            })); 

        }
        catch (Exception ex)
        {
            return Task.FromResult(GenericResult<FinanceUpReportMainOnGetCheckRepPdfResponse>.Fail(ex.Message));
        }
    }
}
