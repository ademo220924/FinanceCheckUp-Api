using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Responses.Users;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;

namespace FinanceCheckUp.Application.Features.BaseApp.Users.Query.GetType;

public class UserTypeQueryHandler(IUserTypeManager userTypeManager): IRequestHandler<UserTypeQuery, GenericResult<UserTypeResponse>>
{
    public Task<GenericResult<UserTypeResponse>> Handle(UserTypeQuery request, CancellationToken cancellationToken)
    {
        return Task.FromResult(GenericResult<UserTypeResponse>.Success(new UserTypeResponse { UserType = userTypeManager.Get_Types(request.Id)}));
    }
}