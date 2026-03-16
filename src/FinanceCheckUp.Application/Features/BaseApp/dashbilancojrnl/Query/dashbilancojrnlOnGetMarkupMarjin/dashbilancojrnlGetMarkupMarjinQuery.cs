using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Requests.dashbilancojrnl;
using FinanceCheckUp.Application.Models.Responses.dashbilancojrnl;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;

namespace FinanceCheckUp.Application.Features.BaseApp.dashbilancojrnl.Query.dashbilancojrnlOnGetMarkupMarjin;
public class dashbilancojrnlOnGetMarkupMarjinQuery : IUserIdAssignable , IRequest<GenericResult<dashbilancojrnlOnGetMarkupMarjinResponse>>
{
    [JsonIgnore] public  string UserId { get; set; }
    public dashbilancojrnlOnGetMarkupMarjinRequest Request { get; set; }

}