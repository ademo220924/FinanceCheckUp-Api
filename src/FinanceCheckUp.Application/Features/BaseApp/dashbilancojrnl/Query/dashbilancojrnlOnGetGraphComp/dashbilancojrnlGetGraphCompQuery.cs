using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Requests.dashbilancojrnl;
using FinanceCheckUp.Application.Models.Responses.dashbilancojrnl;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;


namespace FinanceCheckUp.Application.Features.BaseApp.dashbilancojrnl.Query.dashbilancojrnlOnGetGraphComp;
public class dashbilancojrnlOnGetGraphCompQuery : IUserIdAssignable , IRequest<GenericResult<dashbilancojrnlOnGetGraphCompResponse>>
{

    public dashbilancojrnlOnGetGraphCompRequest Request { get; set; }
    public dashbilancojrnlRequest InitialModel { get; set; }
    [JsonIgnore] public  string UserId { get; set; }

}