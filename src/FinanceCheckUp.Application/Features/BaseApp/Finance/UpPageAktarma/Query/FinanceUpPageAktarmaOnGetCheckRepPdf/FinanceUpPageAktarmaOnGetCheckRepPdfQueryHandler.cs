using FinanceCheckUp.Application.Common.Constants;
using FinanceCheckUp.Application.ExtensionHelpers;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Responses.Finance.UpPageAktarma;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.UpPageAktarma.Query.FinanceUpPageAktarmaOnGetCheckRepPdf;
public class FinanceUpPageAktarmaOnGetCheckRepPdfQueryHandler(
    ICompanyReportManager companyReportManager,
    ICompanyManager companyManager) : IRequestHandler<FinanceUpPageAktarmaOnGetCheckRepPdfQuery, GenericResult<FinanceUpPageAktarmaOnGetCheckRepPdfResponse>>
{
    public Task<GenericResult<FinanceUpPageAktarmaOnGetCheckRepPdfResponse>> Handle(FinanceUpPageAktarmaOnGetCheckRepPdfQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var userId = Convert.ToInt64(request.UserId);
            
            var FileDocz = "";

             var curCompany = companyManager.Get_CompanyRow(request.Request.companyID);
            var nlist = companyReportManager.Get_CompanyReportList(request.Request.companyID);
            nlist = nlist.Where(x => x.MainYear == request.Request.nyear && x.FileTypeID == ReportConstant.FileTypePDF && x.ReportTypeID == ReportConstant.ReportTypeMizanAktarma).ToList();

            if (nlist.Count > 0)
            {
                FileDocz = "FileContent/" + nlist[0].ReportName;
                 return Task.FromResult(GenericResult<FinanceUpPageAktarmaOnGetCheckRepPdfResponse>.Success(new FinanceUpPageAktarmaOnGetCheckRepPdfResponse
                       {
                           Response =new JsonResult(FileDocz)
                       }));

            }
            var NewRepName = "MizanRaporAktarma-" + curCompany.TaxId.ToString() + request.Request.nyear.ToString() + ".pdf";
            FileDocz = "FileContent/" + NewRepName;
            var FileDic = "wwwroot\\FileContent\\" + NewRepName;


            string filePathZ = WebHelper.path;
            string FilePath = System.IO.Path.Combine(filePathZ, FileDic);



            var report = companyReportManager.getMizanRaporuMizanAkt(request.Request.nyear, curCompany);
            report.CreateDocument();
            report.ExportToPdf(FilePath);
            companyReportManager.Set_Report(request.Request.companyID, userId, NewRepName, ReportConstant.FileTypePDF, ReportConstant.ReportTypeMizanAktarma, 12, request.Request.nyear, 0);

            return Task.FromResult(GenericResult<FinanceUpPageAktarmaOnGetCheckRepPdfResponse>.Success(new FinanceUpPageAktarmaOnGetCheckRepPdfResponse
            {
                Response =new JsonResult(FileDocz)
            }));

        }
        catch (Exception ex) {  return Task.FromResult(GenericResult<FinanceUpPageAktarmaOnGetCheckRepPdfResponse>.Fail(ex.Message)); }
    }
}
