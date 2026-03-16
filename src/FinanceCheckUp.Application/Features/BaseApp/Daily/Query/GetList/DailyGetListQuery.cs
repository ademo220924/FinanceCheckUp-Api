using DevExtreme.AspNet.Mvc;
using FinanceCheckUp.Application.Models.Responses;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;

namespace FinanceCheckUp.Application.Features.BaseApp.Daily.Query.GetList;

public class DailyGetListQuery : IRequest<GenericResult<DailyGetListResponse>>
{
    public int Year { get; set; }
    public DataSourceLoadOptions DataSourceLoadOptions { get; set; }
}