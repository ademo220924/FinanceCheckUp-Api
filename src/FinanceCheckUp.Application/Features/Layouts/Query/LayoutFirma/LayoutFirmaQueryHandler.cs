using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Responses.Layouts;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;

namespace FinanceCheckUp.Application.Features.Layouts.Query.LayoutFirma;

public class LayoutFirmaQueryHandler(IHhvnUsersManager hhvnUsersManager,IUserManager userManager): IRequestHandler<LayoutFirmaQuery, GenericResult<LayoutFirmaResponse>>
{
    public Task<GenericResult<LayoutFirmaResponse>> Handle(LayoutFirmaQuery request, CancellationToken cancellationToken)
    {
        var layoutResponse = new LayoutFirmaResponse
        { 
            UserId = Convert.ToInt64(request.UserId)
        };

        layoutResponse.HhvnUsers= hhvnUsersManager.GetRow_User(layoutResponse.UserId);
        layoutResponse.User = userManager.GetRow_User(layoutResponse.UserId);
        layoutResponse.UserApp = "";
        layoutResponse.UserRole = "Admin"; //ToDo: httpcontextten al
        
        return Task.FromResult(GenericResult<LayoutFirmaResponse>.Success(layoutResponse));
    }
}