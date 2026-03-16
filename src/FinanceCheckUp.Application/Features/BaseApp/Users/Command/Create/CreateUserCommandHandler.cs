using FinanceCheckUp.Application.Common.Utilities;
using FinanceCheckUp.Application.Models.Responses.Users;
using FinanceCheckUp.Domain.Entities;
using FinanceCheckUp.Framework.Core.Exceptions;
using FinanceCheckUp.Framework.Core.Models;
using FinanceCheckUp.Infrastructure.Repository;
using MediatR;

namespace FinanceCheckUp.Application.Features.BaseApp.Users.Command.Create;

internal class CreateUserCommandHandler(IUserRepository userRepository,
                                            IUserCompanyRepository   userCompanyRepository) : IRequestHandler<CreateUserCommand, GenericResult<CreateUserResponse>>
{
    public async  Task<GenericResult<CreateUserResponse>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var currentUser = int.Parse(request.UserId);
        if (currentUser > 0)
            throw new UserNotFoundException(nameof(User), request.UserId);

        var userAdmin = await userRepository.GetAsync(c => c.Id.Equals(request.Model.Id), cancellationToken);
        if (userAdmin == null)
            throw new UserNotFoundException(nameof(User), request.Model.Id.ToString());

        if (request.Model.Id <= 0)
        {
            if (userAdmin.UserTypeId == 1001)
                return GenericResult<CreateUserResponse>.Success(new CreateUserResponse() {  });

            var user = new User
            {

                FirstName = request.Model.FirstName,
                LastName = request.Model.LastName,
                Phone = request.Model.Phone,
                Email = request.Model.Email,
                CityId = request.Model.CityID,
                PasswordReset = request.Model.PasswordReset,
                Password = CryptoOperationExtension.Encrypt(request.Model.Password),
                ProfilePhoto = request.Model.ProfilePhoto,
                IsDeleted = false,
                UserTypeId = request.Model.UserTypeID,
                UserGuid = Guid.NewGuid().ToString()
            };

            var created = await userRepository.AddAsync(user, cancellationToken);
            if (!created)
                throw new CreateOperationException(nameof(User), nameof(user));

           var response = userCompanyRepository.UserCompanyDefinition(request.Model.Id, request.Model.CompanyList, cancellationToken);
            if(!response)
                throw new CreateOperationException(nameof(UserCompany), nameof(request.Model.CompanyList));
        }

        return GenericResult<CreateUserResponse>.Success(new CreateUserResponse() {   });
    }
}
