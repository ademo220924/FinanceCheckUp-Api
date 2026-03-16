using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Requests.dashbilsample;
using FinanceCheckUp.Application.Models.Responses.dashbilsample;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;


namespace FinanceCheckUp.Application.Features.BaseApp.dashbilsample.Query.dashbilsampleOnGetPrio;
public class dashbilsampleOnGetPrioQuery : IUserIdAssignable , IRequest<GenericResult<dashbilsampleOnGetPrioResponse>>
{
    [JsonIgnore] public  string UserId { get; set; }
    public dashbilsampleOnGetPrioRequest Request { get; set; }

}