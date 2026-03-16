using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Responses.upreportqnb;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;


namespace FinanceCheckUp.Application.Features.BaseApp.upreportqnb.Query.upreportqnbOnGet;
public class upreportqnbOnGetQuery : IUserIdAssignable , IRequest<GenericResult<upreportqnbOnGetResponse>>
{
    [JsonIgnore] public  string UserId { get; set; }

}