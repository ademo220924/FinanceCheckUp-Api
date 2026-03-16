using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Application.Models.Requests.Finance.Aktarma.dashbilancomain;
using FinanceCheckUp.Application.Models.Responses.Finance.Aktarma.dashbilancomain;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Aktarma.dashbilancomain.Query.dashbilancomainOnGet;
public class AktarmaDashbilancomainOnGetQueryHandler(IHhvnUsersManager hhvnUsersManager, ICompanyManager companiesManager,ITBLXmlManager tBLXmlManager) 
    : IRequestHandler<AktarmaDashbilancomainOnGetQuery, GenericResult<AktarmaDashbilancomainOnGetResponse>>
{
    public Task<GenericResult<AktarmaDashbilancomainOnGetResponse>> Handle(AktarmaDashbilancomainOnGetQuery request, CancellationToken cancellationToken)
    {
        var userId = Convert.ToInt64(request.UserId);
        var responseModel = new AktarmaDashbilancomainInitialModel
        {
            UserID = userId,
            mreqListCompany = companiesManager.Getby_User(userId)
        };


        responseModel.CompID = responseModel.mreqListCompany.Where(x => x.IsDefault == 1).FirstOrDefault().Id;
        responseModel.CompName = responseModel.mreqListCompany.Where(x => x.IsDefault == 1).FirstOrDefault().CompanyName;
        hhvnUsersManager.SetYearMain(responseModel.CompID, responseModel.UserID);
        responseModel.CurrentUser = hhvnUsersManager.GetRow_User(responseModel.UserID);
        responseModel.YearCount = tBLXmlManager.GetYearByComapnyID(responseModel.CompID);
        responseModel.CompCount = responseModel.mreqListCompany.Count();

        responseModel.myearResult = YearResult.getValue();

        responseModel.nRequestListChk = responseModel.nRequestList;
        return Task.FromResult(GenericResult<AktarmaDashbilancomainOnGetResponse>.Success(
            new AktarmaDashbilancomainOnGetResponse
            {
                InitialModel = responseModel
            }));
    }
}
