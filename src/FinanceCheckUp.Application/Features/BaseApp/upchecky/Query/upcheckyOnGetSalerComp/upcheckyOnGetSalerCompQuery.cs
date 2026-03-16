using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Requests.upchecky;
using FinanceCheckUp.Application.Models.Responses.upchecky;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;


namespace FinanceCheckUp.Application.Features.BaseApp.upchecky.Query.upcheckyOnGetSalerComp;
public class upcheckyOnGetSalerCompQuery : IUserIdAssignable , IRequest<GenericResult<upcheckyOnGetSalerCompResponse>>
{
    [JsonIgnore] public  string UserId { get; set; }
    public upcheckyOnGetSalerCompRequest Request { get; set; }

}