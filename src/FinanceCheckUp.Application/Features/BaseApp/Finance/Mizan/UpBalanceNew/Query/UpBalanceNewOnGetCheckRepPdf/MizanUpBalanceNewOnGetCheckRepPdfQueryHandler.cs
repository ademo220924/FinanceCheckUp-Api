using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.UpBalanceNew;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using FinanceCheckUp.Application.Common.Constants;
using FinanceCheckUp.Application.ExtensionHelpers;
using fincheckup.Report;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.UpBalanceNew.Query.UpBalanceNewOnGetCheckRepPdf
{
    public class MizanUpBalanceNewOnGetCheckRepPdfQueryHandler(
        ICompanyReportManager companyReportManager,
        ICompanyManager companyManager)
        : IRequestHandler<MizanUpBalanceNewOnGetCheckRepPdfQuery, GenericResult<MizanUpBalanceNewOnGetCheckRepPdfResponse>>
    {
        public Task<GenericResult<MizanUpBalanceNewOnGetCheckRepPdfResponse>> Handle(MizanUpBalanceNewOnGetCheckRepPdfQuery request, CancellationToken cancellationToken)
        {
            try
            {
                string FileDocz = "";

                var userId = Convert.ToInt64(request.UserId);
                request.InitialModel.UserID = userId;


                request.InitialModel.curCompany = companyManager.Get_CompanyRow(request.Request.companyID);
                List<CompanyReport> nlist = companyReportManager.Get_CompanyReportList(request.Request.companyID);
                nlist = nlist.Where(x =>
                    x.MainYear == request.Request.nyear && x.FileTypeID == ReportConstant.FileTypePDF &&
                    x.ReportTypeID == ReportConstant.ReportTypeMizan).ToList();

                if (nlist.Count > 0)
                {
                    FileDocz = "FileContent/" + nlist[0].ReportName;

                    return Task.FromResult(GenericResult<MizanUpBalanceNewOnGetCheckRepPdfResponse>.Success(
                        new MizanUpBalanceNewOnGetCheckRepPdfResponse
                        {
                            InitialModel = request.InitialModel,
                            Response = new JsonResult(FileDocz)
                        }));
                }

                string NewRepName = "MizanRapor-" + request.InitialModel.curCompany.TaxId.ToString() +
                                    request.Request.nyear.ToString() + ".pdf";
                FileDocz = "FileContent/" + NewRepName;
                var FileDic = "wwwroot\\FileContent\\" + NewRepName;


                string filePathZ = WebHelper.path;
                string FilePath = System.IO.Path.Combine(filePathZ, FileDic);


                BalanceReport report =
                    companyReportManager.getMizanRaporuMizan(request.Request.nyear, request.InitialModel.curCompany);
                report.CreateDocument();
                report.ExportToPdf(FilePath);
                companyReportManager.Set_Report(request.Request.companyID, request.InitialModel.UserID, NewRepName,
                    ReportConstant.FileTypePDF, ReportConstant.ReportTypeMizan, 12, request.Request.nyear, 0);

                return Task.FromResult(GenericResult<MizanUpBalanceNewOnGetCheckRepPdfResponse>.Success(
                    new MizanUpBalanceNewOnGetCheckRepPdfResponse
                    {
                        InitialModel = request.InitialModel,
                        Response = new JsonResult(FileDocz)
                    }));
            }
            catch (Exception ex)
            {
                return Task.FromResult(GenericResult<MizanUpBalanceNewOnGetCheckRepPdfResponse>.Fail(ex.ToString()));
            }
        }
    }
}