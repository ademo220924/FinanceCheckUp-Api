using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Responses;
using FinanceCheckUp.Domain.Entities;
using FinanceCheckUp.Framework.Core.Exceptions;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;

namespace FinanceCheckUp.Application.Features.BaseApp.Users.Command.Delete;

public class UserDeleteCommandHandle(IUserManager userManager) : IRequestHandler<UserDeleteCommand, GenericResult<UserDeleteResponse>>
{

    public async Task<GenericResult<UserDeleteResponse>> Handle(UserDeleteCommand request, CancellationToken cancellationToken)
    {
        var user = userManager.GetRow_User(request.Id);
        if (user == null)
            throw new UserNotFoundException(nameof(User), request.Id.ToString());

        user.IsDeleted = !user.IsDeleted;

        var deleted = userManager.Update_User(user);
        if (!deleted)
            throw new DeleteOperationException(nameof(User), request.Id);

        return GenericResult<UserDeleteResponse>.Success(new UserDeleteResponse { IsDeleted = user.IsDeleted });
    }
}