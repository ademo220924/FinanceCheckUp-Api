using FinanceCheckUp.Application.Models.Requests.Finance.Menu.FirmPanel;
using FinanceCheckUp.Application.Models.Responses.Finance.Menu.FirmPanel;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using FinanceCheckUp.Application.Managers.SqlQueryManager;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Menu.FirmPanel.Query.FirmPanelOnGet;

public class FirmPanelOnGetQueryHandler(IHhvnUsersManager hhvnUsersManager, ICompanyManager companiesManager, IUserTypeManager userTypeManager, ICompanyManager companyManager, ITBLXmlManager tBLXmlManager) : IRequestHandler<FirmPanelOnGetQuery, GenericResult<FirmPanelOnGetResponse>>
{
     
    public Task<GenericResult<FirmPanelOnGetResponse>> Handle(FirmPanelOnGetQuery request, CancellationToken cancellationToken)
    {
        string redirectUrl;
        var userId = Convert.ToInt64(request.UserId);
        var responseModel = new FirmPanelInitialModel
        {
            UserID = userId,
            mreqList = new List<Domain.Entities.Company>()
        };

        responseModel.CurrentUser = hhvnUsersManager.GetRow_User(responseModel.UserID);
        responseModel.UserTypeID = responseModel.CurrentUser.UserTypeID;

        if (responseModel.CurrentUser.UserTypeID is 4 or 1 or 1001 or 1005)
        {
            responseModel.mreqList = companyManager.Getby_User(responseModel.UserID);
            redirectUrl="/admin/finance/yonetim/companylist";
        }
        else if (responseModel.CurrentUser.UserTypeID == 1003)
        {
            redirectUrl="/admin/finance/yonetim/companylist";
        }
        else
        {
            redirectUrl="/logout?handler=logout";
        }
        
        return Task.FromResult(GenericResult<FirmPanelOnGetResponse>.Success(
            new FirmPanelOnGetResponse
            {
                InitialModel = responseModel,
                RedirecrUrl = redirectUrl
            }));
    }
}

