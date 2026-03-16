using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Requests.upchecky;
using FinanceCheckUp.Application.Models.Responses.upchecky;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;


namespace FinanceCheckUp.Application.Features.BaseApp.upchecky.Query.upcheckyOnGetGraphComp;
public class upcheckyOnGetGraphCompQuery : IUserIdAssignable , IRequest<GenericResult<upcheckyOnGetGraphCompResponse>>
{
    [JsonIgnore] public  string UserId { get; set; }
    public upcheckyOnGetGraphCompRequest Request { get; set; }

}