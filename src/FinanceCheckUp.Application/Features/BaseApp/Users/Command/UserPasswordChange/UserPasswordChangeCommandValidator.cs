using FluentValidation;

namespace FinanceCheckUp.Application.Features.BaseApp.Users.Command.UserPasswordChange;

public class UserPasswordChangeCommandValidator : AbstractValidator<UserPasswordChangeCommand>
{
    public UserPasswordChangeCommandValidator()
    {
        RuleFor(user => user.Id)
            .NotEmpty()
            .WithMessage("Id alanı boş olamaz.")
            .GreaterThan(0)
            .WithMessage("Id alanı 0'dan büyük olmalıdır!");
    }
}