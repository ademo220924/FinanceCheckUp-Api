using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.Menu.UserEdit;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.Menu.UserEdit.Query.UserEditOnGetUser;

public class MizanUserEditOnGetUserQueryHandler : IRequestHandler<MizanUserEditOnGetUserQuery, GenericResult<MizanUserEditOnGetUserResponse>>
{

    public Task<GenericResult<MizanUserEditOnGetUserResponse>> Handle(MizanUserEditOnGetUserQuery request, CancellationToken cancellationToken)
    {
        return Task.FromResult(GenericResult<MizanUserEditOnGetUserResponse>.Success(new MizanUserEditOnGetUserResponse
        {
            Response = new JsonResult("true")
        }));
    }
}
