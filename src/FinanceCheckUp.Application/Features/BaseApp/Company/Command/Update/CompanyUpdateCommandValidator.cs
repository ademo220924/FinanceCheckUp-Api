using FluentValidation;

namespace FinanceCheckUp.Application.Features.BaseApp.Company.Command.Update;

public class CompanyUpdateCommandValidator : AbstractValidator<CompanyUpdateCommand>
{
    public CompanyUpdateCommandValidator()
    {
        RuleFor(company => company.CompanyUpdateRequest.Id)
            .NotEmpty()
            .WithMessage("Id alanı boş olamaz.")
            .GreaterThan(0)
            .WithMessage("Id alanı 0'dan büyük olmalıdır!");
    }
}