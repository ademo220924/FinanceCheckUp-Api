using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Responses.Users;
using FinanceCheckUp.Domain.Entities;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;

namespace FinanceCheckUp.Application.Features.BaseApp.Users.Query.GetTypes;

public class UserTypesQueryHandler(IUserTypeManager userTypeManager): IRequestHandler<UserTypesQuery, GenericResult<UserTypesResponse>>
{
    public Task<GenericResult<UserTypesResponse>> Handle(UserTypesQuery request, CancellationToken cancellationToken)
    {
        return Task.FromResult(GenericResult<UserTypesResponse>.Success(new UserTypesResponse { UserTypes = userTypeManager.Get_Types()}));
    }
}