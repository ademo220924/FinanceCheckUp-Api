using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Requests.Finance.Mizan.UpBalanceNew;
using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.UpBalanceNew;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using FinanceCheckUp.Application.Common.Constants;
using fincheckup.Report;
using Microsoft.Extensions.Hosting;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.UpBalanceNew.Query.UpBalanceNewOnGetCheckRepXls
{
    public class MizanUpBalanceNewOnGetCheckRepXlsQueryHandler(
        ICompanyReportManager companyReportManager,
        ICompanyManager companyManager,
        IHostEnvironment hostEnvironment) : IRequestHandler<MizanUpBalanceNewOnGetCheckRepXlsQuery, GenericResult<MizanUpBalanceNewOnGetCheckRepXlsResponse>>
    {
        public Task<GenericResult<MizanUpBalanceNewOnGetCheckRepXlsResponse>> Handle(MizanUpBalanceNewOnGetCheckRepXlsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var userId = Convert.ToInt64(request.UserId);
                var responseModel = new MizanUpBalanceNewRequestInitialModel
                {  
                    UserID = userId
                };

                string FileDocz = "";
                responseModel.curCompany = companyManager.Get_CompanyRow(request.Request.companyID);

                List<CompanyReport> nlist = companyReportManager.Get_CompanyReportList(request.Request.companyID);
                nlist = nlist.Where(x => x.MainYear == request.Request.nyear && x.FileTypeID == ReportConstant.FileTypeExcel && x.ReportTypeID == ReportConstant.ReportTypeMizan).ToList();

                var fileContentDir = System.IO.Path.Combine(hostEnvironment.ContentRootPath, "wwwroot", "FileContent");
                System.IO.Directory.CreateDirectory(fileContentDir);

                if (nlist.Count > 0)
                {
                    var existingName = nlist[0].ReportName;
                    var existingFullPath = System.IO.Path.Combine(fileContentDir, existingName);
                    if (System.IO.File.Exists(existingFullPath))
                    {
                        FileDocz = "FileContent/" + existingName;
                        return Task.FromResult(GenericResult<MizanUpBalanceNewOnGetCheckRepXlsResponse>.Success(new MizanUpBalanceNewOnGetCheckRepXlsResponse
                        {
                            InitialModel = request.InitialModel,
                            Response = FileDocz
                        }));
                    }
                }

                string NewRepName = "MizanRapor-" + responseModel.curCompany.TaxId.ToString() + request.Request.nyear.ToString() + ".xlsx";
                FileDocz = "FileContent/" + NewRepName;
                var filePath = System.IO.Path.GetFullPath(System.IO.Path.Combine(fileContentDir, NewRepName));

                BalanceReport report = companyReportManager.getMizanRaporuMizan(request.Request.nyear, responseModel.curCompany);
                report.CreateDocument();
                report.ExportToXlsx(filePath);

                if (!System.IO.File.Exists(filePath))
                {
                    return Task.FromResult(GenericResult<MizanUpBalanceNewOnGetCheckRepXlsResponse>.Fail(
                        "Excel oluşturuldu ancak diske yazılamadı veya dosya bulunamıyor: " + filePath));
                }

                companyReportManager.Set_Report(request.Request.companyID, responseModel.UserID, NewRepName, ReportConstant.FileTypeExcel, ReportConstant.ReportTypeMizan, 12, request.Request.nyear, 0);

                return Task.FromResult(GenericResult<MizanUpBalanceNewOnGetCheckRepXlsResponse>.Success(new MizanUpBalanceNewOnGetCheckRepXlsResponse
                {
                    InitialModel = request.InitialModel,
                    Response = FileDocz
                }));

            }
            catch (Exception ex)
            {
                return Task.FromResult(GenericResult<MizanUpBalanceNewOnGetCheckRepXlsResponse>.Fail(ex.Message));
            }
        }
    }
}
