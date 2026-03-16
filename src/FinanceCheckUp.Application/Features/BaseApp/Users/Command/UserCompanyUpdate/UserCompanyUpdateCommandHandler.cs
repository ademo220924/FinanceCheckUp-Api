using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Responses;
using FinanceCheckUp.Domain.Entities;
using FinanceCheckUp.Framework.Core.Exceptions;
using FinanceCheckUp.Framework.Core.Models;
using FinanceCheckUp.Framework.Data;
using FinanceCheckUp.Infrastructure.Repository;
using MediatR;
using System.Security.Claims;

namespace FinanceCheckUp.Application.Features.BaseApp.Users.Command.UserCompanyUpdate;

public class UserCompanyUpdateCommandHandle(IUserRepository userRepository,
                                             IUserCompanyRepository userCompanyRepository) : IRequestHandler<UserCompanyUpdateCommand, GenericResult<UserCompanyUpdateResponse>>
{
    public async Task<GenericResult<UserCompanyUpdateResponse>> Handle(UserCompanyUpdateCommand request, CancellationToken cancellationToken)
    {
        long ide = 0;
        var currentUser = int.Parse(request.UserId);
        if (currentUser > 0)
            throw new UserNotFoundException(nameof(User), request.UserId);

        var userAdmin = await userRepository.GetAsync(c => c.Id.Equals(request.Model.OperationUserId), cancellationToken);
        if (userAdmin == null)
            throw new UserNotFoundException(nameof(User), request.Model.Id.ToString());


        var response = userCompanyRepository.UserCompanyDefinition(long.Parse(request.Model.OperationUserId), request.Model.CompanyList, cancellationToken);
        if (!response)
            throw new CreateOperationException(nameof(UserCompany), nameof(request.Model.CompanyList));

        return GenericResult<UserCompanyUpdateResponse>.Success(new UserCompanyUpdateResponse() { Id = ide });
    }
}