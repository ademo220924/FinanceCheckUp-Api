using FluentValidation;

namespace FinanceCheckUp.Application.Features.BaseApp.Users.Command.Delete;

public class UserDeleteCommandValidator : AbstractValidator<UserDeleteCommand>
{
    public UserDeleteCommandValidator()
    {
        RuleFor(user => user.Id)
            .NotEmpty()
            .WithMessage("Id alanı boş olamaz.")
            .GreaterThan(0)
            .WithMessage("Id alanı 0'dan büyük olmalıdır!");
    }
}