using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinanceCheckUp.Framework.Core.Models;

public class GenericResult<T> where T : class, new()
{

    public GenericResult() : this(true)
    {
    }

    public GenericResult(bool isSuccess)
    {
        IsSuccess = isSuccess;
    }

    public bool IsSuccess { get; init; }
    public T? Data { get; private init; } = null;
    public ProblemDetails ProblemDetails { get; private init; } = new();



    public static GenericResult<T> Success(T data)
    {
        return new GenericResult<T>(true)
        {
            Data = data,
            ProblemDetails = new ProblemDetails()
        };
    }

    public static GenericResult<T> Fail(string? message)
    {
        return new GenericResult<T>(false)
        {
            ProblemDetails = new ProblemDetails
            {
                Status = StatusCodes.Status400BadRequest,
                Title = "Operation Error",
                Detail = message
            }
        };
    }

    public static GenericResult<T> Fail(ProblemDetails problemDetails)
    {
        return new GenericResult<T>(false)
        {
            ProblemDetails = problemDetails
        };
    }
}