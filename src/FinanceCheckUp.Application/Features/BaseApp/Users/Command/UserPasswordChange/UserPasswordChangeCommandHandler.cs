using FinanceCheckUp.Application.Common.Utilities;
using FinanceCheckUp.Application.Models.Responses;
using FinanceCheckUp.Domain.Entities;
using FinanceCheckUp.Framework.Core.Exceptions;
using FinanceCheckUp.Framework.Core.Models;
using FinanceCheckUp.Framework.Data;
using FinanceCheckUp.Infrastructure.Repository;
using MediatR;

namespace FinanceCheckUp.Application.Features.BaseApp.Users.Command.UserPasswordChange;



public class UserPasswordChangeCommandHandle(IUserRepository userRepository) : IRequestHandler<UserPasswordChangeCommand, GenericResult<UserPasswordChangeResponse>>
{
    public async Task<GenericResult<UserPasswordChangeResponse>> Handle(UserPasswordChangeCommand command, CancellationToken cancellationToken)
    {
        if (command.Id <= 0)
            throw new UserInfoException("Id alanı 0 veya boş olamaz.");

        var user = await userRepository.GetAsync(c => c.Id == command.Id, cancellationToken);
        if (user == null)
            throw new UserNotFoundException(nameof(User), command.Id.ToString());

        if (string.IsNullOrEmpty(command.Password))  // validation olarak ekle gereksiz if olmasın
            throw new UserInfoException("Şifre boş olamaz.");
        if (user.Password == CryptoOperationExtension.Encrypt(command.Password))
            throw new UserInfoException("Farklı bir şifre Girin.");

        user.Password = CryptoOperationExtension.Encrypt(command.Password);
        var updatedResult = await userRepository.UpdateAsync(user, cancellationToken);
        if (updatedResult)
            throw new UpdateOperationException(nameof(User), command);
        return await Task.FromResult(GenericResult<UserPasswordChangeResponse>.Success(new UserPasswordChangeResponse { Id = command.Id }));

    }
}