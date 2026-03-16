using FinanceCheckUp.Application.Common.Constants;
using FinanceCheckUp.Application.ExtensionHelpers;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Responses.Finance.ReportMainTest;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.ReportMainTest.Query.FinanceReportMainTestOnGetCheckRepPdf;
public class FinanceReportMainTestOnGetCheckRepPdfQueryHandler(
    INaceCodeManager naceCodeManager,
    ICompanyReportManager companyReportManager,
    ICompanyManager companyManager) 
    : IRequestHandler<FinanceReportMainTestOnGetCheckRepPdfQuery, GenericResult<FinanceReportMainTestOnGetCheckRepPdfResponse>>
{
    public Task<GenericResult<FinanceReportMainTestOnGetCheckRepPdfResponse>> Handle(FinanceReportMainTestOnGetCheckRepPdfQuery request, CancellationToken cancellationToken)
    {
      try
      {
                
          var userId = Convert.ToInt64(request.UserId);
          request.InitialModel.UserID = userId;
                
                
          request.InitialModel.codde = naceCodeManager.GetRow_NaceCodes(Convert.ToInt32(request.Request.nacceco));
          var FileDocz = "";
 
          request.InitialModel.curCompany = companyManager.Get_CompanyRow(request.Request.companyID);
          request.InitialModel.curCompanyYearList = companyManager.Get_CompanyReportYearMain(request.Request.companyID);
          IEnumerable<int> curCompanyNonYearList = companyManager.Get_CompanyReportYear(request.Request.companyID);
          request.InitialModel.curCompanyYearList.Sort();
          var nyear = request.InitialModel.curCompanyYearList.Max();
          var nlist = companyReportManager.Get_CompanyReportList(request.Request.companyID);
          nlist = nlist.Where(x => x.MainYear == nyear && x.FileTypeID == ReportConstant.FileTypePDF && x.ReportTypeID == ReportConstant.ReportTypeMainNew).ToList();
          request.InitialModel.compnacecode = "2790";
          if (!string.IsNullOrEmpty(request.InitialModel.curCompany.NaceCode) && !string.IsNullOrWhiteSpace(request.InitialModel.curCompany.NaceCode))
          { 
              if (request.InitialModel.curCompany.NaceCode.Length  == 3)
              { request.InitialModel.compnacecode = request.InitialModel.curCompany.NaceCode.Replace(".", "").Substring(0, 3); }
              else { request.InitialModel.compnacecode = request.InitialModel.curCompany.NaceCode.Replace(".", "").Substring(0, 4); }
          }
          if (nlist.Count > 0)
          {
              FileDocz = "FileContent/" + nlist[0].ReportName;
              return Task.FromResult(GenericResult<FinanceReportMainTestOnGetCheckRepPdfResponse>.Success(new FinanceReportMainTestOnGetCheckRepPdfResponse
              {
                  InitialModel = request.InitialModel,
                  Response = new JsonResult(FileDocz)
              }));
          }
          var NewRepName = "FinansalRiskRapor-" + request.InitialModel.curCompany.TaxId.ToString()   + ".pdf";
          request.InitialModel.FileDocz = "FileContent/" + NewRepName;
          var fileDic = "wwwroot\\FileContent\\" + NewRepName;
          request.InitialModel.curCompanyNonYearList = request.InitialModel.curCompanyYearList.Except(curCompanyNonYearList);

          var filePathZ = WebHelper.path;
          request.InitialModel.FilePath = System.IO.Path.Combine(filePathZ, fileDic);

          return Task.FromResult(GenericResult<FinanceReportMainTestOnGetCheckRepPdfResponse>.Success(new FinanceReportMainTestOnGetCheckRepPdfResponse
          {
              InitialModel = request.InitialModel,
              Response = new JsonResult(FileDocz)
          }));

      }
      catch (Exception ex)
      {
          return Task.FromResult(GenericResult<FinanceReportMainTestOnGetCheckRepPdfResponse>.Fail(ex.Message));
      }
    }
}
