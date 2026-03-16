using DevExtreme.AspNet.Mvc;
using FinanceCheckUp.Application.Models.Responses;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;

namespace FinanceCheckUp.Application.Features.BaseApp.Daily.Query.Priority;

public class DailyGetPriorityQuery : IRequest<GenericResult<DailyGetPriorityResponse>>
{
    public DataSourceLoadOptions DataSourceLoadOptions { get; set; }
}