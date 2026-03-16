using FinanceCheckUp.Domain.Common;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace FinanceCheckUp.Application.Behaviors;

public class UserIdBehavior<TRequest, TResponse>(IHttpContextAccessor httpContextAccessor)
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        
        if (request is not IUserIdAssignable userAssignable)
        {
            return await next();
        }
        
        var userIdFromHeader = httpContextAccessor.HttpContext.Request.Headers["user-id"].ToString();
        if (!string.IsNullOrEmpty(userIdFromHeader) && string.IsNullOrEmpty(userAssignable.UserId))
        {
            userAssignable.UserId = userIdFromHeader;
        }
        
        if (string.IsNullOrEmpty(userIdFromHeader) && !string.IsNullOrEmpty(userAssignable.UserId))
        {
            return await next();
        }
        
        return await next();
    }
}