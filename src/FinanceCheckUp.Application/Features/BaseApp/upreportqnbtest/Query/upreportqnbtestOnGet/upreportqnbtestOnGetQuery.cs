using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Responses.upreportqnbtest;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;


namespace FinanceCheckUp.Application.Features.BaseApp.upreportqnbtest.Query.upreportqnbtestOnGet;
public class upreportqnbtestOnGetQuery : IUserIdAssignable , IRequest<GenericResult<upreportqnbtestOnGetResponse>>
{
    [JsonIgnore] public  string UserId { get; set; }

}