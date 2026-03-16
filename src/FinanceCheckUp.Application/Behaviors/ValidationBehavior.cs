using FinanceCheckUp.Framework.Core.Exceptions.Default;
using FluentValidation;
using MediatR;

namespace FinanceCheckUp.Application.Behaviors;

public class ValidationBehavior<TRequest, TResponse>(IEnumerable<IValidator<TRequest>> validators) : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    public Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        var context = new ValidationContext<TRequest>(request);
        var failures = validators
            .Select(x => x.Validate(context))
            .SelectMany(x => x.Errors)
            .Where(x => x != null)
            .ToList();

        if (failures.Count == 0)
            return next();

        var validationErrorList = failures.Select(failure => failure.ErrorMessage).ToList();

        throw new ArgumentValidationException(validationErrorList);
    }
}