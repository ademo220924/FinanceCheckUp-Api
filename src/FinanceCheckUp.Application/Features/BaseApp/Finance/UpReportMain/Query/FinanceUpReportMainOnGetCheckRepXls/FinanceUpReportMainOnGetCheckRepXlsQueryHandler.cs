using FinanceCheckUp.Application.Common.Constants;
using FinanceCheckUp.Application.ExtensionHelpers;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Application.Models.Requests.Finance.UpReportMain;
using FinanceCheckUp.Application.Models.Responses.Finance.UpReportMain;
using FinanceCheckUp.Domain.Entities;
using FinanceCheckUp.Framework.Core.Models;
using fincheckup.Report;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using FinanceCheckUp.Application.Managers.StaticManagers;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.UpReportMain.Query.FinanceUpReportMainOnGetCheckRepXls;
public class FinanceUpReportMainOnGetCheckRepXlsQueryHandler(
    ICompanyReportManager companyReportManager,
    IComReportManager comReportManager,
    ICompanyManager companyManager) : IRequestHandler<FinanceUpReportMainOnGetCheckRepXlsQuery, GenericResult<FinanceUpReportMainOnGetCheckRepXlsResponse>>
{
    public Task<GenericResult<FinanceUpReportMainOnGetCheckRepXlsResponse>> Handle(FinanceUpReportMainOnGetCheckRepXlsQuery request, CancellationToken cancellationToken)
    {
        try
        {
            string FileDocz = "";
            var userId = Convert.ToInt64(request.UserId);
            request.InitialModel.UserID = userId;
            request.InitialModel.curCompany = companyManager.Get_CompanyRow(request.Request.companyID);

            List<CompanyReport> nlist = companyReportManager.Get_CompanyReportList(request.Request.companyID);
            nlist = nlist.Where(x => x.MainYear == request.Request.nyear && x.FileTypeID == ReportConstant.FileTypeExcel && x.ReportTypeID == ReportConstant.ReportTypeMain).ToList();

            if (nlist.Count > 0)
            {
                FileDocz = "FileContent/" + nlist[0].ReportName;
                 return Task.FromResult(GenericResult<FinanceUpReportMainOnGetCheckRepXlsResponse>.Success(new FinanceUpReportMainOnGetCheckRepXlsResponse
                  {
                      Response =new JsonResult(FileDocz)
                  })); 
            }

            string NewRepName = "FinansalRapor-" + request.InitialModel.curCompany.TaxId.ToString() + request.Request.nyear.ToString() + ".xlsx";
            FileDocz = "FileContent/" + NewRepName;
            var FileDic = "wwwroot\\FileContent\\" + NewRepName;


            string filePathZ = WebHelper.path;
            string FilePath = System.IO.Path.Combine(filePathZ, FileDic);

            var report = comReportManager.Getreport(request.Request.nyear, request.InitialModel.curCompany);
            report.CreateDocument();
            report.ExportToXlsx(FilePath);
            companyReportManager.Set_Report(request.Request.companyID, request.InitialModel.UserID, NewRepName, ReportConstant.FileTypeExcel, ReportConstant.ReportTypeMain, 12, request.Request.nyear, 0);

            return Task.FromResult(GenericResult<FinanceUpReportMainOnGetCheckRepXlsResponse>.Success(new FinanceUpReportMainOnGetCheckRepXlsResponse
            {
                Response =new JsonResult(FileDocz)
            })); 

        }
        catch (Exception ex)
        {
            return Task.FromResult(GenericResult<FinanceUpReportMainOnGetCheckRepXlsResponse>.Fail(ex.Message));
        }
    }
}
