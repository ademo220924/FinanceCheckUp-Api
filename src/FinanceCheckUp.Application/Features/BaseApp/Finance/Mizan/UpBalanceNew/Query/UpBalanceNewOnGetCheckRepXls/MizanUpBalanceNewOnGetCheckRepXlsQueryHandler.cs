using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Requests.Finance.Mizan.UpBalanceNew;
using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.UpBalanceNew;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using FinanceCheckUp.Application.Common.Constants;
using FinanceCheckUp.Application.ExtensionHelpers;
using fincheckup.Report;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.UpBalanceNew.Query.UpBalanceNewOnGetCheckRepXls
{
    public class MizanUpBalanceNewOnGetCheckRepXlsQueryHandler(
        ICompanyReportManager companyReportManager,
        ICompanyManager companyManager) : IRequestHandler<MizanUpBalanceNewOnGetCheckRepXlsQuery, GenericResult<MizanUpBalanceNewOnGetCheckRepXlsResponse>>
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

                if (nlist.Count > 0)
                {
                    FileDocz = "FileContent/" + nlist[0].ReportName;
                     
                    return Task.FromResult(GenericResult<MizanUpBalanceNewOnGetCheckRepXlsResponse>.Success(new MizanUpBalanceNewOnGetCheckRepXlsResponse
                    {
                        InitialModel = request.InitialModel,
                        Response=  new JsonResult(FileDocz)
                    }));
                }

                string NewRepName = "MizanRapor-" + responseModel.curCompany.TaxId.ToString() + request.Request.nyear.ToString() + ".xlsx";
                FileDocz = "FileContent/" + NewRepName;
                var FileDic = "wwwroot\\FileContent\\" + NewRepName;


                string filePathZ = WebHelper.path;
                string FilePath = System.IO.Path.Combine(filePathZ, FileDic);

                BalanceReport report = companyReportManager.getMizanRaporuMizan(request.Request.nyear, responseModel.curCompany);
                report.CreateDocument();
                report.ExportToXlsx(FilePath);
                companyReportManager.Set_Report(request.Request.companyID, responseModel.UserID, NewRepName, ReportConstant.FileTypeExcel, ReportConstant.ReportTypeMizan, 12, request.Request.nyear, 0);

                return Task.FromResult(GenericResult<MizanUpBalanceNewOnGetCheckRepXlsResponse>.Success(new MizanUpBalanceNewOnGetCheckRepXlsResponse
                {
                    InitialModel = request.InitialModel,
                    Response=  new JsonResult(FileDocz)
                }));

            }
            catch (Exception ex)
            {
                return Task.FromResult(GenericResult<MizanUpBalanceNewOnGetCheckRepXlsResponse>.Fail(ex.Message));
            }
        }
    }
}
