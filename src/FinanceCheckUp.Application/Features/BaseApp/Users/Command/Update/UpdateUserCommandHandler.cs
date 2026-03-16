using FinanceCheckUp.Application.Common.Utilities;
using FinanceCheckUp.Application.Models.Responses.Users;
using FinanceCheckUp.Domain.Entities;
using FinanceCheckUp.Framework.Core.Exceptions;
using FinanceCheckUp.Framework.Core.Models;
using FinanceCheckUp.Framework.Data;
using FinanceCheckUp.Infrastructure.Repository;
using MediatR;
using System.Security.Claims;

namespace FinanceCheckUp.Application.Features.BaseApp.Users.Command.Update;

public class UpdateUserCommandHandler(IUserRepository userRepository,
                                            IUserCompanyRepository userCompanyRepository) : IRequestHandler<UpdateUserCommand, GenericResult<UpdateUserResponse>>
{
    public async Task<GenericResult<UpdateUserResponse>> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        long ide = 0;
        var currentUser = int.Parse(request.UserId);
        if (currentUser > 0)
            throw new UserNotFoundException(nameof(User), request.UserId);

        var userAdmin = await userRepository.GetAsync(c => c.Id.Equals(request.Id), cancellationToken);
        if (userAdmin == null)
            throw new UserNotFoundException(nameof(User), request.Id.ToString());

        if (request.Id > 0)
        {
            var user = await userRepository.GetAsync(c => c.UserGuid.Equals(request.Id), cancellationToken);
            if (user != null && user.Id == request.Id || userAdmin.UserTypeId == 1001)
            {
                ide = request.Id;

                if (userAdmin.UserTypeId != 1001)
                    request.UserTypeID = (short)user!.UserTypeId;

                userAdmin.FirstName = request.FirstName;
                userAdmin.LastName = request.LastName;
                userAdmin.IsActive = request.IsActive;
                userAdmin.Phone = request.Phone;
                userAdmin.CityId = request.CityID;
                userAdmin.SessionGuid = request.SessionGuid;
                userAdmin.PasswordReset = request.PasswordReset;
                userAdmin.ProfilePhoto = request.ProfilePhoto;
                userAdmin.Email = request.Email;
                userAdmin.IsDeleted = request.IsDeleted;
                userAdmin.UserTypeId = request.UserTypeID;
                userAdmin.Id = request.Id;

                if (!string.IsNullOrEmpty(request.Password) && user!.Password != CryptoOperationExtension.Encrypt(request.Password))
                {
                    userAdmin.Password = CryptoOperationExtension.Encrypt(request.Password);
                }

                var updated = await userRepository.UpdateAsync(userAdmin, cancellationToken);
                if (!updated)
                    throw new UpdateOperationException(nameof(User), nameof(request));

                var response = userCompanyRepository.UserCompanyDefinition(request.Id, request.CompanyList, cancellationToken);
                if (!response)
                    throw new CreateOperationException(nameof(UserCompany), nameof(request.CompanyList));
            }
        }
        throw new UserInfoException("Id alanı boş olamaz");
    }
}
