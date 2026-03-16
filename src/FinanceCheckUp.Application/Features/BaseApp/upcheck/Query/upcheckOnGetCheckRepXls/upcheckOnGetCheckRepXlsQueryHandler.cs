using FinanceCheckUp.Application.Common.Constants;
using FinanceCheckUp.Application.ExtensionHelpers;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Application.Models.Common;
using FinanceCheckUp.Application.Models.Responses.upcheck;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace FinanceCheckUp.Application.Features.BaseApp.upcheck.Query.upcheckOnGetCheckRepXls;
public class upcheckOnGetCheckRepXlsQueryHandler(ICompanyManager companyManager, ICompanyReportManager companyReportManager, IErrorCheckMainManager errorCheckMainManager, IMainDashManager mainDashManager) : IRequestHandler<upcheckOnGetCheckRepXlsQuery, GenericResult<upcheckOnGetCheckRepXlsResponse>>
{

    public async Task<GenericResult<upcheckOnGetCheckRepXlsResponse>> Handle(upcheckOnGetCheckRepXlsQuery request, CancellationToken cancellationToken)
    {


        try
        {
            string FileDocz = "";
            var UserID = Convert.ToInt64(request.UserId);
            var curCompany = companyManager.Get_CompanyRow(request.Request.companyID);

            List<CompanyReport> nlist = companyReportManager.Get_CompanyReportList(request.Request.companyID);
            nlist = nlist.Where(x => x.MainMonth == request.Request.nmonth && x.MainYear == request.Request.nyear && x.FileTypeID == ReportConstant.FileTypeExcel && x.ReportTypeID == ReportConstant.ReportTypeTaxAudit).ToList();

            if (nlist.Count > 0)
            {
                FileDocz = "FileContent/" + nlist[0].ReportName;
                return GenericResult<upcheckOnGetCheckRepXlsResponse>.Success(new upcheckOnGetCheckRepXlsResponse { Result = new JsonResult(FileDocz) });
            }

            string NewRepName = "DenetimRapor-" + curCompany.TaxId.ToString() + request.Request.nyear.ToString() + "-" + request.Request.nmonth.ToString() + ".xlsx";
            FileDocz = "FileContent/" + NewRepName;
            var FileDic = "wwwroot\\FileContent\\" + NewRepName;


            string filePathZ = WebHelper.path;
            string FilePath = System.IO.Path.Combine(filePathZ, FileDic);
            List<DataViewer> ncheck = mainDashManager.DataViewerMainSource(request.Request.nyear, request.Request.companyID, request.Request.nmonth);
            List<DataViewer> ncheckMain = errorCheckMainManager.Get_ReportSetOther(request.Request.nyear, request.Request.companyID, request.Request.nmonth);

            ncheck.AddRange(ncheckMain);
            ncheck = ncheck.Distinct().OrderBy(c => c.EntryNumber).ThenBy(n => n.DescriptionTax).ToList();
            ncheck.AddRange(ncheckMain);

            if (ncheck.Count < 1)
            {
                return GenericResult<upcheckOnGetCheckRepXlsResponse>.Success(new upcheckOnGetCheckRepXlsResponse { Result = new JsonResult("nok") });
            }

            var report = companyReportManager.getDenetimRaporu(request.Request.nyear, request.Request.companyID, request.Request.nmonth, ncheck);
            report.CreateDocument();
            report.ExportToXlsx(FilePath);
            companyReportManager.Set_Report(request.Request.companyID, UserID, NewRepName, ReportConstant.FileTypeExcel, ReportConstant.ReportTypeTaxAudit, request.Request.nmonth, request.Request.nyear, 0);

            return GenericResult<upcheckOnGetCheckRepXlsResponse>.Success(new upcheckOnGetCheckRepXlsResponse { Result = new JsonResult(FileDocz) });

        }
        catch (Exception ex)
        {
            var chk = ex;
            return GenericResult<upcheckOnGetCheckRepXlsResponse>.Success(new upcheckOnGetCheckRepXlsResponse { Result = new JsonResult(ex.ToString()) });


        }
    }
}