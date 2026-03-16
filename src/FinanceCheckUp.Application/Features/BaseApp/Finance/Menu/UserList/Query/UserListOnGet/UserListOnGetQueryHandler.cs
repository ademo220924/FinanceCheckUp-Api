using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Responses.Finance.Menu.UserList;
using FinanceCheckUp.Domain.Entities;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using FinanceCheckUp.Application.Models.Requests.Finance.Menu.UserList;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Menu.UserList.Query.UserListOnGet;

 

public class UserListOnGetQueryHandler(IHhvnUsersManager hhvnUsersManager) : IRequestHandler<UserListOnGetQuery, GenericResult<UserListOnGetResponse>>
{
    public Task<GenericResult<UserListOnGetResponse>> Handle(UserListOnGetQuery request, CancellationToken cancellationToken)
    {
        var userId = Convert.ToInt64(request.UserId);
        var responseModel = new UserListRequestInitialModel
        {
            UserID = userId,
            mreqList = new List<HhvnUsers>()
        };

        responseModel.CurrentUser = hhvnUsersManager.GetRow_User(responseModel.UserID);

        responseModel.mreqList = responseModel.CurrentUser.UserTypeID == 1001 
            ? hhvnUsersManager.Get_All()
            : hhvnUsersManager.GetByAdminUser((int)responseModel.UserID);
        
        return Task.FromResult(GenericResult<UserListOnGetResponse>.Success(new UserListOnGetResponse { InitialModel = responseModel }));
    }
}
