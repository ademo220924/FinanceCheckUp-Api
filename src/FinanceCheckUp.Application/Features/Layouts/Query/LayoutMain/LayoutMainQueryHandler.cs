using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Responses.Layouts;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;

namespace FinanceCheckUp.Application.Features.Layouts.Query.LayoutMain;

public class LayoutMainQueryHandler(IHhvnUsersManager hhvnUsersManager): IRequestHandler<LayoutMainQuery, GenericResult<LayoutMainResponse>>
{
    public Task<GenericResult<LayoutMainResponse>> Handle(LayoutMainQuery request, CancellationToken cancellationToken)
    {
        var layoutResponse = new LayoutMainResponse
        { 
            UserId = Convert.ToInt64(request.UserId)
        };
        layoutResponse.HhvnUsers= hhvnUsersManager.GetRow_User(layoutResponse.UserId);
        layoutResponse.UserApp = "";
        layoutResponse.UserRole = "Admin"; //ToDo: httpcontextten al
        return Task.FromResult(GenericResult<LayoutMainResponse>.Success(layoutResponse));
    }
}