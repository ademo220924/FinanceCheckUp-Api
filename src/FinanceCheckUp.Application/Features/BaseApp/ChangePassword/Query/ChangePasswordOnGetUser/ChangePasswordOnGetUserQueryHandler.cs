using FinanceCheckUp.Application.Models.Responses.ChangePassword;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace FinanceCheckUp.Application.Features.BaseApp.ChangePassword.Query.ChangePasswordOnGetUser;
public class ChangePasswordOnGetUserQueryHandler : IRequestHandler<ChangePasswordOnGetUserQuery, GenericResult<ChangePasswordOnGetUserResponse>>
{

    public async Task<GenericResult<ChangePasswordOnGetUserResponse>> Handle(ChangePasswordOnGetUserQuery request, CancellationToken cancellationToken)
    {
        string typeresult = "true";
        return GenericResult<ChangePasswordOnGetUserResponse>.Success(new ChangePasswordOnGetUserResponse { Result = new JsonResult(typeresult) });
    }
}