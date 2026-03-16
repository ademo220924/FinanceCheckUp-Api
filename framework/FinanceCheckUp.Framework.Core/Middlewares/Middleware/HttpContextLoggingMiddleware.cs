using Microsoft.AspNetCore.Http;
using Serilog.Context;

namespace FinanceCheckUp.Framework.Core.Middlewares.Middleware;

public class HttpContextLoggingMiddleware(RequestDelegate next)
{
    public async Task Invoke(HttpContext context)
    {
        LogContext.PushProperty("CustomerId", (object)context.Request.Headers["user-id"]);
        LogContext.PushProperty("DeviceId", (object)context.Request.Headers["device-id"]);
        LogContext.PushProperty("X-Correlation-Id", (object)context.Request.Headers["X-Correlation-Id"]);
        LogContext.PushProperty("X-Device-Id", (object)context.Request.Headers["X-Device-Id"]);
        LogContext.PushProperty("X-App-Version", (object)context.Request.Headers["X-App-Version"]);
        LogContext.PushProperty("X-Os-Version", (object)context.Request.Headers["X-Os-Version"]);
        LogContext.PushProperty("X-Device-Type", (object)context.Request.Headers["X-Device-Type"]);
        LogContext.PushProperty("XPlatform", (object)context.Request.Headers["XPlatform"]);
        LogContext.PushProperty("client-ip", (object)context.Request.Headers["client-ip"]);
        await next(context);
    }
}