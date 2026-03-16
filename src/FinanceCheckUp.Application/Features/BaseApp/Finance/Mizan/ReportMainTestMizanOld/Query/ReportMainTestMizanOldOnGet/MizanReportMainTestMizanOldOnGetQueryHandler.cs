using FinanceCheckUp.Application.Common.Constants;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Application.Models.Requests.Finance.Mizan.ReportMainTestMizanOld;
using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.ReportMainTestMizanOld;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.ReportMainTestMizanOld.Query.ReportMainTestMizanOldOnGet;
public class MizanReportMainTestMizanOldOnGetQueryHandler(ICompanyReportManager companyReportManager,IHhvnUsersManager hhvnUsersManager, ICompanyManager companyManager, ITBLXmlManager tBLXmlManager) : IRequestHandler<MizanReportMainTestMizanOldOnGetQuery, GenericResult<MizanReportMainTestMizanOldOnGetResponse>>
{
    
    public Task<GenericResult<MizanReportMainTestMizanOldOnGetResponse>> Handle(MizanReportMainTestMizanOldOnGetQuery request, CancellationToken cancellationToken)
    {
        var userId = Convert.ToInt64(request.UserId);
        var responseModel = new MizanReportMainTestMizanOldRequestInitialModel
        {  
            UserID = userId
        };
 
        responseModel.myearResult = YearResult.getValue();
        responseModel.CurrentUser = hhvnUsersManager.GetRow_User(responseModel.UserID);
        responseModel.mreqListCompany = companyManager.Getby_User(responseModel.UserID);
        responseModel.curCompany = responseModel.mreqListCompany.Where(x => x.IsDefault == 1).FirstOrDefault();
        responseModel.CompName = responseModel.mreqListCompany.Where(x => x.IsDefault == 1).FirstOrDefault().CompanyName;
        responseModel.currentcompname = responseModel.curCompany.CompanyName;
        responseModel.curcomID = responseModel.curCompany.Id;
        responseModel.curcomCount = responseModel.mreqListCompany.Count();
        var curCompanyYearList = companyManager.Get_CompanyReportYearMainMizan(responseModel.curcomID);
        if (curCompanyYearList.Count == 0)
        {
            curCompanyYearList.Add(0);
        }
        var nlist = companyReportManager.Get_CompanyReportList(responseModel.curcomID);
        responseModel.reportList = nlist.Where(x => x.MainYear == curCompanyYearList.Max() 
                                                              && x.FileTypeID == ReportConstant.FileTypePDF 
                                                              && x.ReportTypeID == ReportConstant.ReportTypeMainOld).ToList();

        responseModel.CompID = responseModel.curCompany.Id;
        responseModel.YearCount = tBLXmlManager.GetYearByComapnyID(responseModel.CompID);
        responseModel.CompCount = responseModel.mreqListCompany.Count();
        responseModel.YearCurrent = responseModel.CurrentUser.SelectedYear;
        
        return Task.FromResult(GenericResult<MizanReportMainTestMizanOldOnGetResponse>.Success(new MizanReportMainTestMizanOldOnGetResponse
        {
            InitialModel = responseModel
        }));
    }
}
