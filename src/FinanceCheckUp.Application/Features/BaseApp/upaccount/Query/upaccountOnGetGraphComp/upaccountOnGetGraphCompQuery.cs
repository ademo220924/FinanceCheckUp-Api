using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Requests.upaccount;
using FinanceCheckUp.Application.Models.Responses.upaccount;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;

namespace FinanceCheckUp.Application.Features.BaseApp.upaccount.Query.upaccountOnGetGraphComp;
public class upaccountOnGetGraphCompQuery : IUserIdAssignable , IRequest<GenericResult<upaccountOnGetGraphCompResponse>>
{
    [JsonIgnore] public  string UserId { get; set; }
    public upaccountOnGetGraphCompRequest Request { get; set; }

}