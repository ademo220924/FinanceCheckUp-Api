using FinanceCheckUp.Framework.Core.Middlewares.Middleware;
using Microsoft.AspNetCore.Builder;

namespace FinanceCheckUp.Framework.Core.Middlewares;

public static class CustomMiddlewares
{
    public static IApplicationBuilder UseLogging(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<RequestResponseLoggingMiddleware>();
    }

    public static IApplicationBuilder UseHttpContextLogging(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<HttpContextLoggingMiddleware>();
    }

    public static IApplicationBuilder UseExceptionHandling(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<HttpContextLoggingMiddleware>();
    }
}

