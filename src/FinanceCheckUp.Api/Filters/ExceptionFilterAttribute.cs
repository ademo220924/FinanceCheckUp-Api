using FinanceCheckUp.Framework.Core.Exceptions.Base;
using FinanceCheckUp.Framework.Core.Exceptions.Default;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

//ToDo: ExceptionHandlingMiddleware  de var bunu kaldır
namespace FinanceCheckUp.Api.Filters;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
public class ExceptionFilterAttribute : Attribute, IExceptionFilter
{
    private const string UnexpectedErrorMessage = "Beklenmeyen bir hata ile karşılaşıldı.";
    private const string Version = "1.0.0";

    public ExceptionFilterAttribute()
    { }

    public virtual void OnException(ExceptionContext context)
    {
        if (context.Exception is ArgumentValidationException validationExp)
        {
            context.HttpContext.Response.StatusCode = validationExp.StatusCode;
            context.Result = new ObjectResult(new { Messages = validationExp.MessageProps, Version });
            return;
        }

        if (context.Exception is CustomBaseException baseExp)
        {
            context.HttpContext.Response.StatusCode = baseExp.StatusCode;
            context.Result = new ObjectResult(new { Messages = baseExp.MessageProps.Select(c=>c.Value).ToList() , Code = baseExp.StatusCode, Version });
            return;
        }

        context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
        context.Result = new ObjectResult(new { Messages = new List<string> { UnexpectedErrorMessage }, Version });
        return;
    }

}
