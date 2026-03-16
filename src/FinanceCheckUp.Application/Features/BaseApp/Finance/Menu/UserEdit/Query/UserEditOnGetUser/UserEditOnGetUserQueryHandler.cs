using FinanceCheckUp.Application.Models.Responses.Finance.Menu.UserEdit;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using FinanceCheckUp.Application.Managers.SqlQueryManager;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Menu.UserEdit.Query.UserEditOnGetUser;

public class UserEditOnGetUserQueryHandler(IHhvnUsersManager hhvnUsersManager, ICompanyManager companiesManager, IUserTypeManager userTypeManager, ICompanyManager companyManager, ITBLXmlManager tBLXmlManager) : IRequestHandler<UserEditOnGetUserQuery, GenericResult<UserEditOnGetUserResponse>>
{

    public Task<GenericResult<UserEditOnGetUserResponse>> Handle(UserEditOnGetUserQuery request, CancellationToken cancellationToken)
    {
        var typeresult = "true";
        return Task.FromResult(GenericResult<UserEditOnGetUserResponse>.Success(
            new UserEditOnGetUserResponse
            {
                Response = new JsonResult(typeresult)
            }));
 
    }
}
