using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Requests.dashbilancojrnl;
using FinanceCheckUp.Application.Models.Responses.dashbilancojrnl;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;


namespace FinanceCheckUp.Application.Features.BaseApp.dashbilancojrnl.Query.dashbilancojrnlOnGet;
public class dashbilancojrnlOnGetQuery : IUserIdAssignable , IRequest<GenericResult<dashbilancojrnlOnGetResponse>>
{

    public dashbilancojrnlOnGetRequest Request { get; set; }
    [JsonIgnore] public  string UserId { get; set; }

}