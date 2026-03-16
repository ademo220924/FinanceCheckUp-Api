using FinanceCheckUp.Application.Common.Constants;
using FinanceCheckUp.Application.ExtensionHelpers;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Application.Models.Responses.upbalance;
using FinanceCheckUp.Framework.Core.Models;
using fincheckup.Report;
using MediatR;


namespace FinanceCheckUp.Application.Features.BaseApp.upbalance.Query.upbalanceOnGetCheckRepXls;
public class upbalanceOnGetCheckRepXlsQueryHandler(ICompanyManager companyManager, ICompanyReportManager companyReportManager) : IRequestHandler<upbalanceOnGetCheckRepXlsQuery, GenericResult<upbalanceOnGetCheckRepXlsResponse>>
{

    public async Task<GenericResult<upbalanceOnGetCheckRepXlsResponse>> Handle(upbalanceOnGetCheckRepXlsQuery request, CancellationToken cancellationToken)
    {
        try
        {
            string FileDocz = "";
            var UserID = Convert.ToInt64(request.UserId);
            var curCompany = companyManager.Get_CompanyRow(request.Request.companyID);

            List<CompanyReport> nlist = companyReportManager.Get_CompanyReportList(request.Request.companyID);
            nlist = nlist.Where(x => x.MainYear == request.Request.nyear && x.FileTypeID == ReportConstant.FileTypeExcel && x.ReportTypeID == ReportConstant.ReportTypeMizan).ToList();

            if (nlist.Count > 0)
            {
                FileDocz = "Document/" + nlist[0].ReportName;
                return GenericResult<upbalanceOnGetCheckRepXlsResponse>.Fail(FileDocz);
            }

            string NewRepName = "MizanRapor-" + curCompany.TaxId.ToString() + request.Request.nyear.ToString() + ".xlsx";
            FileDocz = "Document/" + NewRepName;
            var FileDic = "UploadFiles\\Document\\" + NewRepName;


            string filePathZ = WebHelper.path;
            string FilePath = System.IO.Path.Combine(filePathZ, FileDic);

            BalanceReport report = companyReportManager.getMizanRaporu(request.Request.nyear, curCompany);
            report.CreateDocument();
            report.ExportToXlsx(FilePath);
            companyReportManager.Set_Report(request.Request.companyID, UserID, NewRepName, ReportConstant.FileTypeExcel, ReportConstant.ReportTypeMizan, 12, request.Request.nyear, 0);

            return GenericResult<upbalanceOnGetCheckRepXlsResponse>.Fail(FileDocz);

        }
        catch (Exception ex)
        {
            var chk = ex;
            return GenericResult<upbalanceOnGetCheckRepXlsResponse>.Fail(ex.ToString());
        }


    }
}