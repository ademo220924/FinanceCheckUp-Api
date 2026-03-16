using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Requests.Finance.Mizan.Menu.UserList;
using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.Menu.UserList;
using FinanceCheckUp.Domain.Entities;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.Menu.UserList.Query.UserListOnGet;

public class MizanUserListOnGetQueryHandler(IHhvnUsersManager hhvnUsersManager) : IRequestHandler<MizanUserListOnGetQuery, GenericResult<MizanUserListOnGetResponse>>
{
    public Task<GenericResult<MizanUserListOnGetResponse>> Handle(MizanUserListOnGetQuery request, CancellationToken cancellationToken)
    {
        var userId = Convert.ToInt64(request.UserId);
        var responseModel = new MizanUserListRequestInitialModel
        {  
            UserID = userId,
            mreqList = new List<HhvnUsers>()
        };

        responseModel.CurrentUser = hhvnUsersManager.GetRow_User(responseModel.UserID);
        responseModel.mreqList = responseModel.CurrentUser.UserTypeID == 1001 
            ? hhvnUsersManager.Get_All() 
            : hhvnUsersManager.GetByAdminUser((int)responseModel.UserID);
        
        
        return Task.FromResult(GenericResult<MizanUserListOnGetResponse>.Success(new MizanUserListOnGetResponse
        {
            InitialModel = responseModel
        }));
    }
}
