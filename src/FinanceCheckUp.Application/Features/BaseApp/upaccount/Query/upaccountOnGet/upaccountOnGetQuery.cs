using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Responses.upaccount;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;


namespace FinanceCheckUp.Application.Features.BaseApp.upaccount.Query.upaccountOnGet;
public class upaccountOnGetQuery : IUserIdAssignable , IRequest<GenericResult<upaccountOnGetResponse>>
{
    [JsonIgnore] public  string UserId { get; set; }

}