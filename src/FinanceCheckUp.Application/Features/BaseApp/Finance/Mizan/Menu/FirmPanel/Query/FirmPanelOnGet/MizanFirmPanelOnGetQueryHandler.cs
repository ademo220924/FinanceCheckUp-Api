using FinanceCheckUp.Application.Models.Requests.Finance.Mizan.Menu.FirmPanel;
using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.Menu.FirmPanel;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using FinanceCheckUp.Application.Managers.SqlQueryManager;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.Menu.FirmPanel.Query.FirmPanelOnGet;

public class MizanFirmPanelOnGetQueryHandler(IHhvnUsersManager hhvnUsersManager, ICompanyManager companyManager) : IRequestHandler<MizanFirmPanelOnGetQuery, GenericResult<MizanFirmPanelOnGetResponse>>
{
    
    public Task<GenericResult<MizanFirmPanelOnGetResponse>> Handle(MizanFirmPanelOnGetQuery request, CancellationToken cancellationToken)
    {
        
        var userId = Convert.ToInt64(request.UserId);
        var responseModel = new MizanFirmPanelRequestInitialModel
        {  
            UserID = userId,
            mreqList = new List<Domain.Entities.Company>()
        };
        
        string responseRedirectUrl;

        responseModel.CurrentUser = hhvnUsersManager.GetRow_User(responseModel.UserID); 
        responseModel.UserTypeID = responseModel.CurrentUser.UserTypeID;
        switch (responseModel.CurrentUser.UserTypeID)
        {
            case 4 or 1 or 1001 or 1005:
                responseModel.mreqList = companyManager.Getby_User(responseModel.UserID);
                responseRedirectUrl="/admin/finance/yonetim/companylist";
                break;
            case 1003:
                responseRedirectUrl="/admin/finance/yonetim/companylist";
                break;
            default:
                responseRedirectUrl="/logout?handler=logout";
                break;
        }
        
        return Task.FromResult(GenericResult<MizanFirmPanelOnGetResponse>.Success(new MizanFirmPanelOnGetResponse
        {
            InitialModel = responseModel,
            ResponseRedirectUrl=responseRedirectUrl
        }));
    }
}

