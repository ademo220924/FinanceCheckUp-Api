using FinanceCheckUp.Application.Models.Requests.Finance.Mizan.Menu.CompanyList;
using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.Menu.CompanyList;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using FinanceCheckUp.Application.Managers.SqlQueryManager;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.Menu.CompanyList.Query.CompanyListOnGet;

public class MizanCompanyListOnGetQueryHandler(IHhvnUsersManager hhvnUsersManager, ICompanyManager companyManager) : IRequestHandler<MizanCompanyListOnGetQuery, GenericResult<MizanCompanyListOnGetResponse>>
{
    public Task<GenericResult<MizanCompanyListOnGetResponse>> Handle(MizanCompanyListOnGetQuery request, CancellationToken cancellationToken)
    {
        
        var userId = Convert.ToInt64(request.UserId);
        var responseModel = new MizanCompanyListRequestInitialModel
        {  
            UserID = userId,
            mreqList = new List<Domain.Entities.Company>()
        };

        responseModel.CurrentUser = hhvnUsersManager.GetRow_User(responseModel.UserID);
        responseModel.UserTypeID = responseModel.CurrentUser.UserTypeID;
        switch (responseModel.CurrentUser.UserTypeID)
        {
            case 1001:
                responseModel.mreqList = companyManager.Get_All();
                return Task.FromResult(GenericResult<MizanCompanyListOnGetResponse>.Success(new MizanCompanyListOnGetResponse
                {
                    InitialModel = responseModel
                }));
            case 4 or 1 or 1005:
                responseModel.mreqList = companyManager.Getby_User(responseModel.UserID);
                return Task.FromResult(GenericResult<MizanCompanyListOnGetResponse>.Success(new MizanCompanyListOnGetResponse
                {
                    InitialModel = responseModel
                }));
            default:
                return Task.FromResult(GenericResult<MizanCompanyListOnGetResponse>.Success(new MizanCompanyListOnGetResponse
                {
                    InitialModel = responseModel,
                    ResponseRedirectUrl="/logout?handler=logout"
                }));
        }
    }
}
