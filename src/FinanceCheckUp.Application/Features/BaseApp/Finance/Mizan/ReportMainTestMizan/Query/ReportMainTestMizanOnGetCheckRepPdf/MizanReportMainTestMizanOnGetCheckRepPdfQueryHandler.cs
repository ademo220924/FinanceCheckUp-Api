using FinanceCheckUp.Application.Common.Constants;
using FinanceCheckUp.Application.ExtensionHelpers;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.ReportMainTestMizan;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.ReportMainTestMizan.Query.ReportMainTestMizanOnGetCheckRepPdf;

public class MizanReportMainTestMizanOnGetCheckRepPdfQueryHandler(
    INaceCodeManager naceCodeManager,
    ICompanyReportManager companyReportManager,
    ICompanyManager companyManager)
    : IRequestHandler<MizanReportMainTestMizanOnGetCheckRepPdfQuery,
        GenericResult<MizanReportMainTestMizanOnGetCheckRepPdfResponse>>
{
    public Task<GenericResult<MizanReportMainTestMizanOnGetCheckRepPdfResponse>> Handle(MizanReportMainTestMizanOnGetCheckRepPdfQuery request, CancellationToken cancellationToken)
    {
        try
        {

            var userId = Convert.ToInt64(request.UserId);
            request.InitialModel.UserID = userId;
            request.InitialModel.myearResult = YearResult.getValue();

            string FileDocz = "";
            var codde = naceCodeManager.GetRow_NaceCodes(Convert.ToInt32(request.Request.nacceco));
            request.InitialModel.curCompany = companyManager.Get_CompanyRow(request.Request.companyID);
            List<int> curCompanyYearList = companyManager.Get_CompanyReportYearMainMizan(request.Request.companyID);
            curCompanyYearList.Sort();
            int nyear = curCompanyYearList.Max();
            List<CompanyReport> nlist = companyReportManager.Get_CompanyReportList(request.Request.companyID);
            nlist = nlist.Where(x =>
                x.MainYear == nyear && x.FileTypeID == ReportConstant.FileTypePDF &&
                x.ReportTypeID == ReportConstant.ReportTypeMainNew).ToList();
            string compnacecode = "2790";
            if (!string.IsNullOrEmpty(request.InitialModel.curCompany.NaceCode) &&
                !string.IsNullOrWhiteSpace(request.InitialModel.curCompany.NaceCode))
            {
                compnacecode = request.InitialModel.curCompany.NaceCode.Length == 3
                    ? request.InitialModel.curCompany.NaceCode.Replace(".", "")[..3]
                    : request.InitialModel.curCompany.NaceCode.Replace(".", "")[..4];
            }

            if (nlist.Count > 0)
            {
                FileDocz = "FileContent/" + nlist[0].ReportName;

                return Task.FromResult(GenericResult<MizanReportMainTestMizanOnGetCheckRepPdfResponse>.Success(
                    new MizanReportMainTestMizanOnGetCheckRepPdfResponse
                    {
                        InitialModel = request.InitialModel,
                        Response = new JsonResult(FileDocz)
                    }));

            }

            string NewRepName = "FinansalRiskRapor-" + request.InitialModel.curCompany.TaxId.ToString() + ".pdf";
            FileDocz = "FileContent/" + NewRepName;
            var FileDic = "wwwroot\\FileContent\\" + NewRepName;


            string filePathZ = WebHelper.path;
            string FilePath = System.IO.Path.Combine(filePathZ, FileDic);



            // if (curCompanyYearList.Count >= 4)
            // {
            //     DynamicReportfour report = reportCheckZoneManager.getReportMizanFour(request.InitialModel.curCompany.Id, compnacecode, request.InitialModel.UserID, curCompanyYearList, codde.Id.ToString());
            //     report.CreateDocument();
            //     report.ExportToPdf(FilePath);
            //     companyReportManager.Set_Report(request.Request.companyID, request.InitialModel.UserID, NewRepName, ReportConstant.FileTypePDF, ReportConstant.ReportTypeMainNew, 12, nyear, 0);
            // }
            // else
            // {
            //     DynamicReport report = reportCheckZoneManager.getReportMizan(request.InitialModel.curCompany.Id, compnacecode, request.InitialModel.UserID, curCompanyYearList, codde.Id.ToString());
            //     report.CreateDocument();
            //     report.ExportToPdf(FilePath);
            //     companyReportManager.Set_Report(request.Request.companyID, request.InitialModel.UserID, NewRepName, ReportConstant.FileTypePDF, ReportConstant.ReportTypeMainNew, 12, nyear, 0);
            // }


            return Task.FromResult(GenericResult<MizanReportMainTestMizanOnGetCheckRepPdfResponse>.Success(
                new MizanReportMainTestMizanOnGetCheckRepPdfResponse
                {
                    InitialModel = request.InitialModel,
                    Response = new JsonResult(FileDocz)
                }));
        }
        catch (Exception ex)
        {  
            return Task.FromResult(GenericResult<MizanReportMainTestMizanOnGetCheckRepPdfResponse>.Fail(ex.Message));
        }
    }
}