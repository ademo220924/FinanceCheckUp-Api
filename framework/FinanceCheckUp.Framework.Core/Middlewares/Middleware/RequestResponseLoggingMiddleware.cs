using FinanceCheckUp.Framework.Logging.Serilog;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Text;
using System.Web;

namespace FinanceCheckUp.Framework.Core.Middlewares.Middleware;

public class RequestResponseLoggingMiddleware(RequestDelegate next, ILogger<RequestResponseLoggingMiddleware> logger)
{
    public async Task Invoke(HttpContext context)
    {
        var requestBody = await GetBodyByFormatRequest(context.Request);

        logger.LogInformation("{@X-InformationCode} {@X-Information} {@X-Request-Scheme} {@X-Request-Host} {@X-Request-Path} {@X-Request-Headers} {@X-Request-QueryString} {@X-Request-Body}",
            nameof(LogConstant.InComingRequest),
            LogConstant.InComingRequest,
            context.Request.Scheme,
            context.Request.Host,
            context.Request.Path,
            HttpUtility.UrlDecode(JsonConvert.SerializeObject(context.Request.Headers)),
            context.Request.QueryString,
            HttpUtility.UrlDecode(requestBody));

        var originalBodyStream = context.Response.Body;
        using var responseBody = new MemoryStream();
        context.Response.Body = responseBody;
        await next(context);

        var response = await GetResponseByFormatResponse(context.Response);
        logger.LogInformation(response);
        await responseBody.CopyToAsync(originalBodyStream);
    }

    private static async Task<string> GetBodyByFormatRequest(HttpRequest request)
    {
        request.EnableBuffering();
        var buffer = new byte[Convert.ToInt32(request.ContentLength)];
        _ = await request.Body.ReadAsync(buffer.AsMemory(0, buffer.Length)).ConfigureAwait(false);
        var bodyAsText = Encoding.UTF8.GetString(buffer);
        request.Body.Seek(0, SeekOrigin.Begin);
        return bodyAsText;
    }

    private static async Task<string> GetResponseByFormatResponse(HttpResponse response)
    {
        response.Body.Seek(0, SeekOrigin.Begin);
        var text = await new StreamReader(response.Body).ReadToEndAsync();
        response.Body.Seek(0, SeekOrigin.Begin);
        return $"{response.StatusCode}: {text}";
    }
}