using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Responses.CashFlow;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;


namespace FinanceCheckUp.Application.Features.BaseApp.CashFlow.Query.OnGet;
public class OnGetQuery : IUserIdAssignable , IRequest<GenericResult<OnGetResponseModel>>
{
    [JsonIgnore] public  string UserId { get; set; }
}