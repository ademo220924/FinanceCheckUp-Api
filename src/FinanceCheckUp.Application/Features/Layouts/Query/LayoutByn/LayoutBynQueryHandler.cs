using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Responses.Layouts;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;

namespace FinanceCheckUp.Application.Features.Layouts.Query.LayoutByn;

public class LayoutBynQueryHandler(IHhvnUsersManager hhvnUsersManager)
    : IRequestHandler<LayoutBynQuery, GenericResult<LayoutBynResponse>>
{
    public Task<GenericResult<LayoutBynResponse>> Handle(LayoutBynQuery request, CancellationToken cancellationToken)
    {
        var layoutResponse = new LayoutBynResponse
        {
            UserId = Convert.ToInt64(request.UserId)
        };

        layoutResponse.HhvnUsers = hhvnUsersManager.GetRow_User(layoutResponse.UserId);
        layoutResponse.UserApp = "";
        layoutResponse.UserRole = "Admin"; //ToDo: httpcontextten al

        return Task.FromResult(GenericResult<LayoutBynResponse>.Success(layoutResponse));
    }
}