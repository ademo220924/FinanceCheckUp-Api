using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Application.Models.Common;
using FinanceCheckUp.Application.Models.Requests.DashBoard;
using FinanceCheckUp.Application.Models.Responses.DashBoard;
using FinanceCheckUp.Application.Models.ViewModel;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;


namespace FinanceCheckUp.Application.Features.BaseApp.DashBoard.Query.DashBoardOnGet;
public class DashBoardOnGetQueryHandler(ICompanyManager companyManager, IHhvnUsersManager hhvnUsersManager, ITBLXmlManager tBLXmlManager, IBultenManager bultenManager, IMainDashManager mainDashManager) : IRequestHandler<DashBoardOnGetQuery, GenericResult<DashBoardOnGetResponse>>
{

    public async Task<GenericResult<DashBoardOnGetResponse>> Handle(DashBoardOnGetQuery request, CancellationToken cancellationToken)
    {
        var UserID = Convert.ToInt64(request.UserId);
        var responseModel = new DashBoardRequest
        {
            UserID = UserID,
            mreqListCompany = companyManager.Getby_User(UserID),
            ttdashChk = new TaxErrorCheck(),
            ttdashTest = new TaxErrorcheckTest(),
            ttdashDataz = new TaxErrorcheckDataz()
        };


        responseModel.mreqListCompany = companyManager.Getby_User(UserID);
        responseModel.CompID = responseModel.mreqListCompany.Where(x => x.IsDefault == 1).FirstOrDefault()!.Id;
        responseModel.CompName = responseModel.mreqListCompany.Where(x => x.IsDefault == 1).FirstOrDefault()!.CompanyName;
        hhvnUsersManager.SetYearMain(responseModel.CompID, UserID);
        responseModel.CurrentUser = hhvnUsersManager.GetRow_User(UserID);
        responseModel.YearCount = tBLXmlManager.GetYearByComapnyID(responseModel.CompID);
        responseModel.CompCount = responseModel.mreqListCompany.Count();
        responseModel.myearResult = YearResult.getValue();
        responseModel.mrequestDataViewer = new DataViewerMain();
        responseModel.bultenList = bultenManager.Get_All(DateTime.Now.Year).OrderByDescending(x => x.YururlulukTarih);
        responseModel.mrequestEntryView = new YearlyErrorResultView();
        responseModel.mrequestEntryView.mrequestEntryCount = mainDashManager.Get_Data(responseModel.CurrentUser.SelectedYear, responseModel.CompID);
        responseModel.mrequestDataViewer.SetDataViewer(mainDashManager.DataViewerMain(responseModel.CurrentUser.SelectedYear, responseModel.CompID));
        return GenericResult<DashBoardOnGetResponse>.Success(new DashBoardOnGetResponse { InitialModel = responseModel });
    }
}