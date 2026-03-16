using FinanceCheckUp.Framework.Core.Exceptions.Base;
using FinanceCheckUp.Framework.Core.Exceptions.Default;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Net;

namespace FinanceCheckUp.Framework.Core.Middlewares.Middleware;


//ToDo: ExceptionFilterAttribute attrubte de var 1 i kullanılacak
public class ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
{
    private readonly ILogger<ExceptionHandlingMiddleware> _logger = logger;
    private const string UnexpectedErrorMessage = "Beklenmeyen bir hata ile karşılaşıldı.";

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await next(context);
        }
        catch (Exception exception)
        {
            // logger 

            var messages = new List<string>();
            var statusCode = (int)HttpStatusCode.InternalServerError;
            var title = "Server error";

            if (exception is ArgumentValidationException validationExp)
            {
                statusCode = validationExp.StatusCode;
                title = "Validation Error";
                messages.AddRange(validationExp.MessageProps);
            }

            else if (exception is CustomBaseException customBaseException)
            {
                statusCode = customBaseException.StatusCode;
                title = customBaseException.Title;

                var responseExMessage = customBaseException.MessageFormat;
                foreach (var (key, value) in customBaseException.MessageProps)
                    responseExMessage = responseExMessage.Replace(key, value);

                messages.Add(responseExMessage);
            }
            else
            {
                messages.Add(UnexpectedErrorMessage);
            }

            var problemDetails = new ProblemDetails
            {
                Status = statusCode,
                Title = title,
                Detail = string.Join(Environment.NewLine, messages.ToArray())
            };

            context.Response.StatusCode = statusCode;
            //_logger.LogError("{@X-Exception-Status} {@X-Exception-Title} {@X-Exception-Detail}", problemDetails.Status,problemDetails.Title,problemDetails.Detail);
            //await context.Response.WriteAsJsonAsync(GenericResult<GenericResponse>.Fail(problemDetails));
            await context.Response.WriteAsync(text: JsonConvert.SerializeObject(problemDetails),CancellationToken.None);
        }
    }
}