using FinanceCheckUp.Application.Common.Constants;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Application.Models.Requests.Finance.Mizan.ReportMainTestMizan;
using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.ReportMainTestMizan;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.ReportMainTestMizan.Query.ReportMainTestMizanOnGet;
public class MizanReportMainTestMizanOnGetQueryHandler(ICompanyReportManager companyReportManager,IHhvnUsersManager hhvnUsersManager, ICompanyManager companyManager, ITBLXmlManager tBLXmlManager) 
    : IRequestHandler<MizanReportMainTestMizanOnGetQuery, GenericResult<MizanReportMainTestMizanOnGetResponse>>
{
    public Task<GenericResult<MizanReportMainTestMizanOnGetResponse>> Handle(MizanReportMainTestMizanOnGetQuery request, CancellationToken cancellationToken)
    {
        var userId = Convert.ToInt64(request.UserId);
        var responseModel = new MizanReportMainTestMizanRequestInitialModel
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
        List<int> curCompanyYearList = companyManager.Get_CompanyReportYearMainMizan(responseModel.curcomID);
        List<CompanyReport> nlist = companyReportManager.Get_CompanyReportList(responseModel.curcomID);
        if (curCompanyYearList.Count == 0)
        {
            curCompanyYearList.Add(0);
        }
        responseModel.reportList = nlist.Where(x => x.MainYear == curCompanyYearList.Max() && x.FileTypeID == ReportConstant.FileTypePDF && x.ReportTypeID == ReportConstant.ReportTypeMainNew).ToList();

        responseModel.CompID = responseModel.curCompany.Id;
        responseModel.YearCount = tBLXmlManager.GetYearByComapnyID(responseModel.CompID);
        responseModel.CompCount = responseModel.mreqListCompany.Count();
        responseModel.YearCurrent = responseModel.CurrentUser.SelectedYear;
        
        return Task.FromResult(GenericResult<MizanReportMainTestMizanOnGetResponse>.Success(new MizanReportMainTestMizanOnGetResponse
        {
            InitialModel = responseModel
        }));

    }
}
