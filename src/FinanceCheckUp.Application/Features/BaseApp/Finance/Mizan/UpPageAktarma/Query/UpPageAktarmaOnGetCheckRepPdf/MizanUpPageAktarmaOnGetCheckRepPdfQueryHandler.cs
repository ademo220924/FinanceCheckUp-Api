using FinanceCheckUp.Application.Common.Constants;
using FinanceCheckUp.Application.ExtensionHelpers;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.UpPageAktarma;
using FinanceCheckUp.Framework.Core.Models;
using fincheckup.Report;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.UpPageAktarma.Query.UpPageAktarmaOnGetCheckRepPdf
{
    public class MizanUpPageAktarmaOnGetCheckRepPdfQueryHandler(
        ICompanyReportManager companyReportManager,
        ICompanyManager companyManager) : IRequestHandler<MizanUpPageAktarmaOnGetCheckRepPdfQuery, GenericResult<MizanUpPageAktarmaOnGetCheckRepPdfResponse>>
    {
        public Task<GenericResult<MizanUpPageAktarmaOnGetCheckRepPdfResponse>> Handle(MizanUpPageAktarmaOnGetCheckRepPdfQuery request, CancellationToken cancellationToken)
        {
            try
            {
                string FileDocz = "";

                var userId = Convert.ToInt64(request.UserId);
                request.InitialModel.UserID = userId;
                
                 var curCompany = companyManager.Get_CompanyRow(request.Request.companyID);
                List<CompanyReport> nlist = companyReportManager.Get_CompanyReportList(request.Request.companyID);
                nlist = nlist.Where(x => x.MainYear == request.Request.nyear && x.FileTypeID == ReportConstant.FileTypePDF && x.ReportTypeID == ReportConstant.ReportTypeMizanAktarma).ToList();

                if (nlist.Count > 0)
                {
                    FileDocz = "FileContent/" + nlist[0].ReportName;
                    return Task.FromResult(GenericResult<MizanUpPageAktarmaOnGetCheckRepPdfResponse>.Success(
                        new MizanUpPageAktarmaOnGetCheckRepPdfResponse
                        {
                            InitialModel = request.InitialModel,
                            Response = new JsonResult(FileDocz)
                        }));
                }
                string NewRepName = "MizanRaporAktarma-" + curCompany.TaxId.ToString() + request.Request.nyear.ToString() + ".pdf";
                FileDocz = "FileContent/" + NewRepName;
                var FileDic = "wwwroot\\FileContent\\" + NewRepName;


                string filePathZ = WebHelper.path;
                string FilePath = System.IO.Path.Combine(filePathZ, FileDic);



                BalanceReportAktarma report = companyReportManager.getMizanRaporuMizanAkt(request.Request.nyear, curCompany);
                report.CreateDocument();
                report.ExportToPdf(FilePath);
                companyReportManager.Set_Report(request.Request.companyID, userId, NewRepName, ReportConstant.FileTypePDF, ReportConstant.ReportTypeMizanAktarma, 12, request.Request.nyear, 0);

                return Task.FromResult(GenericResult<MizanUpPageAktarmaOnGetCheckRepPdfResponse>.Success(
                    new MizanUpPageAktarmaOnGetCheckRepPdfResponse
                    {
                        InitialModel = request.InitialModel,
                        Response = new JsonResult(FileDocz)
                    }));

            }
            catch (Exception ex) 
            {
                return Task.FromResult(GenericResult<MizanUpPageAktarmaOnGetCheckRepPdfResponse>.Fail(ex.ToString()));
            }
        }
    }
}
