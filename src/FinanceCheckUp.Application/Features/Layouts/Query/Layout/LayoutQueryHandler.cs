using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Responses.Layouts;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;

namespace FinanceCheckUp.Application.Features.Layouts.Query.Layout;

public class LayoutQueryHandler(IHhvnUsersManager hhvnUsersManager,IUserManager userManager): IRequestHandler<LayoutQuery, GenericResult<LayoutResponse>>
{
    public Task<GenericResult<LayoutResponse>> Handle(LayoutQuery request, CancellationToken cancellationToken)
    {
        var layoutResponse = new LayoutResponse
        {
            IsConsole = false,
            UserId = Convert.ToInt64(request.UserId)
        };

        layoutResponse.HhvnUsers= hhvnUsersManager.GetRow_User(layoutResponse.UserId);
        layoutResponse.ChkKonsole = hhvnUsersManager.GetRow_UserKonsolide((int)layoutResponse.UserId);
        layoutResponse.User = userManager.GetRow_User(layoutResponse.UserId);

        layoutResponse.UserApp = "";
        layoutResponse.UserRole = "Admin"; //ToDo: httpcontextten al
        
        if (layoutResponse.ChkKonsole>0)
        {
            layoutResponse.IsConsole = true;
        }
          
        return Task.FromResult(GenericResult<LayoutResponse>.Success(layoutResponse));
    }
}