using FinanceCheckUp.Application.Common.Constants;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Application.Models.Requests.Finance.ReportMainTest;
using FinanceCheckUp.Application.Models.Responses.Finance.ReportMainTest;
using FinanceCheckUp.Domain.Entities;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Security.Claims;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.ReportMainTest.Query.FinanceReportMainTestOnGet;
public class FinanceReportMainTestOnGetQueryHandler(
    ICompanyReportManager companyReportManager,
    IHhvnUsersManager hhvnUsersManager, 
    ICompanyManager companiesManager, 
    IUserTypeManager userTypeManager, 
    ICompanyManager companyManager, 
    ITBLXmlManager tBLXmlManager) : IRequestHandler<FinanceReportMainTestOnGetQuery, GenericResult<FinanceReportMainTestOnGetResponse>>
{
    public Task<GenericResult<FinanceReportMainTestOnGetResponse>> Handle(FinanceReportMainTestOnGetQuery request, CancellationToken cancellationToken)
    {
        
        var userId = Convert.ToInt64(request.UserId);
        var responseModel = new FinanceReportMainTestRequestInitialModel
        {  
            UserID = userId,
            myearResult = YearResult.getValue()
        };


        responseModel.CurrentUser = hhvnUsersManager.GetRow_User(responseModel.UserID);
        responseModel.mreqListCompany = companyManager.Getby_User(responseModel.UserID);
        responseModel.curCompany = responseModel.mreqListCompany.Where(x => x.IsDefault == 1).FirstOrDefault();
        responseModel.CompName = responseModel.mreqListCompany.Where(x => x.IsDefault == 1).FirstOrDefault().CompanyName;
        responseModel.currentcompname = responseModel.curCompany.CompanyName;
        responseModel.curcomID = responseModel.curCompany.Id;
        responseModel.curcomCount = responseModel.mreqListCompany.Count();
        var curCompanyYearList = companyManager.Get_CompanyReportYearMain(responseModel.curcomID);
        var nlist = companyReportManager.Get_CompanyReportList(responseModel.curcomID);
        if (curCompanyYearList.Count == 0)
        {
            curCompanyYearList.Add(0);
        }
        responseModel.reportList = nlist.Where(x => x.MainYear == curCompanyYearList.Max() && x.FileTypeID == ReportConstant.FileTypePDF && x.ReportTypeID == ReportConstant.ReportTypeMainNew).ToList();

        responseModel.CompID = responseModel.curCompany.Id;
        responseModel.YearCount = tBLXmlManager.GetYearByComapnyID(responseModel.CompID);
        responseModel.CompCount = responseModel.mreqListCompany.Count();
        responseModel.YearCurrent = responseModel.CurrentUser.SelectedYear;
        
        return Task.FromResult(GenericResult<FinanceReportMainTestOnGetResponse>.Success(new FinanceReportMainTestOnGetResponse
        {
            InitialModel = responseModel
        }));

    }
}
