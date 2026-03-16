using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Responses.upchecky;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;


namespace FinanceCheckUp.Application.Features.BaseApp.upchecky.Query.upcheckyOnGet;
public class upcheckyOnGetQuery : IUserIdAssignable , IRequest<GenericResult<upcheckyOnGetResponse>>
{
    [JsonIgnore] public  string UserId { get; set; }

}